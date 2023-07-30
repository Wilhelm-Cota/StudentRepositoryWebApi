using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRestApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Department", "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { 1, "Back-end Developer", "pauluswilhelm85@gmail.com", " Paulus", 0, "Wilhelm" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Department", "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { 2, "Front-end Developer", "TK@MAIL.COM", "Tangi", 0, "Kandjimwena" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Department", "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { 3, "Graphics Designer", "I@gmail.com", "Imms", 0, "Immunel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
