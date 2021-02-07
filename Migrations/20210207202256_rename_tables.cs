using Microsoft.EntityFrameworkCore.Migrations;

namespace labs.Migrations
{
    public partial class rename_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModels_Clients_ClientId",
                table: "OrderModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModels_LaboratoryWorks_LaboratoryWorkId",
                table: "OrderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels");

            migrationBuilder.RenameTable(
                name: "OrderModels",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModels_LaboratoryWorkId",
                table: "Orders",
                newName: "IX_Orders_LaboratoryWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModels_ClientId",
                table: "Orders",
                newName: "IX_Orders_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_LaboratoryWorks_LaboratoryWorkId",
                table: "Orders",
                column: "LaboratoryWorkId",
                principalTable: "LaboratoryWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_LaboratoryWorks_LaboratoryWorkId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderModels");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_LaboratoryWorkId",
                table: "OrderModels",
                newName: "IX_OrderModels_LaboratoryWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClientId",
                table: "OrderModels",
                newName: "IX_OrderModels_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModels_Clients_ClientId",
                table: "OrderModels",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModels_LaboratoryWorks_LaboratoryWorkId",
                table: "OrderModels",
                column: "LaboratoryWorkId",
                principalTable: "LaboratoryWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
