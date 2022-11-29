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
    public class ActividadController : ApiController
    {
        // GET api/<controller>
        public List<ActividadEntity> Get()
        {
            var _listActividad = ManejadorActividad.TraerTodos();
            return _listActividad;
        }

        // GET api/<controller>/5
        public List<ActividadEntity> Get(int id)
        {
            var _listActividad = ManejadorActividad.TraerActividadEntityPorIdUsuario(id);

            return _listActividad;
        }

        //// POST api/<controller>
        //public bool Post([FromBody] ActividadEntity act)
        //{
        //    return ManejadorActividad.AgregarActividad(act);
        //}

        //// PUT api/<controller>/5
        //public bool Put(int id, [FromBody] UsuarioEntity us)
        //{
        //    return ManejadorUsuarios.ModificarClienteGC(us);
        //}

        //// DELETE api/<controller>/5
        //public bool Delete(int id)
        //{
        //    return ManejadorUsuarios.EliminarUsuario(id);

        //}
    }
}
