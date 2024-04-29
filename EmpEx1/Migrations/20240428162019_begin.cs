using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpEx1.Migrations
{
    /// <inheritdoc />
    public partial class begin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emps",
                columns: table => new
                {
                    EmpID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emps", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "EmpEducations",
                columns: table => new
                {
                    EmpEducationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMarks = table.Column<long>(type: "bigint", nullable: false),
                    ObtainMarks = table.Column<long>(type: "bigint", nullable: false),
                    standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpEducations", x => x.EmpEducationID);
                    table.ForeignKey(
                        name: "FK_EmpEducations_Emps_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Emps",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpEducations_EmpID",
                table: "EmpEducations",
                column: "EmpID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpEducations");

            migrationBuilder.DropTable(
                name: "Emps");
        }
    }
}
