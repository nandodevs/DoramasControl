
using DoramasControl.Models;
using Microsoft.EntityFrameworkCore;

namespace DoramasControl.Data
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<DoramasModel> Doramas { get; set; }

        internal DoramasModel FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
