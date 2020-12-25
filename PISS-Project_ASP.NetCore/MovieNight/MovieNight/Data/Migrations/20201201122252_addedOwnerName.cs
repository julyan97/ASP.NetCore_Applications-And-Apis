﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieNight.Data.Migrations
{
    public partial class addedOwnerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "ChatRooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "ChatRooms");
        }
    }
}
