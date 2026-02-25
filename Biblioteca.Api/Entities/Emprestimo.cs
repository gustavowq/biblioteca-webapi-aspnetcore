namespace Biblioteca.Api;

public class Emprestimo
{
    public int Id {get; set;}
    public DateTime DataEmprestimo{get;set;}
    public DateTime DataDevolucaoPrevista { get; set; } 
    public bool Ativo{get; set;}

    public int PessoaId{get; set;}
    public int LivroId { get; set;}

    public Pessoa pessoa{get; set;} =null!;
    public Livro livro{ get; set;} = null!;

}
