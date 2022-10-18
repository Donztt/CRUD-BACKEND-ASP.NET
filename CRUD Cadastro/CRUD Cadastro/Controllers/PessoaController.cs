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
    [Route("api/Pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly Contexto _context;

        public PessoaController(Contexto context)
        {
            _context = context;
        }
        [HttpGet]
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

        [HttpPost("/update")]
        public async Task<IActionResult> Update([FromBody] PessoaDTO pessoa)
        {
            try
            {
                _context.Update(pessoa.toPessoa());
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa([FromForm] Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPessoa", new { id = pessoa.Id }, pessoa);
        }
        [HttpDelete("/delete/{id}")]
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

        [HttpPost(template: "Login")]
        public async Task<IActionResult> Login(string login)
        {
            var loginResponse = await _context.Pessoa.FindAsync(login);
            if (loginResponse == null)
            {
                return NotFound();
            }

            return Ok(login); 
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
