using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTA.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Tenants (Id, Name) VALUES ('alpha','Alpha Corporation'),('beta','Beta Pty(Ltd) '),('gamma','Gamma LLC ')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
