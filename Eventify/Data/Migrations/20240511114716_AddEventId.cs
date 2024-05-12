using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventify.Migrations
{
    /// <inheritdoc />
    public partial class AddEventId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Events_Event_IdId",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_Event_IdId",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "Event_IdId",
                table: "Activity",
                newName: "Event_Id");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Activity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_EventId",
                table: "Activity",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Events_EventId",
                table: "Activity",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Events_EventId",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_EventId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "Event_Id",
                table: "Activity",
                newName: "Event_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Event_IdId",
                table: "Activity",
                column: "Event_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Events_Event_IdId",
                table: "Activity",
                column: "Event_IdId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
