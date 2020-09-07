using Microsoft.EntityFrameworkCore.Migrations;

namespace RCTrans.Data.Migrations
{
    public partial class EditVehicleAndOrderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehicleSubType",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "BabySeat",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChildSeat",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleSubType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BabySeat",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ChildSeat",
                table: "Orders");
        }
    }
}
