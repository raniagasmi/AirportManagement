using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpilot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationTicket_Passengers_PassengerFK",
                table: "ReservationTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationTicket_Ticket_TicketFK",
                table: "ReservationTicket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationTicket",
                table: "ReservationTicket");

            migrationBuilder.RenameTable(
                name: "ReservationTicket",
                newName: "ResTicket");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationTicket_PassengerFK",
                table: "ResTicket",
                newName: "IX_ResTicket_PassengerFK");

            migrationBuilder.AddColumn<string>(
                name: "Pilot",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResTicket",
                table: "ResTicket",
                columns: new[] { "TicketFK", "PassengerFK", "dateRes" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResTicket_Passengers_PassengerFK",
                table: "ResTicket",
                column: "PassengerFK",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResTicket_Ticket_TicketFK",
                table: "ResTicket",
                column: "TicketFK",
                principalTable: "Ticket",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResTicket_Passengers_PassengerFK",
                table: "ResTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_ResTicket_Ticket_TicketFK",
                table: "ResTicket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResTicket",
                table: "ResTicket");

            migrationBuilder.DropColumn(
                name: "Pilot",
                table: "Flights");

            migrationBuilder.RenameTable(
                name: "ResTicket",
                newName: "ReservationTicket");

            migrationBuilder.RenameIndex(
                name: "IX_ResTicket_PassengerFK",
                table: "ReservationTicket",
                newName: "IX_ReservationTicket_PassengerFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationTicket",
                table: "ReservationTicket",
                columns: new[] { "TicketFK", "PassengerFK", "dateRes" });

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationTicket_Passengers_PassengerFK",
                table: "ReservationTicket",
                column: "PassengerFK",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationTicket_Ticket_TicketFK",
                table: "ReservationTicket",
                column: "TicketFK",
                principalTable: "Ticket",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
