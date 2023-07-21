using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    first_name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "VARCHAR(10)", fixedLength: true, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    has_passed_quiz = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    has_passed_sample_test = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    image_url = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    national_id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    facebook_url = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    instagram_url = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    linkedin_url = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GitHubUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    twitter_url = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    youtube_url = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_delete = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    created_on = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    created_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_updated_by = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    last_modified_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeviceSpecifications",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    device_name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    device_type = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    device_version = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tester_id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    created_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_modified_at = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    last_modified_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceSpecifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_DeviceSpecifications_AspNetUsers_tester_id",
                        column: x => x.tester_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    exeprience_name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    exeprience_year = table.Column<int>(type: "INT(2)", maxLength: 2, nullable: false),
                    exeprience_month = table.Column<int>(type: "INT(2)", maxLength: 2, nullable: false),
                    exeprience_description = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tester_id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    created_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_modified_at = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    last_modified_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.id);
                    table.ForeignKey(
                        name: "FK_Experiences_AspNetUsers_tester_id",
                        column: x => x.tester_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    qualification_type = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    qualification_organization = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    qualification_course = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    qualification_specialization = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QualificationStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    QualificationEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    tester_id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    created_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_modified_at = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    last_modified_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Qualifications_AspNetUsers_tester_id",
                        column: x => x.tester_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    question_id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_correct = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    created_on = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    created_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_updated_by = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    last_modified_by = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.id);
                    table.ForeignKey(
                        name: "FK_Option_Question_question_id",
                        column: x => x.question_id,
                        principalTable: "Question",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00a8efe8-7a63-49c3-9a55-b395f26e6b72", "1", "Admin", "ADMIN" },
                    { "5f88d5a4-60ca-46b7-829d-596d343ed923", "2", "Tester", "TESTER" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name" },
                values: new object[,]
                {
                    { "28856ff5-c18b-42e3-aa99-158e53da22a8", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4862), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Which is not the software characteristics" },
                    { "3db86fc9-d498-4569-adf4-84af90ef0a72", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4849), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Bug life cycle (1M)" },
                    { "45986160-b05c-47b8-8c41-ec779a4bd0bc", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4924), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Which of the following requirements would be tested by a functional system" },
                    { "4f51da80-effa-428d-92a7-8c5feca3714e", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5241), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Which of the following statements are true?" },
                    { "5a9a2050-fe54-4ea0-b46e-4d22c9262c17", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4834), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Which is the non-functional testing" },
                    { "5dbe8215-8b4a-4643-8095-4bdd6e681b04", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5172), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "What is the main reason for testing software before releasing it?" },
                    { "626cf1a3-edb8-4632-a02f-ca438502d997", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5267), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Regression testing should be performed: \r\nv) every week\r\nw) after the software has changed\r\nx) as often as possible\r\ny) when the environment has changed\r\nz) when the project manager says\r\n" },
                    { "6a2014ce-e8ea-458a-b254-e27a84220f6b", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4949), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "One Key reason why developers have difficulty testing their own work is:" },
                    { "6b0db9f2-11c6-491b-9381-28a2f0089297", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4935), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Pick the best definition of quality" },
                    { "7d718fb2-e2b8-4d0b-94c7-9e6a268e6bf0", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5288), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "What is the purpose of test completion criteria in a test plan:" },
                    { "8666811e-9b83-416b-8604-a1b573eb7cb5", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5278), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Non-functional system testing includes:" },
                    { "8b7c48d2-5b18-4fa1-a866-799af5a8a795", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5160), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Faults found by users are due to:" },
                    { "9eab715e-48bd-4fd3-896e-caecc38e0fe6", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4888), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Which is not the testing objectives" },
                    { "9fc5ab8d-e320-408e-a863-7ccd6b1e7094", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5252), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "When what is visible to end-users is a deviation from the specific or expected behavior, this is called:" },
                    { "bf82b49c-458e-4a75-8d3b-fd055fbc8c5d", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4914), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Which of the following are valid objectives for testing?\r\ni. To find defects.\r\nii. To gain confidence in the level of quality.\r\niii. To identify the cause of defects.\r\niv. To prevent defects.\r\n" },
                    { "ca131cf0-9120-4631-94b9-b623bb8f6966", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5108), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "During the software development process, at what point can the test process start?" },
                    { "d9fbec6c-5261-42c2-a00e-f16fc49a9cda", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4903), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Which is not the fundamental test process " },
                    { "df811d72-625a-4346-b9af-4da5f112d2e3", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(4799), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "System testing should investigate" },
                    { "e04a00de-7ec9-4071-af43-0f39c3e4fb75", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5299), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "What statement about expected outcomes is FALSE:" },
                    { "e1a23107-a828-4106-a2fb-e3241647b0d0", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5227), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Which of the following statements is not true" },
                    { "e8e31d2c-8ae3-4f87-90d1-838b04b0354b", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5148), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Acceptance test cases are based on what?" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "0067e3ed-d57b-4452-bb15-7d03b62acfde", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6373), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Lack of Objectivity", "6a2014ce-e8ea-458a-b254-e27a84220f6b" },
                    { "02d99d82-bacc-46bc-b6f0-f415dd04e508", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6444), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Requirements", "e8e31d2c-8ae3-4f87-90d1-838b04b0354b" },
                    { "0a9a5f71-9d58-4c80-8a83-c1a9d540d424", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6806), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "testing quality attributes of the system including performance and usability", "8666811e-9b83-416b-8604-a1b573eb7cb5" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "0ad60d0b-4d74-49dd-9a39-82bdb456a96d", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5761), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Reliability", "28856ff5-c18b-42e3-aa99-158e53da22a8" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "0c85a6ea-f1d6-4eea-86dc-eb529ef94ac9", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6601), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "to give information for a risk-based decision about release", "5dbe8215-8b4a-4643-8095-4bdd6e681b04" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "0f427a43-f819-4931-bd28-2af6f6e95ef7", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6846), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "to set the criteria used in generating test inputs", "7d718fb2-e2b8-4d0b-94c7-9e6a268e6bf0" },
                    { "10d4f82b-fa24-4776-b04c-704fedeaf466", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6665), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "an error", "9fc5ab8d-e320-408e-a863-7ccd6b1e7094" },
                    { "12a642ad-2050-499d-8f2e-9315d93441dd", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6194), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Quality is job one", "6b0db9f2-11c6-491b-9381-28a2f0089297" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "1644762b-80ee-4f88-8c06-0828222f75a6", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5395), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Performance testing", "5a9a2050-fe54-4ea0-b46e-4d22c9262c17" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "18ae6f80-6873-41de-b292-c7640aedea94", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6451), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Design", "e8e31d2c-8ae3-4f87-90d1-838b04b0354b" },
                    { "19ddb2d4-9623-4fe7-af06-ea64b5d43dd5", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5382), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Non-functional requirements or Functional requirements", "df811d72-625a-4346-b9af-4da5f112d2e3" },
                    { "1bbb83ab-8439-452a-9580-f04360b8d4bd", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6645), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Faults in code are the most expensive to fix", "4f51da80-effa-428d-92a7-8c5feca3714e" },
                    { "23a2b0d6-da5f-47ad-ba50-620319e8548e", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6210), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Zero defects", "6b0db9f2-11c6-491b-9381-28a2f0089297" },
                    { "2424c93b-7d17-44d0-b88a-bb795c085a0c", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5987), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, " i,ii, and iii", "bf82b49c-458e-4a75-8d3b-fd055fbc8c5d" },
                    { "242d6d1c-ef7f-4275-94ad-3abec166a528", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5586), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Open, Fixed, Assigned, Closed", "3db86fc9-d498-4569-adf4-84af90ef0a72" },
                    { "25614a45-ad5d-4f86-875f-19ab6fc72626", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6389), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "When the code is complete", "ca131cf0-9120-4631-94b9-b623bb8f6966" },
                    { "26ac2a27-967d-47aa-98fa-068ee18ae85c", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5609), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Assigned, Open, Closed, Fixed", "3db86fc9-d498-4569-adf4-84af90ef0a72" },
                    { "26b8ae43-4eb7-4f22-b0d2-5f735637d09f", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5947), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Test closure activities", "d9fbec6c-5261-42c2-a00e-f16fc49a9cda" },
                    { "26d1dcd7-e6cb-41bc-b513-02b47cbd395f", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5803), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Maintainability", "28856ff5-c18b-42e3-aa99-158e53da22a8" },
                    { "28e24e1e-0441-4029-a250-bb60e2f89059", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6054), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "The system must perform adequately for up to 30 users", "45986160-b05c-47b8-8c41-ec779a4bd0bc" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "30d759fe-d7c4-42c1-acdb-b4c6a152aebb", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6157), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "The system must allow a user to amend the address of a customer", "45986160-b05c-47b8-8c41-ec779a4bd0bc" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "41cf7874-c11c-4fd6-b271-5d2e7f0413b8", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6674), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "a fault", "9fc5ab8d-e320-408e-a863-7ccd6b1e7094" },
                    { "4434840e-1a54-4c7e-a6e6-9ce957436f8a", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6813), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "testing a system feature using only the software required for that action", "8666811e-9b83-416b-8604-a1b573eb7cb5" },
                    { "446b94e2-f9b9-47ca-aea4-07fe9c68487b", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6180), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "The system must allow 12,000 new customers per year", "45986160-b05c-47b8-8c41-ec779a4bd0bc" },
                    { "44a5aac4-fb50-4d10-a6f1-8ad60a53ad84", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5410), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Unit testing", "5a9a2050-fe54-4ea0-b46e-4d22c9262c17" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "4549c9e0-94f7-4c5e-8bbd-6ddc213ec037", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5792), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Scalability", "28856ff5-c18b-42e3-aa99-158e53da22a8" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "46a51975-2686-4c8e-9b97-b312e467102d", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5422), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Regression testing", "5a9a2050-fe54-4ea0-b46e-4d22c9262c17" },
                    { "4947abb1-af24-42a4-b376-470ff7daa041", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6594), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "to find as many bugs as possible before release", "5dbe8215-8b4a-4643-8095-4bdd6e681b04" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "4958a1a8-86de-458f-b971-4ba851a1a28f", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5363), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Non-functional requirements and Functional requirements", "df811d72-625a-4346-b9af-4da5f112d2e3" },
                    { "4ee1ec22-f0e5-453f-9eea-7022fe5244d5", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6423), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "When the software requirements have been approved", "ca131cf0-9120-4631-94b9-b623bb8f6966" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "5606aaa5-6942-46b8-8d57-b3bb12ad5ed5", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6256), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Lack of technical documentation", "6a2014ce-e8ea-458a-b254-e27a84220f6b" },
                    { "568863c4-058c-4899-bb82-f9451284cd20", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6436), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "When the first code module is ready for unit testing", "ca131cf0-9120-4631-94b9-b623bb8f6966" },
                    { "58614372-15bc-48a1-bbac-f3e25054c2f1", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6839), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "to ensure that the test case specification is complete", "7d718fb2-e2b8-4d0b-94c7-9e6a268e6bf0" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "668d4904-8b1c-48d0-b147-247d740cefb9", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6481), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Poor software and poor testing", "8b7c48d2-5b18-4fa1-a866-799af5a8a795" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "687183e6-d1e1-4350-85c3-e4395e431435", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5999), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "ii, iii and iv", "bf82b49c-458e-4a75-8d3b-fd055fbc8c5d" },
                    { "6aeffff0-fa4c-4ce0-9177-8fd1cde9455e", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6344), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Lack of training", "6a2014ce-e8ea-458a-b254-e27a84220f6b" },
                    { "6af50cad-f0c1-4103-9d14-5b897f2dcfa4", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6281), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Lack of test tools on the market for developers", "6a2014ce-e8ea-458a-b254-e27a84220f6b" },
                    { "6c6da1c4-5ee1-48b6-be00-884ee043396f", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6890), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "expected outcomes should be predicted before a test is run", "e04a00de-7ec9-4071-af43-0f39c3e4fb75" },
                    { "6e077e4b-28b3-45a9-9f97-9e07da1f0ce2", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5917), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Planning and control", "d9fbec6c-5261-42c2-a00e-f16fc49a9cda" },
                    { "6f320c4f-cd92-46cf-84f2-3298e7a54f2b", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6712), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "w, x & y are true, v & z are false", "626cf1a3-edb8-4632-a02f-ca438502d997" },
                    { "6f8755d5-6449-4d24-aeaa-136033e04a5f", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5832), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Gaining confidence about the level of quality and providing information", "9eab715e-48bd-4fd3-896e-caecc38e0fe6" },
                    { "70e4b173-28a6-407a-a95d-a4c391772967", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6632), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Test environments should be as similar to production environments as possible", "e1a23107-a828-4106-a2fb-e3241647b0d0" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "7234807b-2ae2-4b1f-94fb-e52db94b28e7", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6223), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Conformance to requirements", "6b0db9f2-11c6-491b-9381-28a2f0089297" },
                    { "7821aae1-81f6-45b7-b2c9-4baa4948380f", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6681), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "a failure", "9fc5ab8d-e320-408e-a863-7ccd6b1e7094" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "789a597b-d9cb-461a-8119-d2cc85467ece", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6570), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Insufficient time for testing", "8b7c48d2-5b18-4fa1-a866-799af5a8a795" },
                    { "78d204e0-438c-41bc-b55f-6bbb7001fdce", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6827), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "testing for functions that should not exist", "8666811e-9b83-416b-8604-a1b573eb7cb5" },
                    { "7ae120d6-50ec-43b4-919b-adb7594744e9", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6658), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Faults in designs are the most expensive to fix", "4f51da80-effa-428d-92a7-8c5feca3714e" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "826b1757-eb53-4493-b0b5-332161a096fa", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6862), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "to plan when to stop testing", "7d718fb2-e2b8-4d0b-94c7-9e6a268e6bf0" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "82b608e8-4da0-463b-b1ea-a169b99aee7a", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5720), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Assigned, Open, Fixed, Closed", "3db86fc9-d498-4569-adf4-84af90ef0a72" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "8323e576-bea9-4ae5-a5e1-4c027dabae62", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6776), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "w & y are true, v, x & z are false", "626cf1a3-edb8-4632-a02f-ca438502d997" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "919a8a1d-b24b-46c0-9d20-8e1d155935d1", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5778), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Usability", "28856ff5-c18b-42e3-aa99-158e53da22a8" },
                    { "91e5a68f-a8cc-432b-935d-e4707055015d", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6411), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "When the design is complete", "ca131cf0-9120-4631-94b9-b623bb8f6966" },
                    { "94678835-aaf4-4cac-b348-81c2b13eab04", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6790), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "all of the above are true", "626cf1a3-edb8-4632-a02f-ca438502d997" },
                    { "948ac115-8219-4f3b-b0a5-224f36fc6b34", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6466), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Decision table", "e8e31d2c-8ae3-4f87-90d1-838b04b0354b" },
                    { "963a0b1d-202b-44fc-b5e8-02c439f89e04", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6820), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "testing a system feature using only the software required for that function", "8666811e-9b83-416b-8604-a1b573eb7cb5" },
                    { "a1a26a3c-7ac9-4103-a2ea-8c4f189a2374", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6876), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "expected outcomes are derived from a specification, not from the code", "e04a00de-7ec9-4071-af43-0f39c3e4fb75" },
                    { "a2f2d149-6505-4a9f-926c-56a8af408a7a", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6705), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "v & w are true, x – z are false", "626cf1a3-edb8-4632-a02f-ca438502d997" },
                    { "a5c6284d-6683-4744-a08e-c4c3c3ece5f1", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5349), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Functional requirements only not non-functional requirements", "df811d72-625a-4346-b9af-4da5f112d2e3" },
                    { "aa14edbb-d641-4939-af8b-ac484425c6e0", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6698), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "a mistake", "9fc5ab8d-e320-408e-a863-7ccd6b1e7094" },
                    { "aa19266c-bbac-489b-bb1c-e3c0f37d2bca", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6241), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Work as designed", "6b0db9f2-11c6-491b-9381-28a2f0089297" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "b0e1d853-e4d0-4499-9d36-250ce1895f11", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6869), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "expected outcomes are defined by the software’s behavior", "e04a00de-7ec9-4071-af43-0f39c3e4fb75" },
                    { "b396a119-84f5-4466-9fa6-84200999125e", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6011), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "i, ii and iv", "bf82b49c-458e-4a75-8d3b-fd055fbc8c5d" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "b96c4144-d204-40b9-be5f-46e404c841c4", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6488), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Bad luck", "8b7c48d2-5b18-4fa1-a866-799af5a8a795" },
                    { "bb1718ee-3871-45c6-b873-847b1c1c1ac1", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6896), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "expected outcomes may include timing constraints such as response times", "e04a00de-7ec9-4071-af43-0f39c3e4fb75" },
                    { "bc51a669-e351-4bd3-8183-c8c2bf4a2138", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6796), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "testing to see where the system does not function properly", "8666811e-9b83-416b-8604-a1b573eb7cb5" },
                    { "bee855a3-a026-47da-b89a-a72bb6d9ba5d", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6614), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "The acceptance test does not necessarily include a regression test", "e1a23107-a828-4106-a2fb-e3241647b0d0" },
                    { "bf3ff765-2faa-4350-81a4-4f4573207c85", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6473), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Poor quality software", "8b7c48d2-5b18-4fa1-a866-799af5a8a795" },
                    { "c1821b16-0583-4a45-83f1-18112b0096d3", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5844), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Preventing defects", "9eab715e-48bd-4fd3-896e-caecc38e0fe6" },
                    { "c7b9910d-e541-4764-81c4-076d80691978", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6639), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Faults in program specifications are the most expensive to fix", "4f51da80-effa-428d-92a7-8c5feca3714e" },
                    { "c8f78abb-282f-4fab-9c94-3cd292ed0976", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5326), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Non-functional requirements only not Functional requirements", "df811d72-625a-4346-b9af-4da5f112d2e3" },
                    { "cc7132cd-e6b8-4fb2-a819-4a2665638ec0", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6783), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "w is true, v, x y and z are false", "626cf1a3-edb8-4632-a02f-ca438502d997" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "cf4aeb47-e902-4bc4-ac4e-09e915291f13", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5974), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "None", "d9fbec6c-5261-42c2-a00e-f16fc49a9cda" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "d04d3aa6-281e-4ddb-b0d1-cd302f456313", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5816), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Finding defects", "9eab715e-48bd-4fd3-896e-caecc38e0fe6" },
                    { "d343cfcd-3139-4d37-9d74-0dfdd5c978bf", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6043), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, " The system must be able to perform its functions for an average of 23 hours 50 mins Per day", "45986160-b05c-47b8-8c41-ec779a4bd0bc" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "d5a92d0c-88dc-441c-9dbf-9cf6ae9ae07b", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5862), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Debugging defects", "9eab715e-48bd-4fd3-896e-caecc38e0fe6" },
                    { "da49ef2b-4036-4fdc-ab33-6a4f42f27fd3", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5484), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Open, Assigned, Fixed, Closed", "3db86fc9-d498-4569-adf4-84af90ef0a72" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "dc4da15b-fa55-480a-a31e-0843de1a585a", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6031), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "i,iii and iv", "bf82b49c-458e-4a75-8d3b-fd055fbc8c5d" },
                    { "dee4d46f-4fa2-4085-8e34-abed93569569", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6833), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "to know when a specific test has finished its execution", "7d718fb2-e2b8-4d0b-94c7-9e6a268e6bf0" },
                    { "e413a9f5-dcc7-4ddd-9a3f-897f69758e5d", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6581), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "to show that system will work after release", "5dbe8215-8b4a-4643-8095-4bdd6e681b04" },
                    { "e809d30b-1fa1-4aa4-81d3-792bc12a8388", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6852), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "to know when test planning is complete", "7d718fb2-e2b8-4d0b-94c7-9e6a268e6bf0" },
                    { "e96401f8-38f8-44cc-b7d3-fd5a4379fb26", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6458), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Code", "e8e31d2c-8ae3-4f87-90d1-838b04b0354b" },
                    { "ea84723e-7930-4885-a9eb-507c03514466", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6883), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "expected outcomes include outputs to a screen and changes to files and databases", "e04a00de-7ec9-4071-af43-0f39c3e4fb75" },
                    { "ebaf8dd8-52d9-4874-90e9-5cbacbb72075", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6607), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "performance testing can be done during unit testing as well as during the testing of whole system", "e1a23107-a828-4106-a2fb-e3241647b0d0" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "ec14e9c6-87f3-41b4-8b6d-7d094730d7b7", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6621), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Verification activities should not involve testers (reviews, inspections etc)", "e1a23107-a828-4106-a2fb-e3241647b0d0" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[,]
                {
                    { "ec364aa3-b679-4947-9778-ad09018b5775", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6691), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "a defect", "9fc5ab8d-e320-408e-a863-7ccd6b1e7094" },
                    { "f2821b02-c69e-4eb5-9986-c2af31ebac91", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6588), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "to decide when the software is of sufficient quality to release", "5dbe8215-8b4a-4643-8095-4bdd6e681b04" },
                    { "f8ed2952-462e-47a3-8005-831298c4764c", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5434), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Sanity testing", "5a9a2050-fe54-4ea0-b46e-4d22c9262c17" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "is_correct", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "fd127e1a-d1db-4dcb-9e0a-639a5e09d497", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(6652), "0630c378-e8e4-414d-9257-ea2ae873d8f0", true, null, null, "Faults in requirements are the most expensive to fix", "4f51da80-effa-428d-92a7-8c5feca3714e" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "id", "created_on", "created_by", "last_updated_by", "last_modified_by", "name", "question_id" },
                values: new object[] { "ff3a1042-96b0-49d7-9345-a859e7f00a24", new DateTime(2023, 7, 19, 10, 1, 38, 192, DateTimeKind.Local).AddTicks(5962), "0630c378-e8e4-414d-9257-ea2ae873d8f0", null, null, "Analysis and design", "d9fbec6c-5261-42c2-a00e-f16fc49a9cda" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceSpecifications_tester_id",
                table: "DeviceSpecifications",
                column: "tester_id");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_tester_id",
                table: "Experiences",
                column: "tester_id");

            migrationBuilder.CreateIndex(
                name: "IX_Option_question_id",
                table: "Option",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_tester_id",
                table: "Qualifications",
                column: "tester_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceSpecifications");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
