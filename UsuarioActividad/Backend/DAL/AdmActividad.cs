using Backend.GD.DB;
using Backend.Models.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.DAL
{
    public class AdmActividad
    {
        public static List<ActividadEntity> TraerTodos()
        {
            try
            {
                using (var db = ConexionDB.Conexion())
                {


                    var query = "select * from actividades";
                    var list = db.Query<ActividadEntity>(query).ToList();
                    return list;


                }
            }
            catch (Exception ex)
            {
                return new List<ActividadEntity>();
            }


        }

        public static bool GrabarActividad(ActividadEntity act)
        {

            try
            {
                using (var db = ConexionDB.Conexion())
                {                   

                    var query = "set dateformat dmy INSERT INTO actividades (Create_date,Id_usuario,Actividad) " +
                    "VALUES (@Create_date,@Id_usuario,@Actividad)";
                    var response = db.Execute(query, new { Create_date = act.Create_date, Id_usuario = act.Id_usuario, Actividad = act.Actividad });
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}