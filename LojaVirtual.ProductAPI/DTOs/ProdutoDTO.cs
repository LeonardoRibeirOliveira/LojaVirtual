using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.ProductAPI.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Precisa ser fornecido um nome para o produto.")]
        [MaxLength(255)]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Precisa ser fornecido um preço para produto.")]
        public decimal Preço { get; set;}
        [Required(ErrorMessage = "Precisa ser fornecido um link para imagem.")]
        [MaxLength(255)]
        public string? ImagemURL { get; set; }
        public string? NomeCategoria { get; set; }
        public CategoriaDTO? Categoria { get; set; } //Relaciona o produto à categoria por propriedade de navegação
        public int CategoriaId { get; set; }
    }
}
