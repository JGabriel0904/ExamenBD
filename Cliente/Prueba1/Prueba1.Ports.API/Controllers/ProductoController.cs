using Microsoft.AspNetCore.Mvc;

using Prueba1.Adaptors.SQLServerDataAccess.Contexts;
using Prueba1.Core.Application.UseCases;
using Prueba1.Core.Infraestructure.Repository.Concrete;

using Prueba1.Core.Domain.Models;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Data;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba1.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ProductoController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        public ProductoUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();
            ProductoRepository repository = new ProductoRepository(db);
            ProductoUseCase service = new ProductoUseCase(repository);

            return service;
        }

        // GET: api/<SongController>
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            ProductoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            ProductoUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<SongController>
        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto producto)
        {
            ProductoUseCase service = CreateService();

            var result = service.Create(producto);

            return Ok(result);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            ProductoUseCase service = CreateService();
            producto.ProductoId= id;
            service.Update(producto);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ProductoUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllCategoriesNames")]
        public JsonResult GetAllCategoriesNames()
        {
            string query = @"
                    select CategoriaNombre from dbo.tb_categoria
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ProductoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

    }
}
