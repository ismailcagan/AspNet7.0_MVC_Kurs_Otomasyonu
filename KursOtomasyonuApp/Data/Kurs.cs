using System.ComponentModel.DataAnnotations;

namespace KursOtomasyonuApp.Data
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        public string? KursBaslik { get; set; }
        public int? OgretmenId {get;set;} // Her kursa bir öğretmen girmek zorunda anlamına gelir.
        // Eğer sonradan bir tablo eklenecekse yukarıdaki gibi soru işareti ? konulmalıdır.
        public Ogretmen Ogretmen { get; set; } =null!;
        public ICollection<KursKayit>? kursKayitlari{get;set;} =  new List<KursKayit>();
    }
    
}