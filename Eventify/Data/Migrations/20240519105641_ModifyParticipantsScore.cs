using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventify.Migrations
{
    /// <inheritdoc />
    public partial class ModifyParticipantsScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsScores_JudgeActivity_JudgeID",
                table: "ParticipantsScores");

            migrationBuilder.RenameColumn(
                name: "JudgeID",
                table: "ParticipantsScores",
                newName: "JudgeId");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantsScores_JudgeID",
                table: "ParticipantsScores",
                newName: "IX_ParticipantsScores_JudgeId");

            migrationBuilder.AlterColumn<string>(
                name: "JudgedBy",
                table: "ParticipantsScores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "JudgeId",
                table: "ParticipantsScores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsScores_AspNetUsers_JudgeId",
                table: "ParticipantsScores",
                column: "JudgeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsScores_AspNetUsers_JudgeId",
                table: "ParticipantsScores");

            migrationBuilder.RenameColumn(
                name: "JudgeId",
                table: "ParticipantsScores",
                newName: "JudgeID");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantsScores_JudgeId",
                table: "ParticipantsScores",
                newName: "IX_ParticipantsScores_JudgeID");

            migrationBuilder.AlterColumn<int>(
                name: "JudgedBy",
                table: "ParticipantsScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "JudgeID",
                table: "ParticipantsScores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsScores_JudgeActivity_JudgeID",
                table: "ParticipantsScores",
                column: "JudgeID",
                principalTable: "JudgeActivity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
