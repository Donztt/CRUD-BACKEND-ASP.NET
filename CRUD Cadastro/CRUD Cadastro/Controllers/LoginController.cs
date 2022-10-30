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

namespace CRUD_Cadastro.Controllers
{
    [Route("/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Contexto _context;

        public LoginController(Contexto context)
        {
            _context = context;
        }


        [HttpGet("/AuthLogin")]
        public async Task<ActionResult<Login>> AutLogin([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var Login = await _context.Login.FirstAsync(e => e.LoginNome == loginDTO.login);

                if (loginDTO.senha == Login.Senha)
                {
                    return Ok(Login);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.Id == id);
        }
    }
}
