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
        public Cuenta ObtenterCuenta(int id)
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
                comm.Parameters.Add(new SqlParameter("@id_cuenta", id));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    string cvu = dr.GetString(6).Trim();
                    decimal saldo = dr.GetDecimal(3);
                    int id_usuario = dr.GetInt32(1);
                    int estado = dr.GetInt32(5);

                    cuenta = new Cuenta(id, cvu, saldo, id_usuario, estado);
                    
                    comm = conn.CreateCommand();
                    comm.CommandText = "listar_ultimos_movimientos";
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@id_cuenta", id));
                    dr.Close();
                    dr = comm.ExecuteReader();

                    while (dr.Read())
                    {
                        DateTime fechahora = dr.GetDateTime(3);
                        decimal monto = dr.GetDecimal(4);
                        string cvuOrigen = dr.GetString(7).Trim(); 
                        string cvuDestino = dr.GetString(8).Trim();
                    
                        movimiento = new Movimiento(monto, cvuDestino, cvuOrigen);
                        cuenta.movimientos.Add(movimiento);
                        
                    }
                    
                    dr.Close();

                }
               
            }

            return cuenta;
        }


        public int transferencia(Movimiento movimiento)
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

                return Convert.ToInt32(comm.ExecuteScalar());
            }
        }


        public int ingresoDinero(Movimiento movimiento)
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

                return Convert.ToInt32(comm.ExecuteScalar());
            }
        }

        public int retiroDinero(Movimiento retira)
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

                return Convert.ToInt32(comm.ExecuteScalar());
            }
        }
    }
}