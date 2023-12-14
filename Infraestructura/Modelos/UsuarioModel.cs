using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class UsuarioModel
    {
        public int idusuario { get; set; }
        public string idpersona { get; set; }
        public string nombre_usuario { get; set; }
        public string contraseña { get; set; }
        public string nivel { get; set; }
        public string estado { get; set; }
    }
}
