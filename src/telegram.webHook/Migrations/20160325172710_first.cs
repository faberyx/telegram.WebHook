using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace telegram.webHook.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Action = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: false),
                    Pattern = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChatId = table.Column<int>(nullable: false),
                    FromFirstname = table.Column<string>(nullable: true),
                    FromId = table.Column<int>(nullable: false),
                    FromLastname = table.Column<string>(nullable: true),
                    FromUsername = table.Column<string>(nullable: false),
                    LocationLatitude = table.Column<string>(nullable: true),
                    LocationLongitude = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Dictionary");
            migrationBuilder.DropTable("Message");
        }
    }
}
