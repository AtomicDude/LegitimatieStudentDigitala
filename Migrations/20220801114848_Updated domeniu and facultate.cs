using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegitimatieStudentDigitala.Migrations
{
    public partial class Updateddomeniuandfacultate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domenii_Facultati_FacultateId",
                table: "Domenii");

            migrationBuilder.DropForeignKey(
                name: "FK_Useri_Domenii_DomeniuId",
                table: "Useri");

            migrationBuilder.DropIndex(
                name: "IX_Useri_DomeniuId",
                table: "Useri");

            migrationBuilder.DropIndex(
                name: "IX_Domenii_FacultateId",
                table: "Domenii");

            migrationBuilder.DropColumn(
                name: "DomeniuId",
                table: "Useri");

            migrationBuilder.DropColumn(
                name: "FacultateId",
                table: "Domenii");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DomeniuId",
                table: "Useri",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FacultateId",
                table: "Domenii",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Useri_DomeniuId",
                table: "Useri",
                column: "DomeniuId");

            migrationBuilder.CreateIndex(
                name: "IX_Domenii_FacultateId",
                table: "Domenii",
                column: "FacultateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domenii_Facultati_FacultateId",
                table: "Domenii",
                column: "FacultateId",
                principalTable: "Facultati",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Useri_Domenii_DomeniuId",
                table: "Useri",
                column: "DomeniuId",
                principalTable: "Domenii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
