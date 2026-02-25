using Bibilioteca.Biblioteca.Api.DTOs;
using Bibilioteca.Biblioteca.Api.Repositories;
using Biblioteca.Api;
using Biblioteca.Api.Context;
using Humanizer;
using Microsoft.Build.Framework;



namespace Bibilioteca.Service
{
    public class EmprestimoService
    {
        private readonly EmprestimoRepository _emprestimoRepository;
        private readonly PessoasRepository _pessoaRepository;
        private readonly LivrosRepository _livrosRepository;
       
        public EmprestimoService(EmprestimoRepository emprestimoRepository, 
               PessoasRepository pessoasRepository, LivrosRepository livrosRepository)

        {
            _emprestimoRepository = emprestimoRepository;
            _pessoaRepository = pessoasRepository;
            _livrosRepository = livrosRepository;
        }

        public async Task GerarEmprestimo (EmprestimoCreateDto dto) 
        {
           // if (dto.IdPessoa <= 0)
             //   throw new ArgumentException("Pessoa invalida");
            //if (dto.IdLivro <= 0)
              //  throw new ArgumentException("Livro invalido");

            var pessoaExiste = await _pessoaRepository.BuscarDb(dto.Pessoa.Email);
            if (pessoaExiste == null)
                throw new ArgumentException("Pessoa não cadastrada");
 

            var livroExiste = await _livrosRepository.VerificarDb(dto.Livro.Nome);
            if (livroExiste == null)
                throw new ArgumentException("Livro não existe");

            if (!livroExiste.Disponivel)
                throw new ArgumentException("O livro não esta disponivel para emprestimo");

            var emprestimo = new Emprestimo
            {
                LivroId = livroExiste.Id,
                PessoaId = dto.Pessoa.Id,
                DataEmprestimo = DateTime.UtcNow,
                Ativo = true,
                DataDevolucaoPrevista = DateTime.UtcNow.AddDays(7)
            };

            await _emprestimoRepository.SalvarEmprestimo(emprestimo);
            livroExiste.Disponivel = false;
            await _livrosRepository.Salvar(livroExiste);
            

            
        }

        public async Task Devolver(int id) // engenharia reversa - atualizar controller antes de começar.
        {

            if (id <= 0)
                throw new ArgumentException("Emprestimo invalido");

            var emprestimo = await _emprestimoRepository.VerificarPorId(id);
            if (emprestimo == null)
                throw new ArgumentException("Emprestimo não existe");
            if (!emprestimo.Ativo)
                throw new ArgumentException("Emprestimo não está ativo");

            emprestimo.Ativo = false;



            var livro = await _livrosRepository.VerificarPorId(emprestimo.LivroId);

            livro.Disponivel = true;
            await _livrosRepository.Salvar(livro);

        }
    }
}