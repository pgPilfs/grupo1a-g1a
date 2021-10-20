using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MVCWebApi.Models;

namespace MVCWebApi.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
     public class UsuarioController : ApiController
      {
        // GET: api/Usuarios
         public IEnumerable<Usuarios> Get()   
           {
               GestorUsuario gUsuario = new GestorUsuario();
              return gUsuario.ObtenerUsuarios();
           }

             // GET: api/Usuarios/5
           public int Get(string mail)
           {
               GestorUsuario gestorUsuarios = new GestorUsuario();
               return gestorUsuarios.ObtenerUsuario(mail);
           }

        // POST: api/Usuarios
        [AllowAnonymous]
        public Usuarios Post([FromBody]Usuarios value)
           {
               GestorUsuario gUsuario = new GestorUsuario();
               value.id_usuario= gUsuario.AgregarUsuario(value);
               gUsuario.crearCuenta(value.id_usuario);
               return value;
           }



           // PUT: api/Persona/5
           public void Put(int id, [FromBody]Usuarios value)
           {
           }

           // DELETE: api/Persona/5
           public void Delete(int id)
           {
               GestorUsuario gUsuario = new GestorUsuario();
               gUsuario.Eliminar(id);
           }
       }
    }

