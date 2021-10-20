using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCWebApi.Models;
using System.Web.Http.Cors;

namespace MVCWebApi.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CuentaController : ApiController
    {
        // GET: api/Cuenta
       /* public IEnumerable<Cuenta> Get(int id)
        {
            GestorCuenta gCuenta = new GestorCuenta();
            return gCuenta.ObtenterCuentas(id);
        }*/

        // GET: api/Cuenta/5
        public Cuenta Get(int id)
        {
            GestorCuenta cuenta = new GestorCuenta();
            return cuenta.ObtenterCuenta(id);
        }

        public Movimiento Post([FromBody] Movimiento value)
        {
            GestorCuenta transaccion = new GestorCuenta();
            transaccion.transferencia(value);
            return value;
        }


        // PUT: api/Cuenta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cuenta/5
        public void Delete(int id)
        {
        }
    }
}
