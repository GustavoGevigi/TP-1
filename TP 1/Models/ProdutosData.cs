using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace TP_1.Models
{
    public class ProdutosData
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
        public MarcasData Marca { get; set; }
    }
}
