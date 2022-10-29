using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddRatingTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 15, 33, 48, 607, DateTimeKind.Local).AddTicks(4496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 0, 32, 10, 881, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Ratings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 0, 32, 10, 881, DateTimeKind.Local).AddTicks(3014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 15, 33, 48, 607, DateTimeKind.Local).AddTicks(4496));
        }
    }
}
