using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class Empleado
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public class ValuesController : ApiController
    {
        List<Empleado> listaEmpleado = null;
        public ValuesController()
        {
            listaEmpleado = new List<Empleado>();
            listaEmpleado.Add(new Empleado() { id = 1, Name = "Alberto", Department="Departen 1"});
            listaEmpleado.Add(new Empleado() { id = 2, Name = "Alejandro", Department = "Departen 1" });
            listaEmpleado.Add(new Empleado() { id = 3, Name = "Kitzia", Department = "Departen 2" });
            listaEmpleado.Add(new Empleado() { id = 4, Name = "Kenia", Department = "Departen 1" });
            listaEmpleado.Add(new Empleado() { id = 5, Name = "Bernardo", Department = "Departen 2" });
        }

        [ActionName("Empleados")]
        [HttpGet]
        public IEnumerable<Empleado> Empleados()
        {
            return listaEmpleado;
        }

        // GET api/values/5
        public Empleado Get(int id)
        {
            var empleado = listaEmpleado.Where(i => i.id == id).SingleOrDefault();
            return empleado;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}