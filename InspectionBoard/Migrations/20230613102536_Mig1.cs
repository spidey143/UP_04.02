using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionBoard.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admission",
                columns: table => new
                {
                    id_admission_img = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admission_img = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admission", x => x.id_admission_img);
                });

            migrationBuilder.CreateTable(
                name: "OrphanhoodDocument",
                columns: table => new
                {
                    id_orphanhood_document_img = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orphanhood_document_img = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrphanhoodDocument", x => x.id_orphanhood_document_img);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    id_speciality = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.id_speciality);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id_student = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    date_of_birth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    age = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    education = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    grade_point_average = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    snils = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    attestat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    educational_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    admission = table.Column<bool>(type: "bit", nullable: true),
                    id_admission_img = table.Column<int>(type: "int", nullable: true),
                    id_place_of_residence = table.Column<int>(type: "int", nullable: true),
                    id_speciality = table.Column<int>(type: "int", nullable: true),
                    orphanhood_document = table.Column<bool>(type: "bit", nullable: true),
                    id_orphanhood_document_img = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id_student);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admission");

            migrationBuilder.DropTable(
                name: "OrphanhoodDocument");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
