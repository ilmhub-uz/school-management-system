using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.API.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_CreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "student_task_results",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "student_task_results",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "student_task_results",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "student_task_results",
                newName: "CreateDate");
        }
    }
}
