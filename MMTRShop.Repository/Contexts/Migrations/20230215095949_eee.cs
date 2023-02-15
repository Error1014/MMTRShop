using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMTRShop.Repository.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class eee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankCard_Client_ClientId",
                table: "BankCard");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "BankCard",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_BankCard_Client_ClientId",
                table: "BankCard",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankCard_Client_ClientId",
                table: "BankCard");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "BankCard",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankCard_Client_ClientId",
                table: "BankCard",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
