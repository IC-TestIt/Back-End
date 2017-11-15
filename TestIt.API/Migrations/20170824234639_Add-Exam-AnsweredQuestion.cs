using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIt.API.Migrations
{
    public partial class AddExamAnsweredQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    ClassTestsId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    TotalGrade = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_ClassTests_ClassTestsId",
                        column: x => x.ClassTestsId,
                        principalTable: "ClassTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exams_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnsweredQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlternativeId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    EssayAnswer = table.Column<string>(nullable: true),
                    ExamId = table.Column<int>(nullable: false),
                    Grade = table.Column<double>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnsweredQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnsweredQuestions_Alternatives_AlternativeId",
                        column: x => x.AlternativeId,
                        principalTable: "Alternatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnsweredQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnsweredQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnsweredQuestions_AlternativeId",
                table: "AnsweredQuestions",
                column: "AlternativeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnsweredQuestions_ExamId",
                table: "AnsweredQuestions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_AnsweredQuestions_QuestionId",
                table: "AnsweredQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ClassTestsId",
                table: "Exams",
                column: "ClassTestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StudentId",
                table: "Exams",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnsweredQuestions");

            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
