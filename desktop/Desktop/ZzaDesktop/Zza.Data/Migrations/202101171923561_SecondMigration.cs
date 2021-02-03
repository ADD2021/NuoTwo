namespace Zza.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItemOption", "OrderItemId", "dbo.OrderItem");
            DropForeignKey("dbo.OrderItemOption", "ProductOptionId", "dbo.ProductOption");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "ProductSizeId", "dbo.ProductSize");
            DropForeignKey("dbo.Order", "OrderStatusId", "dbo.OrderStatus");
            DropIndex("dbo.Order", new[] { "OrderStatusId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "ProductSizeId" });
            DropIndex("dbo.OrderItemOption", new[] { "OrderItemId" });
            DropIndex("dbo.OrderItemOption", new[] { "ProductOptionId" });
            AddColumn("dbo.Customer", "Address", c => c.String());
            AddColumn("dbo.Order", "CO2Consumption", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "O2Production", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "CreatedAt", c => c.Long(nullable: false));
            DropColumn("dbo.Customer", "StoreId");
            DropColumn("dbo.Customer", "FirstName");
            DropColumn("dbo.Customer", "LastName");
            DropColumn("dbo.Customer", "Phone");
            DropColumn("dbo.Customer", "Email");
            DropColumn("dbo.Customer", "Street");
            DropColumn("dbo.Customer", "City");
            DropColumn("dbo.Customer", "State");
            DropColumn("dbo.Customer", "Zip");
            DropColumn("dbo.Order", "StoreId");
            DropColumn("dbo.Order", "OrderStatusId");
            DropColumn("dbo.Order", "OrderDate");
            DropColumn("dbo.Order", "DeliveryDate");
            DropColumn("dbo.Order", "DeliveryCharge");
            DropColumn("dbo.Order", "ItemsTotal");
            DropColumn("dbo.Order", "Phone");
            DropColumn("dbo.Order", "DeliveryStreet");
            DropColumn("dbo.Order", "DeliveryCity");
            DropColumn("dbo.Order", "DeliveryState");
            DropColumn("dbo.Order", "DeliveryZip");
            DropTable("dbo.OrderItem");
            DropTable("dbo.OrderItemOption");
            DropTable("dbo.ProductOption");
            DropTable("dbo.Product");
            DropTable("dbo.ProductSize");
            DropTable("dbo.OrderStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSize",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PremiumPrice = c.Decimal(precision: 18, scale: 2),
                        ToppingPrice = c.Decimal(precision: 18, scale: 2),
                        IsGlutenFree = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        HasOptions = c.Boolean(nullable: false),
                        IsVegetarian = c.Boolean(nullable: false),
                        WithTomatoSauce = c.Boolean(nullable: false),
                        SizeIds = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Factor = c.Int(nullable: false),
                        IsPizzaOption = c.Boolean(nullable: false),
                        IsSaladOption = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItemOption",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StoreId = c.Guid(),
                        OrderItemId = c.Long(nullable: false),
                        ProductOptionId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StoreId = c.Guid(),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductSizeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Instructions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Order", "DeliveryZip", c => c.String());
            AddColumn("dbo.Order", "DeliveryState", c => c.String());
            AddColumn("dbo.Order", "DeliveryCity", c => c.String());
            AddColumn("dbo.Order", "DeliveryStreet", c => c.String());
            AddColumn("dbo.Order", "Phone", c => c.String());
            AddColumn("dbo.Order", "ItemsTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "DeliveryCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "DeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Order", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Order", "OrderStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "StoreId", c => c.Guid());
            AddColumn("dbo.Customer", "Zip", c => c.String());
            AddColumn("dbo.Customer", "State", c => c.String());
            AddColumn("dbo.Customer", "City", c => c.String());
            AddColumn("dbo.Customer", "Street", c => c.String());
            AddColumn("dbo.Customer", "Email", c => c.String());
            AddColumn("dbo.Customer", "Phone", c => c.String());
            AddColumn("dbo.Customer", "LastName", c => c.String());
            AddColumn("dbo.Customer", "FirstName", c => c.String());
            AddColumn("dbo.Customer", "StoreId", c => c.Guid());
            DropColumn("dbo.Order", "CreatedAt");
            DropColumn("dbo.Order", "O2Production");
            DropColumn("dbo.Order", "CO2Consumption");
            DropColumn("dbo.Customer", "Address");
            CreateIndex("dbo.OrderItemOption", "ProductOptionId");
            CreateIndex("dbo.OrderItemOption", "OrderItemId");
            CreateIndex("dbo.OrderItem", "ProductSizeId");
            CreateIndex("dbo.OrderItem", "ProductId");
            CreateIndex("dbo.OrderItem", "OrderId");
            CreateIndex("dbo.Order", "OrderStatusId");
            AddForeignKey("dbo.Order", "OrderStatusId", "dbo.OrderStatus", "Id");
            AddForeignKey("dbo.OrderItem", "ProductSizeId", "dbo.ProductSize", "Id");
            AddForeignKey("dbo.OrderItem", "ProductId", "dbo.Product", "Id");
            AddForeignKey("dbo.OrderItem", "OrderId", "dbo.Order", "Id");
            AddForeignKey("dbo.OrderItemOption", "ProductOptionId", "dbo.ProductOption", "Id");
            AddForeignKey("dbo.OrderItemOption", "OrderItemId", "dbo.OrderItem", "Id");
        }
    }
}
