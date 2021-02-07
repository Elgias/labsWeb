using Microsoft.EntityFrameworkCore.Migrations;

namespace labs.Migrations
{
    public partial class constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryWorkModel_SubjectModel_SubjectId",
                table: "LaboratoryWorkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_ClientModel_ClientId",
                table: "OrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_LaboratoryWorkModel_LaboratoryWorkId",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectModel",
                table: "SubjectModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LaboratoryWorkModel",
                table: "LaboratoryWorkModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientModel",
                table: "ClientModel");

            migrationBuilder.RenameTable(
                name: "SubjectModel",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "OrderModel",
                newName: "OrderModels");

            migrationBuilder.RenameTable(
                name: "LaboratoryWorkModel",
                newName: "LaboratoryWorks");

            migrationBuilder.RenameTable(
                name: "ClientModel",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_LaboratoryWorkId",
                table: "OrderModels",
                newName: "IX_OrderModels_LaboratoryWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_ClientId",
                table: "OrderModels",
                newName: "IX_OrderModels_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LaboratoryWorkModel_SubjectId",
                table: "LaboratoryWorks",
                newName: "IX_LaboratoryWorks_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LaboratoryWorks",
                table: "LaboratoryWorks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryWorks_Subjects_SubjectId",
                table: "LaboratoryWorks",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryWorks_Subjects_SubjectId",
                table: "LaboratoryWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModels_Clients_ClientId",
                table: "OrderModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModels_LaboratoryWorks_LaboratoryWorkId",
                table: "OrderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LaboratoryWorks",
                table: "LaboratoryWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "SubjectModel");

            migrationBuilder.RenameTable(
                name: "OrderModels",
                newName: "OrderModel");

            migrationBuilder.RenameTable(
                name: "LaboratoryWorks",
                newName: "LaboratoryWorkModel");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "ClientModel");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModels_LaboratoryWorkId",
                table: "OrderModel",
                newName: "IX_OrderModel_LaboratoryWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModels_ClientId",
                table: "OrderModel",
                newName: "IX_OrderModel_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LaboratoryWorks_SubjectId",
                table: "LaboratoryWorkModel",
                newName: "IX_LaboratoryWorkModel_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectModel",
                table: "SubjectModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LaboratoryWorkModel",
                table: "LaboratoryWorkModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientModel",
                table: "ClientModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryWorkModel_SubjectModel_SubjectId",
                table: "LaboratoryWorkModel",
                column: "SubjectId",
                principalTable: "SubjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_ClientModel_ClientId",
                table: "OrderModel",
                column: "ClientId",
                principalTable: "ClientModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_LaboratoryWorkModel_LaboratoryWorkId",
                table: "OrderModel",
                column: "LaboratoryWorkId",
                principalTable: "LaboratoryWorkModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
