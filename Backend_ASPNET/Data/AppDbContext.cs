using ControleDeEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Data{
    public class AppDbContext : DbContext{
        // public DbSet<Empresa> EmpresaModel { get; set; }
        public DbSet<Product> ProductModel { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ControleDeEstoque.db");
        }

        protected void OnModelConfiguring(ModelBuilder builder){
            builder.Entity<Product>().ToTable("Item");
        }
    }
}