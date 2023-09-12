using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McqExaminationSystem.Migrations
{
    /// <inheritdoc />
    public partial class Momen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExamDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.ExamId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionHeader = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuestionFirstChoice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuestionSecondChoice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuestionThirdChoice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuestionFourthChoice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RightAnswer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Question_Exam",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "ExamId");
                });

            migrationBuilder.CreateTable(
                name: "UserExamRelation",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    ExamDateAndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExamScore = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExamRelation", x => new { x.UserId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_UserExamRelation_Exam",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "ExamId");
                    table.ForeignKey(
                        name: "FK_UserExamRelation_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ExamName",
                table: "Exam",
                column: "ExamName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ExamId",
                table: "Question",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserExamRelation_ExamId",
                table: "UserExamRelation",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "UserExamRelation");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
