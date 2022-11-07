using CRUD_Cadastro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Cadastro.DTO
{
    public class PessoaDTO
    {
        public Guid id { get; set; }
        public string? nome { get; set; }
        public string? cep { get; set; }
        public string? cpf { get; set; }
        public string? cidade { get; set; }
        public string? estado { get; set; }
        public string? endereco { get; set; }
        public string? cel { get; set; }
        public string? login { get; set; }
        public string? senha { get; set; }

        public Pessoa toPessoa() {
            return new Pessoa()
            {
                Id = this.id,
                Nome = this.nome,
                CEP = this.cep,
                CPF = this.cpf,
                Cidade = this.cidade,
                Estado = this.estado,
                Endereco = this.endereco,
                Cel = this.cel
            };
        }

        public Login toLogin(Guid id_pessoa)
        {
            return new Login()
            {
               LoginNome = this.login,
               Senha = this.senha,
               Pessoa_id = id_pessoa
            };
        }
    }
}
