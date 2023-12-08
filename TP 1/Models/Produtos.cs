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

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Preço deve ser maior que zero.")]
        public double Preco { get; set; }

        [Display(Name = "Disponível")]
        public bool Disponivel { get; set; }

        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Insira uma URL de imagem válida.")]
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

            // Substitui espaços por traços
            string slug = stringBuilder.ToString().ToLower().Replace(" ", "-");

            // Remove caracteres não alfanuméricos ou traços consecutivos
            slug = Regex.Replace(slug, @"[^a-z0-9\-]+", "");

            return slug;
        }
    }
}
