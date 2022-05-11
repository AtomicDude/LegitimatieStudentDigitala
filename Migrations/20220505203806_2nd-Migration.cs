using Microsoft.EntityFrameworkCore.Migrations;

namespace LegitimatieStudentDigitala.Migrations
{
    public partial class _2ndMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[Domenii_UPDATE] ON [dbo].[Domenii]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.Domenii
                    SET DataModificat = GETDATE()
                    WHERE Id = @auxId
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[Facultati_UPDATE] ON [dbo].[Facultati]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.Facultati
                    SET DataModificat = GETDATE()
                    WHERE Id = @auxId
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[StudiiUniversitare_UPDATE] ON [dbo].[StudiiUniversitare]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.StudiiUniversitare
                    SET DataModificat = GETDATE()
                    WHERE Id = @auxId
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER [dbo].[Useri_UPDATE] ON [dbo].[Useri]
                    AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                    DECLARE @auxId uniqueidentifier

                    SELECT @auxId = INSERTED.Id
                    FROM INSERTED

                    UPDATE dbo.Useri
                    SET DataModificat = GETDATE()
                    WHERE Id = @auxId
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
