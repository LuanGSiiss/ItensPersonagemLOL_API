using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItensPersonagemLOL_API.Migrations
{
    /// <inheritdoc />
    public partial class ajustesFinos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Classe",
                newName: "Descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Classe",
                newName: "descricao");
        }
    }
}
