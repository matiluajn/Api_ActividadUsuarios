using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Entidades
{
    public class ActividadEntity
    {
        public int Id_actividad { get; set; }
        public DateTime Create_date { get; set; }
        public int Id_usuario { get; set; }
        public string Actividad { get; set; }


    }
}