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
    public class AdministradorController : ControllerBase
    {
        public AdministradorUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();
            AdministradorRepository repository = new AdministradorRepository(db);
            AdministradorUseCase service = new AdministradorUseCase(repository);

            return service;
        }

        // GET: api/<SongController>
        [HttpGet]
        public ActionResult<IEnumerable<Administrador>> Get()
        {
            AdministradorUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public ActionResult<Administrador> Get(int id)
        {
            AdministradorUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<SongController>
        [HttpPost]
        public ActionResult<Administrador> Post([FromBody] Administrador administrador)
        {
            AdministradorUseCase service = CreateService();

            var result = service.Create(administrador);

            return Ok(result);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Administrador administrador)
        {
            AdministradorUseCase service = CreateService();
            administrador.AdministradorId = id;
            service.Update(administrador);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            AdministradorUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}

