using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetPdf.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    idPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.idPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    idEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sueldo = table.Column<int>(type: "int", nullable: false),
                    idPerfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.idEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Perfil_idPerfil",
                        column: x => x.idPerfil,
                        principalTable: "Perfil",
                        principalColumn: "idPerfil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "idPerfil", "Nombre" },
                values: new object[] { 1, "Nilo" });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_idPerfil",
                table: "Empleado",
                column: "idPerfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
