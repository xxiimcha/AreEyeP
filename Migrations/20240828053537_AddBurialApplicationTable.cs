using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AreEyeP.Migrations
{
    /// <inheritdoc />
    public partial class AddBurialApplicationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BurialApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApplicantLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipToDeceased = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeceasedFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeceasedLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeceasedGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeceasedDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeceasedDateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BurialDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurialStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BurialEndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachedRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialApplications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurialApplications");
        }
    }
}
