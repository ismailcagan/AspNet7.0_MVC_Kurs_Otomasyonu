using KursOtomasyonuApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KursOtomasyonuApp.Controllers
{
    public class KursController : Controller
    {
        private readonly DataContext _context;

        public KursController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kurs = await _context.Kurslar.
                            Include(x=>x.Ogretmen).
                            ToListAsync();
            return View(kurs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Ogretmenler = new SelectList( _context.Ogretmenler.ToList(),"OgretmenId","Ad");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kurs kurs)
        {
            _context.Kurslar.Add(kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Ogretmenler =  new SelectList( _context.Ogretmenler.ToList(),"OgretmenId","Ad");
            if (id == null)
            {
                return NotFound();
            }
            Kurs? kurs = await _context.Kurslar
                        .Include(x=>x.Ogretmen)
                        .Include(x=>x.kursKayitlari)
                        .ThenInclude(x=>x.Ogrenci)
                        .FirstOrDefaultAsync(x=>x.KursId==id);

            if (kurs == null)
            {
                return NotFound();
            }
            return View(kurs);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Kurs kurs)
        {
            if(id==null)
            {
                return NotFound();
            }
                _context.Kurslar.Update(kurs);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var kurs = await _context.Kurslar.FindAsync(id);
            return View(kurs);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, Kurs model)
        {
            if(id ==null || model == null)
            {
                return NotFound();
            }
            _context.Kurslar.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}