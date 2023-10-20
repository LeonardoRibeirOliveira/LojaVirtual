using LojaVirtual.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.ProductAPI.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) { } //Passa as opções de configuração
        public DbSet<Categoria> Categorias { get; set; }//Definir o mapeamento entre entidades e tabelas
        public DbSet<Produto> Produtos { get; set; }

        //Usando Fluent API
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Categoria>().HasKey(c => c.CategoriaId);
            mb.Entity<Categoria>().Property(c=> c.Nome).HasMaxLength(50);

            mb.Entity<Produto>().HasKey(c => c.Id);
            mb.Entity<Produto>().Property(c => c.Nome).HasMaxLength(50);
            mb.Entity<Produto>().Property(c => c.Preço).HasPrecision(10,2);
            mb.Entity<Produto>().Property(c => c.ImagemURL).HasMaxLength(50);

            mb.Entity<Categoria>().HasMany(g => g.Produtos).WithOne(c=> c.Categoria).IsRequired().OnDelete(DeleteBehavior.Cascade); //Caso exclua uma categoria, os produtos também serão excluidos


        }
    }
}
