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
        public DbSet<ProductKart> ProductsKart { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*IdentityUserLogin<string>*/
            //TODO: Aggiungere APIfluent. 

            //****** PROFILE ******
            modelBuilder.Entity<Profile>().ToTable("Profiles").HasKey(p => p.Id);
            modelBuilder.Entity<Profile>().HasIndex(p => p.Id).IsUnique();
            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Addresses)
                .WithMany(a => a.Profiles);
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(ad => ad.Profile)
                .HasForeignKey<User>(ad => ad.ProfileId);

            modelBuilder.Entity<Profile>().Property(p => p.FirstName).HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Profile>().Property(p => p.LastName).HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Profile>().Property(p => p.FiscalCode).IsFixedLength(true).HasColumnType("VARCHAR(16)").HasMaxLength(16);
            modelBuilder.Entity<Profile>().Property(p => p.Birthday).HasColumnType("DATETIME");
            modelBuilder.Entity<Profile>().Property(p => p.AtCreated).HasColumnType("DATETIME");

            //****** ADDRESS ******
            modelBuilder.Entity<Address>().ToTable("Addresses").HasKey(a => a.Id);
            modelBuilder.Entity<Address>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Payment)
                .WithOne(p => p.Address)
                .HasForeignKey<Payment>(p => p.AddressId);

            modelBuilder.Entity<Address>().Property(p => p.City).HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Address>().Property(p => p.Province).HasColumnType("VARCHAR(2)").HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Address>().Property(p => p.Region).HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();


            //****** PAYMENTS ******
            modelBuilder.Entity<Payment>().ToTable("Payments").HasKey(a => a.Id);
            modelBuilder.Entity<Payment>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Order>(o => o.PaymentId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.DataPayment)
                .WithMany(d => d.Payments)
                .HasForeignKey("DataPaymentId");

            modelBuilder.Entity<Payment>().Property(p => p.ResponsePay).HasColumnType("BIGINT").IsRequired();   


            //****** DATA PAYMENTS ******
            modelBuilder.Entity<DataPayment>().ToTable("DataPayments").HasKey(a => a.Id);
            modelBuilder.Entity<DataPayment>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<DataPayment>()
                .HasOne(d => d.Profile)
                .WithMany(p => p.DataPayments)
                .HasForeignKey("ProfileId");

            modelBuilder.Entity<DataPayment>().Property(p => p.ExpirationDate).HasColumnType("DATETIME").IsRequired();
            modelBuilder.Entity<DataPayment>().Property(p => p.Circuit).HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<DataPayment>().Property(p => p.Number).IsFixedLength(true).HasColumnType("VARCHAR(16)").HasMaxLength(16).IsRequired();
            modelBuilder.Entity<DataPayment>().Property(p => p.ExpirationDate).HasColumnType("DATETIME").IsRequired();
            modelBuilder.Entity<DataPayment>().Property(p => p.SecurityCode).IsFixedLength(true).HasColumnType("VARCHAR(3)").HasMaxLength(3);


            //****** INVOICE PDF ******
            modelBuilder.Entity<InvoicePDF>().ToTable("InvoicesPDF").HasKey(a => a.Id);
            modelBuilder.Entity<InvoicePDF>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<InvoicePDF>()
                .HasOne(i => i.Payment)
                .WithOne(p => p.InvoicePDF)
                .HasForeignKey<Payment>(p => p.InvoiceId);

            modelBuilder.Entity<InvoicePDF>().Property(i => i.LoadingStatus).HasColumnType("REAL");
            modelBuilder.Entity<InvoicePDF>().Property(i => i.InvoiceCode).HasColumnType("VARCHAR(100)").HasMaxLength(100).IsRequired();
            modelBuilder.Entity<InvoicePDF>().Property(i => i.ReleaseDate).HasColumnType("DATETIME");
            modelBuilder.Entity<InvoicePDF>().Property(i => i.DataPDF).HasColumnType("TINYINT");
            modelBuilder.Entity<InvoicePDF>().Property(i => i.DataExcel).HasColumnType("TINYINT");


            //****** COMMENTS ******
            modelBuilder.Entity<Comment>().ToTable("Comments").HasKey(a => a.Id);
            modelBuilder.Entity<Comment>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Comment>()
                .HasOne(d => d.Profile)
                .WithMany(p => p.Comments)
                .HasForeignKey("ProfileId");
            modelBuilder.Entity<Comment>()
                .HasOne(d => d.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey("ProductId");

            modelBuilder.Entity<Comment>().Property(c => c.Title).HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.Description).HasColumnType("TEXT").IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.IsLike).HasColumnType("BIT").IsRequired();


            //****** TAGS ******
            modelBuilder.Entity<Tag>().ToTable("Tags").HasKey(a => a.Id);
            modelBuilder.Entity<Tag>().HasIndex(a => a.Id).IsUnique();

            modelBuilder.Entity<Tag>().Property(t => t.Name).HasColumnType("VARCHAR(10)").HasMaxLength(10).IsRequired();


            //****** IMAGES ******
            modelBuilder.Entity<Image>().ToTable("Images").HasKey(a => a.Id);
            modelBuilder.Entity<Image>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Image>()
                .HasOne(i => i.Product)
                .WithOne(p => p.Image)
                .HasForeignKey<Product>(p => p.ImageId);

            modelBuilder.Entity<Image>().Property(i => i.PathImage).HasColumnType("VARCHAR(255)").HasMaxLength(255);


            //****** PRODUCTS ******
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(a => a.Id);
            modelBuilder.Entity<Product>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Tags)
                .WithMany(a => a.Products);

            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("TEXT").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("REAL").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Quantity).HasColumnType("INT").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Status).HasColumnType("VARCHAR(1)").HasMaxLength(1).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Stars).HasColumnType("INT");
            modelBuilder.Entity<Product>().Property(p => p.ImageId).HasColumnType("BIGINT");


            //****** ORDERS ******
            modelBuilder.Entity<Order>().ToTable("Orders").HasKey(a => a.Id);
            modelBuilder.Entity<Order>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Order>()
                .HasOne(d => d.Profile)
                .WithMany(p => p.Orders)
                .HasForeignKey("ProfileId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>().Property(o => o.CodeOrd).HasColumnType("VARCHAR(32)").HasMaxLength(32).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.IsFastDelivery).HasColumnType("BIT").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.IsDelivered).HasColumnType("BIT").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.IsFastDelivery).HasColumnType("BIT").IsRequired();


            //****** KARTS ******
            modelBuilder.Entity<Kart>().ToTable("Karts").HasKey(a => a.Id);
            modelBuilder.Entity<Kart>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Kart>()
                .HasOne(i => i.Order)
                .WithOne(p => p.Kart)
                .HasForeignKey<Order>(p => p.KartId);

            modelBuilder.Entity<Kart>().Property(k => k.TotalPrice).HasColumnType("REAL").IsRequired();
            modelBuilder.Entity<Kart>().Property(k => k.CreatedAt).HasColumnType("DATETIME").IsRequired();


            //****** PRODUCTS KART ******
            modelBuilder.Entity<ProductKart>().ToTable("ProductsKart").HasKey(a => a.Id);
            modelBuilder.Entity<ProductKart>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<ProductKart>()
                .HasOne(d => d.Kart)
                .WithMany(p => p.ProductsKart)
                .HasForeignKey("KartId");
            modelBuilder.Entity<ProductKart>()
                .HasOne(d => d.Product)
                .WithMany(p => p.ProductsKart)
                .HasForeignKey("ProductId");
                        
            modelBuilder.Entity<ProductKart>().Property(p => p.QtyToBuy).HasColumnType("INT").HasDefaultValue(1).IsRequired();

            //****** RELAZIONI *******
            //mini guida:
            /*
             * 
             * 
             * # UNO A UNO
             * 
             * modelBuilder.Entity<Student>()
             *      .HasOne(s => s.Address)
             *      .WithOne(ad => ad.Student)
             *      .HasForeignKey<Address>(ad => ad.AddresId);
             *      
             * # UNO A MOlTI
             * 
             * modelBuilder.Entity<Comment>()
             *      .HasOne(x => x.User)
             *      .WithMany(x => x.Comments)
             *      .HasForeignKey("user_id");
             * 
             * # MOLTI A MOLTI
             * 
             *  modelBuilder.Entity<Tag>()
             *      .HasMany(x => x.Products)
             *      .WithMany(x => x.Tags);
            */



        }
    }
}
