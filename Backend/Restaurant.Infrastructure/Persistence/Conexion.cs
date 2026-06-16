using Microsoft.EntityFrameworkCore;


namespace Restaurant.Infrastructure.Persistence
{
    public class Conexion(string conexion) : DbContext
    {
        private readonly string _conexion = conexion;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql (_conexion);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}

