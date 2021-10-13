using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCWebApi.Models
{
    public class GestorUsuario
    {
        public int AgregarUsuario(Usuarios usuario)
        {
            string connection = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "crear_usuario";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@username", usuario.username));
                comm.Parameters.Add(new SqlParameter("@nombre", usuario.nombre));
                comm.Parameters.Add(new SqlParameter("@apellido", usuario.apellido));
                comm.Parameters.Add(new SqlParameter("@email", usuario.email));
                comm.Parameters.Add(new SqlParameter("@contraseña", usuario.contrasena));
                comm.Parameters.Add(new SqlParameter("@telefono", usuario.telefono));
                //comm.Parameters.Add(new SqlParameter("@ciudad", usuario.ciudad));
                comm.Parameters.Add(new SqlParameter("@fecha_nacimiento", usuario.fecha_nacimiento));

                return Convert.ToInt32(comm.ExecuteScalar());
            }

        }


        public Usuarios ObtenerUsuario(int id)
        {
            Usuarios usuario = null;
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obtener_usuario";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@id_usuario", id));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    string username = dr.GetString(1).Trim();
                    string nombre = dr.GetString(2).Trim();
                    string apellido = dr.GetString(3).Trim();
                    string email = dr.GetString(4);
                    string contrasena = dr.GetString(5);
                    int ciudad = dr.GetInt32(6);
                    // int dni = dr.GetInt32(5);
                    DateTime fecha_nacimiento = dr.GetDateTime(7);
                    
                    usuario = new Usuarios(id, username, nombre, apellido, email, contrasena, fecha_nacimiento, ciudad);
                }
                
                dr.Close();
                }

                return usuario;
        }


        public string ObtenerPassword(string pass)
        {
            Usuarios usuario = null;
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obtenerPass";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@password", pass));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    string contrasena = dr.GetString(0);
                    usuario = new Usuarios();



                    usuario.contrasena = contrasena;
                }

                dr.Close();
            }

            return usuario.contrasena;
        }


        public bool IniciarSesion(string Usuario, string Contraseña)
        {
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();
            int result = 0;

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "LoguearUsuario";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@email", Usuario));
                comm.Parameters.Add(new SqlParameter("@password", Contraseña));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    result = dr.GetInt32(0);
                }

                dr.Close();
            }

            return result > 0;
        }

        public void Eliminar(int id)
        {
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand("eliminar_usuario", conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@id_usuario", id));

                comm.ExecuteNonQuery();
            }

        }

        public List<Usuarios> ObtenerUsuarios()
        {
            List<Usuarios> lista = new List<Usuarios>();
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obteniendo_usuarios";
                comm.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string username = dr.GetString(1).Trim();
                    string nombre = dr.GetString(2).Trim();
                    string apellido = dr.GetString(3).Trim();
                    string email = dr.GetString(4);
                    string contrasena = dr.GetString(5);
                    int ciudad = dr.GetInt32(7);
                    DateTime fecha_nac = dr.GetDateTime(11);
                    

                    Usuarios usuario = new Usuarios(id, username,nombre, apellido, email, contrasena, fecha_nac, ciudad);
                    lista.Add(usuario);
                }

                dr.Close();
            }

            return lista;
        }

        public LoginRequest UsuarioLogeado(string userName, string pass)
        {
            LoginRequest usuario = null;
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obtenerid";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@email", userName));
                comm.Parameters.Add(new SqlParameter("@password", pass));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    int id_usuario = dr.GetInt32(0);
                    string username = dr.GetString(1).Trim();
                    string nombre = dr.GetString(2).Trim();
                    string apellido = dr.GetString(3).Trim();
                    string telefono = dr.GetString(6);
                    

                    usuario = new LoginRequest(id_usuario, username, nombre, apellido, telefono);
                }

                dr.Close();
            }

            return usuario;
        }

    }
}

//     public Persona ObtenerPersona(int id)
//     {
//         Persona persona = null;
//string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

//         using (SqlConnection conn = new SqlConnection(StrConn))
//        {
//            conn.Open();

// SqlCommand comm = conn.CreateCommand();
// comm.CommandText = "obtener_persona";
// comm.CommandType = CommandType.StoredProcedure;
// comm.Parameters.Add(new SqlParameter("@id", id));

// SqlDataReader dr = comm.ExecuteReader();

//          if (dr.Read())
//          {
// string nombre = dr.GetString(1).Trim();
// string apellido = dr.GetString(2).Trim();
// string domicilio = dr.GetString(3).Trim();
// int id_localidad = dr.GetInt32(4);
// int dni = dr.GetInt32(5);
// string email = dr.GetString(6);
// DateTime fecha_nac = dr.GetDateTime(7);
//               string pass = dr.GetString(8);
// 
//              persona = new Persona(id, nombre, apellido, domicilio, id_localidad,dni,email,pass,fecha_nac);
//   }
// 
// dr.Close();
//       }

//  return persona;
// 
//    }

/*

        public Persona ObtenerPorId(int id)
        {
            Persona persona = null;
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obtener_persona";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    string nombre = dr.GetString(1).Trim();
                    string apellido = dr.GetString(2).Trim();
                    string domicilio = dr.GetString(3).Trim();
                    int id_localidad = dr.GetInt32(4);
                    int dni = dr.GetInt32(5);
                    string email = dr.GetString(6);
                    DateTime fecha_nac = dr.GetDateTime(7);
                    string pass = dr.GetString(8);

                    persona = new Persona(id, nombre, apellido, domicilio, id_localidad, dni, email, pass, fecha_nac);
                }

                dr.Close();
            }

            return persona;

        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> lista = new List<Persona>();
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obtener_personas";
                comm.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string apellido = dr.GetString(2).Trim();
                    string domicilio = dr.GetString(3).Trim();
                    int id_localidad = dr.GetInt32(4);
                    int dni = dr.GetInt32(5);
                    string email = dr.GetString(6);
                    DateTime fecha_nac = dr.GetDateTime(7);
                    string pass = dr.GetString(8);

                    Persona persona = new Persona(id, nombre, apellido, domicilio, id_localidad, dni, email, pass, fecha_nac);
                    lista.Add(persona);
                }

                dr.Close();
            }

            return lista;
        }
    }
}*/