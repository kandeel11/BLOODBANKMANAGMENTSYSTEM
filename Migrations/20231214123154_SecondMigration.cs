using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "BB_Manager",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DonorBloodComp",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodId = table.Column<int>(type: "int", nullable: false),
                    BloodGroup1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorBloodComp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DonorBloodComp_BloodGroup_BloodId",
                        column: x => x.BloodId,
                        principalTable: "BloodGroup",
                        principalColumn: "Blood_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonorBloodComp_BloodId",
                table: "DonorBloodComp",
                column: "BloodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorBloodComp");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "BB_Manager");
        }
    }
}
