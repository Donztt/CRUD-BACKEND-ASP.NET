using CRUD_Cadastro.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Cadastro.Model
{
    [Table("PESSOA")]
    public class Pessoa
    {
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("CEP")]
        public string CEP { get; set; }
        [Column("CPF")]
        public string CPF { get; set; }
        [Column("CIDADE")]
        public string Cidade { get; set; }
        [Column("ESTADO")]
        public string Estado { get; set; }
        [Column("ENDERECO")]
        public string Endereco { get; set; }
        [Column("CEL")]
        public string Cel { get; set; }

        public PessoaDTO toDTO() {
            return new PessoaDTO()
            {
                id = this.Id,
                nome = this.Nome,
                cep = this.CEP,
                cpf = this.CPF,
                cidade = this.Cidade,
                estado = this.Estado,
                endereco = this.Endereco,
                cel = this.Cel
            };
        }
    }
}
