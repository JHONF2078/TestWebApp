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
                    usuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 100, nullable: false),
                    apellido = table.Column<string>(maxLength: 100, nullable: false)
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
                    { 1, "Pérez", "Juan" },
                    { 2, "García", "Ana" },
                    { 3, "Martínez", "Luis" },
                    { 4, "López", "María" },
                    { 5, "Ramírez", "Carlos" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
