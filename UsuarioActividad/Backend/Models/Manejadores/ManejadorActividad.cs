using Backend.DAL;
using Backend.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Manejadores
{
    public class ManejadorActividad
    {
        private static List<ActividadEntity> ListadoActividadEntity;
        private static DateTime UltimaActualizacion;
        private static int TiempoCache = 15;

        private static void VerificarListadoActividad()
        {
            if (ListadoActividadEntity == null)
            {
                Recargar();
                return;
            }

            if (TiempoCache == 0)
            {
                Recargar();
            }
            if (TiempoCache > 0)
            {
                var difCache = DateTime.Now - UltimaActualizacion;
                if (difCache.Minutes > TiempoCache)
                {
                    Recargar();
                }
            }
        }

        public static void Recargar()
        {
            ListadoActividadEntity = AdmActividad.TraerTodos();
            UltimaActualizacion = DateTime.Now;
        }

        public static List<ActividadEntity> TraerTodos()
        {
            VerificarListadoActividad();
            return ListadoActividadEntity;

        }

        public static ActividadEntity TraerActividadEntityPorId(int idActividad)
        {
            VerificarListadoActividad();
            return ListadoActividadEntity.FirstOrDefault(x => x.Id_actividad == idActividad);

        }
        public static List<ActividadEntity> TraerActividadEntityPorIdUsuario(int idUsuario)
        {
            VerificarListadoActividad();
            return ListadoActividadEntity.Where(x => x.Id_usuario == idUsuario).ToList();

        }

        public static bool AgregarActividad(ActividadEntity act)
        {
            var resultado = AdmActividad.GrabarActividad(act);
            Recargar();
            return resultado;
        }
    }
}