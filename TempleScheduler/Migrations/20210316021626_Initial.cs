using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TempleScheduler.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApptTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.AppointmentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");
        }
    }
}
