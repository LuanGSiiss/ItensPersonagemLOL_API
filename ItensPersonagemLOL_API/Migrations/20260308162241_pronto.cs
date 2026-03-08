using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ItensPersonagemLOL_API.Migrations
{
    /// <inheritdoc />
    public partial class pronto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemAtributos",
                table: "ItemAtributos");

            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "ItemAtributos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemAtributos",
                table: "ItemAtributos",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAtributos_ItemCodigo",
                table: "ItemAtributos",
                column: "ItemCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemAtributos",
                table: "ItemAtributos");

            migrationBuilder.DropIndex(
                name: "IX_ItemAtributos_ItemCodigo",
                table: "ItemAtributos");

            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "ItemAtributos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemAtributos",
                table: "ItemAtributos",
                columns: new[] { "ItemCodigo", "AtributoCodigo" });
        }
    }
}
