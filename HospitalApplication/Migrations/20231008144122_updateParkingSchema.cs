using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApplication.Migrations
{
    public partial class updateParkingSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idPerson",
                table: "ParkingEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idPerson",
                table: "ParkingEntries");
        }
    }
}
