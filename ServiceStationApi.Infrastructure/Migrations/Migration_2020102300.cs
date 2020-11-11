using FluentMigrator;

using FluentMigrator.SqlServer;

namespace ServiceStationApi.Infrastructure.Migrations
{
    [Migration(2020102300)]
    public class Migration_2020102300 : Migration
    {
        public override void Up()
        {

            Create.Table("Customer")
                  .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Name").AsString(50).NotNullable()
                  .WithColumn("Phone").AsString(50).Nullable();


            Create.Table("Car")
                  .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                  .WithColumn("Nubber").AsString(50).NotNullable()
                  .WithColumn("Car_model").AsString(50).NotNullable()
                  .WithColumn("Date").AsDate().NotNullable()
                  .WithColumn("CustomerId").AsInt32().NotNullable();
            
            Create.Table("Work")
                  .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                  .WithColumn("TypeWork").AsString(50).NotNullable()
                  .WithColumn("Price").AsDecimal(10, 2).NotNullable();
                  
             //Create.PrimaryKey("Pk").OnTable("Work").Column("Id").Clustered();

            Create.Table("Detail")

                  .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                  .WithColumn("NAME").AsString(50).NotNullable()
                  .WithColumn("Price").AsDecimal(10, 2).NotNullable()
                  .WithColumn("WorkId").AsInt32().NotNullable();

            Create.Table("Service")
                  .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Date").AsDate().NotNullable()
                  .WithColumn("Description").AsString(50).NotNullable()
                  .WithColumn("WorkId").AsInt32().NotNullable()
                  .WithColumn("WorkerId").AsInt32().NotNullable()
                  .WithColumn("CarId").AsInt32().NotNullable();
                  

            Create.Table("Worker")
                  .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Name").AsString(50).NotNullable()
                  .WithColumn("Phone").AsString(50).NotNullable();

            Create.ForeignKey()
                .FromTable("Service").ForeignColumn("WorkerId")
                .ToTable("Worker").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("Service").ForeignColumn("CarId")
                .ToTable("Car").PrimaryColumn("Id");
            
            Create.ForeignKey()
                .FromTable("Detail").ForeignColumn("WorkId")
                .ToTable("Work").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("Car").ForeignColumn("CustomerId")
                .ToTable("Customer").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("Service").ForeignColumn("WorkId")
                .ToTable("Work").PrimaryColumn("Id");


            //Execute.Script("service.sql");

        }

        public override void Down()
        {
            Delete.Table("Customer");
            Delete.Table("Car");
            Delete.Table("Detail");
            Delete.Table("Service");
            Delete.Table("Work");
            Delete.Table("Worker");

        }
    }
}

