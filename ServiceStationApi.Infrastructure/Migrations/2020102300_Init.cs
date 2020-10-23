using FluentMigrator;

[Migration(2020102300)]
public class TestCreateAndDropTableMigration : Migration
{
	public override void Up()
	{
        if (!Schema.Table("Customer").Exists())
        {
            Create.Table("Customer")
              .WithColumn("ID").AsInt16().NotNullable().PrimaryKey("ID")
              .WithColumn("NAME").AsAnsiString(100).NotNullable()
              .WithColumn("Phone").AsAnsiString(50).Nullable();
        }

        #region table
        //CreateTable(
        //        name: "Customer",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(maxLength: 50, nullable: true),
        //            Phone = table.Column<string>(maxLength: 50, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Customer", x => x.Id);
        //        });

        //migrationBuilder.CreateTable(
        //    name: "Work",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        TypeWork = table.Column<string>(maxLength: 50, nullable: true),
        //        Price = table.Column<decimal>(type: "money", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Work", x => x.Id);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Worker",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Name = table.Column<string>(maxLength: 20, nullable: true),
        //        Phone = table.Column<string>(maxLength: 20, nullable: true)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Worker", x => x.Id);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Car",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Car_model = table.Column<string>(maxLength: 50, nullable: true),
        //        Number = table.Column<string>(maxLength: 50, nullable: true),
        //        Date = table.Column<DateTime>(type: "date", nullable: false),
        //        CustomerId = table.Column<int>(nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Car", x => x.Id);
        //        table.ForeignKey(
        //            name: "FK_Car_Customer_CustomerId",
        //            column: x => x.CustomerId,
        //            principalTable: "Customer",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Details",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Name = table.Column<string>(maxLength: 50, nullable: true),
        //        Price = table.Column<decimal>(type: "money", nullable: false),
        //        WorkId = table.Column<int>(nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Details", x => x.Id);
        //        table.ForeignKey(
        //            name: "FK_Details_Work_WorkId",
        //            column: x => x.WorkId,
        //            principalTable: "Work",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Services",
        //    columns: table => new
        //    {
        //        WorkerId = table.Column<int>(nullable: false),
        //        WorkId = table.Column<int>(nullable: false),
        //        Id = table.Column<int>(nullable: false),
        //        Description = table.Column<string>(maxLength: 50, nullable: true),
        //        Date = table.Column<DateTime>(type: "date", nullable: false),
        //        CarId = table.Column<int>(nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Services", x => new { x.WorkerId, x.WorkId });
        //        table.ForeignKey(
        //            name: "FK_Services_Car_CarId",
        //            column: x => x.CarId,
        //            principalTable: "Car",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //        table.ForeignKey(
        //            name: "FK_Services_Work_WorkId",
        //            column: x => x.WorkId,
        //            principalTable: "Work",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //        table.ForeignKey(
        //            name: "FK_Services_Worker_WorkerId",
        //            column: x => x.WorkerId,
        //            principalTable: "Worker",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //    });

        //migrationBuilder.CreateIndex(
        //    name: "IX_Car_CustomerId",
        //    table: "Car",
        //    column: "CustomerId");

        //migrationBuilder.CreateIndex(
        //    name: "IX_Details_WorkId",
        //    table: "Details",
        //    column: "WorkId");

        //migrationBuilder.CreateIndex(
        //    name: "IX_Services_CarId",
        //    table: "Services",
        //    column: "CarId");

        //migrationBuilder.CreateIndex(
        //    name: "IX_Services_WorkId",
        //    table: "Services",
        //    column: "WorkId");
    }
    #endregion
    public override void Down()
    {
        Delete.Table("Customer");
    }		
}


