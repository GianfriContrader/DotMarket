namespace DotMarket.Context

{
    public class DotContext : IdentityDbContext<User>
    {
        public DotContext(DbContextOptions<DotContext> options) : base(options) { }

        public DotContext() { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
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
