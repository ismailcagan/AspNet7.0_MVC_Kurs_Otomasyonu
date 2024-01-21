using KursOtomasyonuApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursOtomasyonuApp.Controllers;
public class OgretmenController : Controller
{
    private readonly DataContext _context;

    public OgretmenController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var ogretmen = await _context.Ogretmenler
                            .Include(x=>x.Kurslar)
                            .ToListAsync();
        return View(ogretmen);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Ogretmen ogretmen)
    {
        _context.Ogretmenler.Add(ogretmen);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var ogretmen = await _context.Ogretmenler.
                                Include(x=>x.Kurslar)
                                .FirstOrDefaultAsync(x=>x.OgretmenId==id);
        return View(ogretmen);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id,Ogretmen ogretmen)
    {
        if(ogretmen.OgretmenId == id)
        {
            _context.Ogretmenler.Update(ogretmen);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var ogretmen = await _context.Ogretmenler.FindAsync(id);
        return View(ogretmen);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Ogretmen ogretmen)
    {
        _context.Ogretmenler.Remove(ogretmen);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}