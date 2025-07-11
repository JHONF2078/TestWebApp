using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWebApp.DataAccess.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    nombre = table.Column<string>(maxLength: 100, nullable: true),
                    apellido = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuId);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "usuId", "apellido", "nombre" },
                values: new object[,]
                {
                    { 1m, "Pérez", "Juan" },
                    { 2m, "García", "Ana" },
                    { 3m, "Martínez", "Luis" },
                    { 4m, "López", "María" },
                    { 5m, "Ramírez", "Carlos" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
