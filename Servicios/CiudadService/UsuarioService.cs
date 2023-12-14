using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Datos;
using Infraestructura.Modelos;


namespace Servicios.CiudadService
{
    public class UsuarioService
    {
        private string cadenaConexion;
        UsuarioDatos usuarioDatos;
        public UsuarioService(string _cadenaConexion)
        {
            this.cadenaConexion= _cadenaConexion;
            usuarioDatos = new UsuarioDatos(_cadenaConexion);
        }



        public void InsertarUsuario(UsuarioModel usuario)
        {

            usuarioDatos.insertarUsuario(usuario);
        }

 
        public UsuarioModel obtenerUsuario(int idusuario)
        {

            return usuarioDatos.obtenerUsuario(idusuario);
        }


        public UsuarioModel eliminarUsuario(int idusuario)
        {

            return usuarioDatos.eliminarUsuario(idusuario);
        }

    }
}

