using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class adjustedDiagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "AdmissionHistories",
                newName: "Birthdate");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "AdmissionHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "AdmissionHistories");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "AdmissionHistories",
                newName: "BirthDate");
        }
    }
}
