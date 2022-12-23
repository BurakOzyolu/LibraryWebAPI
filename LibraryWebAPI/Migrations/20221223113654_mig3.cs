using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWebAPI.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhonoNo",
                table: "Users",
                newName: "UserImage");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookImage",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookImage",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "UserImage",
                table: "Users",
                newName: "PhonoNo");
        }
    }
}
