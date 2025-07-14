using Microsoft.EntityFrameworkCore;
using shipment_service.Models;

namespace shipment_service.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        public DbSet<Shipment> Shipments { get; set; } = null!;
    }
}
