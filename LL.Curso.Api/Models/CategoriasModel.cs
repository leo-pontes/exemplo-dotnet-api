using LL.Curso.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LL.Curso.Api.Models
{
    public class CategoriasGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }            
        public string Descricao { get; set; }
    }   

    public class CategoriasAddEdit
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "Limite de caracteres excedido.")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "Limite de caracteres excedido.")]
        public string Descricao { get; set; }
    }

    public static class CategoriasModelExtension
    {
        public static CategoriasGet ToCategoriaGet(this Categoria entity) =>        
            new CategoriasGet()
            {
                Id = entity.Id,
                Nome = entity.Nome,                
                Descricao = entity.Descricao
            };
        

        public static Categoria ToCategoria(this CategoriasAddEdit entity) =>        
            new Categoria()
            {
                Nome = entity.Nome,
                Descricao = entity.Descricao
            };
    }
}
