using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expansetrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateuserregforpasswordencrypt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Password","userRegistraions");
            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "userRegistraions",
                type: "varbinary(max)",
                nullable: false,
                defaultValue:"");
                //oldClrType: typeof(string),
                //oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordKey",
                table: "userRegistraions",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "userRegistraions");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "userRegistraions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }
    }
}
