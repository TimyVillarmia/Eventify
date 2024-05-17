using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventify.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEventifySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JudgeActivityID",
                table: "Activity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriteriaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityID = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    MaxScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Criteria_Activity_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JudgeActivity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeActivity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JudgeActivity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    OverallScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantsScore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<double>(type: "float", nullable: false),
                    CriteriaId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    JudgedBy = table.Column<int>(type: "int", nullable: false),
                    JudgeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantsScore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantsScore_Criteria_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "Criteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantsScore_JudgeActivity_JudgeID",
                        column: x => x.JudgeID,
                        principalTable: "JudgeActivity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantsScore_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_JudgeActivityID",
                table: "Activity",
                column: "JudgeActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_ActivityID",
                table: "Criteria",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeActivity_UserId",
                table: "JudgeActivity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantsScore_CriteriaId",
                table: "ParticipantsScore",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantsScore_JudgeID",
                table: "ParticipantsScore",
                column: "JudgeID");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantsScore_ParticipantId",
                table: "ParticipantsScore",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_ActivityId",
                table: "Result",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_ParticipantId",
                table: "Result",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_JudgeActivity_JudgeActivityID",
                table: "Activity",
                column: "JudgeActivityID",
                principalTable: "JudgeActivity",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_JudgeActivity_JudgeActivityID",
                table: "Activity");

            migrationBuilder.DropTable(
                name: "ParticipantsScore");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "JudgeActivity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_JudgeActivityID",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "JudgeActivityID",
                table: "Activity");
        }
    }
}
