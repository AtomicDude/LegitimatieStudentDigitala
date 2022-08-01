using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegitimatieStudentDigitala.Migrations
{
    public partial class Updatedfacultate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Useri_Facultati_FacultateId",
                table: "Useri");

            migrationBuilder.DropIndex(
                name: "IX_Useri_FacultateId",
                table: "Useri");

            migrationBuilder.DropColumn(
                name: "FacultateId",
                table: "Useri");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FacultateId",
                table: "Useri",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Useri_FacultateId",
                table: "Useri",
                column: "FacultateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Useri_Facultati_FacultateId",
                table: "Useri",
                column: "FacultateId",
                principalTable: "Facultati",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
