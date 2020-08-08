using LL.Curso.Api.Models;
using LL.Curso.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LL.Curso.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutosController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        public async Task<IActionResult> GetAll()
        {
            var data = (await _produtoRepository.GetAllWithCategoriaAsync())
                .Select(p => p.ToProdutoGet());

            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetProdutoById")]
        [Produces("application/json", "application/xml")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = (await _produtoRepository.GetByIdWithCategoriaAsync(id));

            if (data == null)
                return NotFound();

            return Ok(data?.ToProdutoGet());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProdutoAddEdit model)
        {
            var categoria = await _categoriaRepository.GetAsync(model.CategoriaId);

            if (categoria == null)
                ModelState.AddModelError("CategoriaId", "Categoria não cadastrada.");

            if (ModelState.IsValid)
                return BadRequest(ModelState);

            var data = model.ToProduto();

            _produtoRepository.Add(data);

            var prodInserido = data.ToProdutoGet();
            prodInserido.CategoriaNome = categoria.Nome;

            return CreatedAtRoute("GetProdutoById", new { prodInserido.Id }, prodInserido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]ProdutoAddEdit model)
        {
            var categoria = await _categoriaRepository.GetAsync(model.CategoriaId);
            if (categoria == null)
                ModelState.AddModelError("CategoriaId", "Categoria não cadastrada.");

            var produto = await _produtoRepository.GetAsync(id);
            if (produto == null)
                ModelState.AddModelError("Id", "Produto não encontrado.");

            if (ModelState.IsValid)
                return BadRequest(ModelState);

            produto.Update(model.Nome, model.Preco, model.CategoriaId);
            _produtoRepository.Update(produto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoRepository.GetAsync(id);
            if (produto == null)
                return BadRequest(new { Produto = new string[] { "Produto não encontrado." } });
            
            _produtoRepository.Delete(produto);

            return Ok();
        }
    }
}
