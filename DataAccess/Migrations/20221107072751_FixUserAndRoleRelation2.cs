using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class FixUserAndRoleRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleAppUser_AspNetRoles_UsersId",
                table: "AppRoleAppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleAppUser_AspNetUsers_UsersId1",
                table: "AppRoleAppUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppRoleAppUser",
                table: "AppRoleAppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppRoleAppUser_UsersId1",
                table: "AppRoleAppUser");

            migrationBuilder.RenameColumn(
                name: "UsersId1",
                table: "AppRoleAppUser",
                newName: "RolesId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(7531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 24, 40, 384, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(8016),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 24, 40, 384, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(7846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 24, 40, 384, DateTimeKind.Local).AddTicks(2895));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppRoleAppUser",
                table: "AppRoleAppUser",
                columns: new[] { "RolesId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleAppUser_UsersId",
                table: "AppRoleAppUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleAppUser_AspNetRoles_RolesId",
                table: "AppRoleAppUser",
                column: "RolesId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleAppUser_AspNetUsers_UsersId",
                table: "AppRoleAppUser",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleAppUser_AspNetRoles_RolesId",
                table: "AppRoleAppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleAppUser_AspNetUsers_UsersId",
                table: "AppRoleAppUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppRoleAppUser",
                table: "AppRoleAppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppRoleAppUser_UsersId",
                table: "AppRoleAppUser");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "AppRoleAppUser",
                newName: "UsersId1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 24, 40, 384, DateTimeKind.Local).AddTicks(2619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 24, 40, 384, DateTimeKind.Local).AddTicks(3063),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 24, 40, 384, DateTimeKind.Local).AddTicks(2895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppRoleAppUser",
                table: "AppRoleAppUser",
                columns: new[] { "UsersId", "UsersId1" });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleAppUser_UsersId1",
                table: "AppRoleAppUser",
                column: "UsersId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleAppUser_AspNetRoles_UsersId",
                table: "AppRoleAppUser",
                column: "UsersId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleAppUser_AspNetUsers_UsersId1",
                table: "AppRoleAppUser",
                column: "UsersId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
