
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_Cadastro.Settings;
using CRUD_Cadastro.Model;
using CRUD_Cadastro.DTO;
using System.Linq;
using System;

namespace CRUD_Cadastro.Repository
{
    public class PessoaRepository
    {
        private readonly Contexto _context;

        public PessoaRepository(Contexto context)
        {
            _context = context;
        }

        public async Task<Pessoa> GetPessoa(Guid id)
        {
            return await _context.Pessoa.FindAsync(id);
        }
        public async Task<List<Pessoa>> GetPessoas() 
        {
            return await _context.Pessoa.ToListAsync();
        }
        public async Task SetPessoa(PessoaDTO dto)
        {
            dto.id = Guid.NewGuid();
            _context.Pessoa.Add(dto.toPessoa());
            _context.Login.Add(dto.toLogin(dto.id));
            await _context.SaveChangesAsync();
        } 
        public async Task UpdatePessoa(PessoaDTO dto)
        {
            _context.Pessoa.Update(dto.toPessoa());
            await _context.SaveChangesAsync();
        }
        public async Task DeletePessoa(Guid pessoaId)
        {
            Pessoa pessoa = await _context.Pessoa.FindAsync(pessoaId);
            Login login = await _context.Login.Where(l => l.Pessoa_id == pessoa.Id).FirstAsync();
            _context.Login.Remove(login);
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
        }
        private bool PessoaExists(Guid id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
