﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskBoard.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("5fb6f564-309f-4215-a92d-854b5c6d6992"), 1, new DateTime(2023, 1, 10, 18, 20, 28, 34, DateTimeKind.Utc).AddTicks(1028), "Create Android client App for the RESTful TaskBoard service", "0d854fc1-5c0d-4645-b1bc-e486e94cde9b", "Android Client App" },
                    { new Guid("73e4828e-be7e-42f1-aac1-3aaf910be1eb"), 1, new DateTime(2022, 11, 22, 18, 20, 28, 34, DateTimeKind.Utc).AddTicks(1000), "Implement better styling for all public pages", "0d854fc1-5c0d-4645-b1bc-e486e94cde9b", "Improve CSS styles" },
                    { new Guid("bc32e3f4-a18b-4c80-b337-090d7dc3e0a7"), 2, new DateTime(2023, 5, 10, 18, 20, 28, 34, DateTimeKind.Utc).AddTicks(1034), "Create Desktop client App for the RESTful TaskBoard service", "0d854fc1-5c0d-4645-b1bc-e486e94cde9b", "Desktop Client App" },
                    { new Guid("e4f6643e-0227-4243-8109-d85d61a76752"), 3, new DateTime(2022, 6, 10, 18, 20, 28, 34, DateTimeKind.Utc).AddTicks(1036), "Implement [Create Task] page for adding tasks", "dbc68811-2d8b-4559-97b5-96faaee5e38c", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
