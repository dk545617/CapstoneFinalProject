using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CapstoneFinalProject.Data.Migrations
{
    public partial class modifyMenuClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MenuCategoryId",
                table: "Menus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuCategoryId",
                table: "Menus",
                column: "MenuCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_MenuCategories_MenuCategoryId",
                table: "Menus",
                column: "MenuCategoryId",
                principalTable: "MenuCategories",
                principalColumn: "MenuCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_MenuCategories_MenuCategoryId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuCategoryId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuCategoryId",
                table: "Menus");
        }
    }
}
