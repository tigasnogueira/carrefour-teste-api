using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carrefour.ProductApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Photo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Edict = table.Column<string>(type: "varchar(100)", nullable: false),
                    Comiters = table.Column<string>(type: "varchar(100)", nullable: false),
                    Goal = table.Column<string>(type: "varchar(100)", nullable: false),
                    Increase = table.Column<string>(type: "varchar(100)", nullable: false),
                    Nature = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    InitialValue = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
