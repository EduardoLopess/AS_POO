using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUsuarioId1Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LivroId1",
                table: "Emprestimo",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_LivroId1",
                table: "Emprestimo",
                column: "LivroId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Livro_LivroId1",
                table: "Emprestimo",
                column: "LivroId1",
                principalTable: "Livro",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Livro_LivroId1",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_LivroId1",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "LivroId1",
                table: "Emprestimo");
        }
    }
}
