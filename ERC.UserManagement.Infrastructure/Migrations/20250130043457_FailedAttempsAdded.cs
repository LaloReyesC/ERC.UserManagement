using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERC.UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FailedAttempsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ushort>(
                name: "FailedAttemps",
                table: "UserAccounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: (ushort)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedAttemps",
                table: "UserAccounts");
        }
    }
}
