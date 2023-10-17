using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.API.Enums;

namespace PharmacyManagementSystem.API.Models.Domain
{
    public class PharmacyManagementDbContext : DbContext
    {
        public PharmacyManagementDbContext(DbContextOptions<PharmacyManagementDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PickedUpOrder> PickedUpOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drug>()
                .Property(d => d.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Drug>()
                .HasMany(s => s.Suppliers)
                .WithMany(d => d.Drugs)
                .UsingEntity(j =>
                {
                    j.ToTable("DrugSupplier"); // Specify the table name for the junction table

                    // Define the foreign key properties
                    j.HasData(SeedDrugSupplierData());
                });



            base.OnModelCreating(modelBuilder);


            var users = new List<User>()
            {
                new User()
                {
                    UserId = Guid.Parse("EC596F12-B18E-4284-A9B6-16F6DA9DBB42"),
                    //UserName = "SRam12",
                    Email = "sreeram12@gmail.com",
                    FullName = "Sree Ram",
                    PhoneNumber = "7658734658",
                    Gender = Gender.Male,
                    //Password = "Ram1234",
                    Role = "Admin"
                },
                new User()
                {
                    UserId = Guid.Parse("9613F220-2650-4F63-BBB6-13FF6DE4F0F6"),
                    //UserName = "Pavani245",
                    Email = "pavanisri24@gmail.com",
                    FullName = "Pavani Sri",
                    PhoneNumber = "8756847568",
                    Gender = Gender.Female,
                    //Password = "Sri245",
                    Role = "Doctor"
                },
            };

            modelBuilder.Entity<User>().HasData(users);

            var suppliers = new List<Supplier>()
            {
                new Supplier()
                {
                    SupplierId = Guid.Parse("BF2A7B49-3B04-40B6-9D66-4B553CAC184C"),
                    Name = "D Vijay Pharma Pvt. Ltd. ",
                    Email = "dvpharma@gmail.com",
                    ContactNumber = "9826287851",
                },
                new Supplier()
                {
                    SupplierId = Guid.Parse("F70AC1C8-2BD7-4C86-A111-68472643B0B6"),
                    Name = "Gaia Pharmaceutical Trade",
                    Email = "gajapharma@gmail.com",
                    ContactNumber = "8582583454",
                },
                new Supplier()
                {
                    SupplierId = Guid.Parse("C140372D-A6DE-4738-B40A-E1160D81774A"),
                    Name = "Meher Distributors Pvt. Ltd.",
                    Email = "mdpharma@gmail.com",
                    ContactNumber = "9485658458",
                },
                new Supplier()
                {
                    SupplierId = Guid.Parse("0495808A-ACA5-4CA1-A431-6C4FCC150E01"),
                    Name = "Euphoria Healthcare Private Limited",
                    Email = "ehpharma@gmail.com",
                    ContactNumber = "8765545765",
                },
            };

            modelBuilder.Entity<Supplier>().HasData(suppliers);

            var drugs = new List<Drug>()
            {
                new Drug()
                {
                    DrugId = Guid.Parse("6119868F-6D63-4346-B637-7D4058A734BF"),
                    DrugName = "Azithromycin",
                    Quantity = 200,
                    ExpiryDate = DateTime.Now.AddMonths(12),
                    Price = 10.2m,
                    ImageUrl = "",
                },

                new Drug()
                {
                    DrugId = Guid.Parse("25778D4C-C364-4CF2-8AE7-38CB494EFF2B"),
                    DrugName = "Amoxicillin",
                    Quantity = 100,
                    ExpiryDate = DateTime.Now.AddMonths(14),
                    Price = 8.5m,
                    ImageUrl = "",
                },
                new Drug()
                {
                    DrugId = Guid.Parse("97981659-2052-4C72-B307-D7DB41FED780"),
                    DrugName = "Cetirizine",
                    Quantity = 280,
                    ExpiryDate = DateTime.Now.AddMonths(20),
                    Price = 5.5m,
                    ImageUrl = "",
                },
                new Drug()
                {
                    DrugId = Guid.Parse("D48CF152-6CCA-481A-B28E-970B5491F0F2"),
                    DrugName = "Detrol",
                    Quantity = 50,
                    ExpiryDate = DateTime.Now.AddMonths(8),
                    Price = 12.5m,
                    ImageUrl = "",
                },
                new Drug()
                {
                    DrugId = Guid.Parse("8A49F061-C88E-408C-947C-3FB24351D304"),
                    DrugName = "Diclofenac",
                    Quantity = 180,
                    ExpiryDate = DateTime.Now.AddMonths(30),
                    Price = 9.5m,
                    ImageUrl = "",
                },

            };



            modelBuilder.Entity<Drug>().HasData(drugs);



            var orders = new List<Order>()
            {
                new Order()
                {
                    OrderId = Guid.Parse("3D8CD2B2-1FA1-46DA-9CED-0D1DF92DB769"),
                    OrderDate = DateTime.Now,
                    DrugId = Guid.Parse("6119868F-6D63-4346-B637-7D4058A734BF"),
                    UserId = Guid.Parse("9613F220-2650-4F63-BBB6-13FF6DE4F0F6"),
                    Quantity = 10,
                    Status = OrderStatus.Pending
                },
                new Order()
                {
                    OrderId = Guid.Parse("717E33D3-91AA-4417-B64B-BF104D059635"),
                    OrderDate = DateTime.Now,
                    DrugId = Guid.Parse("8A49F061-C88E-408C-947C-3FB24351D304"),
                    UserId = Guid.Parse("9613F220-2650-4F63-BBB6-13FF6DE4F0F6"),
                    Quantity = 20,
                    Status = OrderStatus.PickedUp
                },


            };

            modelBuilder.Entity<Order>().HasData(orders);

            var pickedUpOrders = new List<PickedUpOrder>()
            {
                new PickedUpOrder()
                {
                    PickedUpOrderId = Guid.NewGuid(),
                    PickedUpDate = DateTime.Now,
                    OrderId = Guid.Parse("717E33D3-91AA-4417-B64B-BF104D059635"),
                }
            };

            modelBuilder.Entity<PickedUpOrder>().HasData(pickedUpOrders);

            var payments = new List<Payment>
            {
                new Payment()
                {
                    PaymentId = Guid.NewGuid(),
                    Amount = 102,
                    Method = PaymentMethod.DebitCard,
                    OrderId = Guid.Parse("3D8CD2B2-1FA1-46DA-9CED-0D1DF92DB769")
                },
                new Payment()
                {
                    PaymentId = Guid.NewGuid(),
                    Amount = 190,
                    Method = PaymentMethod.Upi,
                    OrderId = Guid.Parse("717E33D3-91AA-4417-B64B-BF104D059635")
                }

            };

            modelBuilder.Entity<Payment>().HasData(payments);

        }

        private object[] SeedDrugSupplierData()
        {
            var drugSupplierData = new[]
            {
                new {DrugId = Guid.Parse("6119868F-6D63-4346-B637-7D4058A734BF"), SupplierId = Guid.Parse("BF2A7B49-3B04-40B6-9D66-4B553CAC184C")}, //0
                new {DrugId = Guid.Parse("6119868F-6D63-4346-B637-7D4058A734BF"), SupplierId = Guid.Parse("F70AC1C8-2BD7-4C86-A111-68472643B0B6")}, //1

                new {DrugId = Guid.Parse("25778D4C-C364-4CF2-8AE7-38CB494EFF2B"), SupplierId = Guid.Parse("BF2A7B49-3B04-40B6-9D66-4B553CAC184C")},
                new {DrugId = Guid.Parse("25778D4C-C364-4CF2-8AE7-38CB494EFF2B"), SupplierId = Guid.Parse("C140372D-A6DE-4738-B40A-E1160D81774A")}, //2

                new {DrugId = Guid.Parse("97981659-2052-4C72-B307-D7DB41FED780"), SupplierId = Guid.Parse("0495808A-ACA5-4CA1-A431-6C4FCC150E01")}, //3

                new {DrugId = Guid.Parse("D48CF152-6CCA-481A-B28E-970B5491F0F2"), SupplierId = Guid.Parse("C140372D-A6DE-4738-B40A-E1160D81774A")},
                new {DrugId = Guid.Parse("D48CF152-6CCA-481A-B28E-970B5491F0F2"), SupplierId = Guid.Parse("0495808A-ACA5-4CA1-A431-6C4FCC150E01")},

                new {DrugId = Guid.Parse("8A49F061-C88E-408C-947C-3FB24351D304"), SupplierId = Guid.Parse("BF2A7B49-3B04-40B6-9D66-4B553CAC184C")},
                new {DrugId = Guid.Parse("8A49F061-C88E-408C-947C-3FB24351D304"), SupplierId = Guid.Parse("F70AC1C8-2BD7-4C86-A111-68472643B0B6")},
                new {DrugId = Guid.Parse("8A49F061-C88E-408C-947C-3FB24351D304"), SupplierId = Guid.Parse("C140372D-A6DE-4738-B40A-E1160D81774A")},
                new {DrugId = Guid.Parse("8A49F061-C88E-408C-947C-3FB24351D304"), SupplierId = Guid.Parse("0495808A-ACA5-4CA1-A431-6C4FCC150E01")},


            };

            var data = drugSupplierData.Select(item => new Dictionary<string, object>
            {
                { "DrugsDrugId", item.DrugId },
                { "SuppliersSupplierId", item.SupplierId }
            }).ToArray();

            return data;
        }

    }
}

