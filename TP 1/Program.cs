using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using Microsoft.AspNetCore.Identity;
using TP_1.Areas.Identity.Data;
using TP_1.Areas.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicione o IProdutoService ? cole??o de servi?os

// Adicione o IHttpContextAccessor ? cole??o de servi?os
builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache(); // Adiciona o cache distribu?do em mem?ria para sess?o
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo limite de inatividade da sess?o
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddHttpClient<ViaCepService>();


builder.Services.AddMvc()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

// Adicione Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TP_1Context>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("TP_1Context") ?? throw new InvalidOperationException("Connection string 'TP_1Context' not found.")));

// Adicione o contexto de banco de dados `DBContextUser` com o tempo de vida `Scoped` antes de configurar o Identity
builder.Services.AddDbContext<DBContextUser>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DBContextUser") ?? throw new InvalidOperationException("Connection string 'DBContextUser' not found.")));

builder.Services.AddDefaultIdentity<UserData>(options => options.SignIn.RequireConfirmedAccount = true)
  .AddEntityFrameworkStores<DBContextUser>();

var app = builder.Build();

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();
app.UseAuthentication(); ;
app.UseAuthorization();
app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();

    endpoints.MapControllerRoute(
      name: "slugRoute",
      pattern: "Produto/{slug}",
      defaults: new { controller = "Produto", action = "Details" });
});

app.Run();