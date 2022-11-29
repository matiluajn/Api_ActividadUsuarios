using Backend.GD.DB;
using Backend.Models.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.DAL
{
    public class AdmUsuario
    {
        public static List<UsuarioEntity> TraerTodos()
        {
            try
            {
                using (var db = ConexionDB.Conexion())
                {


                    var query = "select * from usuarios";
                    var list = db.Query<UsuarioEntity>(query).ToList();
                    return list;


                }
            }
            catch (Exception ex)
            {
                
                return new List<UsuarioEntity>();
            }


        }

        public static UsuarioEntity TraerUsuarioEntityPorId(int Id_usuario)
        {

            try
            {
                using (var db = ConexionDB.Conexion())
                {
                    var query = "select * from usuarios where Id_usuario = @Id_usuario";


                    var list = db.Query<UsuarioEntity>(query, new { Id_usuario = Id_usuario }).FirstOrDefault();
                    return list;

                }
            }
            catch (Exception ex)
            {
                return new UsuarioEntity();
            }
        }

        public static bool GrabarUsuario(UsuarioEntity usu)
        {

            try
            {
                using (var db = ConexionDB.Conexion())
                {
                    //var usuario = new UsuarioEntity();

                    //usuario.Nombre = usu.Nombre;
                    //usuario.Apellido = usu.Apellido;
                    //usuario.Correo_Electronico = usu.Correo_Electronico;
                    //usuario.Fecha_Nacimiento = usu.Fecha_Nacimiento;
                    //usuario.Telefono = usu.Telefono;
                    //usuario.Pais_Residencia = usu.Pais_Residencia;
                    //usuario.info = usu.info;

                    var query = "set dateformat dmy INSERT INTO usuarios (Nombre,Apellido,Correo_Electronico,Fecha_Nacimiento,Telefono,Pais_Residencia,info) " +
                    "VALUES (@Nombre,@Apellido,@Correo_Electronico,@Fecha_Nacimiento,@Telefono,@Pais_Residencia,@info)";
                    var response = db.Execute(query, new { Nombre = usu.Nombre, Apellido = usu.Apellido, Correo_Electronico = usu.Correo_Electronico, Fecha_Nacimiento = usu.Fecha_Nacimiento, Telefono = usu.Telefono, Pais_Residencia = usu.Pais_Residencia, info = usu.info });
                    return true;

                }
            }
            catch (Exception ex)
            {
               
                return false;
            }


        }

        public static bool ModificarUsuario(UsuarioEntity usu)
        {

            try
            {
                using (var db = ConexionDB.Conexion())
                {
                    

                    //Modificamos
                    var query = "set dateformat dmy UPDATE usuarios SET Nombre = @Nombre, Apellido = @Apellido, Correo_Electronico= @Correo_Electronico," +
                    "Fecha_Nacimiento = @Fecha_Nacimiento, Telefono = @Telefono, Pais_Residencia = @Pais_Residencia ,info = @info WHERE Id_usuario=@Id_usuario";
                    var response = db.Execute(query, new { Id_usuario= usu.Id_usuario, Nombre = usu.Nombre, Apellido = usu.Apellido, Correo_Electronico =usu.Correo_Electronico, Fecha_Nacimiento = usu.Fecha_Nacimiento, Telefono =usu.Telefono, Pais_Residencia = usu.Pais_Residencia, info = usu.info });

                   
                    return true;

                }
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public static bool EliminarUsuarioEntityPorId(int Id_usuario)
        {

            try
            {
                using (var db = ConexionDB.Conexion())
                {
                    var query = "delete from usuarios where Id_usuario=@Id_usuario ";


                    var list = db.Query<UsuarioEntity>(query, new { Id_usuario = Id_usuario }).FirstOrDefault();
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