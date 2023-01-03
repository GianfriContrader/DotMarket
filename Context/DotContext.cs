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

            //****** USER ******
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(ad => ad.Profile)
                .HasForeignKey<User>(ad => ad.ProfileId);


            //****** PROFILE ******
            modelBuilder.Entity<Profile>().ToTable("Profiles").HasKey(p => p.Id);
            modelBuilder.Entity<Profile>().HasIndex(p => p.Id).IsUnique();
            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Addresses)
                .WithMany(a => a.Profiles);
            
            //****** ADDRESS ******
            modelBuilder.Entity<Address>().ToTable("Addresses").HasKey(a => a.Id);
            modelBuilder.Entity<Address>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Payment)
                .WithOne(p => p.Address)
                .HasForeignKey<Payment>(p => p.AddressId);

            // *************************************** NEEEWWWW

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




            //****** DATA PAYMENTS ******
            modelBuilder.Entity<DataPayment>().ToTable("DataPayments").HasKey(a => a.Id);
            modelBuilder.Entity<DataPayment>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<DataPayment>()
                .HasOne(d => d.Profile)
                .WithMany(p => p.DataPayments)
                .HasForeignKey("ProfileId");
            



            //****** INVOICE PDF ******
            modelBuilder.Entity<InvoicePDF>().ToTable("InvoicesPDF").HasKey(a => a.Id);
            modelBuilder.Entity<InvoicePDF>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<InvoicePDF>()
                .HasOne(i => i.Payment)
                .WithOne(p => p.InvoicePDF)
                .HasForeignKey<Payment>(p => p.InvoiceId);


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


            //****** TAGS ******
            modelBuilder.Entity<Tag>().ToTable("Tags").HasKey(a => a.Id);
            modelBuilder.Entity<Tag>().HasIndex(a => a.Id).IsUnique();


            //****** IMAGES ******
            modelBuilder.Entity<Image>().ToTable("Images").HasKey(a => a.Id);
            modelBuilder.Entity<Image>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Image>()
                .HasOne(i => i.Product)
                .WithOne(p => p.Image)
                .HasForeignKey<Product>(p => p.ImageId);


            //****** PRODUCTS ******
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(a => a.Id);
            modelBuilder.Entity<Product>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Tags)
                .WithMany(a => a.Products);


            //****** ORDERS ******
            modelBuilder.Entity<Order>().ToTable("Orders").HasKey(a => a.Id);
            modelBuilder.Entity<Order>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Order>()
                .HasOne(d => d.Profile)
                .WithMany(p => p.Orders)
                .HasForeignKey("ProfileId")
                .OnDelete(DeleteBehavior.NoAction);


            //****** KARTS ******
            modelBuilder.Entity<Kart>().ToTable("Karts").HasKey(a => a.Id);
            modelBuilder.Entity<Kart>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Kart>()
                .HasOne(i => i.Order)
                .WithOne(p => p.Kart)
                .HasForeignKey<Order>(p => p.KartId);


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




            //one to one (igor)


            //many to many

        }
    }
}
