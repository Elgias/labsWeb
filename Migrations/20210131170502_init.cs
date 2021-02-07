using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace labs.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequentialNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryWorkModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryWorkModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryWorkModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    LaboratoryWorkId = table.Column<int>(type: "int", nullable: false),
                    RegisterDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Payed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderModel_ClientModel_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderModel_LaboratoryWorkModel_LaboratoryWorkId",
                        column: x => x.LaboratoryWorkId,
                        principalTable: "LaboratoryWorkModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryWorkModel_SubjectId",
                table: "LaboratoryWorkModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_ClientId",
                table: "OrderModel",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_LaboratoryWorkId",
                table: "OrderModel",
                column: "LaboratoryWorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderModel");

            migrationBuilder.DropTable(
                name: "ClientModel");

            migrationBuilder.DropTable(
                name: "LaboratoryWorkModel");

            migrationBuilder.DropTable(
                name: "SubjectModel");
        }
    }
}
