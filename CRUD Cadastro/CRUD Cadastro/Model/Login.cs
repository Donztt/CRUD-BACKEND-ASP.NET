using CRUD_Cadastro.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Cadastro.Model
{
    [Table("LOGIN")]
    public class Login
    {
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("LOGIN")]
        public string LoginNome { get; set; }
        [Column("SENHA")]
        public string Senha { get; set; }
        [Column("PESSOA_ID")]
        public Guid Pessoa_id { get; set; }

        public LoginDTO toDTO()
        {
            return new LoginDTO()
            {
               login = this.LoginNome,
               senha = this.Senha
            };
        }
    }

}
