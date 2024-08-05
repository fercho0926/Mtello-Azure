using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class paycheckFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayCheckRecords",
                columns: table => new
                {
                    PayCheckRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Day2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Day3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Day4 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Day5 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Day6 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Day7 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Wk1Regular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wk1Overtime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wk2Regular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wk2Overtime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegularPay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miscellaneous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayCheckRecords", x => x.PayCheckRecordId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayCheckRecords");
        }
    }
}
