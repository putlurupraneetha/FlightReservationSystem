using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationSystem.Migrations
{
    public partial class FixBookingPassengerPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the table if it exists (important to avoid conflict with existing table)
            migrationBuilder.DropTable(
                name: "BookingPassengers");

            // Recreate the table with the correct 'Id' column having Identity property
            migrationBuilder.CreateTable(
                name: "BookingPassengers",
                columns: table => new
                {
                    // Define the 'Id' column as an Identity column
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Identity column starts from 1 and increments by 1
                    
                    // Add other columns as they were before
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    IsCheckedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    // Define primary key and foreign keys
                    table.PrimaryKey("PK_BookingPassengers", x => x.Id);
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

            // Add indexes if needed
            migrationBuilder.CreateIndex(
                name: "IX_BookingPassengers_BookingId",
                table: "BookingPassengers",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingPassengers_PassengerId",
                table: "BookingPassengers",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Rollback changes if necessary (drops the table if you need to revert)
            migrationBuilder.DropTable(name: "BookingPassengers");
        }
    }
}
