using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIt.API.Migrations
{
    public partial class AddAlternativeQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2017, 7, 29, 23, 11, 36, 350, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "AlternativeQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlternativeId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alternatives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlternativeQuestionId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alternatives_AlternativeQuestions_AlternativeQuestionId",
                        column: x => x.AlternativeQuestionId,
                        principalTable: "AlternativeQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternatives_AlternativeQuestionId",
                table: "Alternatives",
                column: "AlternativeQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeQuestions_AlternativeId",
                table: "AlternativeQuestions",
                column: "AlternativeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeQuestions_QuestionId",
                table: "AlternativeQuestions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeQuestions_Alternatives_AlternativeId",
                table: "AlternativeQuestions",
                column: "AlternativeId",
                principalTable: "Alternatives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_AlternativeQuestions_AlternativeQuestionId",
                table: "Alternatives");

            migrationBuilder.DropTable(
                name: "AlternativeQuestions");

            migrationBuilder.DropTable(
                name: "Alternatives");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2017, 7, 29, 23, 11, 36, 350, DateTimeKind.Local),
                oldClrType: typeof(DateTime));
        }
    }
}
