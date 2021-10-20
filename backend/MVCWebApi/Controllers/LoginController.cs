using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using MVCWebApi.Models;
using MVCWebApi.Controllers;
using System.Web.Http.Cors;

namespace MVCWebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }
        [AllowAnonymous]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            GestorUsuario user = new GestorUsuario();
            //TODO: This code is only for demo - extract method in new class & validate correctly in your application !!
            var isUserValid = user.IniciarSesion(login.UserName, login.Password);
            if (isUserValid)
            {
                var rolename = "User";
                var token = TokenGenerator.GenerateTokenJwt(login.UserName, rolename);
                login.Token = token;
                LoginRequest welcome = user.UsuarioLogeado(login.UserName, login.Password);
                login.id_usuario = welcome.id_usuario;
                login.nombre = welcome.nombre;
                login.apellido = welcome.apellido;
                login.user = welcome.user;
                return Ok(login);
            }

            // Unauthorized access 
            return Unauthorized();
        }


    }
}
