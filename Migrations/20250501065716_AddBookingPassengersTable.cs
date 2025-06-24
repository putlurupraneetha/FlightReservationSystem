using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationSystem.Migrations
{
    public partial class AddBookingPassengersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the BookingPassengers table
            migrationBuilder.CreateTable(
                name: "BookingPassengers",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false),
                    PassengerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingPassengers", x => new { x.BookingId, x.PassengerId });
                    table.ForeignKey(
                        name: "FK_BookingPassengers_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingPassengers_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Optionally, if you want to drop the foreign key if it exists
            migrationBuilder.DropForeignKey(
                name: "FK_BookingPassengers_Bookings_BookingId1",  // The incorrect foreign key
                table: "BookingPassengers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingPassengers");
        }
    }
}
