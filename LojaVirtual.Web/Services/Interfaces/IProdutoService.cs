using LojaVirtual.Web.Models;

namespace LojaVirtual.Web.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> GetAllProdutos();
        Task<ProdutoViewModel> GetProdutosById(int id);
        Task<ProdutoViewModel> CreateProduct(ProdutoViewModel produto);
        Task<ProdutoViewModel> UpdateProduct(ProdutoViewModel produto);
        Task<bool> DeleteProductById(int id);

    }
}
