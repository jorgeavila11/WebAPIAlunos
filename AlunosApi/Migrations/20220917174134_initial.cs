using Microsoft.EntityFrameworkCore.Migrations;

namespace AlunosApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "Email", "Idade", "Nome" },
                values: new object[] { 1, "mariapenha@yahoo.com", 23, "Maria da Penha" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "Email", "Idade", "Nome" },
                values: new object[] { 2, "manuelbueno@yahoo.com", 22, "Manuel Bueno" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "Email", "Idade", "Nome" },
                values: new object[] { 3, "jorgeavila@yahoo.com", 37, "Jorge Ávila" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
