using System.Text.Json.Serialization;

namespace LojaVirtual.ProductAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preço { get; set;}
        public string? ImagemURL { get; set; }
        [JsonIgnore] //Usa apenas para navegação. Ignora-se na serialização
        public Categoria? Categoria { get; set; } //Relaciona o produto à categoria por propriedade de navegação
        public int CategoriaId { get; set; }
    }
}
