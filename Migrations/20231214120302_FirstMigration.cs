using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BB_Manager",
                columns: table => new
                {
                    MID = table.Column<int>(name: "M_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MUserName = table.Column<string>(name: "M_UserName", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BB_Manager", x => x.MID);
                });

            migrationBuilder.CreateTable(
                name: "BloodGroup",
                columns: table => new
                {
                    BloodID = table.Column<int>(name: "Blood_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroup = table.Column<string>(name: "Blood_Group", type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroup", x => x.BloodID);
                });

            migrationBuilder.CreateTable(
                name: "MainHospital",
                columns: table => new
                {
                    HospID = table.Column<int>(name: "Hosp_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospName = table.Column<string>(name: "Hosp_Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CityName = table.Column<string>(name: "City_Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MID = table.Column<int>(name: "M_ID", type: "int", nullable: false),
                    BloodGroupID = table.Column<int>(name: "Blood_Group_ID", type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainHospital", x => x.HospID);
                    table.ForeignKey(
                        name: "FK_MainHospital_BB_Manager",
                        column: x => x.MID,
                        principalTable: "BB_Manager",
                        principalColumn: "M_ID");
                    table.ForeignKey(
                        name: "FK_MainHospital_BloodGroup",
                        column: x => x.BloodGroupID,
                        principalTable: "BloodGroup",
                        principalColumn: "Blood_ID");
                });

            migrationBuilder.CreateTable(
                name: "DiseaseFinder",
                columns: table => new
                {
                    DfindID = table.Column<int>(name: "Dfind_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DfindName = table.Column<string>(name: "Dfind_Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DfindEmail = table.Column<string>(name: "Dfind_Email", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Dfindphone = table.Column<int>(name: "Dfind_phone", type: "int", nullable: false),
                    HospitalID = table.Column<int>(name: "Hospital_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseFinder", x => x.DfindID);
                    table.ForeignKey(
                        name: "FK_DiseaseFinder_MainHospital",
                        column: x => x.HospitalID,
                        principalTable: "MainHospital",
                        principalColumn: "Hosp_ID");
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalNeededBlood = table.Column<int>(name: "Hospital_Needed_Blood", type: "int", nullable: false),
                    HospitalID = table.Column<int>(name: "Hospital_ID", type: "int", nullable: false),
                    HospitalName = table.Column<string>(name: "Hospital_Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    HospNeededqnty = table.Column<int>(name: "Hosp_Needed_qnty", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals_1", x => x.HospitalNeededBlood);
                    table.ForeignKey(
                        name: "FK_Hospitals_MainHospital",
                        column: x => x.HospitalID,
                        principalTable: "MainHospital",
                        principalColumn: "Hosp_ID");
                });

            migrationBuilder.CreateTable(
                name: "NurseStaff",
                columns: table => new
                {
                    NurseID = table.Column<int>(name: "Nurse_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseName = table.Column<string>(name: "Nurse_Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NursephNo = table.Column<int>(name: "Nurse_phNo", type: "int", nullable: true),
                    HospitalID = table.Column<int>(name: "Hospital_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseStaff", x => x.NurseID);
                    table.ForeignKey(
                        name: "FK_NurseStaff_MainHospital",
                        column: x => x.HospitalID,
                        principalTable: "MainHospital",
                        principalColumn: "Hosp_ID");
                });

            migrationBuilder.CreateTable(
                name: "Blood_specimen",
                columns: table => new
                {
                    Specimennumber = table.Column<int>(name: "Specimen_number", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bgroup = table.Column<int>(name: "B_group", type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DfindID = table.Column<int>(name: "Dfind_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blood_specimen", x => new { x.Specimennumber, x.Bgroup });
                    table.ForeignKey(
                        name: "FK_Blood_specimen_BloodGroup",
                        column: x => x.Bgroup,
                        principalTable: "BloodGroup",
                        principalColumn: "Blood_ID");
                    table.ForeignKey(
                        name: "FK_Blood_specimen_DiseaseFinder",
                        column: x => x.DfindID,
                        principalTable: "DiseaseFinder",
                        principalColumn: "Dfind_ID");
                });

            migrationBuilder.CreateTable(
                name: "Need_Blood",
                columns: table => new
                {
                    NBID = table.Column<int>(name: "NB_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NBName = table.Column<string>(name: "NB_Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NBAge = table.Column<int>(name: "NB_Age", type: "int", nullable: true),
                    NBEmail = table.Column<string>(name: "NB_Email", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ReasonForNB = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Gender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    BloodGroup = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    HospitalID = table.Column<int>(name: "Hospital_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Need_Blood", x => x.NBID);
                    table.ForeignKey(
                        name: "FK_Need_Blood_Hospitals",
                        column: x => x.HospitalID,
                        principalTable: "Hospitals",
                        principalColumn: "Hospital_Needed_Blood");
                });

            migrationBuilder.CreateTable(
                name: "Blood_Donor",
                columns: table => new
                {
                    BDID = table.Column<int>(name: "BD_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BDName = table.Column<string>(name: "BD_Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    BDAge = table.Column<int>(name: "BD_Age", type: "int", nullable: false),
                    BDSex = table.Column<string>(name: "BD_Sex", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    BDGroup = table.Column<string>(name: "BD_Group", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    BDRegDate = table.Column<DateTime>(name: "BDReg_Date", type: "datetime", nullable: false),
                    CityName = table.Column<string>(name: "City_Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NurseID = table.Column<int>(name: "Nurse_ID", type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blood_Donor", x => x.BDID);
                    table.ForeignKey(
                        name: "FK_Blood_Donor_NurseStaff",
                        column: x => x.NurseID,
                        principalTable: "NurseStaff",
                        principalColumn: "Nurse_ID");
                });

            migrationBuilder.CreateIndex(
                name: "BloodDonorIndx",
                table: "Blood_Donor",
                column: "BD_Group");

            migrationBuilder.CreateIndex(
                name: "IX_Blood_Donor_Nurse_ID",
                table: "Blood_Donor",
                column: "Nurse_ID");

            migrationBuilder.CreateIndex(
                name: "NameDonorIndx",
                table: "Blood_Donor",
                column: "BD_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Blood_specimen_B_group",
                table: "Blood_specimen",
                column: "B_group");

            migrationBuilder.CreateIndex(
                name: "IX_Blood_specimen_Dfind_ID",
                table: "Blood_specimen",
                column: "Dfind_ID");

            migrationBuilder.CreateIndex(
                name: "GroupBloodIndx",
                table: "BloodGroup",
                column: "Blood_Group");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseFinder_Hospital_ID",
                table: "DiseaseFinder",
                column: "Hospital_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_Hospital_ID",
                table: "Hospitals",
                column: "Hospital_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MainHospital_Blood_Group_ID",
                table: "MainHospital",
                column: "Blood_Group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MainHospital_M_ID",
                table: "MainHospital",
                column: "M_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Need_Blood_Hospital_ID",
                table: "Need_Blood",
                column: "Hospital_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NurseStaff_Hospital_ID",
                table: "NurseStaff",
                column: "Hospital_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blood_Donor");

            migrationBuilder.DropTable(
                name: "Blood_specimen");

            migrationBuilder.DropTable(
                name: "Need_Blood");

            migrationBuilder.DropTable(
                name: "NurseStaff");

            migrationBuilder.DropTable(
                name: "DiseaseFinder");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "MainHospital");

            migrationBuilder.DropTable(
                name: "BB_Manager");

            migrationBuilder.DropTable(
                name: "BloodGroup");
        }
    }
}
