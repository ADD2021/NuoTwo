using DeviceDashboard.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceDashboard.API.DbContexts
{
    public class DeviceDashboardContext : DbContext
    {
        /// <summary>
        /// Context class that represent database
        /// </summary>
        /// <param name="options"></param>
        public DeviceDashboardContext(DbContextOptions<DeviceDashboardContext> options)
           : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Reading> Readings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Device>().HasData(
                new Device()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Address = "Gaje Alage 8, Zagreb, Hrvatska"
                },
                new Device()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Address = "Kobiljacka 50, Zagreb, Hrvatska"
                },
                new Device()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Address = "Pete Poljanice 12, Zagreb, Hrvatska"
                },
                new Device()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Address = "Maksimirska 23, Zagreb, Hrvatska"
                },
                new Device()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Address = "Sesvete 45, Zagreb, Hrvatska"
                }
                );

            modelBuilder.Entity<Reading>().HasData(
               new Reading
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   DeviceId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 12,
                   O2Production = 10
               },
               new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7d4"),
                   DeviceId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   CreatedAt = 1603368000000,
                   CO2Consumption = 15,
                   O2Production = 8
                   
               },
               new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea737"),
                   DeviceId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   CreatedAt = 1603454400000,
                   CO2Consumption = 10,
                   O2Production = 4
                   
               },
               new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7a6"),
                   DeviceId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 12,
                   O2Production = 10
                   
               },
               new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7b7"),
                   DeviceId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   CreatedAt = 1603371600000,
                   CO2Consumption = 11,
                   O2Production = 6
                   
               },
               new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea766"),
                   DeviceId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 14,
                   O2Production = 8
                   
               },
               new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea76b"),
                   DeviceId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   CreatedAt = 1603368000000,
                   CO2Consumption = 16,
                   O2Production = 9
                   
               },
                new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7b5"),
                   DeviceId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   CreatedAt = 1603454400000,
                   CO2Consumption = 5,
                   O2Production = 1
                   
               },
                new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea655"),
                   DeviceId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 14,
                   O2Production = 8
                   
               },
                new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7a5"),
                   DeviceId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   CreatedAt = 1603371600000,
                   CO2Consumption = 11,
                   O2Production = 6
                   
               },
                new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea754"),
                   DeviceId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 12,
                   O2Production = 7
                   
               },
                new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea745"),
                   DeviceId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   CreatedAt = 1603368000000,
                   CO2Consumption = 14,
                   O2Production = 6
                   
               },
                new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea744"),
                   DeviceId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   CreatedAt = 1603454400000,
                   CO2Consumption = 9,
                   O2Production = 3
                   
               },
                new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea743"),
                   DeviceId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 12,
                   O2Production = 7
                   
               },
                new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea734"),
                   DeviceId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   CreatedAt = 1603371600000,
                   CO2Consumption = 13,
                   O2Production = 5
                   
               },
                new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea633"),
                   DeviceId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 17,
                   O2Production = 10
                   
               },
                 new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea733"),
                   DeviceId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                   CreatedAt = 1603368000000,
                   CO2Consumption = 13,
                   O2Production = 7
                   
               },
                 new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea721"),
                   DeviceId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                   CreatedAt = 1603454400000,
                   CO2Consumption = 18,
                   O2Production = 11
                   
               },
                 new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea723"),
                   DeviceId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 17,
                   O2Production = 10
                   
               },
                 new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea722"),
                   DeviceId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                   CreatedAt = 1603371600000,
                   CO2Consumption = 12,
                   O2Production = 5
                   
               },
                 new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea711"),
                   DeviceId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 19,
                   O2Production = 12
                   
               },
                  new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea712"),
                   DeviceId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                   CreatedAt = 1603368000000,
                   CO2Consumption = 23,
                   O2Production = 17
                   
               },
                  new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea77a"),
                   DeviceId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                   CreatedAt = 1603454400000,
                   CO2Consumption = 9,
                   O2Production = 2
                   
               },
                  new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea778"),
                   DeviceId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                   CreatedAt = 1603540800000,
                   CO2Consumption = 19,
                   O2Production = 12
                   
               },
                  new Reading
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea777"),
                   DeviceId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                   CreatedAt = 1603371600000,
                   CO2Consumption = 14,
                   O2Production = 7
                   
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
