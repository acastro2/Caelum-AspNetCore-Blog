using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class UniqueLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Nome",
                table: "Usuarios",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Nome",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
