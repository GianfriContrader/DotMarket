namespace DotMarket.Context

{
    public class DotContext : IdentityDbContext<User>
    {
        public DotContext(DbContextOptions<DotContext> options) : base(options) { }

        public DotContext() { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Address> Addresses { get; set; }

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


        }
    }
}
