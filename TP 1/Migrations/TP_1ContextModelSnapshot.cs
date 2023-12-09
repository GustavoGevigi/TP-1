﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_1.Data;

#nullable disable

namespace TP_1.Migrations
{
    [DbContext(typeof(TP_1Context))]
    partial class TP_1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TP_1.Models.MarcasData", b =>
                {
                    b.Property<int>("MarcasDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarcasDataId"), 1L, 1);

                    b.Property<string>("MarcasDataNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarcasDataId");

                    b.ToTable("MarcasData");

                    b.HasData(
                        new
                        {
                            MarcasDataId = 1,
                            MarcasDataNome = "Nike"
                        },
                        new
                        {
                            MarcasDataId = 2,
                            MarcasDataNome = "Adidas"
                        },
                        new
                        {
                            MarcasDataId = 3,
                            MarcasDataNome = "Puma"
                        });
                });

            modelBuilder.Entity("TP_1.Models.ProdutosData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("ImagemPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ProdutosData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataLancamento = new DateTime(1985, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Um clássico do basquete",
                            Disponivel = false,
                            ImagemPath = "airjordan1.jpg",
                            Nome = "Air Jordan 1",
                            Preco = 1999.99
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
