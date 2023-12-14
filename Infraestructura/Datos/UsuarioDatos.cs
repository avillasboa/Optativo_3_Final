using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Conexiones;
using Infraestructura.Modelos;

namespace Infraestructura.Datos
{
    public class UsuarioDatos
    {
        private string cadenaConexion;
        private ConexionDB conexion;
        public UsuarioDatos(string cadenaConexion)
        {
            this.cadenaConexion= cadenaConexion;
            conexion = new ConexionDB(cadenaConexion);
            
        }

        public void insertarUsuario(UsuarioModel usuario)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO usuario (idpersona, nombre_usuario, contraseña, nivel, estado)" +
                                                "VALUES(@idpersona, @nombre_usuario, @contraseña, @nivel, @estado)", conn);

            comando.Parameters.AddWithValue("idpersona", usuario.idpersona);
            comando.Parameters.AddWithValue("nombre_usuario", usuario.nombre_usuario);
            comando.Parameters.AddWithValue("contraseña", usuario.contraseña);
            comando.Parameters.AddWithValue("nivel", usuario.nivel);
            comando.Parameters.AddWithValue("estado", usuario.estado);


            comando.ExecuteNonQuery();

        }

        public UsuarioModel obtenerUsuario(int idusuario)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * from usuario where idusuario = {idusuario}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new UsuarioModel
                {
                    idusuario = reader.GetInt32("idusuario"),
                    idpersona = reader.GetString("idpersona"),
                    nombre_usuario = reader.GetString("nombre_usuario"),
                    contraseña = reader.GetString("contraseña"),
                    nivel = reader.GetString("nivel"),
                    estado = reader.GetString("estado"),
                };
            }
            return null;
        }

        public void modificarUsuario(UsuarioModel usuario)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE usuario SET idpersona = '{usuario.idpersona}', " +
                                                          $"nombre_usuario = '{usuario.nombre_usuario}', " +
                                                          $"contraseña = '{usuario.contraseña}' " +
                                                          $"nivel = '{usuario.nivel}' " +
                                                          $"estado = '{usuario.estado}' " +
                                                $" WHERE id = {usuario.idusuario}", conn);

            comando.ExecuteNonQuery();
        }

        public UsuarioModel eliminarUsuario(int idusuario)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM usuario WHERE idusuario = {idusuario}", conn);
            using var reader = comando.ExecuteReader();

            if (reader.Read())
            {
 
            }
            return null;

        }

    }
}