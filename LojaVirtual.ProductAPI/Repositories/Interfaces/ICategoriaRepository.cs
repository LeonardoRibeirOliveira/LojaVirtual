using LojaVirtual.ProductAPI.Models;

namespace LojaVirtual.ProductAPI.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAll();

        Task<IEnumerable<Categoria>> GetCategoriasProdutos();
        Task<Categoria> GetCategoriasbyId(int id);
        Task<Categoria> Create(Categoria categoria);
        Task<Categoria> Update(Categoria categoria);
        Task<Categoria> Delete(int id);
    }
}
