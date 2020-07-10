using Microsoft.EntityFrameworkCore.Migrations;

namespace Nhom2.TMDT.Data.Migrations
{
    public partial class Edit01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ShipmentDetail_ShipmentDetailId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ShipmentDetailId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ShipmentDetailId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ShipmentDetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetail_UserId",
                table: "ShipmentDetail",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentDetail_User_UserId",
                table: "ShipmentDetail",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentDetail_User_UserId",
                table: "ShipmentDetail");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentDetail_UserId",
                table: "ShipmentDetail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShipmentDetail");

            migrationBuilder.AddColumn<int>(
                name: "ShipmentDetailId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ShipmentDetailId",
                table: "User",
                column: "ShipmentDetailId",
                unique: true,
                filter: "[ShipmentDetailId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ShipmentDetail_ShipmentDetailId",
                table: "User",
                column: "ShipmentDetailId",
                principalTable: "ShipmentDetail",
                principalColumn: "Id");
        }
    }
}
