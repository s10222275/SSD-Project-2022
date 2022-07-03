using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSD_Project.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    FacilityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    MaxNumOfPeople = table.Column<int>(nullable: false),
                    BlockNum = table.Column<string>(nullable: true),
                    LocationName = table.Column<string>(nullable: true),
                    LevelNo = table.Column<string>(nullable: true),
                    RommNo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.FacilityID);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(nullable: false),
                    FacilityID = table.Column<int>(nullable: false),
                    StatusOfBooking = table.Column<string>(nullable: true),
                    CheckInStatus = table.Column<bool>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    NumOfPeople = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_Facility_FacilityID",
                        column: x => x.FacilityID,
                        principalTable: "Facility",
                        principalColumn: "FacilityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FacilityID",
                table: "Booking",
                column: "FacilityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Facility");
        }
    }
}
