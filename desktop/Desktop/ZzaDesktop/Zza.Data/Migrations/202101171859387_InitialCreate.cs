namespace Zza.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StoreId = c.Guid(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StoreId = c.Guid(),
                        CustomerId = c.Guid(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemsTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Phone = c.String(),
                        DeliveryStreet = c.String(),
                        DeliveryCity = c.String(),
                        DeliveryState = c.String(),
                        DeliveryZip = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.OrderStatusId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.ProductSize", t => t.ProductSizeId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductSizeId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderItem", t => t.OrderItemId)
                .ForeignKey("dbo.ProductOption", t => t.ProductOptionId)
                .Index(t => t.OrderItemId)
                .Index(t => t.ProductOptionId);
            
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
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Order", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderItem", "ProductSizeId", "dbo.ProductSize");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderItemOption", "ProductOptionId", "dbo.ProductOption");
            DropForeignKey("dbo.OrderItemOption", "OrderItemId", "dbo.OrderItem");
            DropIndex("dbo.OrderItemOption", new[] { "ProductOptionId" });
            DropIndex("dbo.OrderItemOption", new[] { "OrderItemId" });
            DropIndex("dbo.OrderItem", new[] { "ProductSizeId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "OrderStatusId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropTable("dbo.OrderStatus");
            DropTable("dbo.ProductSize");
            DropTable("dbo.Product");
            DropTable("dbo.ProductOption");
            DropTable("dbo.OrderItemOption");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
