using Backend.Models.Entidades;
using Backend.Models.Manejadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET api/<controller>
        public List<UsuarioEntity> Get()
        {
            var _listUsuarios = ManejadorUsuarios.TraerTodos();
            return _listUsuarios;
        }

        // GET api/<controller>/5
        public UsuarioEntity Get(int id)
        {
            var _listUsuarios = ManejadorUsuarios.TraerUsuarioEntityPorId(id);

            return _listUsuarios;
        }

        // POST api/<controller>
        public bool Post([FromBody] UsuarioEntity us)
        {
            return ManejadorUsuarios.AgregarUsuario(us);
        }

        // PUT api/<controller>/5
        public bool Put(int id, [FromBody] UsuarioEntity us)
        {
            return ManejadorUsuarios.ModificarClienteGC(us);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ManejadorUsuarios.EliminarUsuario(id);

        }
    }
}
