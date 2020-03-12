using Microsoft.EntityFrameworkCore.Migrations;

namespace _2doParcial_Aplicada.Migrations
{
    public partial class dfr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Llamadas",
                columns: table => new
                {
                    LlamadaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamadas", x => x.LlamadaId);
                });

            migrationBuilder.CreateTable(
                name: "LLamadasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LlamadaId = table.Column<int>(nullable: false),
                    Problema = table.Column<string>(nullable: true),
                    Solucion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LLamadasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LLamadasDetalle_Llamadas_LlamadaId",
                        column: x => x.LlamadaId,
                        principalTable: "Llamadas",
                        principalColumn: "LlamadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LLamadasDetalle_LlamadaId",
                table: "LLamadasDetalle",
                column: "LlamadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LLamadasDetalle");

            migrationBuilder.DropTable(
                name: "Llamadas");
        }
    }
}
