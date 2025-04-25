using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItensPersonagemLOL_API.Migrations
{
    /// <inheritdoc />
    public partial class correcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "PersonagemItens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "ItemComponente",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "ItemAtributos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "PersonagemItens");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "ItemComponente");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "ItemAtributos");
        }
    }
}
