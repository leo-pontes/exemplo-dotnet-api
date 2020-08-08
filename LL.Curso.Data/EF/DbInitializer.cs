using LL.Curso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LL.Curso.Data.EF
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasData(new Produto() { Id = 1, Nome = "Alimento" },
                         new Produto() { Id = 2, Nome = "Higiene" },                         
                         new Produto() { Id = 3, Nome = "Papelaria" },
                         new Produto() { Id = 4, Nome = "Informática" });

            modelBuilder.Entity<Produto>()
                .HasData(new Produto() { Id = 1, Nome = "Picanha", CategoriaId = 1, Preco = 99.9M },
                         new Produto() { Id = 2, Nome = "pasta de Dente", CategoriaId = 2, Preco = 9.9M },
                         new Produto() { Id = 3, Nome = "Danone", CategoriaId = 1, Preco = 10.59M },
                         new Produto() { Id = 4, Nome = "Caneta Bic", CategoriaId = 3, Preco = 1.9M },
                         new Produto() { Id = 5, Nome = "Caderno 10 Matérias", CategoriaId = 3, Preco = 55.4M },
                         new Produto() { Id = 6, Nome = "Fralda Pampers", CategoriaId = 2, Preco = 50.1M },
                         new Produto() { Id = 7, Nome = "Mouse Microsoft", CategoriaId = 4, Preco = 80.0M });
        }
    }
}
