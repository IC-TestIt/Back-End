using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIt.API.Migrations
{
    public partial class AddKeyWordsPercentCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "EssayQuestions",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PercentCorrect",
                table: "AnsweredQuestions",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "EssayQuestions");

            migrationBuilder.DropColumn(
                name: "PercentCorrect",
                table: "AnsweredQuestions");
        }
    }
}
