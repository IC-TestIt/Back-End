using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIt.API.Migrations
{
    public partial class AddFieldIsCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_AlternativeQuestions_AlternativeQuestionId",
                table: "Alternatives");

            migrationBuilder.DropForeignKey(
                name: "FK_AlternativeQuestions_Alternatives_AlternativeId",
                table: "AlternativeQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AlternativeQuestions_AlternativeId",
                table: "AlternativeQuestions");

            migrationBuilder.DropColumn(
                name: "AlternativeId",
                table: "AlternativeQuestions");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Alternatives",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Alternatives_AlternativeQuestions_AlternativeQuestionId",
                table: "Alternatives",
                column: "AlternativeQuestionId",
                principalTable: "AlternativeQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_AlternativeQuestions_AlternativeQuestionId",
                table: "Alternatives");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Alternatives");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "Active");

            migrationBuilder.AddColumn<int>(
                name: "AlternativeId",
                table: "AlternativeQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeQuestions_AlternativeId",
                table: "AlternativeQuestions",
                column: "AlternativeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alternatives_AlternativeQuestions_AlternativeQuestionId",
                table: "Alternatives",
                column: "AlternativeQuestionId",
                principalTable: "AlternativeQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeQuestions_Alternatives_AlternativeId",
                table: "AlternativeQuestions",
                column: "AlternativeId",
                principalTable: "Alternatives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
