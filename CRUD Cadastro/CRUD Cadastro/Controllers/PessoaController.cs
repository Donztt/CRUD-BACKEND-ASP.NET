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
using CRUD_Cadastro.Service;
using System.Net;


namespace CRUD_Cadastro.Controllers
{
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private PessoaService pessoaService;

        public PessoaController(Contexto context)
        {
            pessoaService = new PessoaService(context);
        }

        [HttpGet("/pessoas")]
        public async Task<ActionResult<List<PessoaDTO>>> GetPessoa()
        {
            try 
            {
                return await pessoaService.GetPessoas();
            }
            catch (Exception) 
            {
                return BadRequest();
            }
        }

        [HttpGet("/getPessoa/{id}")]
        public async Task<ActionResult<PessoaDTO>> GetPessoa(Guid id)
        {
            try 
            {
                return await pessoaService.GetPessoa(id);
            }
            catch (Exception) 
            {
                return BadRequest();
            }
        }

        [HttpPost("/updatePessoa")]
        public async Task<ActionResult> Update([FromBody] PessoaDTO pessoa)
        {
            try
            {
                await pessoaService.UpdatePessoa(pessoa);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("/PostPessoa")]
        public async Task<ActionResult> PostPessoa([FromBody] PessoaDTO pessoa)
        {
            try
            {
                await pessoaService.SetPessoa(pessoa);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/deletePessoa/{id}")]
        public async Task<IActionResult> DeletePessoa(Guid id)
        {
            try
            {
                await pessoaService.DeletePessoa(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
