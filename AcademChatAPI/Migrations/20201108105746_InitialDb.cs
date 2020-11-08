using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AcademChatAPI.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 10, nullable: false),
                    status = table.Column<string>(maxLength: 30, nullable: true),
                    secret = table.Column<string>(maxLength: 32, nullable: true),
                    position = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(nullable: false),
                    data = table.Column<string>(nullable: true),
                    user_id = table.Column<long>(nullable: false),
                    to_user_id = table.Column<long>(nullable: true),
                    time_stamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_to_user_id",
                        column: x => x.to_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "name", "position", "secret", "status" },
                values: new object[,]
                {
                    { 1L, "Vitaly", "CEO", "B/9HOf6JVnY+eHf4bLqarA==", "Using ChatClient" },
                    { 2L, "Valery", "CTO", "B/9HOf6JVnY+eHf4bLqarA==", "Using ChatClient" },
                    { 3L, "Matvey", "Lead", "B/9HOf6JVnY+eHf4bLqarA==", "Free for chat" },
                    { 4L, "Natalya", "CFO", "B/9HOf6JVnY+eHf4bLqarA==", "Come to taste a coockies!" },
                    { 5L, "Aydar", "SWE", "B/9HOf6JVnY+eHf4bLqarA==", "Busy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_to_user_id",
                table: "Messages",
                column: "to_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_user_id",
                table: "Messages",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
