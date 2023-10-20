using LojaVirtual.ProductAPI.Models;

namespace LojaVirtual.ProductAPI.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetProdutobyId(int id);
        Task<Produto> GetProdutobyUpperPrice(decimal preco);
        Task<Produto> GetProdutobyPrice(decimal preco);
        Task<Produto> GetProdutobyLessPrice(decimal preco);
        Task<Produto> Create(Produto produto);
        Task<Produto> Update(Produto produto);
        Task<Produto> Delete(int id);
    }
}
