﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Curso.Domain.Entities
{
    public class Produto: Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public void Update(string nome, decimal preco, int categoriaId)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.CategoriaId = categoriaId;
        }
    }
}
