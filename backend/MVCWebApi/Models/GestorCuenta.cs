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
                    string cvu = dr.GetString(1).Trim();
                    double saldo = dr.GetDouble(2);
                    int id_usuario = dr.GetInt32(3);
                    int estado = dr.GetInt32(4);

                    cuenta = new Cuenta(id, cvu, saldo, id_usuario, estado);

                    comm = conn.CreateCommand();
                    comm.CommandText = "listar_ultimos_movimientos";
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@id_cuenta", id));
                    dr.Close();
                    dr = comm.ExecuteReader();

                    while (dr.Read())
                    {
                        DateTime fechahora = dr.GetDateTime(1);
                        double monto = dr.GetDouble(2);
                        string cvuOrigen = dr.GetString(3).Trim(); 
                        string cvuDestino = dr.GetString(4).Trim();
                        string tipoMovimiento = dr.GetString(7).Trim();

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