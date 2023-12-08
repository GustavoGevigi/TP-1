using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace TP_1.Models
{
    public class Produtos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome � obrigat�rio.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no m�ximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descri��o � obrigat�rio.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Pre�o � obrigat�rio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Pre�o deve ser maior que zero.")]
        public double Preco { get; set; }

        [Display(Name = "Dispon�vel")]
        public bool Disponivel { get; set; }

        [Display(Name = "Data de Lan�amento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Insira uma URL de imagem v�lida.")]
        public string ImagemPath { get; set; }

        public int MarcaId { get; set; }

        public Branding? Marcas { get; set; }

        public string SlugNome { get; set; }
        public string Slug => GerarSlug(SlugNome);

        private string GerarSlug(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            // Remove caracteres especiais
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Substitui espa�os por tra�os
            string slug = stringBuilder.ToString().ToLower().Replace(" ", "-");

            // Remove caracteres n�o alfanum�ricos ou tra�os consecutivos
            slug = Regex.Replace(slug, @"[^a-z0-9\-]+", "");

            return slug;
        }
    }
}
