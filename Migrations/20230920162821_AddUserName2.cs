using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312POEPart1DAF.Migrations
{
    /// <inheritdoc />
    public partial class AddUserName2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ApplicationUsers");
        }
    }
}
