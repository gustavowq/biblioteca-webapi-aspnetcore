using Bibilioteca.Biblioteca.Api.DTOs;
using Bibilioteca.Biblioteca.Api.Repositories;
using Biblioteca.Api;
using Biblioteca.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;



namespace Bibilioteca.Service
{
    public class PessoaService
    {
        private readonly PessoasRepository _repository;

        public PessoaService(PessoasRepository repository, IConfiguration configuration) 
        {
            _repository = repository;
            string con = configuration.GetConnectionString("ConexaoPadrao");
            Console.WriteLine(con);
        }

        public async Task Cadastrar(PessoaCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new Exception("O nome não pode ser nulo");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("O email não pode ser nulo");

      
            bool emailExiste = await _repository.Verficar(dto.Email);

            if (emailExiste )
                throw new Exception("Ja existe um cadastro com o seu email");

            var pessoa = new Pessoa
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Id = dto.id
            };

            await _repository.SalvarPessoa(pessoa);
            

        }

        public async Task<PessoaCreateDto> BuscarPessoa (PessoaCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("O email não pode ser nulo");


            var pessoa = await _repository.BuscarDb(dto.Email);

            if (pessoa == null)
                throw new Exception("Pessoa não cadastrada");

            

            var retorno = new PessoaCreateDto
            {
                Nome = pessoa.Nome, 
                Email = pessoa.Email,
                id = pessoa.Id
            };
           
            return retorno;

        }

    }
}
