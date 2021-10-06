using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApi.Models
{
    public class Cuenta
    {
        public int id_cuenta;
        private string cvu;
        public decimal saldo;
        private int id_usuario;
        private int id_estado;
        public List<Movimiento> movimientos = new List<Movimiento>();

        public Cuenta(int id, string Cvu, decimal Monto, int id_user, int estado)
        {
            id_cuenta = id;
            cvu = Cvu;
            saldo = Monto;
            id_usuario = id_user;
            id_estado = estado;
        }

        //   public int Id { get => id; set => id = value; }
        //       public string Cvu { get => cvu; set => cvu = value; }
        //       public double Saldo { get => saldo; set => saldo = value; }
        //         public int Id_persona { get => id_persona; set => id_persona = value; }
        //    public bool Estado { get => estado; set => estado = value; }
        //       public List<Movimiento> Movimientos { get => movimientos; set => movimientos = value; }
    }

    public class Movimiento
    {
        public int id_movimiento;
        public DateTime fechaHora;
        public decimal monto;
        public int id_cuenta_recibe;
        public int id_cuenta_principal;
        public bool is_ingreso;
        public int id_estado;
        public string cvuOrigen;
        public string cvuDestino;
        public string tipoMovimiento;


        public Movimiento(DateTime FechaHora, decimal Monto, string CvuDestino, string CvuOrigen, int Id_cuenta_principal, string TipoMovimiento)
        {

            fechaHora = FechaHora;
            monto = Monto;
            cvuDestino = CvuDestino;
            cvuOrigen = CvuOrigen;
            id_cuenta_principal = Id_cuenta_principal;
            tipoMovimiento = TipoMovimiento;
        }



    } } 