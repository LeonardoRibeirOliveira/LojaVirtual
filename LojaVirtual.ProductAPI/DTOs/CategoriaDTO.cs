using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.ProductAPI.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Precisa ser fornecido um nome para classes.")]
        [MaxLength(255)]
        public string? Nome { get; set; }
        public ICollection<ProdutoDTO>? Produtos { get; set; } //Expressa a relação de 1 categoria para n Produtos
    }
}
