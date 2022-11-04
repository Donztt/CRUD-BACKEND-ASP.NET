using CRUD_Cadastro.DTO;
using CRUD_Cadastro.Model;
using CRUD_Cadastro.Repository;
using CRUD_Cadastro.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Cadastro.Service
{
    public class PessoaService 
    {
        private PessoaRepository pessoaRepository;

        public PessoaService(Contexto context)
        {
            pessoaRepository = new PessoaRepository(context);
        }

        public async Task<PessoaDTO> GetPessoa(int id)
        {    
            var pessoa = await pessoaRepository.GetPessoa(id);
            return pessoa.toDTO();
        }
        public async Task<List<PessoaDTO>> GetPessoas()
        {
            List<Pessoa> pessoas = await pessoaRepository.GetPessoas();

            List<PessoaDTO> pessoasDTO = new List<PessoaDTO>();
            foreach (Pessoa p in pessoas) {
                pessoasDTO.Add(p.toDTO());
            }
            
            return pessoasDTO;
        }
        public void SetPessoa(PessoaDTO dto)
        {
            pessoaRepository.SetPessoa(dto);
        }
        public void UpdatePessoa(PessoaDTO dto)
        {
            pessoaRepository.UpdatePessoa(dto);
        }
        public void DeletePessoa(int pessoaId)
        {
            pessoaRepository.DeletePessoa(pessoaId);
        }
    }
}
