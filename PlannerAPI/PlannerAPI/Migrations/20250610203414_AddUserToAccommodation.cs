using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToAccommodation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDuser",
                table: "Accommodation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_IDaccommodation",
                table: "Booking",
                column: "IDaccommodation");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_IDuser",
                table: "Booking",
                column: "IDuser");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_IDuser",
                table: "Accommodation",
                column: "IDuser");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_User_IDuser",
                table: "Accommodation",
                column: "IDuser",
                principalTable: "User",
                principalColumn: "IDuser");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Accommodation_IDaccommodation",
                table: "Booking",
                column: "IDaccommodation",
                principalTable: "Accommodation",
                principalColumn: "IDaccommodation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_IDuser",
                table: "Booking",
                column: "IDuser",
                principalTable: "User",
                principalColumn: "IDuser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodation_User_IDuser",
                table: "Accommodation");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Accommodation_IDaccommodation",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_IDuser",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_IDaccommodation",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_IDuser",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Accommodation_IDuser",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "IDuser",
                table: "Accommodation");
        }
    }
}
