using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LawPavillion.Library.Backend.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationForBookAndUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Law Pavillion");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 3, "George bush", "1234567890125", new DateTime(2000, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2001" },
                    { 4, "Aldous smith", "1234567890126", new DateTime(1935, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brave Law" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Brave New World");
        }
    }
}
