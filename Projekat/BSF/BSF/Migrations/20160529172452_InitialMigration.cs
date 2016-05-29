using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace BSF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    BankAccountID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.BankAccountID);
                });
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    AccoutnId = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NameOfFather = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    PostalNumber = table.Column<int>(nullable: false),
                    SurName = table.Column<string>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Validated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.AccoutnId);
                    table.ForeignKey(
                        name: "FK_Person_BankAccount_AccoutnId",
                        column: x => x.AccoutnId,
                        principalTable: "BankAccount",
                        principalColumn: "BankAccountID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MobileVerification",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    VerifyingAccoutnId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileVerification", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MobileVerification_Person_VerifyingAccoutnId",
                        column: x => x.VerifyingAccoutnId,
                        principalTable: "Person",
                        principalColumn: "AccoutnId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<double>(nullable: false),
                    FromAccountBankAccountID = table.Column<int>(nullable: true),
                    ReferentAccoutnId = table.Column<int>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    ToAccountBankAccountID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_BankAccount_FromAccountBankAccountID",
                        column: x => x.FromAccountBankAccountID,
                        principalTable: "BankAccount",
                        principalColumn: "BankAccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Person_ReferentAccoutnId",
                        column: x => x.ReferentAccoutnId,
                        principalTable: "Person",
                        principalColumn: "AccoutnId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_BankAccount_ToAccountBankAccountID",
                        column: x => x.ToAccountBankAccountID,
                        principalTable: "BankAccount",
                        principalColumn: "BankAccountID",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("MobileVerification");
            migrationBuilder.DropTable("Transaction");
            migrationBuilder.DropTable("Person");
            migrationBuilder.DropTable("BankAccount");
        }
    }
}
