namespace DotMarket.Context

{
    public class DotContext : IdentityDbContext<User>
    {
        public DotContext(DbContextOptions<DotContext> options) : base(options) { }

        public DotContext() { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
// Souhail
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Kart> Karts { get; set; }

//
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
            modelBuilder.Entity<Profile>().HasIndex(p => p.Id).IsUnique();

            modelBuilder.Entity<Address>().ToTable("Addresses").HasKey(a => a.ZipCode);
            modelBuilder.Entity<Address>().HasIndex(a => a.ZipCode).IsUnique();

            // souhail
            modelBuilder.Entity<Comment>().ToTable("Comments").HasKey(x => x.Id);
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(x => x.Id);
            modelBuilder.Entity<Order>().ToTable("Orders").HasKey(x => x.Id);
            modelBuilder.Entity<Kart>().ToTable("Karts").HasKey(x => x.Id);
            modelBuilder.Entity<Image>().ToTable("Images").HasKey(x => x.Id);

            
            modelBuilder.Entity<Comment>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Kart>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Image>().HasIndex(x => x.Id).IsUnique();

            //  souhail relazione uno a molti
              
              modelBuilder.Entity<Comment>().HasOne(x => x.Profile).WithMany(x => x.Comments).HasForeignKey("profile_id");
              modelBuilder.Entity<Comment>().HasOne(x => x.Product).WithMany(x => x.Comments).HasForeignKey("product_id").OnDelete(DeleteBehavior.ClientCascade); 

              modelBuilder.Entity<Kart>().HasOne(x => x.Order).WithMany(x => x.Karts).HasForeignKey("order_id").OnDelete(DeleteBehavior.ClientCascade);
              modelBuilder.Entity<Kart>().HasOne(x => x.Product).WithMany(x => x.Karts).HasForeignKey("product_id").OnDelete(DeleteBehavior.ClientCascade);
             
              modelBuilder.Entity<Order>().HasOne(x => x.Profile).WithMany(x => x.Orders).HasForeignKey("profile_id").OnDelete(DeleteBehavior.ClientCascade);
        
              




            // relazioni molti a uno
            modelBuilder.Entity<Order>().HasMany(x => x.Karts).WithOne(x => x.Order).HasForeignKey("kart_id");

            modelBuilder.Entity<Product>().HasMany(x => x.Comments).WithOne(x => x.Product).HasForeignKey("comment_id");
            modelBuilder.Entity<Product>().HasMany(x => x.Karts).WithOne(x => x.Product).HasForeignKey("Kart_id");





            //  souhail relazione uno a uno

            modelBuilder.Entity<Order>().HasOne(x => x.Payment).WithOne(x => x.Order).HasForeignKey("profile_id");

            modelBuilder.Entity<Product>().HasOne(x => x.Image).WithOne(x => x.Product).HasForeignKey("profile_id");

            //  souhail relazione molti a molti


            modelBuilder.Entity<Tag>().HasMany(x => x.Products).WithMany(x => x.Tags);


            // inizio commento -> igor
            modelBuilder.Entity<Tag>().ToTable("Tags").HasKey(t => t.Id);
            modelBuilder.Entity<Tag>().HasIndex(t => t.Id).IsUnique();

            modelBuilder.Entity<DataPayment>().ToTable("DataPayments").HasKey(t => t.Id);
            modelBuilder.Entity<DataPayment>().HasIndex(t => t.Id).IsUnique();

            modelBuilder.Entity<DataPayment>().ToTable("Payments").HasKey(t => t.Id);
            modelBuilder.Entity<DataPayment>().HasIndex(t => t.Id).IsUnique();

            modelBuilder.Entity<DataPayment>().ToTable("InvoicesPDF").HasKey(t => t.Id);
            modelBuilder.Entity<DataPayment>().HasIndex(t => t.Id).IsUnique();
            //fine commento -> igor
            
            
            
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

            modelBuilder.Entity<User>()
                .HasOne(p=> p.Profile)
                .WithOne(ad => ad.User)
                .HasForeignKey<Profile>(ad => ad.UserId);

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Addresses)
                .WithMany(a => a.Profiles);

            //one to one (igor)
            modelBuilder.Entity<Payment>()
                .HasOne<DataPayment>(s => s.DataPayment)
                .WithOne(s => s.Payment)
                .HasForeignKey<DataPayment>(d => d.PaymentId);

            modelBuilder.Entity<Payment>()
                .HasOne<Address>(s => s.Address)
                .WithOne(s => s.Payment)
                .HasForeignKey<Address>(ad => ad.PaymentId);

            modelBuilder.Entity<Payment>()
                .HasOne<Order>(s => s.Order)
                .WithOne(s => s.Payment)
                .HasForeignKey<Order>(ad => ad.PaymentId);

            modelBuilder.Entity<InvoicePDF>()
                .HasOne<DataPayment>(s => s.DataPayment)
                .WithOne(s => s.invoicePDF)
                .HasForeignKey<DataPayment>(d => d.InvoicePDFId);
        
            //many to many

        }
    }
}
