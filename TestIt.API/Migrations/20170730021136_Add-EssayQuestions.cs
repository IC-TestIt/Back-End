using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIt.API.Migrations
{
    public partial class AddEssayQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Questions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 373, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 373, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 392, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 392, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 29, 23, 11, 36, 350, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "EssayQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssayQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EssayQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EssayQuestions_QuestionId",
                table: "EssayQuestions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EssayQuestions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 373, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 373, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 392, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 392, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Questions",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 25, 16, 6, 2, 398, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 29, 23, 11, 36, 350, DateTimeKind.Local));
        }
    }
}
