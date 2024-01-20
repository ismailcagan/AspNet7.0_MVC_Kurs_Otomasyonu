using System.ComponentModel.DataAnnotations;

namespace KursOtomasyonuApp.Data
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        public string? KursBaslik { get; set; }
        public ICollection<KursKayit> kursKayitlari{get;set;} =  new List<KursKayit>();
    }
    
}