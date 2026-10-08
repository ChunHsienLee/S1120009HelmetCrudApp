
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelmetCrudApp.Models;

public class HelmetsController : Controller
{
    private readonly S1120009HelmetCrudAppContext _context;

    public HelmetsController(S1120009HelmetCrudAppContext context)
    {
        _context = context;
    }

    // GET: HELMETS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Helmet.ToListAsync());
    }

    // GET: HELMETS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var helmet = await _context.Helmet
            .FirstOrDefaultAsync(m => m.Id == id);
        if (helmet == null)
        {
            return NotFound();
        }

        return View(helmet);
    }

    // GET: HELMETS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: HELMETS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Brand,ModelName,Price,HasPFS,PurchaseDate")] Helmet helmet)
    {
        if (ModelState.IsValid)
        {
            _context.Add(helmet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(helmet);
    }

    // GET: HELMETS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var helmet = await _context.Helmet.FindAsync(id);
        if (helmet == null)
        {
            return NotFound();
        }
        return View(helmet);
    }

    // POST: HELMETS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Brand,ModelName,Price,HasPFS,PurchaseDate")] Helmet helmet)
    {
        if (id != helmet.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(helmet);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelmetExists(helmet.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(helmet);
    }

    // GET: HELMETS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var helmet = await _context.Helmet
            .FirstOrDefaultAsync(m => m.Id == id);
        if (helmet == null)
        {
            return NotFound();
        }

        return View(helmet);
    }

    // POST: HELMETS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var helmet = await _context.Helmet.FindAsync(id);
        if (helmet != null)
        {
            _context.Helmet.Remove(helmet);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HelmetExists(int? id)
    {
        return _context.Helmet.Any(e => e.Id == id);
    }
}
