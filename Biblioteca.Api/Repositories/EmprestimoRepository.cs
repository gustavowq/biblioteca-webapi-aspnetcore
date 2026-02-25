using Bibilioteca.Service;
using Biblioteca.Api;
using Biblioteca.Api.Context;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;



namespace Bibilioteca.Biblioteca.Api.Repositories
{
    public class EmprestimoRepository
    {
        private readonly BibliotecaContext _context;

        public EmprestimoRepository (BibliotecaContext context)
        {
            _context = context;
        }

         public async Task SalvarEmprestimo(Emprestimo emprestimo)
        {
            await _context.Emprestimos.AddAsync(emprestimo);
            await _context.SaveChangesAsync();
        }
        public async Task<Emprestimo> VerificarPorId(int id)
        {
            Emprestimo emprestimo = await _context.Emprestimos.FirstOrDefaultAsync(e => e.Id == id);

            return emprestimo;
        }

        
    }

}
