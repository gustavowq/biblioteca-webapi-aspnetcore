using Biblioteca.Api;

namespace Bibilioteca.Biblioteca.Api.DTOs
{
    public class EmprestimoCreateDto
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; } 
        public bool Ativo { get; set; }

        public int IdPessoa { get; set; }
        public int IdLivro { get; set; }

        public Pessoa Pessoa { get; set; } = null!;
        public Livro Livro { get; set; } = null!;


    }
}
