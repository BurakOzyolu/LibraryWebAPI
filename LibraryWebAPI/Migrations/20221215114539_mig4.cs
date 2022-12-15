using System;
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

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Writes_WriterId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "UptatedAt",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "UptatedBy",
                table: "Types");

            migrationBuilder.AlterColumn<int>(
                name: "WriterId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPages",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedYear",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Types_TypeId",
                table: "Books",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "typeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Writes_WriterId",
                table: "Books",
                column: "WriterId",
                principalTable: "Writes",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Types_TypeId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Writes_WriterId",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Types",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Types",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Types",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UptatedAt",
                table: "Types",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UptatedBy",
                table: "Types",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WriterId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPages",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedYear",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Types_TypeId",
                table: "Books",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "typeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Writes_WriterId",
                table: "Books",
                column: "WriterId",
                principalTable: "Writes",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
