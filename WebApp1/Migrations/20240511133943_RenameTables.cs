using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp1.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logRecords_Rooms_RoomId",
                table: "logRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_logRecords_reservations_ReservationId",
                table: "logRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Rooms_RoomId",
                table: "reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservations",
                table: "reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_logRecords",
                table: "logRecords");

            migrationBuilder.RenameTable(
                name: "reservations",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "logRecords",
                newName: "LogRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogRecords",
                table: "LogRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogRecords_Reservations_ReservationId",
                table: "LogRecords",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogRecords_Rooms_RoomId",
                table: "LogRecords",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogRecords_Reservations_ReservationId",
                table: "LogRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_LogRecords_Rooms_RoomId",
                table: "LogRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogRecords",
                table: "LogRecords");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "reservations");

            migrationBuilder.RenameTable(
                name: "LogRecords",
                newName: "logRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservations",
                table: "reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logRecords",
                table: "logRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_logRecords_Rooms_RoomId",
                table: "logRecords",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_logRecords_reservations_ReservationId",
                table: "logRecords",
                column: "ReservationId",
                principalTable: "reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Rooms_RoomId",
                table: "reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
