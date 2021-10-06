﻿using System;
using System.Net;
using System.Threading;
using System.Web.Http;

using System.Net.Http;
using MVCWebApi.Models;
using MVCWebApi.Controllers;
using System.Web.Http.Cors;

namespace WebApiSegura.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
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
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: { identity.IsAuthenticated}");
        }
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: This code is only for demo - extract method in new class & validate correctly in your application !!
             var isUserValid = (login.Usuario == "user" && login.Password == "123456");
            if (isUserValid)
            {
                var rolename = "Developer";
                var token = TokenGenerator.GenerateTokenJwt(login.Usuario, rolename);
                return Ok(token);
            }
            //TODO: This code is only for demo - extract method in new class & validate correctly in your application !!
             var isTesterValid = (login.Usuario == "test" && login.Password == "123456");
            if (isTesterValid)
            {
                var rolename = "Tester";
                var token = TokenGenerator.GenerateTokenJwt(login.Usuario, rolename);
                return Ok(token);
            }
            //TODO: This code is only for demo - extract method in new class & validate  correctly in your application !!
             var isAdminValid = (login.Usuario == "admin" && login.Password == "123456");
            if (isAdminValid)
            {
                var rolename = "Administrator";
                var token = TokenGenerator.GenerateTokenJwt(login.Usuario, rolename);
                return Ok(token);
            }
            // Unauthorized access
            return Unauthorized();
        }
    }
}