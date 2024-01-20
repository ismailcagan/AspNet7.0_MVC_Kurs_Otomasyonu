using Microsoft.EntityFrameworkCore;

namespace KursOtomasyonuApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }
        public DbSet<Ogrenci> Ogrencis => Set<Ogrenci>();
        public DbSet<KursKayit> kursKayits => Set<KursKayit>();
        public DbSet<Kurs> Kurslar => Set<Kurs>();
    }
}