using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationSystem.Migrations
{
    public partial class FixBookingPassengerFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key constraints
            migrationBuilder.DropForeignKey(
                name: "FK_BookingPassengers_Bookings_BookingId",
                table: "BookingPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingPassengers_Passengers_PassengerId",
                table: "BookingPassengers");

            // Drop index only if it exists
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_BookingPassengers_BookingId' AND object_id = OBJECT_ID('BookingPassengers'))
                BEGIN
                    DROP INDEX [IX_BookingPassengers_BookingId] ON [BookingPassengers];
                END
            ");

            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_BookingPassengers_PassengerId' AND object_id = OBJECT_ID('BookingPassengers'))
                BEGIN
                    DROP INDEX [IX_BookingPassengers_PassengerId] ON [BookingPassengers];
                END
            ");

            // Drop unnecessary columns if they exist
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = 'BookingPassengers' AND column_name = 'BookingId1')
                BEGIN
                    ALTER TABLE [BookingPassengers] DROP COLUMN [BookingId1];
                END
            ");

            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = 'BookingPassengers' AND column_name = 'PassengerId1')
                BEGIN
                    ALTER TABLE [BookingPassengers] DROP COLUMN [PassengerId1];
                END
            ");

            // Recreate the correct foreign key relationships
            migrationBuilder.AddForeignKey(
                name: "FK_BookingPassengers_Bookings_BookingId",
                table: "BookingPassengers",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPassengers_Passengers_PassengerId",
                table: "BookingPassengers",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id");

            // Recreate the correct indexes
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
            // Drop the foreign key constraints
            migrationBuilder.DropForeignKey(
                name: "FK_BookingPassengers_Bookings_BookingId",
                table: "BookingPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingPassengers_Passengers_PassengerId",
                table: "BookingPassengers");

            // Drop indexes
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_BookingPassengers_BookingId' AND object_id = OBJECT_ID('BookingPassengers'))
                BEGIN
                    DROP INDEX [IX_BookingPassengers_BookingId] ON [BookingPassengers];
                END
            ");

            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_BookingPassengers_PassengerId' AND object_id = OBJECT_ID('BookingPassengers'))
                BEGIN
                    DROP INDEX [IX_BookingPassengers_PassengerId] ON [BookingPassengers];
                END
            ");

            // Drop columns (if any exist)
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = 'BookingPassengers' AND column_name = 'BookingId1')
                BEGIN
                    ALTER TABLE [BookingPassengers] DROP COLUMN [BookingId1];
                END
            ");

            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = 'BookingPassengers' AND column_name = 'PassengerId1')
                BEGIN
                    ALTER TABLE [BookingPassengers] DROP COLUMN [PassengerId1];
                END
            ");

            // Optionally, add back the original columns and constraints if needed
            migrationBuilder.AddColumn<int>(
                name: "BookingId1",
                table: "BookingPassengers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassengerId1",
                table: "BookingPassengers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingPassengers_BookingId1",
                table: "BookingPassengers",
                column: "BookingId1");

            migrationBuilder.CreateIndex(
                name: "IX_BookingPassengers_PassengerId1",
                table: "BookingPassengers",
                column: "PassengerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPassengers_Bookings_BookingId1",
                table: "BookingPassengers",
                column: "BookingId1",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPassengers_Passengers_PassengerId1",
                table: "BookingPassengers",
                column: "PassengerId1",
                principalTable: "Passengers",
                principalColumn: "Id");
        }
    }
}
