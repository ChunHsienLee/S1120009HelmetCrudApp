using Microsoft.EntityFrameworkCore;

public class S1120009HelmetCrudAppContext(DbContextOptions<S1120009HelmetCrudAppContext> options) : DbContext(options)
{
    public DbSet<HelmetCrudApp.Models.Helmet> Helmet { get; set; } = default!;
}
