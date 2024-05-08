using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace labProject.Migrations
{
    /// <inheritdoc />
    public partial class MakeRoomIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int?>(
                name: "RoomId",
                table: "reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int?>(
                name: "RoomId",
                table: "reservations",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
