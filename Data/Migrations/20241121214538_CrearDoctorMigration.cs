using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CrearDoctorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellidos = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    EspecialidaId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Especialidades_EspecialidaId",
                        column: x => x.EspecialidaId,
                        principalTable: "Especialidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_EspecialidaId",
                table: "Doctors",
                column: "EspecialidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
