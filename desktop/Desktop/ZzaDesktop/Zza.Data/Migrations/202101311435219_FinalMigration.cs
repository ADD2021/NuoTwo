namespace Zza.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customer", newName: "Device");
            RenameTable(name: "dbo.Order", newName: "Reading");
            RenameColumn(table: "dbo.Reading", name: "CustomerId", newName: "DeviceId");
            RenameIndex(table: "dbo.Reading", name: "IX_CustomerId", newName: "IX_DeviceId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reading", name: "IX_DeviceId", newName: "IX_CustomerId");
            RenameColumn(table: "dbo.Reading", name: "DeviceId", newName: "CustomerId");
            RenameTable(name: "dbo.Reading", newName: "Order");
            RenameTable(name: "dbo.Device", newName: "Customer");
        }
    }
}
