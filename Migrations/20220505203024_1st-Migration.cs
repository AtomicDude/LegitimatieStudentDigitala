using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegitimatieStudentDigitala.Migrations
{
    public partial class _1stMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facultati",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Numar_Telefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Numar_FAX = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataCreat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModificat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudiiUniversitare",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume_Tip_Studiu_Universitar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCreat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModificat = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Domenii",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Forma_Invatamant = table.Column<int>(type: "int", nullable: false),
                    Numar_Ani = table.Column<long>(type: "bigint", nullable: false),
                    StudiuUniversitarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCreat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModificat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domenii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domenii_StudiiUniversitare_StudiuUniversitarId",
                        column: x => x.StudiuUniversitarId,
                        principalTable: "StudiiUniversitare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Useri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Forma_Finantare = table.Column<int>(type: "int", nullable: false),
                    Stare_Inmatriculare = table.Column<int>(type: "int", nullable: false),
                    An_Curent = table.Column<long>(type: "bigint", nullable: false),
                    Cod_Legitimatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path_Poza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomeniuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacultateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCreat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModificat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Useri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Useri_Domenii_DomeniuId",
                        column: x => x.DomeniuId,
                        principalTable: "Domenii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Useri_Facultati_FacultateId",
                        column: x => x.FacultateId,
                        principalTable: "Facultati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domenii_StudiuUniversitarId",
                table: "Domenii",
                column: "StudiuUniversitarId");

            migrationBuilder.CreateIndex(
                name: "IX_StudiiUniversitare_FacultateId",
                table: "StudiiUniversitare",
                column: "FacultateId");

            migrationBuilder.CreateIndex(
                name: "IX_Useri_DomeniuId",
                table: "Useri",
                column: "DomeniuId");

            migrationBuilder.CreateIndex(
                name: "IX_Useri_FacultateId",
                table: "Useri",
                column: "FacultateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Useri");

            migrationBuilder.DropTable(
                name: "Domenii");

            migrationBuilder.DropTable(
                name: "StudiiUniversitare");

            migrationBuilder.DropTable(
                name: "Facultati");
        }
    }
}
