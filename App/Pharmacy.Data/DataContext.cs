using System;
using System.Collections.Generic;
using System.Data.Entity;
using Pharmacy.Core;
using Pharmacy.Data.Mapping;

namespace Pharmacy.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Medcine> Medcines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetailses { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<MedcinePriceHistory> MedcinePriceHistories { get; set; }
        public DbSet<Core.Pharmacy> Pharmacies { get; set; }

        public DataContext()
            : base("PharmacyConnectionString")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new PharmacyInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StorageMap());
            modelBuilder.Configurations.Add(new MedcineMap());
            modelBuilder.Configurations.Add(new MedcinePriceHistoryMap());
            modelBuilder.Configurations.Add(new OrderDetailsMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new PharmacyMap());
        }

        private class PharmacyInitializer : CreateDatabaseIfNotExists<DataContext>
        {
            protected override void Seed(DataContext context)
            {
                var pharmacies = new List<Core.Pharmacy> {
                    new Core.Pharmacy() {
                        Address = "Kharkiv",
                        Number = 1,
                        PhoneNumber = "050 000 00 00",
                        OpenDate = DateTime.Now.AddDays(-5),
                    },
                    new Core.Pharmacy() {
                        Address = "Kiev",
                        Number = 2,
                        PhoneNumber = "095 000 00 00",
                        OpenDate = DateTime.Now.AddDays(-10),
                    },
                    new Core.Pharmacy() {
                        Address = "Odessa",
                        Number = 3,
                        PhoneNumber = "099 000 00 00",
                        OpenDate = DateTime.Now.AddDays(-15),
                    }
                };
                foreach (var pharmacy in pharmacies)
                    context.Pharmacies.Add(pharmacy);
                context.SaveChanges();

                var medcines = new List<Medcine> {
                    new Medcine() {
                        Name = "QQQ",
                        Description = "qwqwfewf",
                        Price = 500,
                        SerialNumber = "000-000-00"
                    },
                    new Medcine() {
                        Name = "WWW",
                        Description = "brwbaGS",
                        Price = 1500,
                        SerialNumber = "100-000-00"
                    },
                    new Medcine () {
                        Name = "EEE",
                        Description = "ear43gt",
                        Price = 750,
                        SerialNumber = "200-000-00"
                    }
                };
                foreach (var medcine in medcines)
                    context.Medcines.Add(medcine);
                context.SaveChanges();

                var storages = new List<Storage> {
                    new Storage() {
                        Count = 10,
                        MedcineId = 1,
                        PharmacyId = 1
                    },
                    new Storage() {
                        Count = 15,
                        MedcineId = 2,
                        PharmacyId = 1
                    },
                    new Storage() {
                        Count = 20,
                        MedcineId = 3,
                        PharmacyId = 1
                    },
                    new Storage() {
                        Count = 20,
                        MedcineId = 1,
                        PharmacyId = 2
                    },
                    new Storage() {
                        Count = 30,
                        MedcineId = 3,
                        PharmacyId = 2
                    }
                };
                foreach (var storage in storages)
                    context.Storages.Add(storage);
                context.SaveChanges();

                var orders = new List<Order> {
                    new Order() {
                        PharmacyId = 1,
                        Type = OperationType.Purchase,
                        OrderDate = DateTime.Now.AddDays(-2)
                    },
                    new Order() {
                        PharmacyId = 1,
                        Type = OperationType.Sales,
                        OrderDate = DateTime.Now.AddDays(-3)
                    },
                    new Order() {
                        PharmacyId = 2,
                        Type = OperationType.Sales,
                        OrderDate = DateTime.Now.AddDays(-3)
                    },
                    new Order() {
                        PharmacyId = 3,
                        Type = OperationType.Purchase,
                        OrderDate = DateTime.Now.AddDays(-1)
                    },
                };
                foreach (var order in orders)
                    context.Orders.Add(order);
                context.SaveChanges();

                var orderDetails = new List<OrderDetails> {
                    new OrderDetails() {
                        OrderId = 1,
                        MedcineId = 1,
                        Count = 5,
                        UnitPrice = 150
                    },
                    new OrderDetails() {
                        OrderId = 2,
                        MedcineId = 2,
                        Count = 10,
                        UnitPrice = 250
                    },
                    new OrderDetails() {
                        OrderId = 3,
                        MedcineId = 2,
                        Count = 20,
                        UnitPrice = 550
                    },
                    new OrderDetails() {
                        OrderId = 4,
                        MedcineId = 3,
                        Count = 50,
                        UnitPrice = 1500
                    },
                };
                foreach (var orderDetail in orderDetails)
                    context.OrderDetailses.Add(orderDetail);
                context.SaveChanges();

                var priceHistories = new List<MedcinePriceHistory> {
                    new MedcinePriceHistory() {
                        Price = 175,
                        MedcineId = 1,
                        PriceDate = DateTime.Now.AddHours(-5),
                    },
                    new MedcinePriceHistory() {
                        Price = 275,
                        MedcineId = 1,
                        PriceDate = DateTime.Now.AddHours(-2),
                    },
                    new MedcinePriceHistory() {
                        Price = 450,
                        MedcineId = 2,
                        PriceDate = DateTime.Now.AddHours(-10),
                    },
                    new MedcinePriceHistory() {
                        Price = 600,
                        MedcineId = 3,
                        PriceDate = DateTime.Now.AddHours(-6),
                    }
                };
                foreach (var priceHistory in priceHistories)
                    context.MedcinePriceHistories.Add(priceHistory);
                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}
