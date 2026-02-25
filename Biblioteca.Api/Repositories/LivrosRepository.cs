using Bibilioteca.Service;
using Biblioteca.Api;
using Biblioteca.Api.Context;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


namespace Bibilioteca.Biblioteca.Api.Repositories
{
    public class LivrosRepository
    {
        private readonly BibliotecaContext _context;

        public LivrosRepository(BibliotecaContext context) 
        {
            _context = context;
        }

        public async Task SalvarLivro(Livro livro)
        {
            await _context.AddAsync(livro);
            await _context.SaveChangesAsync();
        }

        public async Task<Livro> VerificarDb(string livro)
        {
            Livro retorno = await _context.Livros.FirstOrDefaultAsync(l => l.Nome == livro); //está retornando null

            return retorno;
        }

        public async Task<List<Livro>> Listar()
        {
            var lista = await _context.Livros.ToListAsync();
            return lista;
        }

        public async Task<Livro> VerificarPorId(int id)
        {
            Livro retorno = await _context.Livros.FirstOrDefaultAsync(l => l.Id == id);

            return retorno;
        }

        public async Task Salvar(Livro livro)
        {
            await _context.SaveChangesAsync();
        }
    }
}
