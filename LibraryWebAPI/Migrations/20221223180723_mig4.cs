using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWebAPI.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Types_TypeId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Books_TypeId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookTypetypeId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    typeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.typeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookTypetypeId",
                table: "Books",
                column: "BookTypetypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_BookTypetypeId",
                table: "Books",
                column: "BookTypetypeId",
                principalTable: "BookTypes",
                principalColumn: "typeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_BookTypetypeId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookTypetypeId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookTypetypeId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    typeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.typeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_TypeId",
                table: "Books",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Types_TypeId",
                table: "Books",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "typeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
