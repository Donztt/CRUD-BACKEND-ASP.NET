using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_Cadastro.Settings;
using CRUD_Cadastro.Model;
using CRUD_Cadastro.DTO;
using CRUD_Cadastro.Service;

namespace CRUD_Cadastro.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService loginService;

        public LoginController(Contexto context)
        {
            loginService = new LoginService(context);
        }

        [HttpPost("/AuthLogin")]
        public async Task<ActionResult<LoginDTO>> AuthLogin([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var response = await loginService.Auth(loginDTO);
                return Ok(response); 
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
     
    }
}
