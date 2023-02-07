using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.ShoppingCartEntities;
using TechWizard.Data.Models.Many2ManyEntities;

namespace TechWizard.Data
{
    public class WizardDbContext : IdentityDbContext<WizardUser>
    {
        public WizardDbContext(DbContextOptions<WizardDbContext> options) : base(options) { }

        // EXTENDED IDENTITY USERS
        public DbSet<WizardUser> WizardUsers { get; set; }
        public DbSet<IdentityRole> identityRoles { get; set; }
        public DbSet<IdentityUserRole<string>> identityUserRoles { get; set; }

        // ENTITIES
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<AttributeType> AttributeTypes { get; set; }

        // SHOPPING CART ENTITIES
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        // MANY TO MANY ENTITIES
        public DbSet<Product_AttributeType> Products_AttributeTypes { get; set; }
        public DbSet<ProductType_AttributeType> ProductTypes_AttributeTypes { get; set; }

        private string GenerateProductCode()
        {
            string code = Guid.NewGuid().ToString().Substring(0, 18).ToUpper();
            return code;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DEFINING MANY TO MANY RELATIONSHIP
            modelBuilder.Entity<Product_AttributeType>().HasKey(x => new { x.ProductId, x.AttributeTypeId });

            modelBuilder.Entity<Product_AttributeType>()
            .HasOne(x => x.Product)
            .WithMany(x => x.Attributes)
            .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Product_AttributeType>()
            .HasOne(x => x.AttributeType)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.AttributeTypeId);


            modelBuilder.Entity<ProductType_AttributeType>().HasKey(x => new { x.ProductTypeId, x.AttributeTypeId });

            modelBuilder.Entity<ProductType_AttributeType>()
            .HasOne(x => x.ProductType)
            .WithMany(x => x.Attributes)
            .HasForeignKey(x => x.ProductTypeId);

            modelBuilder.Entity<ProductType_AttributeType>()
            .HasOne(x => x.AttributeType)
            .WithMany(x => x.ProductTypes)
            .HasForeignKey(x => x.AttributeTypeId);


            //SETTING UNIQUE KEYS
            modelBuilder.Entity<AttributeType>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<ProductType>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(x => x.Name).IsUnique();

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {
            var brands = new List<Brand>()
            {
                new Brand() { Id = 1, Name = "ASUS" },
                new Brand() { Id = 2, Name = "GIGABYTE" },
                new Brand() { Id = 3, Name = "MSI" },
                new Brand() { Id = 4, Name = "SAPPHIRE" },
                new Brand() { Id = 5, Name = "AMD" },
                new Brand() { Id = 6, Name = "INTEL" },
                new Brand() { Id = 7, Name = "MS" },
                new Brand() { Id = 8, Name = "ARMAGGEDDON" },
                new Brand() { Id = 9, Name = "KINGSTON" },
                new Brand() { Id = 10, Name = "GEIL" },
                new Brand() { Id = 11, Name = "CRUCIAL" },
                new Brand() { Id = 12, Name = "WESTERN DIGITAL" },
                new Brand() { Id = 13, Name = "SEAGATE" },
                new Brand() { Id = 14, Name = "TOSHIBA" },
                new Brand() { Id = 15, Name = "SAMSUNG" },
                new Brand() { Id = 16, Name = "CHIEFTEC" },
                new Brand() { Id = 17, Name = "COOLER MASTER" },
                new Brand() { Id = 18, Name = "LC-POWER" },
                new Brand() { Id = 19, Name = "FSP" },
                new Brand() { Id = 20, Name = "CORSAIR" },
                new Brand() { Id = 21, Name = "G.SKILL" },
                new Brand() { Id = 22, Name = "GAINWARD" },
                new Brand() { Id = 23, Name = "ZOTAC" },
                new Brand() { Id = 24, Name = "THERMALTAKE" },
                new Brand() { Id = 25, Name = "REDRAGON" },
                new Brand() { Id = 26, Name = "AS ROCK" },
            };


            var productTypes = new List<ProductType>()
            {
                new ProductType() { Id = 1, Name = "Motherboard" },
                new ProductType() { Id = 2, Name = "Processor" },
                new ProductType() { Id = 3, Name = "Graphics card" },
                new ProductType() { Id = 4, Name = "RAM memory" },
                new ProductType() { Id = 5, Name = "HDD" },
                new ProductType() { Id = 6, Name = "SSD" },
                new ProductType() { Id = 7, Name = "Power supply" },
                new ProductType() { Id = 8, Name = "PC Case" }
            };

            var attributeTypes = new List<AttributeType>()
            {
                new AttributeType() { Id = 1, Name = "CPU Manufacturer"},
                new AttributeType() { Id = 2, Name = "Socket"},
                new AttributeType() { Id = 3, Name = "Chipset"},
                new AttributeType() { Id = 4, Name = "Memory type"},
                new AttributeType() { Id = 5, Name = "CPU model"},
                new AttributeType() { Id = 6, Name = "Amount of cores"},
                new AttributeType() { Id = 7, Name = "Amount of threads"},
                new AttributeType() { Id = 8, Name = "Frequency"},
                new AttributeType() { Id = 9, Name = "GPU model"},
                new AttributeType() { Id = 10, Name = "GPU Manufacturer"},
                new AttributeType() { Id = 11, Name = "Capacity"},
                new AttributeType() { Id = 12, Name = "Latency"},
                new AttributeType() { Id = 13, Name = "RPM"},
                new AttributeType() { Id = 14, Name = "Buffer"},
                new AttributeType() { Id = 15, Name = "SSD format"},
                new AttributeType() { Id = 16, Name = "Writing speed"},
                new AttributeType() { Id = 17, Name = "Reading speed"},
                new AttributeType() { Id = 18, Name = "Power output"},
                new AttributeType() { Id = 19, Name = "Color"},
                new AttributeType() { Id = 20, Name = "Size"},
            };

            var productTypes_attributeTypes = new List<ProductType_AttributeType>()
            {
                // MOTHERBOARD
                new ProductType_AttributeType() { ProductTypeId = 1, AttributeTypeId = 1 },
                new ProductType_AttributeType() { ProductTypeId = 1, AttributeTypeId = 2 },
                new ProductType_AttributeType() { ProductTypeId = 1, AttributeTypeId = 3 },
                new ProductType_AttributeType() { ProductTypeId = 1, AttributeTypeId = 4 },

                // PROCESSOR
                //new ProductType_AttributeType() { ProductTypeId = 2, AttributeTypeId = 1 },
                new ProductType_AttributeType() { ProductTypeId = 2, AttributeTypeId = 2 },
                new ProductType_AttributeType() { ProductTypeId = 2, AttributeTypeId = 5 },
                new ProductType_AttributeType() { ProductTypeId = 2, AttributeTypeId = 6 },
                new ProductType_AttributeType() { ProductTypeId = 2, AttributeTypeId = 7 },
                new ProductType_AttributeType() { ProductTypeId = 2, AttributeTypeId = 8 },

                // GRAPHICS CARD
                new ProductType_AttributeType() { ProductTypeId = 3, AttributeTypeId = 10 },
                new ProductType_AttributeType() { ProductTypeId = 3, AttributeTypeId = 9 },
                new ProductType_AttributeType() { ProductTypeId = 3, AttributeTypeId = 4 },
                new ProductType_AttributeType() { ProductTypeId = 3, AttributeTypeId = 11 },

                // RAM MEMORY
                new ProductType_AttributeType() { ProductTypeId = 4, AttributeTypeId = 4 },
                new ProductType_AttributeType() { ProductTypeId = 4, AttributeTypeId = 11 },
                new ProductType_AttributeType() { ProductTypeId = 4, AttributeTypeId = 8 },
                new ProductType_AttributeType() { ProductTypeId = 4, AttributeTypeId = 12 },

                // HDD
                new ProductType_AttributeType() { ProductTypeId = 5, AttributeTypeId = 11 },
                new ProductType_AttributeType() { ProductTypeId = 5, AttributeTypeId = 13 },
                new ProductType_AttributeType() { ProductTypeId = 5, AttributeTypeId = 14 },

                // SSD
                new ProductType_AttributeType() { ProductTypeId = 6, AttributeTypeId = 15 },
                new ProductType_AttributeType() { ProductTypeId = 6, AttributeTypeId = 11 },
                new ProductType_AttributeType() { ProductTypeId = 6, AttributeTypeId = 17 },
                new ProductType_AttributeType() { ProductTypeId = 6, AttributeTypeId = 16 },

                // POWER SUPPLY
                new ProductType_AttributeType() { ProductTypeId = 7, AttributeTypeId = 18 },

                // PC CASE
                new ProductType_AttributeType() { ProductTypeId = 8, AttributeTypeId = 19 },
                new ProductType_AttributeType() { ProductTypeId = 8, AttributeTypeId = 20 },
            };

            var products_attributeTypes = new List<Product_AttributeType>()
            {
                // MOTHERBOARD
                new Product_AttributeType() { ProductId = 1, AttributeTypeId = 1, Value = "AMD" },
                new Product_AttributeType() { ProductId = 1, AttributeTypeId = 2, Value = "AMD AM4" },
                new Product_AttributeType() { ProductId = 1, AttributeTypeId = 3, Value = "AMD B550" },
                new Product_AttributeType() { ProductId = 1, AttributeTypeId = 4, Value = "DDR4" },

                new Product_AttributeType() { ProductId = 2, AttributeTypeId = 1, Value = "AMD" },
                new Product_AttributeType() { ProductId = 2, AttributeTypeId = 2, Value = "AMD AM4" },
                new Product_AttributeType() { ProductId = 2, AttributeTypeId = 3, Value = "AMD B450" },
                new Product_AttributeType() { ProductId = 2, AttributeTypeId = 4, Value = "DDR4" },

                new Product_AttributeType() { ProductId = 3, AttributeTypeId = 1, Value = "Intel" },
                new Product_AttributeType() { ProductId = 3, AttributeTypeId = 2, Value = "Intel 1700" },
                new Product_AttributeType() { ProductId = 3, AttributeTypeId = 3, Value = "Intel B660" },
                new Product_AttributeType() { ProductId = 3, AttributeTypeId = 4, Value = "DDR4" },

                new Product_AttributeType() { ProductId = 4, AttributeTypeId = 1, Value = "Intel" },
                new Product_AttributeType() { ProductId = 4, AttributeTypeId = 2, Value = "Intel 1200" },
                new Product_AttributeType() { ProductId = 4, AttributeTypeId = 3, Value = "Intel Z590" },
                new Product_AttributeType() { ProductId = 4, AttributeTypeId = 4, Value = "DDR4" },

                new Product_AttributeType() { ProductId = 5, AttributeTypeId = 1, Value = "Intel" },
                new Product_AttributeType() { ProductId = 5, AttributeTypeId = 2, Value = "Intel 1200" },
                new Product_AttributeType() { ProductId = 5, AttributeTypeId = 3, Value = "Intel Z590" },
                new Product_AttributeType() { ProductId = 5, AttributeTypeId = 4, Value = "DDR4" },

                // PROCESSOR
                //new Product_AttributeType() { ProductId = 6, AttributeTypeId = 1, Value = "Intel" },
                new Product_AttributeType() { ProductId = 6, AttributeTypeId = 2, Value = "Intel 1200" },
                new Product_AttributeType() { ProductId = 6, AttributeTypeId = 5, Value = "Intel Core i5" },
                new Product_AttributeType() { ProductId = 6, AttributeTypeId = 8, Value = "3.3 GHz" },
                new Product_AttributeType() { ProductId = 6, AttributeTypeId = 6, Value = "6" },
                new Product_AttributeType() { ProductId = 6, AttributeTypeId = 7, Value = "12" },

                //new Product_AttributeType() { ProductId = 7, AttributeTypeId = 1, Value = "Intel" },
                new Product_AttributeType() { ProductId = 7, AttributeTypeId = 2, Value = "Intel 1700" },
                new Product_AttributeType() { ProductId = 7, AttributeTypeId = 5, Value = "Intel Core i9" },
                new Product_AttributeType() { ProductId = 7, AttributeTypeId = 8, Value = "3.2 GHz" },
                new Product_AttributeType() { ProductId = 7, AttributeTypeId = 6, Value = "16" },
                new Product_AttributeType() { ProductId = 7, AttributeTypeId = 7, Value = "24" },

                //new Product_AttributeType() { ProductId = 8, AttributeTypeId = 1, Value = "Intel" },
                new Product_AttributeType() { ProductId = 8, AttributeTypeId = 2, Value = "Intel 1200" },
                new Product_AttributeType() { ProductId = 8, AttributeTypeId = 5, Value = "Intel Core i7" },
                new Product_AttributeType() { ProductId = 8, AttributeTypeId = 8, Value = "2.5 GHz" },
                new Product_AttributeType() { ProductId = 8, AttributeTypeId = 6, Value = "8" },
                new Product_AttributeType() { ProductId = 8, AttributeTypeId = 7, Value = "16" },

                //new Product_AttributeType() { ProductId = 9, AttributeTypeId = 1, Value = "AMD" },
                new Product_AttributeType() { ProductId = 9, AttributeTypeId = 2, Value = "AMD AM4" },
                new Product_AttributeType() { ProductId = 9, AttributeTypeId = 5, Value = "AMD Ryzen 7" },
                new Product_AttributeType() { ProductId = 9, AttributeTypeId = 8, Value = "3.9 GHz" },
                new Product_AttributeType() { ProductId = 9, AttributeTypeId = 6, Value = "8" },
                new Product_AttributeType() { ProductId = 9, AttributeTypeId = 7, Value = "16" },

                //new Product_AttributeType() { ProductId = 10, AttributeTypeId = 1, Value = "AMD" },
                new Product_AttributeType() { ProductId = 10, AttributeTypeId = 2, Value = "AMD AM4" },
                new Product_AttributeType() { ProductId = 10, AttributeTypeId = 5, Value = "AMD Ryzen 7" },
                new Product_AttributeType() { ProductId = 10, AttributeTypeId = 8, Value = "3.4 GHz" },
                new Product_AttributeType() { ProductId = 10, AttributeTypeId = 6, Value = "8" },
                new Product_AttributeType() { ProductId = 10, AttributeTypeId = 7, Value = "16" },

                //GRAPHICS CARD
                new Product_AttributeType() { ProductId = 11, AttributeTypeId = 10, Value = "Nvidia" },
                new Product_AttributeType() { ProductId = 11, AttributeTypeId = 9, Value = "GeForce RTX 3060" },
                new Product_AttributeType() { ProductId = 11, AttributeTypeId = 11, Value = "12 GB" },
                new Product_AttributeType() { ProductId = 11, AttributeTypeId = 4, Value = "GDDR6" },

                new Product_AttributeType() { ProductId = 12, AttributeTypeId = 10, Value = "Nvidia" },
                new Product_AttributeType() { ProductId = 12, AttributeTypeId = 9, Value = "GeForce RTX 2060" },
                new Product_AttributeType() { ProductId = 12, AttributeTypeId = 11, Value = "6 GB" },
                new Product_AttributeType() { ProductId = 12, AttributeTypeId = 4, Value = "GDDR6" },

                new Product_AttributeType() { ProductId = 13, AttributeTypeId = 10, Value = "Nvidia" },
                new Product_AttributeType() { ProductId = 13, AttributeTypeId = 9, Value = "GeForce RTX 3080 Ti" },
                new Product_AttributeType() { ProductId = 13, AttributeTypeId = 11, Value = "12 GB" },
                new Product_AttributeType() { ProductId = 13, AttributeTypeId = 4, Value = "GDDR6X" },

                new Product_AttributeType() { ProductId = 14, AttributeTypeId = 10, Value = "AMD" },
                new Product_AttributeType() { ProductId = 14, AttributeTypeId = 9, Value = "Radeon RX 6700 XT" },
                new Product_AttributeType() { ProductId = 14, AttributeTypeId = 11, Value = "12 GB" },
                new Product_AttributeType() { ProductId = 14, AttributeTypeId = 4, Value = "GDDR6" },

                new Product_AttributeType() { ProductId = 15, AttributeTypeId = 10, Value = "AMD" },
                new Product_AttributeType() { ProductId = 15, AttributeTypeId = 9, Value = "Radeon RX 6500 XT" },
                new Product_AttributeType() { ProductId = 15, AttributeTypeId = 11, Value = "4 GB" },
                new Product_AttributeType() { ProductId = 15, AttributeTypeId = 4, Value = "GDDR6" },

                //RAM MEMORY               
                new Product_AttributeType() { ProductId = 16, AttributeTypeId = 11, Value = "8 GB" },
                new Product_AttributeType() { ProductId = 16, AttributeTypeId = 4, Value = "DDR4" },
                new Product_AttributeType() { ProductId = 16, AttributeTypeId = 8, Value = "3733 MHz" },
                new Product_AttributeType() { ProductId = 16, AttributeTypeId = 12, Value = "CL19" },
                
                new Product_AttributeType() { ProductId = 17, AttributeTypeId = 11, Value = "32 GB" },
                new Product_AttributeType() { ProductId = 17, AttributeTypeId = 4, Value = "DDR4" },
                new Product_AttributeType() { ProductId = 17, AttributeTypeId = 8, Value = "3600 MHz" },
                new Product_AttributeType() { ProductId = 17, AttributeTypeId = 12, Value = "CL18" },

                new Product_AttributeType() { ProductId = 18, AttributeTypeId = 11, Value = "16 GB" },
                new Product_AttributeType() { ProductId = 18, AttributeTypeId = 4, Value = "DDR5" },
                new Product_AttributeType() { ProductId = 18, AttributeTypeId = 8, Value = "6000 MHz" },
                new Product_AttributeType() { ProductId = 18, AttributeTypeId = 12, Value = "CL40" },

                new Product_AttributeType() { ProductId = 19, AttributeTypeId = 11, Value = "32 GB" },
                new Product_AttributeType() { ProductId = 19, AttributeTypeId = 4, Value = "DDR4" },
                new Product_AttributeType() { ProductId = 19, AttributeTypeId = 8, Value = "3200 MHz" },
                new Product_AttributeType() { ProductId = 19, AttributeTypeId = 12, Value = "CL16" },

                new Product_AttributeType() { ProductId = 20, AttributeTypeId = 11, Value = "128 GB" },
                new Product_AttributeType() { ProductId = 20, AttributeTypeId = 4, Value = "DDR4" },
                new Product_AttributeType() { ProductId = 20, AttributeTypeId = 8, Value = "3600 MHz" },
                new Product_AttributeType() { ProductId = 20, AttributeTypeId = 12, Value = "CL18" },

                //HDD
                new Product_AttributeType() { ProductId = 21, AttributeTypeId = 11, Value = "10 TB" },
                new Product_AttributeType() { ProductId = 21, AttributeTypeId = 13, Value = "7200 RPM" },
                new Product_AttributeType() { ProductId = 21, AttributeTypeId = 14, Value = "256 MB" },

                new Product_AttributeType() { ProductId = 22, AttributeTypeId = 11, Value = "2 TB" },
                new Product_AttributeType() { ProductId = 22, AttributeTypeId = 13, Value = "5400 RPM" },
                new Product_AttributeType() { ProductId = 22, AttributeTypeId = 14, Value = "128 MB" },

                new Product_AttributeType() { ProductId = 23, AttributeTypeId = 11, Value = "8 TB" },
                new Product_AttributeType() { ProductId = 23, AttributeTypeId = 13, Value = "7200 RPM" },
                new Product_AttributeType() { ProductId = 23, AttributeTypeId = 14, Value = "256 MB" },

                new Product_AttributeType() { ProductId = 24, AttributeTypeId = 11, Value = "2 TB" },
                new Product_AttributeType() { ProductId = 24, AttributeTypeId = 13, Value = "5400 RPM" },
                new Product_AttributeType() { ProductId = 24, AttributeTypeId = 14, Value = "128 MB" },

                new Product_AttributeType() { ProductId = 25, AttributeTypeId = 11, Value = "2 TB" },
                new Product_AttributeType() { ProductId = 25, AttributeTypeId = 13, Value = "7200 RPM" },
                new Product_AttributeType() { ProductId = 25, AttributeTypeId = 14, Value = "256 MB" },

                //SSD
                new Product_AttributeType() { ProductId = 26, AttributeTypeId = 15, Value = "M.2 2280" },
                new Product_AttributeType() { ProductId = 26, AttributeTypeId = 11, Value = "500 GB" },
                new Product_AttributeType() { ProductId = 26, AttributeTypeId = 17, Value = "3500 MB/s" },
                new Product_AttributeType() { ProductId = 26, AttributeTypeId = 16, Value = "3200 MB/s" },

                new Product_AttributeType() { ProductId = 27, AttributeTypeId = 15, Value = "M.2 2280" },
                new Product_AttributeType() { ProductId = 27, AttributeTypeId = 11, Value = "2 TB" },
                new Product_AttributeType() { ProductId = 27, AttributeTypeId = 17, Value = "3500 MB/s" },
                new Product_AttributeType() { ProductId = 27, AttributeTypeId = 16, Value = "3300 MB/s" },

                new Product_AttributeType() { ProductId = 28, AttributeTypeId = 15, Value = "M.2 2280" },
                new Product_AttributeType() { ProductId = 28, AttributeTypeId = 11, Value = "250 GB" },
                new Product_AttributeType() { ProductId = 28, AttributeTypeId = 17, Value = "3500 MB/s" },
                new Product_AttributeType() { ProductId = 28, AttributeTypeId = 16, Value = "2300 MB/s" },

                new Product_AttributeType() { ProductId = 29, AttributeTypeId = 15, Value = "M.2 2280" },
                new Product_AttributeType() { ProductId = 29, AttributeTypeId = 11, Value = "1 TB" },
                new Product_AttributeType() { ProductId = 29, AttributeTypeId = 17, Value = "5000 MB/s" },
                new Product_AttributeType() { ProductId = 29, AttributeTypeId = 16, Value = "4400 MB/s" },

                new Product_AttributeType() { ProductId = 30, AttributeTypeId = 15, Value = "M.2 2280" },
                new Product_AttributeType() { ProductId = 30, AttributeTypeId = 11, Value = "250 GB" },
                new Product_AttributeType() { ProductId = 30, AttributeTypeId = 17, Value = "2100 MB/s" },
                new Product_AttributeType() { ProductId = 30, AttributeTypeId = 16, Value = "1150 MB/s" },

                //POWER SUPPLY
                new Product_AttributeType() { ProductId = 31, AttributeTypeId = 18, Value = "500W" },

                new Product_AttributeType() { ProductId = 32, AttributeTypeId = 18, Value = "750W" },

                new Product_AttributeType() { ProductId = 33, AttributeTypeId = 18, Value = "242W" },

                new Product_AttributeType() { ProductId = 34, AttributeTypeId = 18, Value = "500W" },

                new Product_AttributeType() { ProductId = 35, AttributeTypeId = 18, Value = "700W" },

                //PC CASE
                new Product_AttributeType() { ProductId = 36, AttributeTypeId = 20, Value = "Midi Tower" },
                new Product_AttributeType() { ProductId = 36, AttributeTypeId = 19, Value = "White" },

                new Product_AttributeType() { ProductId = 37, AttributeTypeId = 20, Value = "Mini Tower" },
                new Product_AttributeType() { ProductId = 37, AttributeTypeId = 19, Value = "Black" },

                new Product_AttributeType() { ProductId = 38, AttributeTypeId = 20, Value = "Midi Tower" },
                new Product_AttributeType() { ProductId = 38, AttributeTypeId = 19, Value = "Black" },

                new Product_AttributeType() { ProductId = 39, AttributeTypeId = 20, Value = "Mini Tower" },
                new Product_AttributeType() { ProductId = 39, AttributeTypeId = 19, Value = "Black" },

                new Product_AttributeType() { ProductId = 40, AttributeTypeId = 20, Value = "Mini Tower" },
                new Product_AttributeType() { ProductId = 40, AttributeTypeId = 19, Value = "Black" },
            };

            var products = new List<Product>()
            {
                // MOTHERBOARDS
                new Product()
                {
                    Id = 1,
                    ProductCode = GenerateProductCode(),
                    BrandId = 1,
                    Name = "Asus Prime B550-PLUS",
                    Price = 209M,
                    Picture = "/images/ASUSPRIMEB550PLUS.png",
                    TypeId = 1,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 88
                },

                new Product()
                {
                    Id = 2,
                    ProductCode = GenerateProductCode(),
                    BrandId = 3,
                    Name = "MSI B450 Gaming PLUS MAX",
                    Price = 159M,
                    Picture = "/images/image5da5cafd9a2b9.png",
                    TypeId = 1,
                    OnPromotion = true,
                    IsVisible = true,
                    Quantity = 23
                },

                new Product()
                {
                    Id = 3,
                    ProductCode = GenerateProductCode(),
                    BrandId = 1,
                    Name = "Asus TUF Gaming B660M-PLUS Wifi D4",
                    Price = 249M,
                    Picture = "/images/image61fd2b7e9bba4.png",
                    TypeId = 1,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 65
                },

                new Product()
                {
                    Id = 4,
                    ProductCode = GenerateProductCode(),
                    BrandId = 2,
                    Name = "Gigabyte Z590I AORUS ULTRA",
                    Price = 399M,
                    Picture = "/images/GIGABYTE-Z590I-AORUS-ULTRA.png",
                    TypeId = 1,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 36
                },

                new Product()
                {
                    Id = 5,
                    ProductCode = GenerateProductCode(),
                    BrandId = 3,
                    Name = "MSI Z590 PRO Wifi",
                    Price = 219M,
                    Picture = "/images/image62458b01608fa.png",
                    TypeId = 1,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 73
                },

                // PROCESSOR
                new Product()
                {
                    Id = 6,
                    ProductCode = GenerateProductCode(),
                    BrandId = 6,
                    Name = "Intel Core i5-10600 3.3GHz (4.8GHz)",
                    Price = 319M,
                    Picture = "/images/image5ec863b23325c.png",
                    TypeId = 2,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 57
                },

                new Product()
                {
                    Id = 7,
                    ProductCode = GenerateProductCode(),
                    BrandId = 6,
                    Name = "Intel Core i9-12900 3.2GHz (5.2GHz)",
                    Price = 899M,
                    Picture = "/images/image61e1691968cfd.png",
                    TypeId = 2,
                    OnPromotion = true,
                    IsVisible = true,
                    Quantity = 20
                },

                new Product()
                {
                    Id = 8,
                    ProductCode = GenerateProductCode(),
                    BrandId = 6,
                    Name = "Intel Core i7-11700 2.5GHz (4.9GHz)",
                    Price = 479M,
                    Picture = "/images/image62a9bde3e51e1.png",
                    TypeId = 2,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 74
                },

                new Product()
                {
                    Id = 9,
                    ProductCode = GenerateProductCode(),
                    BrandId = 5,
                    Name = "AMD Ryzen 7 3800X 3.9GHz (4.5GHz)",
                    Price = 449M,
                    Picture = "/images/image5d66752a42531.png",
                    TypeId = 2,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 46
                },

                new Product()
                {
                    Id = 10,
                    ProductCode = GenerateProductCode(),
                    BrandId = 5,
                    Name = "AMD Ryzen 7 5800X3D 3.4GHz (4.5GHz)",
                    Price = 699M,
                    Picture = "/images/image62728b1684f03.png",
                    TypeId = 2,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 86
                },

                //GRAPHICS CARD
                new Product()
                {
                    Id = 11,
                    ProductCode = GenerateProductCode(),
                    BrandId = 1,
                    Name = "Asus TUF Gaming GeForce RTX 3060 12GB GDDR6 192-bit",
                    Price = 749M,
                    Picture = "/images/ASUS-TUF-Gaming-GeForce-RTX-3060.png",
                    TypeId = 3,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 26
                },

                new Product()
                {
                    Id = 12,
                    ProductCode = GenerateProductCode(),
                    BrandId = 3,
                    Name = "MSI GeForce RTX 2060 VENTUS 6GB GDDR6 192-bit",
                    Price = 599M,
                    Picture = "/images/image614d8cbf61188.png",
                    TypeId = 3,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 34
                },

                new Product()
                {
                    Id = 13,
                    ProductCode = GenerateProductCode(),
                    BrandId = 1,
                    Name = "Asus TUF Gaming GeForce RTX 3080Ti 12GB GDDR6X 384-bit",
                    Price = 2499M,
                    Picture = "/images/ASSUS TUF RTX 3080.png",
                    TypeId = 3,
                    OnPromotion = true,
                    IsVisible = true,
                    Quantity = 15
                },

                new Product()
                {
                    Id = 14,
                    ProductCode = GenerateProductCode(),
                    BrandId = 2,
                    Name = "Gigabyte AMD Radeon RX6700 XT EAGLE 12GB GDDR6 192-bit",
                    Price = 899M,
                    Picture = "/images/gigabyterx6700xtEagle.png",
                    TypeId = 3,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 22
                },

                new Product()
                {
                    Id = 15,
                    ProductCode = GenerateProductCode(),
                    BrandId = 4,
                    Name = "Sapphire PULSE AMD Radeon RX6500 XT 4GB GDDR6 64-bit",
                    Price = 349M,
                    Picture = "/images/rx6500xt.png",
                    TypeId = 3,
                    OnPromotion = true,
                    IsVisible = true,
                    Quantity = 12
                },

                //RAM MEMORY
                new Product()
                {
                    Id = 16,
                    ProductCode = GenerateProductCode(),
                    BrandId = 9,
                    Name = "Kingston Beast RGB 8GB DDR4 3733MHz CL19",
                    Price = 69M,
                    Picture = "/images/ddr48gb3733.png",
                    TypeId = 4,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 76
                },

                new Product()
                {
                    Id = 17,
                    ProductCode = GenerateProductCode(),
                    BrandId = 9,
                    Name = "Kingston Renegade RGB 32GB DDR4 3600MHz CL18",
                    Price = 239M,
                    Picture = "/images/32gb3600.png",
                    TypeId = 4,
                    OnPromotion = true,
                    IsVisible = true,
                    Quantity = 28
                },

                new Product()
                {
                    Id = 18,
                    ProductCode = GenerateProductCode(),
                    BrandId = 9,
                    Name = "Kingston Fury Beast 16GB DDR5 6000MHz CL40",
                    Price = 209M,
                    Picture = "/images/ddr516gb.png",
                    TypeId = 4,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 52
                },

                new Product()
                {
                    Id = 19,
                    ProductCode = GenerateProductCode(),
                    BrandId = 10,
                    Name = "Geil Orion RGB 32GB (2x16GB) DDR4 3200MHz CL16",
                    Price = 199M,
                    Picture = "/images/geilDDR.png",
                    TypeId = 4,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 43
                },

                new Product()
                {
                    Id = 20,
                    ProductCode = GenerateProductCode(),
                    BrandId = 9,
                    Name = "Kingston Fury RGB 128GB (4x32GB) DDR4 3600MHz CL18",
                    Price = 889M,
                    Picture = "/images/4x32kingston.png",
                    TypeId = 4,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 60
                },

                //HDD
                new Product()
                {
                    Id = 21,
                    ProductCode = GenerateProductCode(),
                    BrandId = 12,
                    Name = "WD 10TB 3.5 256MB 7200rpm NAS RedPlus",
                    Price = 449M,
                    Picture = "/images/WD-10TB-3.5.png",
                    TypeId = 5,
                    OnPromotion = true,
                    IsVisible = true,
                    Quantity = 19
                },

                new Product()
                {
                    Id = 22,
                    ProductCode = GenerateProductCode(),
                    BrandId = 12,
                    Name = "WD 2TB 3.5 128MB 5400rpm NAS RedPlus",
                    Price = 119M,
                    Picture = "/images/image61ee87ed2e535.png",
                    TypeId = 5,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 93
                },

                new Product()
                {
                    Id = 23,
                    ProductCode = GenerateProductCode(),
                    BrandId = 14,
                    Name = "Toshiba 8TB 3.5 256MB 7200rpm X300",
                    Price = 279M,
                    Picture = "/images/723844000288-min-86.png",
                    TypeId = 5,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 14
                },

                new Product()
                {
                    Id = 24,
                    ProductCode = GenerateProductCode(),
                    BrandId = 13,
                    Name = "Seagate 2TB 2.5 128MB 5400rpm Baracuda",
                    Price = 109M,
                    Picture = "/images/image5bb5c5a17f576.png",
                    TypeId = 5,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 66
                },

                new Product()
                {
                    Id = 25,
                    ProductCode = GenerateProductCode(),
                    BrandId = 13,
                    Name = "Seagate 2TB 3.5 SATA III 256MB 7200rpm",
                    Price = 79M,
                    Picture = "/images/image58b5545e696ff.png",
                    TypeId = 5,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 35
                },

                //SSD
                new Product()
                {
                    Id = 26,
                    ProductCode = GenerateProductCode(),
                    BrandId = 15,
                    Name = "Samsung SSD 970 EVO PLUS 500GB M.2 2280",
                    Price = 109M,
                    Picture = "/images/image5c6fdb548f82f1.png",
                    TypeId = 6,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 33
                },

                new Product()
                {
                    Id = 27,
                    ProductCode = GenerateProductCode(),
                    BrandId = 15,
                    Name = "Samsung 2TB SSD 970 EVO PLUS M.2 2280",
                    Price = 359M,
                    Picture = "/images/samsung2TB.png",
                    TypeId = 6,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 47
                },

                new Product()
                {
                    Id = 28,
                    ProductCode = GenerateProductCode(),
                    BrandId = 15,
                    Name = "Samsung SSD 970 EVO PLUS 250G M.2 2280",
                    Price = 79M,
                    Picture = "/images/samsung250gb.png",
                    TypeId = 6,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 0
                },

                new Product()
                {
                    Id = 29,
                    ProductCode = GenerateProductCode(),
                    BrandId = 2,
                    Name = "Gigabyte AORUS NVMe Gen4 SSD 1TB",
                    Price = 239M,
                    Picture = "/images/image5e01e2654eda2.png",
                    TypeId = 6,
                    OnPromotion = true,
                    IsVisible = true,
                    Quantity = 77
                },

                new Product()
                {
                    Id = 30,
                    ProductCode = GenerateProductCode(),
                    BrandId = 11,
                    Name = "Crucial SSD 250GB PCIe M.2 280 P2",
                    Price = 54M,
                    Picture = "/images/image5ef48b1fa2009.png",
                    TypeId = 6,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 1
                },

                //POWER SUPPLY
                new Product()
                {
                    Id = 31,
                    ProductCode = GenerateProductCode(),
                    BrandId = 7,
                    Name = "MS CORE M500 80 Plus Platinum Pro 500W",
                    Price = 59M,
                    Picture = "/images/MS-Napajanje-CORE-M500-80-Plus-PLATINUM-PRO-39.png",
                    TypeId = 7,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 36
                },

                new Product()
                {
                    Id = 32,
                    ProductCode = GenerateProductCode(),
                    BrandId = 17,
                    Name = "CoolerMaster XG750 Platinum Plus 750W",
                    Price = 379M,
                    Picture = "/images/image6246d3ec405ae.png",
                    TypeId = 7,
                    OnPromotion = true,
                    IsVisible = true,
                    Quantity = 36
                },

                new Product()
                {
                    Id = 33,
                    ProductCode = GenerateProductCode(),
                    BrandId = 8,
                    Name = "Armaggeddon VOLTRON BRONZE 235FX 242W",
                    Price = 29M,
                    Picture = "/images/image5d9b4a2c06d5b.png",
                    TypeId = 7,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 36
                },

                new Product()
                {
                    Id = 34,
                    ProductCode = GenerateProductCode(),
                    BrandId = 17,
                    Name = "CoolerMaster 500W ELITE",
                    Price = 74M,
                    Picture = "/images/image5aa929bb5ba6c.png",
                    TypeId = 7,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 36
                },

                new Product()
                {
                    Id = 35,
                    ProductCode = GenerateProductCode(),
                    BrandId = 16,
                    Name = "Chieftec BBS-700S",
                    Price = 129M,
                    Picture = "/images/image5d09f7085dbf2.png",
                    TypeId = 7,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 36
                },

                //PC CASE
                new Product()
                {
                    Id = 36,
                    ProductCode = GenerateProductCode(),
                    BrandId = 18,
                    Name = "LC-Power Gaming 992W Solar Flare",
                    Price = 74M,
                    Picture = "/images/image5f9ffbf28c1e6.png",
                    TypeId = 8,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 36
                },

                new Product()
                {
                    Id = 37,
                    ProductCode = GenerateProductCode(),
                    BrandId = 19,
                    Name = "FSP CMT340 PLUS",
                    Price = 119M,
                    Picture = "/images/image6239999ddf98c.png",
                    TypeId = 8,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 1
                },

                new Product()
                {
                    Id = 38,
                    ProductCode = GenerateProductCode(),
                    BrandId = 7,
                    Name = "MS Gaming ARMOR V500",
                    Price = 59M,
                    Picture = "/images/MS-Kućište-ARMOR-V500-.png",
                    TypeId = 8,
                    OnPromotion = true,
                    IsVisible = true,
                    Quantity = 2
                },

                new Product()
                {
                    Id = 39,
                    ProductCode = GenerateProductCode(),
                    BrandId = 17,
                    Name = "CoolerMaster MasterBox MB311L ARGB",
                    Price = 112M,
                    Picture = "/images/COOLER-MASTER-Kućište-MASTERBOX-MB311L-ARGB-MCB-B311L-KGNN-S02-54.png",
                    TypeId = 8,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 8
                },

                new Product()
                {
                    Id = 40,
                    ProductCode = GenerateProductCode(),
                    BrandId = 8,
                    Name = "Armaggeddon NIMITZ TR 1100",
                    Price = 59M,
                    Picture = "/images/image62b1765247c79.png",
                    TypeId = 8,
                    OnPromotion = false,
                    IsVisible = true,
                    Quantity = 14
                }
            };


            var passHasher = new PasswordHasher<WizardUser>();
            var password = "Microsoft99!";

            var users = new List<WizardUser>()
            {
                new WizardUser()
                {
                    Id = "24ab6a6c-14f1-4b49-8964-ecfcbce372a3",
                    FirstName = "Nikola",
                    LastName = "Panic",
                    UserName = "nicjpa89@gmail.com",
                    City = "Belgrade",
                    StreetAddress = "HadziMelentijeva 53",
                    NormalizedUserName = "NICJPA89@GMAIL.COM",
                    Email = "nicjpa89@gmail.com",
                    NormalizedEmail = "NICJPA89@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = passHasher.HashPassword(null, password),
                    PhoneNumber = "+381605605093"
                },
            };

            var aspNetRoles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = "7a7be58a-9eca-403c-8c5d-2d8c2e3bb7ef",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "9c4cb918-9be8-41fd-bb7a-40b75aebc037"
                },

                new IdentityRole
                {
                    Id = "dd231ff5-5cf5-41f5-ba39-ffbce9aa933f",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                    ConcurrencyStamp = "89891c77-9ac3-4e52-bf51-a15e012463f1"
                }
            };

            var aspUsersRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = "7a7be58a-9eca-403c-8c5d-2d8c2e3bb7ef",
                    UserId = "24ab6a6c-14f1-4b49-8964-ecfcbce372a3"
                }
            };

            // USERS AND ROLES SETUP
            modelBuilder.Entity<WizardUser>().HasData(users);
            modelBuilder.Entity<IdentityRole>().HasData(aspNetRoles);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(aspUsersRoles);

            // PRODUCTS SETUP
            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<ProductType>().HasData(productTypes);
            modelBuilder.Entity<AttributeType>().HasData(attributeTypes);
            modelBuilder.Entity<Product_AttributeType>().HasData(products_attributeTypes);
            modelBuilder.Entity<ProductType_AttributeType>().HasData(productTypes_attributeTypes);
        }
    }
}
