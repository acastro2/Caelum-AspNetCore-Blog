using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class RelacionamentoAutorPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_AutorId",
                table: "Post",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Usuarios_AutorId",
                table: "Post",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Usuarios_AutorId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_AutorId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Post");
        }
    }
}
