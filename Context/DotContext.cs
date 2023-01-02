namespace DotMarket.Context
{
    public class DotContext : IdentityDbContext<IdentityUser<long>, IdentityRole<long>, long>
    {
        public DotContext(DbContextOptions<DotContext> options) : base(options) { }

    }
}
