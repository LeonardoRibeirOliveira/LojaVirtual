using LojaVirtual.ProductAPI.DTOs;

namespace LojaVirtual.ProductAPI.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetAll();
        Task<ProdutoDTO> GetProdutobyId(int id);
        //Task<ProdutoDTO> GetProdutobyUpperPrice(decimal preco);
        //Task<ProdutoDTO> GetProdutobyPrice(decimal preco);
        //Task<ProdutoDTO> GetProdutobyLessPrice(decimal preco);
        Task AddProduto(ProdutoDTO produtoDto);
        Task UpdateProduto(ProdutoDTO produtoDto);
        Task RemoveProduto(int id);
    }
}
