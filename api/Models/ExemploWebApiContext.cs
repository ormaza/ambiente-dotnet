using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class ExemploWebApiContext : DbContext
    {
        public ExemploWebApiContext(DbContextOptions<ExemploWebApiContext> options) : base(options)
        {
        }

        public DbSet<ExemploWebApiItem> ExemploWebApiItems {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}