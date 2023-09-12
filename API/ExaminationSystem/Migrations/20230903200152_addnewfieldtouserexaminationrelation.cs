using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McqExaminationSystem.Migrations
{
    /// <inheritdoc />
    public partial class addnewfieldtouserexaminationrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UEid",
                table: "UserExamRelation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UEid",
                table: "UserExamRelation");
        }
    }
}
