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
    public class RetiroController : ApiController
    {
        public Movimiento Post([FromBody] Movimiento value)
        {
            GestorCuenta retiro = new GestorCuenta();
            value.id_movimiento = retiro.retiroDinero(value);
            return value;
        }
    }
}
