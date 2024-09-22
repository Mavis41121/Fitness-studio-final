using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFitnessStudio.Models; // Adjust if the namespace is different
using System.Linq;
using System.Threading.Tasks;

namespace MyFitnessStudio.Controllers
{
    public class SessionController : Controller
    {
        private readonly FitnessStudioContext _context;

        public SessionController(FitnessStudioContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sessions = await _context.Sessions.ToListAsync();
            return View(sessions);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .FirstOrDefaultAsync(m => m.SessionID == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionID,SessionName,SessionSchedule")] Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(session);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessionID,SessionName,SessionSchedule")] Session session)
        {
            if (id != session.SessionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.SessionID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(session);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .FirstOrDefaultAsync(m => m.SessionID == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(e => e.SessionID == id);
        }
    }
}


