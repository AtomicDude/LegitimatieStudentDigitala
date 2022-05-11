using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegitimatieStudentDigitala.Migrations
{
    public partial class _5thMigrationRemovedStudiiUniversitare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domenii_StudiiUniversitare_StudiuUniversitarId",
                table: "Domenii");

            migrationBuilder.DropTable(
                name: "StudiiUniversitare");

            migrationBuilder.RenameColumn(
                name: "StudiuUniversitarId",
                table: "Domenii",
                newName: "FacultateId");

            migrationBuilder.RenameIndex(
                name: "IX_Domenii_StudiuUniversitarId",
                table: "Domenii",
                newName: "IX_Domenii_FacultateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domenii_Facultati_FacultateId",
                table: "Domenii",
                column: "FacultateId",
                principalTable: "Facultati",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domenii_Facultati_FacultateId",
                table: "Domenii");

            migrationBuilder.RenameColumn(
                name: "FacultateId",
                table: "Domenii",
                newName: "StudiuUniversitarId");

            migrationBuilder.RenameIndex(
                name: "IX_Domenii_FacultateId",
                table: "Domenii",
                newName: "IX_Domenii_StudiuUniversitarId");

            migrationBuilder.CreateTable(
                name: "StudiiUniversitare",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCreat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModificat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FacultateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nume_Tip_Studiu_Universitar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudiiUniversitare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudiiUniversitare_Facultati_FacultateId",
                        column: x => x.FacultateId,
                        principalTable: "Facultati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudiiUniversitare_FacultateId",
                table: "StudiiUniversitare",
                column: "FacultateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domenii_StudiiUniversitare_StudiuUniversitarId",
                table: "Domenii",
                column: "StudiuUniversitarId",
                principalTable: "StudiiUniversitare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
