using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIt.API.Migrations
{
    public partial class NullableFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AlternativeId",
                table: "AnsweredQuestions",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AlternativeId",
                table: "AnsweredQuestions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
