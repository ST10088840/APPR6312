using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312POEPart1DAF.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Catagory",
                columns: table => new
                {
                    CatagoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatagoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagory", x => x.CatagoryId);
                });

            migrationBuilder.CreateTable(
                name: "Disasters",
                columns: table => new
                {
                    DisasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disasters", x => x.DisasterId);
                });

            migrationBuilder.CreateTable(
                name: "DonationsItems",
                columns: table => new
                {
                    ItemDonationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatagoryID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numItems = table.Column<int>(type: "int", nullable: false),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Donor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationsItems", x => x.ItemDonationId);
                    table.ForeignKey(
                        name: "FK_DonationsItems_Catagory_CatagoryID",
                        column: x => x.CatagoryID,
                        principalTable: "Catagory",
                        principalColumn: "CatagoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationsItems_Disasters_DisasterId",
                        column: x => x.DisasterId,
                        principalTable: "Disasters",
                        principalColumn: "DisasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationsMoney",
                columns: table => new
                {
                    DonationMoneyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Doner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationsMoney", x => x.DonationMoneyId);
                    table.ForeignKey(
                        name: "FK_DonationsMoney_Disasters_DisasterId",
                        column: x => x.DisasterId,
                        principalTable: "Disasters",
                        principalColumn: "DisasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationsItems_CatagoryID",
                table: "DonationsItems",
                column: "CatagoryID");

            migrationBuilder.CreateIndex(
                name: "IX_DonationsItems_DisasterId",
                table: "DonationsItems",
                column: "DisasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationsMoney_DisasterId",
                table: "DonationsMoney",
                column: "DisasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "DonationsItems");

            migrationBuilder.DropTable(
                name: "DonationsMoney");

            migrationBuilder.DropTable(
                name: "Catagory");

            migrationBuilder.DropTable(
                name: "Disasters");
        }
    }
}
