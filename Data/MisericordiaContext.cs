using Microsoft.EntityFrameworkCore;
using Misericordia.Models;
namespace Misericordia.Data
{
    public class MisericordiaContext : DbContext{
        public MisericordiaContext (DbContextOptions<MisericordiaContext> options): base(options) {
            
        }
        public DbSet <Employee>Employees { get; set; }
        public DbSet <User>Users { get; set; }
        public DbSet <Attention> Attentions { get; set; }
        public DbSet <DocumentType> DocumentTypes { get; set; }
    }
}
