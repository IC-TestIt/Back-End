using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIt.Data.Migrations
{
    public partial class AddOrganizationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 468, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 844, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 460, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 836, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 853, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 853, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 481, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 858, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "SocialIds",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 858, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "SocialIds",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 858, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 859, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 483, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 860, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 844, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 468, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 836, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 460, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 853, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 853, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 858, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 481, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "SocialIds",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 858, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "SocialIds",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 858, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 859, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 12, 58, 16, 860, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 483, DateTimeKind.Local));
        }
    }
}
