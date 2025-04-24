using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ItensPersonagemLOL_API.Migrations
{
    /// <inheritdoc />
    public partial class criacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atributo",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Apresentacao = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributo", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Preco = table.Column<int>(type: "integer", nullable: false),
                    EfeitoAtivo = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: false),
                    ClasseCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Item_Classe_ClasseCodigo",
                        column: x => x.ClasseCodigo,
                        principalTable: "Classe",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personagem",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ClasseCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagem", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Personagem_Classe_ClasseCodigo",
                        column: x => x.ClasseCodigo,
                        principalTable: "Classe",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EfeitosPassivo",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: false),
                    ItemCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EfeitosPassivo", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_EfeitosPassivo_Item_ItemCodigo",
                        column: x => x.ItemCodigo,
                        principalTable: "Item",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemAtributos",
                columns: table => new
                {
                    ItemCodigo = table.Column<int>(type: "integer", nullable: false),
                    AtributoCodigo = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAtributos", x => new { x.ItemCodigo, x.AtributoCodigo });
                    table.ForeignKey(
                        name: "FK_ItemAtributos_Atributo_AtributoCodigo",
                        column: x => x.AtributoCodigo,
                        principalTable: "Atributo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemAtributos_Item_ItemCodigo",
                        column: x => x.ItemCodigo,
                        principalTable: "Item",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemComponente",
                columns: table => new
                {
                    ItemCodigo = table.Column<int>(type: "integer", nullable: false),
                    ComponenteCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemComponente", x => new { x.ItemCodigo, x.ComponenteCodigo });
                    table.ForeignKey(
                        name: "FK_ItemComponente_Item_ComponenteCodigo",
                        column: x => x.ComponenteCodigo,
                        principalTable: "Item",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemComponente_Item_ItemCodigo",
                        column: x => x.ItemCodigo,
                        principalTable: "Item",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemItens",
                columns: table => new
                {
                    PersonagemCodigo = table.Column<int>(type: "integer", nullable: false),
                    ItemCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemItens", x => new { x.PersonagemCodigo, x.ItemCodigo });
                    table.ForeignKey(
                        name: "FK_PersonagemItens_Item_ItemCodigo",
                        column: x => x.ItemCodigo,
                        principalTable: "Item",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemItens_Personagem_PersonagemCodigo",
                        column: x => x.PersonagemCodigo,
                        principalTable: "Personagem",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EfeitosPassivo_ItemCodigo",
                table: "EfeitosPassivo",
                column: "ItemCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ClasseCodigo",
                table: "Item",
                column: "ClasseCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAtributos_AtributoCodigo",
                table: "ItemAtributos",
                column: "AtributoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ItemComponente_ComponenteCodigo",
                table: "ItemComponente",
                column: "ComponenteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Personagem_ClasseCodigo",
                table: "Personagem",
                column: "ClasseCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemItens_ItemCodigo",
                table: "PersonagemItens",
                column: "ItemCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EfeitosPassivo");

            migrationBuilder.DropTable(
                name: "ItemAtributos");

            migrationBuilder.DropTable(
                name: "ItemComponente");

            migrationBuilder.DropTable(
                name: "PersonagemItens");

            migrationBuilder.DropTable(
                name: "Atributo");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Personagem");

            migrationBuilder.DropTable(
                name: "Classe");
        }
    }
}
