using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestIt.Data.Migrations
{
    public partial class AddManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Students_StudentId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Classes_StudentId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Classes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 901, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 468, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 890, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 460, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 912, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 912, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 917, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 481, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "SocialIds",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 918, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "SocialIds",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 917, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 918, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 918, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 919, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 483, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "ClassStudents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_ClassId",
                table: "ClassStudents",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_StudentId",
                table: "ClassStudents",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 468, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 901, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 460, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 890, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 912, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 912, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 481, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 917, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "SocialIds",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 918, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "SocialIds",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 917, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 918, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 918, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 12, 13, 19, 14, 483, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 12, 16, 16, 1, 919, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_StudentId",
                table: "Classes",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Students_StudentId",
                table: "Classes",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
