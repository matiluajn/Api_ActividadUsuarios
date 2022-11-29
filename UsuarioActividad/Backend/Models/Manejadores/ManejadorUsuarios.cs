using Backend.DAL;
using Backend.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Manejadores
{
    public class ManejadorUsuarios
    {
        private static List<UsuarioEntity> ListadoUsuarioEntity;
        private static DateTime UltimaActualizacion;
        private static int TiempoCache = 15;

        private static void VerificarListadoUsuarios()
        {
            if (ListadoUsuarioEntity == null)
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
            ListadoUsuarioEntity = AdmUsuario.TraerTodos();
            UltimaActualizacion = DateTime.Now;
        }

        public static List<UsuarioEntity> TraerTodos()
        {
            VerificarListadoUsuarios();
            return ListadoUsuarioEntity;

        }
        public static UsuarioEntity TraerUsuarioEntityPorId(int idUsuario)
        {
            VerificarListadoUsuarios();
            return ListadoUsuarioEntity.FirstOrDefault(x => x.Id_usuario == idUsuario);

        }

        public static bool AgregarUsuario(UsuarioEntity us)
        {
            var resultado = AdmUsuario.GrabarUsuario(us);
            Recargar();
            return resultado;
        }

        public static bool ModificarClienteGC(UsuarioEntity us)
        {
            var resultado = AdmUsuario.ModificarUsuario(us);
            Recargar();
            return resultado;
        }

        public static bool EliminarUsuario(int idUsuario)
        {
            var resultado = AdmUsuario.EliminarUsuarioEntityPorId(idUsuario);
            Recargar();
            return resultado;
        }


    }
}