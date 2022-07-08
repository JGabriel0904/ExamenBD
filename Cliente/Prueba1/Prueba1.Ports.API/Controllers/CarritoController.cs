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
    public class CarritoController : ControllerBase
    {
        public CarritoUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();
            CarritoRepository repository = new CarritoRepository(db);
            CarritoUseCase service = new CarritoUseCase(repository);

            return service;
        }

        // GET: api/<SongController>
        [HttpGet]
        public ActionResult<IEnumerable<Carrito>> Get()
        {
            CarritoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public ActionResult<Carrito> Get(int id)
        {
            CarritoUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<SongController>
        [HttpPost]
        public ActionResult<Carrito> Post([FromBody] Carrito carrito)
        {
            CarritoUseCase service = CreateService();

            var result = service.Create(carrito);

            return Ok(result);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Carrito carrito)
        {
            CarritoUseCase service = CreateService();
            carrito.CarritoId = id;
            service.Update(carrito);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            CarritoUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}

