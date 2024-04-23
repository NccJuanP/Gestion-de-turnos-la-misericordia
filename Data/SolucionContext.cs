using Microsoft.EntityFrameworkCore;

namespace Misericordia.Data
{
    public class MisericordiaContext : DbContext{
        public MisericordiaContext (DbContextOptions<MisericordiaContext> options): base(options) {
            
        }
    }
}