using Microsoft.EntityFrameworkCore.Migrations;

namespace PresonasImagen.Migrations
{
    public partial class CrearMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstudiosModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estudios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiosModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalidadModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalidadModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TitulosModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitulosModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlumnosModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    ImagenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLocalidad = table.Column<int>(type: "int", nullable: false),
                    IdEstudio = table.Column<int>(type: "int", nullable: false),
                    IdTitulo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnosModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumnosModel_EstudiosModel_IdEstudio",
                        column: x => x.IdEstudio,
                        principalTable: "EstudiosModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnosModel_LocalidadModel_IdLocalidad",
                        column: x => x.IdLocalidad,
                        principalTable: "LocalidadModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnosModel_TitulosModel_IdTitulo",
                        column: x => x.IdTitulo,
                        principalTable: "TitulosModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosModel_IdEstudio",
                table: "AlumnosModel",
                column: "IdEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosModel_IdLocalidad",
                table: "AlumnosModel",
                column: "IdLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosModel_IdTitulo",
                table: "AlumnosModel",
                column: "IdTitulo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnosModel");

            migrationBuilder.DropTable(
                name: "EstudiosModel");

            migrationBuilder.DropTable(
                name: "LocalidadModel");

            migrationBuilder.DropTable(
                name: "TitulosModel");
        }
    }
}
