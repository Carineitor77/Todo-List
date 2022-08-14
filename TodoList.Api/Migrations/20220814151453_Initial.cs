using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Annotation = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "getdate()"),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_AffairId", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affairs_Title",
                table: "Affairs",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affairs");
        }
    }
}
