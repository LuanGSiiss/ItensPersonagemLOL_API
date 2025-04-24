using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItensPersonagemLOL_API.Migrations
{
    /// <inheritdoc />
    public partial class ajustesFinos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EfeitoAtivo",
                table: "Item",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(800)",
                oldMaxLength: 800);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EfeitoAtivo",
                table: "Item",
                type: "character varying(800)",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
