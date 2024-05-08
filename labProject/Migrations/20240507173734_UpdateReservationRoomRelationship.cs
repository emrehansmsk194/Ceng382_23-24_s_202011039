using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace labProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservationRoomRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_rooms_RoomId",
                table: "reservations");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "reservations",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_rooms_RoomId",
                table: "reservations",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_rooms_RoomId",
                table: "reservations");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_rooms_RoomId",
                table: "reservations",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id");
        }
    }
}
