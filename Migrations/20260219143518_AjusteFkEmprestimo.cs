using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibilioteca.Migrations
{
    /// <inheritdoc />
    public partial class AjusteFkEmprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Livros_livroId",
                table: "Emprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Pessoas_pessoaId",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "IdLivro",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "IdPessoa",
                table: "Emprestimos");

            migrationBuilder.RenameColumn(
                name: "disponivel",
                table: "Livros",
                newName: "Disponivel");

            migrationBuilder.RenameColumn(
                name: "pessoaId",
                table: "Emprestimos",
                newName: "PessoaId");

            migrationBuilder.RenameColumn(
                name: "livroId",
                table: "Emprestimos",
                newName: "LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Emprestimos_pessoaId",
                table: "Emprestimos",
                newName: "IX_Emprestimos_PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Emprestimos_livroId",
                table: "Emprestimos",
                newName: "IX_Emprestimos_LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Livros_LivroId",
                table: "Emprestimos",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Pessoas_PessoaId",
                table: "Emprestimos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Livros_LivroId",
                table: "Emprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Pessoas_PessoaId",
                table: "Emprestimos");

            migrationBuilder.RenameColumn(
                name: "Disponivel",
                table: "Livros",
                newName: "disponivel");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Emprestimos",
                newName: "pessoaId");

            migrationBuilder.RenameColumn(
                name: "LivroId",
                table: "Emprestimos",
                newName: "livroId");

            migrationBuilder.RenameIndex(
                name: "IX_Emprestimos_PessoaId",
                table: "Emprestimos",
                newName: "IX_Emprestimos_pessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Emprestimos_LivroId",
                table: "Emprestimos",
                newName: "IX_Emprestimos_livroId");

            migrationBuilder.AddColumn<int>(
                name: "IdLivro",
                table: "Emprestimos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPessoa",
                table: "Emprestimos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Livros_livroId",
                table: "Emprestimos",
                column: "livroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Pessoas_pessoaId",
                table: "Emprestimos",
                column: "pessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
