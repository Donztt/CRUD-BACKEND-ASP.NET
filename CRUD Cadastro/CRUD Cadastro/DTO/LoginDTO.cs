using CRUD_Cadastro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Cadastro.DTO
{
    public class LoginDTO
    {
        public string login { get; set; }
        public string senha { get; set; }
    }
}
