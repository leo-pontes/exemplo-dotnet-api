using LL.Curso.Api.Models;
using LL.Curso.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Curso.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriasController: ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        public async Task<IActionResult> GetAll()
        {
            var data = (await _categoriaRepository.GetAsync())
                .Select(c => c.ToCategoriaGet());

            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetCategoriaById")]
        [Produces("application/json", "application/xml")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _categoriaRepository.GetAsync(id);
            if (data == null)
                NotFound();

            return Ok(data.ToCategoriaGet());
        }

        [HttpPost]
        public IActionResult Add([FromBody]CategoriasAddEdit model)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            var data = model.ToCategoria();

            _categoriaRepository.Add(data);

            return CreatedAtRoute("GetCategoriaById", new { data.Id }, data.ToCategoriaGet());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]CategoriasAddEdit model)
        {
            var data = await _categoriaRepository.GetAsync(id);

            if (data == null)
                ModelState.AddModelError("Id", "Categoria não encontrada.");

            if (ModelState.IsValid)
                return BadRequest(ModelState);

            data.Update(model.Nome, model.Descricao);

            _categoriaRepository.Update(data);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _categoriaRepository.GetAsync(id);

            if (data == null)
                return BadRequest(new { Categoria = new string[] { "Categoria não encontrada." } });

            _categoriaRepository.Delete(data);

            return Ok();
        }
    }
}
