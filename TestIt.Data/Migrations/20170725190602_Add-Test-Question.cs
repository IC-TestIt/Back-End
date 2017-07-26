using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestIt.Data.Migrations
{
    public partial class AddTestQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 373, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 117, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 373, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 103, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 392, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 132, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 392, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 132, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 144, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TeacherId",
                table: "Tests",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 117, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 373, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 103, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 373, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 132, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 392, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 132, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 392, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 141, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 18, 0, 52, 51, 144, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local));
        }
    }
}
