using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Library.Infrastructure.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(
                "server=localhost;database=LibraryDB;user=root;password=mysql",
                new MySqlServerVersion(new Version(8, 0, 32))
            );

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
