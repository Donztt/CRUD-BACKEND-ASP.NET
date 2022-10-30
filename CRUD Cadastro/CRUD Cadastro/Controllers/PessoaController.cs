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
    [Route("/Pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly Contexto _context;

        public PessoaController(Contexto context)
        {
            _context = context;
        }
        [HttpGet("/pessoas")]
        public async Task<List<Pessoa>> GetPessoa()
        {
            return await  _context.Pessoa.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var Pessoa = await _context.Pessoa.FindAsync(id);

            if (Pessoa == null)
            {
                return NotFound();
            }

            return Pessoa;
        }

        [HttpPost("/updatePessoa")]
        public async Task<IActionResult> Update([FromBody] PessoaDTO pessoa)
        {
            try
            {
                _context.Pessoa.Update(pessoa.toPessoa());
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("/PostPessoa")]
        public async Task<IActionResult> PostPessoa([FromBody] PessoaDTO pessoa)
        {
            var pessoaResult = _context.Pessoa.Add(pessoa.toPessoa());
            _context.Login.Add(pessoa.toLogin(pessoaResult.Entity.Id));
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("/deletePessoa/{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            var Pessoa = await _context.Pessoa.FindAsync(id);
            if (Pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoa.Remove(Pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
