using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApi.Models
{
    public class Usuarios
    {
        public int id_usuario { get; set; }
        public string username { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int ciudad { get; set;  }


        public Usuarios(int Id_usuario, string Username, string Nombre, string Apellido, string Email, string Contrasena, DateTime Fecha_nacimiento, int Ciudad)
        {
            id_usuario = Id_usuario;
            username = Username;
            nombre = Nombre;
            apellido = Apellido;
            email = Email;
            contrasena = Contrasena;
            fecha_nacimiento = Fecha_nacimiento;
            ciudad = Ciudad;
        }

        public Usuarios() {}
    }
}