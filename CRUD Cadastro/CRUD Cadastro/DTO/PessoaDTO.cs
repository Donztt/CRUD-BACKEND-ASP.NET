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
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string CPF { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Endereco { get; set; }
        public string Cel { get; set; }

        public Pessoa toPessoa() {
            return new Pessoa()
            {
                Id = this.Id,
                Nome = this.Nome,
                CEP = this.CEP,
                CPF = this.CPF,
                Cidade = this.Cidade,
                Estado = this.Estado,
                Endereco = this.Endereco,
                Cel = this.Cel
            };
        }
    }
}
