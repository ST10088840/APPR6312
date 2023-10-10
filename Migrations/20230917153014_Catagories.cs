using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312POEPart1DAF.Migrations
{
    /// <inheritdoc />
    public partial class Catagories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationsItems_Catagory_CatagoryID",
                table: "DonationsItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catagory",
                table: "Catagory");

            migrationBuilder.RenameTable(
                name: "Catagory",
                newName: "Catagories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catagories",
                table: "Catagories",
                column: "CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationsItems_Catagories_CatagoryID",
                table: "DonationsItems",
                column: "CatagoryID",
                principalTable: "Catagories",
                principalColumn: "CatagoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationsItems_Catagories_CatagoryID",
                table: "DonationsItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catagories",
                table: "Catagories");

            migrationBuilder.RenameTable(
                name: "Catagories",
                newName: "Catagory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catagory",
                table: "Catagory",
                column: "CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationsItems_Catagory_CatagoryID",
                table: "DonationsItems",
                column: "CatagoryID",
                principalTable: "Catagory",
                principalColumn: "CatagoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
