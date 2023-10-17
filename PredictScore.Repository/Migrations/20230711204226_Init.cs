using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PredictScore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Players_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupPlayer",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPlayer", x => new { x.GroupsId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_GroupPlayer_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupPlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PredictionSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    PredictionSeasonRulesId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictionSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredictionSeasons_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredictionSeasons_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PredictionSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PredictionSeasonRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerScorePoints = table.Column<int>(type: "int", nullable: false),
                    FullScorePoints = table.Column<int>(type: "int", nullable: false),
                    HalfScorePoints = table.Column<int>(type: "int", nullable: false),
                    ScoreDifferencePoint = table.Column<int>(type: "int", nullable: false),
                    PredictionSeasonId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictionSeasonRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredictionSeasonRules_PredictionSeasons_PredictionSeasonId",
                        column: x => x.PredictionSeasonId,
                        principalTable: "PredictionSeasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PredictionMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictionMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredictionMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredictionMatches_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "CreationDateTime", "Description", "LastModificationDateTime", "Name" },
                values: new object[] { 1, new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(2974), "American football for those not familiar with..", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3023), "NFL" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Acronym", "CreationDateTime", "FullName", "LastModificationDateTime", "SeasonId", "ShortName", "SportId" },
                values: new object[,]
                {
                    { 1, "ARZ", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3488), "Arizona Cardinals", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3490), null, "Cardinals", 1 },
                    { 2, "ATL", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3552), "Atlanta Falcons", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3553), null, "Falcons", 1 },
                    { 3, "BLT", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3572), "Baltimore Ravens", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3573), null, "Ravens", 1 },
                    { 4, "BUF", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3589), "Buffalo Bills", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3590), null, "Bills", 1 },
                    { 5, "CAR", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3605), "Carolina Panthers", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3606), null, "Panthers", 1 },
                    { 6, "CHI", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3624), "Chicago Bears", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3625), null, "Bears", 1 },
                    { 7, "CIN", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3639), "Cincinatti Bengals", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3640), null, "Bengals", 1 },
                    { 8, "CLV", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3654), "Cleveland Browns", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3656), null, "Browns", 1 },
                    { 9, "DAL", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3670), "Dallas Cowboys", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3671), null, "Cowboys", 1 },
                    { 10, "DEN", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3685), "Denver Broncos", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3686), null, "Broncos", 1 },
                    { 11, "DET", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3700), "Detroit Lions", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3701), null, "Lions", 1 },
                    { 12, "GB", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3715), "Green Bay Packers", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3716), null, "Packers", 1 },
                    { 13, "HST", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3731), "Houston Texas", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3732), null, "Texas", 1 },
                    { 14, "IND", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3747), "Indianapolis Colts", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3748), null, "Colts", 1 },
                    { 15, "JAX", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3762), "Jacksonville Jaguars", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3763), null, "Jaguars", 1 },
                    { 16, "KC", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3776), "Kansas City Chiefs", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3777), null, "Chiefs", 1 },
                    { 17, "LV", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3792), "Las Vegas Raiders", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3793), null, "Raiders", 1 },
                    { 18, "LAC", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3807), "Los Angeles Chargers", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3808), null, "Chargers", 1 },
                    { 19, "LA", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3822), "Los Angeles Rams", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3823), null, "Rams", 1 },
                    { 20, "MIA", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3836), "Miami Dolphins", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3837), null, "Dolphins", 1 },
                    { 21, "MIN", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3851), "Minnesota Vikings", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3852), null, "Vikings", 1 },
                    { 22, "NE", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3866), "New England Patriots", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3867), null, "Patriots", 1 },
                    { 23, "NO", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3880), "New Orleans Saints", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3881), null, "Saints", 1 },
                    { 24, "NYG", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3894), "New York Giants", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3895), null, "Giants", 1 },
                    { 25, "NYJ", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3909), "New York Jets", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3910), null, "Jets", 1 },
                    { 26, "PHI", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3924), "Philadelphia Eagles", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3925), null, "Eagles", 1 },
                    { 27, "PIT", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3938), "Pittsburgh Steelers", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3939), null, "Steelers", 1 },
                    { 28, "SF", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3953), "San Francisco 49ers", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3954), null, "49ers", 1 },
                    { 29, "SEA", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3968), "Seattle Seahawks", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3969), null, "Seahawks", 1 },
                    { 30, "TB", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3982), "Tampa Bay Buccaneers", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3983), null, "Buccaneers", 1 },
                    { 31, "TEN", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3996), "Tennessee Titans", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(3997), null, "Titans", 1 },
                    { 32, "WAS", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(4011), "Washington Commanders", new DateTime(2023, 7, 11, 16, 42, 26, 413, DateTimeKind.Local).AddTicks(4012), null, "Commanders", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_SportId",
                table: "Competitions",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPlayer_PlayersId",
                table: "GroupPlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_OwnerId",
                table: "Groups",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RoundId",
                table: "Matches",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_PredictionMatches_MatchId",
                table: "PredictionMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PredictionMatches_PlayerId",
                table: "PredictionMatches",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PredictionSeasonRules_PredictionSeasonId",
                table: "PredictionSeasonRules",
                column: "PredictionSeasonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PredictionSeasons_GroupId",
                table: "PredictionSeasons",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PredictionSeasons_PlayerId",
                table: "PredictionSeasons",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PredictionSeasons_SeasonId",
                table: "PredictionSeasons",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_SeasonId",
                table: "Rounds",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_CompetitionId",
                table: "Seasons",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SeasonId",
                table: "Teams",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                table: "Teams",
                column: "SportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupPlayer");

            migrationBuilder.DropTable(
                name: "PredictionMatches");

            migrationBuilder.DropTable(
                name: "PredictionSeasonRules");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "PredictionSeasons");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
