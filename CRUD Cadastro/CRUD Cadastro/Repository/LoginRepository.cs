
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_Cadastro.Settings;
using CRUD_Cadastro.Model;
using CRUD_Cadastro.DTO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Cadastro.Repository
{
    public class LoginRepository
    {
        private readonly Contexto _context;

        public LoginRepository(Contexto context)
        {
            _context = context;
        }

        public async Task<Login> Auth(LoginDTO dto)
        {
            var login = await _context.Login
              .Where(e => e.LoginNome == dto.login)
              .Where(e => e.Senha == dto.senha)
              .FirstAsync();

             return login;
        }

    }
}
