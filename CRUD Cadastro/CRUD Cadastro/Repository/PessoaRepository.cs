
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_Cadastro.Settings;
using CRUD_Cadastro.Model;
using CRUD_Cadastro.DTO;
using System.Linq;

namespace CRUD_Cadastro.Repository
{
    public class PessoaRepository
    {
        private readonly Contexto _context;

        public PessoaRepository(Contexto context)
        {
            _context = context;
        }

        public async Task<Pessoa> GetPessoa(int id)
        {
            return await _context.Pessoa.FindAsync(id);
        }
        public async Task<List<Pessoa>> GetPessoas() 
        {
            return await _context.Pessoa.ToListAsync();
        }
        public async void SetPessoa(PessoaDTO dto)
        {
            var pessoaResult = _context.Pessoa.Add(dto.toPessoa());
            _context.Login.Add(dto.toLogin(pessoaResult.Entity.Id));
            await _context.SaveChangesAsync();
        }
        public async void UpdatePessoa(PessoaDTO dto)
        {
            _context.Pessoa.Update(dto.toPessoa());
            await _context.SaveChangesAsync();
        }
        public async void DeletePessoa(int pessoaId)
        {
            await _context.Pessoa.FindAsync(pessoaId);
        }
        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
