using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MVCWebApi.Models
{
    public class GestorCuenta
    {
        public Cuenta ObtenterCuenta(int id_user)
        {
            Cuenta cuenta = null;
            Movimiento movimiento = null;
            

            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obtener_cuenta";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@id_user", id_user));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    string cvu = dr.GetString(5).Trim();
                    decimal saldo = dr.GetDecimal(3);
                    int id_cuenta = dr.GetInt32(0);
                    int estado = dr.GetInt32(4);

                    cuenta = new Cuenta(id_cuenta, cvu, saldo, id_user, estado);
                    
                    comm = conn.CreateCommand();
                    comm.CommandText = "listar_ultimos_movimientos";
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@cvu", cvu));
                    dr.Close();
                    dr = comm.ExecuteReader();

                    while (dr.Read())
                    {
                        DateTime fechahora = dr.GetDateTime(1);
                        decimal monto = dr.GetDecimal(2);
                        string cvuOrigen = dr.GetString(5).Trim(); 
                        string cvuDestino = dr.GetString(6).Trim();
                        string tipo = dr.GetString(7).Trim();
                    
                        movimiento = new Movimiento(monto, cvuDestino, cvuOrigen, tipo);
                        cuenta.movimientos.Add(movimiento);
                        
                    }
                    
                    dr.Close();

                }
               
            }

            return cuenta;
        }


        public Cuenta ObtenterCuentaCvu(string id_user)
        {
            Cuenta cuenta = null;
            Movimiento movimiento = null;


            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obtener_cuenta_cvu";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@id_user", id_user));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    int idusuario = dr.GetInt32(1);
                    decimal saldo = dr.GetDecimal(3);
                    int id_cuenta = dr.GetInt32(0);
                    int estado = dr.GetInt32(4);

                    cuenta = new Cuenta(id_cuenta, id_user, saldo, idusuario, estado);

                    comm = conn.CreateCommand();
                    comm.CommandText = "listar_ultimos_movimientos";
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@cvu", id_user));
                    dr.Close();
                    dr = comm.ExecuteReader();

                    while (dr.Read())
                    {
                        DateTime fechahora = dr.GetDateTime(1);
                        decimal monto = dr.GetDecimal(2);
                        string cvuOrigen = dr.GetString(5).Trim();
                        string cvuDestino = dr.GetString(6).Trim();
                        string tipo = dr.GetString(7).Trim();

                        movimiento = new Movimiento(monto, cvuDestino, cvuOrigen, tipo);
                        cuenta.movimientos.Add(movimiento);

                    }

                    dr.Close();

                }

            }
            return cuenta;
        }

        public string ObtenerCvu(int id_user)
        {
            // Usuarios usuario = new Usuarios();
            string cvu = "";
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obtener_cvu";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@id", id_user));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    cvu = dr.GetString(0);
                  
                }

                dr.Close();
            }

            return cvu;
        }


        public void transferencia(Movimiento movimiento)
        {
            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "transferir_dinero";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@cvu_origen", movimiento.cvuOrigen));
                comm.Parameters.Add(new SqlParameter("@cvu_destino", movimiento.cvuDestino));
                comm.Parameters.Add(new SqlParameter("@monto", movimiento.monto));

                SqlDataReader dr = comm.ExecuteReader();

              
            }
        }


        public void ingresoDinero(Movimiento movimiento)
        {


            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "ingresar_dinero";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@cvu", movimiento.cvuOrigen));
                comm.Parameters.Add(new SqlParameter("@monto", movimiento.monto));

                SqlDataReader dr = comm.ExecuteReader();

                
            }
        }




        public void retiroDinero(Movimiento retira)
        {


            string StrConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "retirar_dinero";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@cvu", retira.cvuOrigen));
                comm.Parameters.Add(new SqlParameter("@monto", retira.monto));

                SqlDataReader dr = comm.ExecuteReader();

             
            }
        }
    }
}