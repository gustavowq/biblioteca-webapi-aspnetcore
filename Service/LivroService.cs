using Bibilioteca.Biblioteca.Api.DTOs;
using Bibilioteca.Biblioteca.Api.Repositories;
using Biblioteca.Api;
using Biblioteca.Api.Context;
using Microsoft.AspNetCore.Mvc;

namespace Bibilioteca.Service
{
    public class LivroService // Class que leva os dados ate o EF
    {
        private readonly LivrosRepository _repository;

        public LivroService(LivrosRepository repository)
        {
            _repository = repository;
        }

        public async Task Cadastrar(LivroCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new Exception("Nome do livro invalido");

            var livro = new Livro //Da valor as propriedades do Objeto Livro, utilizando do argumento do metodo
            {
                Nome = dto.Nome,
                Disponivel = dto.Disponivel, 
                Id = dto.id
            };

            await _repository.SalvarLivro(livro);
           

        }

        public async Task<List<LivroCreateDto>> ListarLivros()
        {
            var LivrosBanco = await _repository.Listar(); //recebe as informações do DB
            var LivrosDto = new List<LivroCreateDto>(); //Cria uma lista vazia do tipo DTO

            foreach(var livro in LivrosBanco) 
            {
                var dto = new LivroCreateDto(); //Cria um objeto DTO para receber os dados 

                dto.Nome = livro.Nome;
                dto.Disponivel = livro.Disponivel;


                LivrosDto.Add(dto); //Adiciona na lista que estava vazia
            }

            return LivrosDto;

        }

        public async Task <LivroCreateDto> BuscarLivro([FromQuery]LivroCreateDto dto)
        {
           // if (string.IsNullOrWhiteSpace(dto.Nome))
             //  throw new Exception("Nome do livro invalido");

            var NomeBusca = dto.Nome;
            var livro = await _repository.VerificarDb(NomeBusca);
            

            if (livro == null)
                throw new Exception("O livro buscado não existe");

            if (!livro.Disponivel)
                throw new Exception("O livro buscado não está disponivel");

            var retorno = new LivroCreateDto()
            {
                Nome = livro.Nome,
                Disponivel = livro.Disponivel,
                id = livro.Id
            };

            return retorno;

        }
    }
}
