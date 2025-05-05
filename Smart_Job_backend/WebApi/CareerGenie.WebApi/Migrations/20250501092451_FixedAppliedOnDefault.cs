using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerGenie.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixedAppliedOnDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 1, 9, 24, 51, 301, DateTimeKind.Utc).AddTicks(6474),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2025, 5, 1, 9, 24, 42, 826, DateTimeKind.Utc).AddTicks(7071));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 1, 9, 24, 42, 826, DateTimeKind.Utc).AddTicks(7071),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2025, 5, 1, 9, 24, 51, 301, DateTimeKind.Utc).AddTicks(6474));
        }
    }
}
