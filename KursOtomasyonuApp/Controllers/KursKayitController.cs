using KursOtomasyonuApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KursOtomasyonuApp.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly DataContext _context;

        public KursKayitController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<KursKayit>? kursKayit = await _context.kursKayits
                            .Include(x => x.Ogrenci)
                            .Include(x => x.Kurs)
                            .ToListAsync();
            return View(kursKayit);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrencis.ToListAsync(), "OgrenciId", "OgrenciAdSoyAd");
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "KursBaslik");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(KursKayit kursKayit)
        {
            kursKayit.KayitTarihi = DateTime.Now;
            _context.kursKayits.Add(kursKayit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}