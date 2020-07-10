using Microsoft.EntityFrameworkCore.Migrations;

namespace Nhom2.TMDT.Data.Migrations
{
    public partial class Edit02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "ShipmentDetail",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShipmentDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShipmentDetail");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ShipmentDetail",
                newName: "Phone");
        }
    }
}
