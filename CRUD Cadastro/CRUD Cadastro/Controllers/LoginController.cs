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
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Contexto _context;

        public LoginController(Contexto context)
        {
            _context = context;
        }

        [HttpPost("/AuthLogin")]
        public async Task<ActionResult<Login>> AuthLogin([FromBody] LoginDTO loginDTO)
        {
            var login = await _context.Login
                .Where(e => e.LoginNome == loginDTO.login)
                .Where(e => e.Senha == loginDTO.senha)
                .FirstAsync();

            if (login != null)
            {
                return Ok(login);
            }
            else
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
