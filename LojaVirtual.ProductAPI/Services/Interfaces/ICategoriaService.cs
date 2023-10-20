using LojaVirtual.ProductAPI.DTOs;

namespace LojaVirtual.ProductAPI.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetAll();

        Task<IEnumerable<CategoriaDTO>> GetCategoriasProdutos();
        Task<CategoriaDTO> GetCategoriasbyId(int id);
        Task AddCategoria(CategoriaDTO categoriaDto);
        Task Updatecategoria(CategoriaDTO categoriaDto);
        Task RemoveCategoria(int id);
    }
}
