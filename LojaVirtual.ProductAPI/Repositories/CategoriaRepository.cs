using LojaVirtual.ProductAPI.Models;
using LojaVirtual.ProductAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.ProductAPI.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Context.Context _context;

        public CategoriaRepository(Context.Context context)
        {
            _context = context;
        }
         
        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Delete(int id)
        {
            var categoriaDelete = await GetCategoriasbyId(id);
            _context.Categorias.Remove(categoriaDelete);
            await _context.SaveChangesAsync();
            return categoriaDelete;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetCategoriasbyId(int id)
        {
            return await _context.Categorias.Where(c => c.CategoriaId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return await _context.Categorias.Include(c => c.Produtos).ToListAsync();

        }

        public async Task<Categoria> Update(Categoria categoria)
        {
            _context.Categorias.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}
