using Microsoft.EntityFrameworkCore;
using misericordia.Models;
namespace Misericordia.Data
{
    public class MisericordiaContext : DbContext{
        public MisericordiaContext (DbContextOptions<MisericordiaContext> options): base(options) {
            
        }
        public DbSet <Employee>Employees { get; set; }
        public DbSet <User>Users { get; set; }

        public DbSet <Attention>Attentions {get;set;}
    }
}
