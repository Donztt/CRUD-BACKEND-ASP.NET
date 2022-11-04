using CRUD_Cadastro.DTO;
using CRUD_Cadastro.Model;
using CRUD_Cadastro.Repository;
using CRUD_Cadastro.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Cadastro.Service
{
    public class LoginService 
    {
        private LoginRepository loginRepository;

        public LoginService(Contexto context)
        {
            loginRepository = new LoginRepository(context);
        }

        public async Task<LoginDTO> Auth(LoginDTO dto)
        {    
            var login = await loginRepository.Auth(dto);
            return login.toDTO();
        }

    }
}
