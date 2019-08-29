using Microsoft.EntityFrameworkCore.Migrations;

namespace Polling.Migrations
{
    public partial class RestructuringRelationships_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Polls_PollId",
                table: "Answers");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Polls_PollId",
                table: "Answers",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Polls_PollId",
                table: "Answers");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Polls_PollId",
                table: "Answers",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
