using Bibilioteca.Service;
using Biblioteca.Api;
using Biblioteca.Api.Context;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Bibilioteca.Biblioteca.Api.Repositories
{
    public class PessoasRepository
    {
        private readonly BibliotecaContext _context;

        public PessoasRepository(BibliotecaContext context) 
        {
            _context = context;
        }

        public async Task SalvarPessoa (Pessoa pessoa)
        {
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Verficar(string email)
        {
 
            return await _context.Pessoas.AnyAsync(p => p.Email == email); //anyAsync retorna um bool
  
        }

        public async Task<Pessoa> BuscarDb(string pessoaEmail) 
        {
            Pessoa retorno = await _context.Pessoas.FirstOrDefaultAsync(p => p.Email == pessoaEmail);

            return retorno;


        }

       
    }
}
