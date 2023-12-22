using System.ComponentModel.DataAnnotations;

namespace TP_1.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public double PrecoUnitario { get; set; }


        // Propriedade de navegação para o produto associado ao pedido
        public ProdutosData Produto { get; set; }
    }
}
