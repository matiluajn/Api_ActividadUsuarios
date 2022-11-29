using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Entidades
{
    public class UsuarioEntity
    {
        public int Id_usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo_Electronico { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public String Telefono { get; set; }
        public string Pais_Residencia { get; set; }
        public bool info { get; set; }




    }
}