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
        public MarcasData Marca { get; set; }
    }
}
