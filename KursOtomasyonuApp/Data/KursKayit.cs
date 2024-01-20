using System.ComponentModel.DataAnnotations;

namespace KursOtomasyonuApp.Data
{
    public class KursKayit
    {
        [Key]
        public int KayitId { get; set; }
        public int OgrenciId { get; set; }
        public Ogrenci? Ogrenci { get; set; }
        public int KursId { get; set; }
        public Kurs? Kurs { get; set; } =null!;
        public DateTime? KayitTarihi { get; set; }
    }
}