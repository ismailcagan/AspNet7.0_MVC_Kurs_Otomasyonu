using KursOtomasyonuApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KursOtomasyonuApp.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly DataContext _context;
        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Ogrenci>? ogrenciler = await _context.Ogrencis.ToListAsync();
            return View(ogrenciler);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            _context.Ogrencis.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Ogrenci");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Ogrenci? ogrenci = await _context.Ogrencis
                        .Include(x=>x.kursKayitlari)
                        .ThenInclude(x=>x.Kurs)
                        .FirstOrDefaultAsync(x=>x.OgrenciId==id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]int? id, Ogrenci model)
        {
            if (id != model.OgrenciId || model == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Ogrencis.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ogrencis.Any(o => o.OgrenciId == model.OgrenciId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ogrenci = await _context.Ogrencis.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id )
        {
            var ogrenci = await _context.Ogrencis.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            _context.Ogrencis.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}