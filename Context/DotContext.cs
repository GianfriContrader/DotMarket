﻿namespace DotMarket.Context

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
            modelBuilder.Entity<Address>().ToTable("Addresses").HasKey(a => a.ZipCode);
            modelBuilder.Entity<Comment>().ToTable("Comments").HasKey(x => x.Id);
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(x => x.Id);
            modelBuilder.Entity<Order>().ToTable("Orders").HasKey(x => x.Id);
            modelBuilder.Entity<Kart>().ToTable("Karts").HasKey(x => x.Id);
            modelBuilder.Entity<Image>().ToTable("Images").HasKey(x => x.Id);
            modelBuilder.Entity<Tag>().ToTable("Tags").HasKey(t => t.Id);
            modelBuilder.Entity<DataPayment>().ToTable("DataPayments").HasKey(t => t.Id);
            modelBuilder.Entity<Payment>().ToTable("Payments").HasKey(t => t.Id);
            modelBuilder.Entity<InvoicePDF>().ToTable("InvoicesPDF").HasKey(t => t.Id);

            // assegnazione campo unique chiave primaria
            modelBuilder.Entity<Profile>().HasIndex(p => p.Id).IsUnique();
            modelBuilder.Entity<Address>().HasIndex(a => a.ZipCode).IsUnique();
            modelBuilder.Entity<Comment>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Kart>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Image>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Tag>().HasIndex(t => t.Id).IsUnique();
            modelBuilder.Entity<DataPayment>().HasIndex(t => t.Id).IsUnique();
            modelBuilder.Entity<Payment>().HasIndex(t => t.Id).IsUnique();
            modelBuilder.Entity<InvoicePDF>().HasIndex(t => t.Id).IsUnique();

            // relazione uno a molti

            modelBuilder.Entity<Comment>().HasOne(x => x.Profile).WithMany(x => x.Comments).HasForeignKey("profile_id");
            modelBuilder.Entity<Comment>().HasOne(x => x.Product).WithMany(x => x.Comments).HasForeignKey("product_id").OnDelete(DeleteBehavior.ClientCascade); 
            modelBuilder.Entity<Kart>().HasOne(x => x.Order).WithMany(x => x.Karts).HasForeignKey("order_id").OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Kart>().HasOne(x => x.Product).WithMany(x => x.Karts).HasForeignKey("product_id").OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Order>().HasOne(x => x.Profile).WithMany(x => x.Orders).HasForeignKey("profile_id").OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Profile>().HasMany(p => p.Addresses).WithMany(a => a.Profiles);


            // relazioni molti a uno

            modelBuilder.Entity<Order>().HasMany(x => x.Karts).WithOne(x => x.Order).HasForeignKey("kart_id");
            modelBuilder.Entity<Product>().HasMany(x => x.Comments).WithOne(x => x.Product).HasForeignKey("comment_id");
            modelBuilder.Entity<Product>().HasMany(x => x.Karts).WithOne(x => x.Product).HasForeignKey("Kart_id");


            // relazioni uno a uno

            modelBuilder.Entity<Order>().HasOne(x => x.Payment).WithOne(x => x.Order).HasForeignKey("payment_id");
            modelBuilder.Entity<Payment>().HasOne(p => p.Order).WithOne(o => o.Payment).HasForeignKey("order_id");


            modelBuilder.Entity<Product>().HasOne(x => x.Image).WithOne(x => x.Product).HasForeignKey("image_id");

            modelBuilder.Entity<Payment>().HasOne(s => s.DataPayment).WithOne(s => s.Payment).HasForeignKey("datapayment_id");

            modelBuilder.Entity<Payment>().HasOne(s => s.Address).WithOne(s => s.Payment).HasForeignKey("address_id");

            modelBuilder.Entity<InvoicePDF>().HasOne(s => s.DataPayment).WithOne(s => s.InvoicePDF).HasForeignKey("datapayment_id");
            modelBuilder.Entity<User>().HasOne(p => p.Profile).WithOne(ad => ad.User).HasForeignKey("profile_id");

            // relazione molti a molti


            modelBuilder.Entity<Tag>().HasMany(x => x.Products).WithMany(x => x.Tags);


     
            
            
            
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
