using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sexId = table.Column<int>(type: "int", nullable: false),
                    timeTypeId = table.Column<int>(type: "int", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: false),
                    starId = table.Column<int>(type: "int", nullable: false),
                    armId = table.Column<int>(type: "int", nullable: false),
                    costId = table.Column<float>(type: "real", nullable: false),
                    Attackdistance = table.Column<int>(type: "int", nullable: false),
                    InitialStrategy = table.Column<float>(type: "real", nullable: false),
                    Initialattack = table.Column<float>(type: "real", nullable: false),
                    Initialsiege = table.Column<float>(type: "real", nullable: false),
                    InitialDefense = table.Column<float>(type: "real", nullable: false),
                    Initialspeed = table.Column<float>(type: "real", nullable: false),
                    BasictacticsId = table.Column<int>(type: "int", nullable: false),
                    DetachabletacticsId = table.Column<int>(type: "int", nullable: false),
                    picPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroModel", x => x.Id);
                });

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroModel");

            migrationBuilder.DropTable(
                name: "SkillModel");
        }
    }
}
