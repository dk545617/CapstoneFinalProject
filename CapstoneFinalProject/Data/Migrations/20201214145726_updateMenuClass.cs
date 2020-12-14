using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CapstoneFinalProject.Data.Migrations
{
    public partial class updateMenuClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MenuImageId",
                table: "Menus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuImageId",
                table: "Menus",
                column: "MenuImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_MenuImages_MenuImageId",
                table: "Menus",
                column: "MenuImageId",
                principalTable: "MenuImages",
                principalColumn: "MenuImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_MenuImages_MenuImageId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuImageId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuImageId",
                table: "Menus");
        }
    }
}
