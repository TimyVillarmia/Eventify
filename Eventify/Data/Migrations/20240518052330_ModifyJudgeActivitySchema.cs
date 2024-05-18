using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventify.Migrations
{
    /// <inheritdoc />
    public partial class ModifyJudgeActivitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_JudgeActivity_JudgeActivityID",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgeActivity_AspNetUsers_UserId",
                table: "JudgeActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsScore_Criteria_CriteriaId",
                table: "ParticipantsScore");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsScore_JudgeActivity_JudgeID",
                table: "ParticipantsScore");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsScore_Participants_ParticipantId",
                table: "ParticipantsScore");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Activity_ActivityId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Participants_ParticipantId",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Activity_JudgeActivityID",
                table: "Activity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantsScore",
                table: "ParticipantsScore");

            migrationBuilder.DropColumn(
                name: "JudgeActivityID",
                table: "Activity");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "Results");

            migrationBuilder.RenameTable(
                name: "ParticipantsScore",
                newName: "ParticipantsScores");

            migrationBuilder.RenameIndex(
                name: "IX_Result_ParticipantId",
                table: "Results",
                newName: "IX_Results_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Result_ActivityId",
                table: "Results",
                newName: "IX_Results_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantsScore_ParticipantId",
                table: "ParticipantsScores",
                newName: "IX_ParticipantsScores_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantsScore_JudgeID",
                table: "ParticipantsScores",
                newName: "IX_ParticipantsScores_JudgeID");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantsScore_CriteriaId",
                table: "ParticipantsScores",
                newName: "IX_ParticipantsScores_CriteriaId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "JudgeActivity",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ActivityID",
                table: "JudgeActivity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantsScores",
                table: "ParticipantsScores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeActivity_ActivityID",
                table: "JudgeActivity",
                column: "ActivityID");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeActivity_Activity_ActivityID",
                table: "JudgeActivity",
                column: "ActivityID",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeActivity_AspNetUsers_UserId",
                table: "JudgeActivity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsScores_Criteria_CriteriaId",
                table: "ParticipantsScores",
                column: "CriteriaId",
                principalTable: "Criteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsScores_JudgeActivity_JudgeID",
                table: "ParticipantsScores",
                column: "JudgeID",
                principalTable: "JudgeActivity",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsScores_Participants_ParticipantId",
                table: "ParticipantsScores",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Activity_ActivityId",
                table: "Results",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Participants_ParticipantId",
                table: "Results",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgeActivity_Activity_ActivityID",
                table: "JudgeActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgeActivity_AspNetUsers_UserId",
                table: "JudgeActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsScores_Criteria_CriteriaId",
                table: "ParticipantsScores");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsScores_JudgeActivity_JudgeID",
                table: "ParticipantsScores");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsScores_Participants_ParticipantId",
                table: "ParticipantsScores");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Activity_ActivityId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Participants_ParticipantId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_JudgeActivity_ActivityID",
                table: "JudgeActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantsScores",
                table: "ParticipantsScores");

            migrationBuilder.DropColumn(
                name: "ActivityID",
                table: "JudgeActivity");

            migrationBuilder.RenameTable(
                name: "Results",
                newName: "Result");

            migrationBuilder.RenameTable(
                name: "ParticipantsScores",
                newName: "ParticipantsScore");

            migrationBuilder.RenameIndex(
                name: "IX_Results_ParticipantId",
                table: "Result",
                newName: "IX_Result_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_ActivityId",
                table: "Result",
                newName: "IX_Result_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantsScores_ParticipantId",
                table: "ParticipantsScore",
                newName: "IX_ParticipantsScore_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantsScores_JudgeID",
                table: "ParticipantsScore",
                newName: "IX_ParticipantsScore_JudgeID");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantsScores_CriteriaId",
                table: "ParticipantsScore",
                newName: "IX_ParticipantsScore_CriteriaId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "JudgeActivity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JudgeActivityID",
                table: "Activity",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result",
                table: "Result",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantsScore",
                table: "ParticipantsScore",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_JudgeActivityID",
                table: "Activity",
                column: "JudgeActivityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_JudgeActivity_JudgeActivityID",
                table: "Activity",
                column: "JudgeActivityID",
                principalTable: "JudgeActivity",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeActivity_AspNetUsers_UserId",
                table: "JudgeActivity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsScore_Criteria_CriteriaId",
                table: "ParticipantsScore",
                column: "CriteriaId",
                principalTable: "Criteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsScore_JudgeActivity_JudgeID",
                table: "ParticipantsScore",
                column: "JudgeID",
                principalTable: "JudgeActivity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsScore_Participants_ParticipantId",
                table: "ParticipantsScore",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Activity_ActivityId",
                table: "Result",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Participants_ParticipantId",
                table: "Result",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
