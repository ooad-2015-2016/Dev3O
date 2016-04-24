/*using Microsoft.Data.Entity.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Migrations
{
    public partial class Migracija : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(name: "Restoran", columns: table => new
            {
                AccountId = table.Column(type: "INTEGER", nullable: false),
                // .Annotation("Sqlite:Autoincrement", true),

                Username = table.Column(type: "TEXT", nullable: true),
                Password = table.Column(type: "TEXT", nullable: true),


            },
            constraints: table => { table.PrimaryKey("PK_Account", x => x.AccountId); });
        }
        public override void Down(MigrationBuilder migration) { migration.DropTable("Restoran"); }
    }
}
*/