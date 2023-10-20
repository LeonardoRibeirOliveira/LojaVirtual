using LojaVirtual.ProductAPI.Models;
using LojaVirtual.ProductAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.ProductAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Context.Context _context;

        public ProdutoRepository(Context.Context context)
        {
            _context = context;
        }

        public async Task<Produto> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Delete(int id)
        {
            var produtoDelete = await GetProdutobyId(id);
            _context.Produtos.Remove(produtoDelete);
            await _context.SaveChangesAsync();
            return produtoDelete;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutobyId(int id)
        {
            return await _context.Produtos.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Produto> GetProdutobyLessPrice(decimal preco)
        {
            return await _context.Produtos.Where(c => c.Preço < preco).FirstOrDefaultAsync();
        }

        public async Task<Produto> GetProdutobyPrice(decimal preco)
        {
            return await _context.Produtos.Where(c => c.Preço == preco).FirstOrDefaultAsync();
        }

        public async Task<Produto> GetProdutobyUpperPrice(decimal preco)
        {
            return await _context.Produtos.Where(c => c.Preço > preco).FirstOrDefaultAsync();
        }

        public async Task<Produto> Update(Produto produto)
        {
            _context.Produtos.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return produto;
        }
    }
}
