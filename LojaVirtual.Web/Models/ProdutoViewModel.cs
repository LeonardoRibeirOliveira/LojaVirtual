using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Web.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preço { get; set; }
        public string? ImagemURL { get; set; }

        public string? NomeCategoria { get; set; } //Relaciona o produto à categoria por propriedade de navegação
        public int CategoriaId { get; set; }
    }
}
