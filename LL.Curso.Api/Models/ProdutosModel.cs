using LL.Curso.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace LL.Curso.Api.Models
{
    public class ProdutosGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }

    public class ProdutoAddEdit
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "Limite de caracteres excedido.")]
        public string Nome { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "Valor Inválido")]
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }

    public static class ProdutosModelExtension
    {
        public static ProdutosGet ToProdutoGet(this Produto entity) => 
            new ProdutosGet()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Preco = entity.Preco,
                CategoriaId = entity.CategoriaId,
                CategoriaNome = entity.Categoria?.Nome
            };

        public static Produto ToProduto(this ProdutoAddEdit entity) =>
            new Produto()
            {                
                Nome = entity.Nome,
                Preco = entity.Preco,
                CategoriaId = entity.CategoriaId
            };
    }
}
