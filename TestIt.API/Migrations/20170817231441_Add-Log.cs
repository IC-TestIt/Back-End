using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIt.API.Migrations
{
    public partial class AddLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EssayQuestions_QuestionId",
                table: "EssayQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AlternativeQuestions_QuestionId",
                table: "AlternativeQuestions");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Class = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EssayQuestions_QuestionId",
                table: "EssayQuestions",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeQuestions_QuestionId",
                table: "AlternativeQuestions",
                column: "QuestionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_EssayQuestions_QuestionId",
                table: "EssayQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AlternativeQuestions_QuestionId",
                table: "AlternativeQuestions");

            migrationBuilder.CreateIndex(
                name: "IX_EssayQuestions_QuestionId",
                table: "EssayQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeQuestions_QuestionId",
                table: "AlternativeQuestions",
                column: "QuestionId");
        }
    }
}
