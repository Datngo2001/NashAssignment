using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class FixUserAndRoleRelation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleAppUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 20, 2, 19, 56, DateTimeKind.Local).AddTicks(5750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 20, 2, 19, 56, DateTimeKind.Local).AddTicks(6192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 20, 2, 19, 56, DateTimeKind.Local).AddTicks(6037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4691));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 20, 2, 19, 56, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4865),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 20, 2, 19, 56, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 20, 2, 19, 56, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.CreateTable(
                name: "AppRoleAppUser",
                columns: table => new
                {
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleAppUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppRoleAppUser_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRoleAppUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleAppUser_UsersId",
                table: "AppRoleAppUser",
                column: "UsersId");
        }
    }
}
