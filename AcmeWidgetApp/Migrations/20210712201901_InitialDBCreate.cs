using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeWidgetApp.Migrations
{
    public partial class InitialDBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    ActivityId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantInfo_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "ActivityId", "ActivityName", "Description" },
                values: new object[,]
                {
                    { 1, "Board game tournament", "A team-wide board game or card game tournament for some in-office fun. Includes prizes!" },
                    { 2, "Rock Climbing", "test 2" },
                    { 3, "Escape room", "Escape rooms can simulate office collaboration – they build the same leadership skills, teamwork, logic, and patience. No wonder they have become a popular team building exercise!" },
                    { 4, "Scavenger hunt", "Scavenger Hunt Anywhere challenges you to a series of questions that you must answer correctly and in time in order to win! This is a great way to focus on skills related to communications, problem solving, strategy and the need to be creative. This event also covers the history of Old Montreal and can be customized to meet the needs of your company" },
                    { 5, "Mud Racing", "Get your unique mudding experience! Enjoy this awesome off-road racing experience, compete against other mudder truckers and win! Simple controls, a variety of obstacles to pass, awesome cars and extreme tuning!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantInfo_ActivityId",
                table: "ParticipantInfo",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantInfo");

            migrationBuilder.DropTable(
                name: "Activity");
        }
    }
}
