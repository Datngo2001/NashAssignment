using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class FixUserAndRoleRelation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4865),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(7846));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(7531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(8016),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 7, 14, 27, 51, 407, DateTimeKind.Local).AddTicks(7846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 7, 15, 41, 17, 901, DateTimeKind.Local).AddTicks(4691));
        }
    }
}
