using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Onion.Arq.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lk_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lk_users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lk_users_lk_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "lk_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lk_session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lk_session_lk_users_UserId",
                        column: x => x.UserId,
                        principalTable: "lk_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "lk_roles",
                columns: new[] { "Id", "Activated", "CreatedBy", "CreatedDate", "Description", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "All Permissions", "Admin", null, null },
                    { 2, true, null, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create, Edit, View", "User", null, null }
                });

            migrationBuilder.InsertData(
                table: "lk_users",
                columns: new[] { "Id", "Activated", "CreatedBy", "CreatedDate", "Email", "LastName", "Name", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, true, null, new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "agallardo@tekssolutions.com", "Gallardo", "Abraham", "123456", 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_lk_session_UserId",
                table: "lk_session",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_lk_users_Email",
                table: "lk_users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lk_users_RoleId",
                table: "lk_users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lk_session");

            migrationBuilder.DropTable(
                name: "lk_users");

            migrationBuilder.DropTable(
                name: "lk_roles");
        }
    }
}
