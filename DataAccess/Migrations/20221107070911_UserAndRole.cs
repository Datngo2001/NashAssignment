using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_ApplicationUserId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Ratings",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_ApplicationUserId",
                table: "Ratings",
                newName: "IX_Ratings_AppUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 9, 10, 938, DateTimeKind.Local).AddTicks(2720),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 1, 29, 46, 652, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 9, 10, 938, DateTimeKind.Local).AddTicks(3236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 1, 29, 46, 652, DateTimeKind.Local).AddTicks(5388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 9, 10, 938, DateTimeKind.Local).AddTicks(3067),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 1, 29, 46, 652, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppRoleId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserId",
                table: "AspNetUsers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_AppRoleId",
                table: "AspNetRoles",
                column: "AppRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_AppRoleId",
                table: "AspNetRoles",
                column: "AppRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AppUserId",
                table: "AspNetUsers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_AppUserId",
                table: "Ratings",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_AppRoleId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AppUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_AppUserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AppUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AppRoleId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Ratings",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_AppUserId",
                table: "Ratings",
                newName: "IX_Ratings_ApplicationUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 1, 29, 46, 652, DateTimeKind.Local).AddTicks(4522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 9, 10, 938, DateTimeKind.Local).AddTicks(2720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 1, 29, 46, 652, DateTimeKind.Local).AddTicks(5388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 9, 10, 938, DateTimeKind.Local).AddTicks(3236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 1, 29, 46, 652, DateTimeKind.Local).AddTicks(5108),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 9, 10, 938, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_ApplicationUserId",
                table: "Ratings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
