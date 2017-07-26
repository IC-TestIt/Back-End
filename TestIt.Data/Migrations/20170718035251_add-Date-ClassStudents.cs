using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIt.Data.Migrations
{
    public partial class addDateClassStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 117, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 542, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 103, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 533, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 132, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 551, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 132, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 551, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 556, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 556, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 556, DateTimeKind.Local));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ClassStudents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "ClassStudents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 144, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 557, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ClassStudents");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ClassStudents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 542, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 117, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 533, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 103, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 551, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 132, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 551, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 132, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 556, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 556, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 556, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 17, 15, 13, 29, 557, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 144, DateTimeKind.Local));
        }
    }
}
