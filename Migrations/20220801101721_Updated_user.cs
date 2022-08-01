using Microsoft.EntityFrameworkCore.Migrations;

namespace LegitimatieStudentDigitala.Migrations
{
    public partial class Updated_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNP",
                table: "Useri",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Initiala_Tata",
                table: "Useri",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Serie_Legitimatie",
                table: "Useri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cod_Facultate",
                table: "Facultati",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cod_Domeniu",
                table: "Domenii",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Studiu_Universitar",
                table: "Domenii",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNP",
                table: "Useri");

            migrationBuilder.DropColumn(
                name: "Initiala_Tata",
                table: "Useri");

            migrationBuilder.DropColumn(
                name: "Serie_Legitimatie",
                table: "Useri");

            migrationBuilder.DropColumn(
                name: "Cod_Facultate",
                table: "Facultati");

            migrationBuilder.DropColumn(
                name: "Cod_Domeniu",
                table: "Domenii");

            migrationBuilder.DropColumn(
                name: "Studiu_Universitar",
                table: "Domenii");
        }
    }
}
