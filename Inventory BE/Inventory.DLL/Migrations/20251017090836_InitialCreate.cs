using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.DLL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suppliers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                            table: "Inventory",
                            columns: new[]
                            {
                    "Id", "Name", "Description", "Color", "Suppliers", "Manufacturers",
                    "CreatedDate", "CreatedBy", "ModifiedDate", "ModifiedBy"
                            },
                            values: new object[,]
                            {
                    {
                        1,
                        "Red Chair",
                        "Comfortable red chair with cushion",
                        "Red",
                        "Furniture Co",
                        "Chair Factory Ltd",
                        DateTime.Now,
                        "Editor",
                        DateTime.Now,
                        "Editor"
                    },
                    {
                        2,
                        "Blue Table",
                        "Wooden dining table painted blue",
                        "Blue",
                        "Wood Supplies Inc",
                        "Table Makers",
                        DateTime.Now,
                        "Editor",
                        DateTime.Now,
                        "Editor"
                    },
                    {
                        3,
                        "Green Lamp",
                        "Modern LED desk lamp",
                        "Green",
                        "LightHouse Ltd",
                        "LampWorks",
                        DateTime.Now,
                        "Editor",
                        DateTime.Now,
                        "Editor"
                    }
                            });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[]
                {
                    "Id", "Username", "Password", "Role",
                    "CreatedDate", "CreatedBy", "ModifiedDate", "ModifiedBy"
                },
                values: new object[,]
                {
                    {
                        1,
                        "Peter",
                        "$2a$12$2BeI7i9Tqh6cOztJyME5zuUahwOnECU.ecCwllyy0wxSdeXQT.HJ6",
                        "Editor",
                        DateTime.Now,
                        null,
                        DateTime.Now,
                        null
                    },
                    {
                        2,
                        "Mark",
                        "$2a$12$9yKrSlc7gs.FqY9c6OqeuOnetY5G9.fpmb/AIHCdd8FbVBm.mEZ4W",
                        "Viewer",
                        DateTime.Now,
                        null,
                        DateTime.Now,
                        null
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
