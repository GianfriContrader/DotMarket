using Microsoft.EntityFrameworkCore;

namespace DotMarket.Context

{
    public class DotContext : IdentityDbContext<User>
    {
        public DotContext(DbContextOptions<DotContext> options) : base(options) { }

        public DotContext() { }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Kart> Karts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DataPayment> DataPayments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<InvoicePDF> InvoicesPDF { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*IdentityUserLogin<string>*/
            //TODO: Aggiungere APIfluent. 

            //assegnazione chiave primaria.
            modelBuilder.Entity<Profile>().ToTable("Profiles").HasKey(p => p.Id);
            modelBuilder.Entity<Address>().ToTable("Addresses").HasKey(a => a.Id);
            modelBuilder.Entity<Comment>().ToTable("Comments").HasKey(x => x.Id);
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(x => x.Id);
            modelBuilder.Entity<Order>().ToTable("Orders").HasKey(x => x.Id);
            modelBuilder.Entity<Kart>().ToTable("Karts").HasKey(x => x.Id);
            modelBuilder.Entity<Image>().ToTable("Images").HasKey(x => x.Id);
            modelBuilder.Entity<Tag>().ToTable("Tags").HasKey(t => t.Id);
            modelBuilder.Entity<DataPayment>().ToTable("DataPayments").HasKey(t => t.Id);
            modelBuilder.Entity<Payment>().ToTable("Payments").HasKey(t => t.Id);
            modelBuilder.Entity<InvoicePDF>().ToTable("InvoicesPDF").HasKey(t => t.Id);

            // vincoli tabella Kart
            modelBuilder.Entity<Kart>().Property(p => p.Quantity).IsRequired();
            modelBuilder.Entity<Kart>().Property(p => p.ProductPrice).IsRequired();
            modelBuilder.Entity<Kart>().Property(p => p.Date).IsRequired();
            modelBuilder.Entity<Kart>().Property(p => p.DiscountApplied).IsRequired();

            // vincoli tabella Comment
            modelBuilder.Entity<Comment>().Property(p => p.Title).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Comment>().Property(p => p.Description).IsRequired().HasColumnType("varchar");
            modelBuilder.Entity<Comment>().Property(p => p.IsLike).IsRequired();

            // vincoli tabella Order
            modelBuilder.Entity<Order>().Property(p => p.CodeOrd).IsRequired().HasColumnType("varchar").HasMaxLength(32);
            modelBuilder.Entity<Order>().Property(p => p.FastDelivery).IsRequired();
            modelBuilder.Entity<Order>().Property(p => p.ProcessedPayment).IsRequired();
            modelBuilder.Entity<Order>().Property(p => p.TotalPrice).IsRequired();
            modelBuilder.Entity<Order>().Property(p => p.Delivered).IsRequired();

            // vincoli tabella Product
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired().HasColumnType("varchar");
            modelBuilder.Entity<Product>().Property(p => p.Quantity).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Status).IsRequired().HasMaxLength(1);

            // vincoli tabella Tag
            modelBuilder.Entity<Tag>().Property(p => p.Name).IsRequired().HasColumnType("varchar").HasMaxLength(10);

            // vincoli tabella InvoicePDF
            modelBuilder.Entity<InvoicePDF>().Property(p => p.InvoiceCode).IsRequired();
            modelBuilder.Entity<InvoicePDF>().Property(p => p.DataPDF).IsRequired();
            modelBuilder.Entity<InvoicePDF>().Property(p => p.DataExcel).IsRequired();

            // vincoli tabella Profile
            modelBuilder.Entity<Profile>().Property(p => p.FirstName).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Profile>().Property(p => p.LastName).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Profile>().Property(p => p.FiscalCode).HasColumnType("text").HasMaxLength(16);
            modelBuilder.Entity<Profile>().Property(p => p.Birthday).IsRequired();

            // vincoli tabella DataPayment
            modelBuilder.Entity<DataPayment>().Property(p => p.Circuit).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<DataPayment>().Property(p => p.Number).IsRequired().HasColumnType("text").HasMaxLength(16); //correggere
            modelBuilder.Entity<DataPayment>().Property(p => p.ExpirationDate).IsRequired();
            modelBuilder.Entity<DataPayment>().Property(p => p.SecurityCode).IsRequired().HasColumnType("text").HasMaxLength(3);

            // vincoli tabella Payment
            modelBuilder.Entity<Payment>().Property(p => p.ResponsePay).IsRequired();

            // vincoli tabella Address
            modelBuilder.Entity<Address>().Property(p => p.City).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Address>().Property(p => p.Province).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Address>().Property(p => p.Residence).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Address>().Property(p => p.ZipCode).IsRequired().HasColumnType("varchar").HasMaxLength(5);
            modelBuilder.Entity<Address>().Property(p => p.Region).HasColumnType("varchar").HasMaxLength(20);

            // relazione uno a molti //////////////////////////////////////////////////////
            modelBuilder.Entity<Comment>().HasOne(c => c.Profile).WithMany(p => p.Comments).HasForeignKey(c => c.ProfileId);
            modelBuilder.Entity<Order>().HasOne(o => o.Profile).WithMany(p => p.Orders).HasForeignKey(o => o.ProfileId); //.OnDelete(DeleteBehavior.ClientCascade);

            // relazioni molti a uno //////////////////////////////////////////////////////
            modelBuilder.Entity<Profile>().HasMany(p => p.DataPayments).WithOne(dp => dp.Profile).HasForeignKey(dp => dp.ProfileId);
			modelBuilder.Entity<DataPayment>().HasMany(dp => dp.Payments).WithOne(p => p.DataPayment).HasForeignKey(p => p.DataPaymentId);
			modelBuilder.Entity<Product>().HasMany(p => p.Comments).WithOne(c => c.Product).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Product>().HasMany(x => x.Karts).WithOne(x => x.Product).HasForeignKey(k => k.ProductId); //"product_id");

            // relazioni uno a uno //////////////////////////////////////////////////////
            modelBuilder.Entity<Payment>().HasOne(p => p.Address).WithOne(a => a.Payment).HasForeignKey<Payment>(p => p.AddressId); //.OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Payment>().HasOne(p => p.Order).WithOne(o => o.Payment).HasForeignKey<Payment>(p => p.OrderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Payment>().HasOne(p => p.InvoicePDF).WithOne(i => i.Payment).HasForeignKey<Payment>(p => p.InvoicePDFId).OnDelete(DeleteBehavior.NoAction);
            //
            modelBuilder.Entity<Kart>().HasOne(k => k.Order).WithOne(o => o.Kart).HasForeignKey<Kart>(k => k.OrderId).OnDelete(DeleteBehavior.NoAction);
            //
            modelBuilder.Entity<Product>().HasOne(x => x.Image).WithOne(x => x.Product).HasForeignKey<Product>(p => p.ImageId);
            //
            modelBuilder.Entity<User>().HasOne(u => u.Profile).WithOne(p => p.User).HasForeignKey<User>(u => u.ProfileId);

            // relazioni molti-a-molti ////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Product>().HasMany(p => p.Tags).WithMany(t => t.Products);
            modelBuilder.Entity<Address>().HasMany(a => a.Profiles).WithMany(p => p.Addresses);

            //****** RELAZIONI *******
            //mini guida:
            /*
             * 
             * 
             * # UNO A UNO
             * 
             * modelBuilder.Entity<Entity>()
             *      .HasOne<Address>(s => s.Address)
             *      .WithOne(ad => ad.Student)
             *      .HasForeignKey<Address>(ad => ad.AddressOfStudentId);
             *      
             * # UNO A MOlTI
             * 
             * modelBuilder.Entity<Entity>()
             *      .HasOne(x => x.User)
             *      .WithMany(x => x.Comments)
             *      .HasForeignKey("user_id");
             * 
             * # MOLTI A MOLTI
             * 
             *  modelBuilder.Entity<Entity>()
             *      .HasMany(x => x.Products)
             *      .WithMany(x => x.Tags);

            */




            //one to one (igor)


            //many to many

        }
    }
}
