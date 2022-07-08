using Microsoft.AspNetCore.Mvc;

using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using Prueba1.Core.Application.UseCases;
using Prueba1.Core.Infraestructure.Repository.Concrete;

using Prueba1.Core.Domain.Models;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba1.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public CategoriaUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();
            CategoriaRepository repository = new CategoriaRepository(db);
            CategoriaUseCase service = new CategoriaUseCase(repository);

            return service;
        }

        // GET: api/<SongController>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            CategoriaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {
            CategoriaUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<SongController>
        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria categoria)
        {
            CategoriaUseCase service = CreateService();

            var result = service.Create(categoria);

            return Ok(result);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            CategoriaUseCase service = CreateService();
            categoria.CategoriaId= id;
            service.Update(categoria);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            CategoriaUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
