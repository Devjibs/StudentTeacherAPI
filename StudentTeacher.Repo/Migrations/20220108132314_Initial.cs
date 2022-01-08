using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTeacher.Repo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Name", "Subject" },
                values: new object[] { 1, "John", "Maths" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Name", "Subject" },
                values: new object[] { 2, "Femi", "English" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Class", "Name", "TeacherId" },
                values: new object[] { 1, "Science", "Azeez", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Class", "Name", "TeacherId" },
                values: new object[] { 2, "Management", "Kamal", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Class", "Name", "TeacherId" },
                values: new object[] { 3, "Science", "Benson", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
