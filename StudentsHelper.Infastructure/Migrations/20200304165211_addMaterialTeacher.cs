using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsHelper.Infastructure.Migrations
{
    public partial class addMaterialTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialtyId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTeachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaterialId = table.Column<Guid>(nullable: false),
                    TeacherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialTeachers_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InstitutionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialties_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_InstitutionId",
                table: "Teachers",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SpecialtyId",
                table: "Teachers",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTeachers_MaterialId",
                table: "MaterialTeachers",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTeachers_TeacherId",
                table: "MaterialTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_InstitutionId",
                table: "Specialties",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Institutions_InstitutionId",
                table: "Teachers",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Specialties_SpecialtyId",
                table: "Teachers",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Institutions_InstitutionId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Specialties_SpecialtyId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "MaterialTeachers");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_InstitutionId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SpecialtyId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Teachers");
        }
    }
}
