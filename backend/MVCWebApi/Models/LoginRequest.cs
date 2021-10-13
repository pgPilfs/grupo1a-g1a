using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApi.Models
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int id_usuario { get; set; }
        public string user { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string Token;


        public LoginRequest(int Id_usuario, string nombreuser, string Nombre, string Apellido, string Telefono )
        {
            id_usuario = Id_usuario;
            user = nombreuser;
            nombre = Nombre;
            apellido = Apellido;
            telefono = Telefono;
            
            
        }


    }
}