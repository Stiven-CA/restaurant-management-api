using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence
{
    public class Conexion : DbContext
    {
        public Conexion(DbContextOptions<Conexion> options)
            : base(options)
        {
        }


        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }

    }
}