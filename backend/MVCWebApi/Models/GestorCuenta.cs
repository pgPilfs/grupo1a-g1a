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
                        string tipoMovimiento = dr.GetString(9).Trim();

                        movimiento = new Movimiento(fechahora, monto, cvuOrigen, cvuDestino, id, tipoMovimiento);
                        cuenta.movimientos.Add(movimiento);
                    }
                    dr.Close();

                }
               
            }

            return cuenta;
        }
    }
}