using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.GD.DB
{
    public class ConexionDB
    {
        public const string ConexionBase = @"SERVER=.\SQLENTERPRISE;DATABASE=UsuarioActividad;User ID=sa;Password=a123456.";

        public static SqlConnection Conexion()
        {
            SqlConnection cn = new SqlConnection(ConexionBase);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la conexion con la Data Base: " + ex);
                return cn;
            }
        }
    }
}