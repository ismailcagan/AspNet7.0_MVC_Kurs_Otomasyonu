using System.ComponentModel.DataAnnotations;

namespace KursOtomasyonuApp.Data
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyAd { get; set; }
        public string? OgrenciAdSoyAd
        {
            get { return OgrenciAd + " " + OgrenciSoyAd; }
        }
        public string? EPosta { get; set; }
        public string? Telefon { get; set; }
        public ICollection<KursKayit?> kursKayitlari { get; set; } = new List<KursKayit?>();
    }
}