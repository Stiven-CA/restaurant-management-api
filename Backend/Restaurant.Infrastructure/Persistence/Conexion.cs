using Microsoft.EntityFrameworkCore;

namespace Restaurant.Infrastructure.Persistence
{
    public class Conexion : DbContext
    {
        public Conexion(DbContextOptions<Conexion> options)
            : base(options)
        {
        }
    }
}