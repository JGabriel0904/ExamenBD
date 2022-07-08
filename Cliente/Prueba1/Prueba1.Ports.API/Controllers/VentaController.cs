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
    public class VentaController : ControllerBase
    {
        public VentaUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();
            VentaRepository repository = new VentaRepository(db);
            VentaUseCase service = new VentaUseCase(repository);

            return service;
        }

        // GET: api/<SongController>
        [HttpGet]
        public ActionResult<IEnumerable<Venta>> Get()
        {
            VentaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public ActionResult<Venta> Get(int id)
        {
            VentaUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<SongController>
        [HttpPost]
        public ActionResult<Venta> Post([FromBody] Venta venta)
        {
            VentaUseCase service = CreateService();

            var result = service.Create(venta);

            return Ok(result);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Venta venta)
        {
            VentaUseCase service = CreateService();
            venta.VentaId = id;
            service.Update(venta);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            VentaUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
