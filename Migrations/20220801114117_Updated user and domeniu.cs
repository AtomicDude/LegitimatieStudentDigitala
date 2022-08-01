using Microsoft.EntityFrameworkCore.Migrations;

namespace LegitimatieStudentDigitala.Migrations
{
    public partial class Updateduseranddomeniu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cod_Domeniu",
                table: "Useri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cod_Facultate",
                table: "Domenii",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cod_Domeniu",
                table: "Useri");

            migrationBuilder.DropColumn(
                name: "Cod_Facultate",
                table: "Domenii");
        }
    }
}
