using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI_Employee_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class tablesfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "ToDate",
                table: "Leaves",
                type: "date",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FromDate",
                table: "Leaves",
                type: "date",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Leaves");

            migrationBuilder.AlterColumn<string>(
                name: "ToDate",
                table: "Leaves",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FromDate",
                table: "Leaves",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldFixedLength: true,
                oldMaxLength: 10);
        }
    }
}
