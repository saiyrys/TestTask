using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    areasId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    areasNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.areasId);
                });

            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    cabinetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cabinetNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.cabinetId);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    specializationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    specializationName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.specializationId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    areasId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                    table.ForeignKey(
                        name: "FK_Patients_Areas_areasId",
                        column: x => x.areasId,
                        principalTable: "Areas",
                        principalColumn: "areasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    specializationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cabinetsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    areasId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Doctors_Areas_areasId",
                        column: x => x.areasId,
                        principalTable: "Areas",
                        principalColumn: "areasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Cabinets_cabinetsId",
                        column: x => x.cabinetsId,
                        principalTable: "Cabinets",
                        principalColumn: "cabinetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialization_specializationId",
                        column: x => x.specializationId,
                        principalTable: "Specialization",
                        principalColumn: "specializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_areasNumber",
                table: "Areas",
                column: "areasNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cabinets_cabinetNumber",
                table: "Cabinets",
                column: "cabinetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_areasId",
                table: "Doctors",
                column: "areasId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_cabinetsId",
                table: "Doctors",
                column: "cabinetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_fullName",
                table: "Doctors",
                column: "fullName");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_specializationId",
                table: "Doctors",
                column: "specializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_areasId",
                table: "Patients",
                column: "areasId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_firstName_lastName_middleName",
                table: "Patients",
                columns: new[] { "firstName", "lastName", "middleName" });

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_specializationName",
                table: "Specialization",
                column: "specializationName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
