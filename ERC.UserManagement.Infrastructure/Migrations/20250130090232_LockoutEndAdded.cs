using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERC.UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LockoutEndAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LockoutEnd",
                table: "UserAccounts",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "UserAccounts");
        }
    }
}
