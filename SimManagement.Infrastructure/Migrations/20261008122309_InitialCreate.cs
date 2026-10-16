using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Iccid = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Msisdn = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Imsi = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Eid = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    SimState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SimPlans",
                columns: table => new
                {
                    SimId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimPlans", x => new { x.SimId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_SimPlans_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SimPlans_Sims_SimId",
                        column: x => x.SimId,
                        principalTable: "Sims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimPlans_PlanId",
                table: "SimPlans",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimPlans");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Sims");
        }
    }
}
