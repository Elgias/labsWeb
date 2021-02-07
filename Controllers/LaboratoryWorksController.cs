using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using labs.Models;
using labs.Models.EF_Models;

namespace labs.Controllers
{
    public class LaboratoryWorksController : Controller
    {
        private readonly labsAWContext _context;

        public LaboratoryWorksController(labsAWContext context)
        {
            _context = context;
        }

        // GET: LaboratoryWork
        public async Task<IActionResult> Index()
        {
            var labsAWContext = _context.LaboratoryWorks.Include(l => l.SubjectModel);
            return View(await labsAWContext.ToListAsync());
        }

        // GET: LaboratoryWork/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratoryWorkModel = await _context.LaboratoryWorks
                .Include(l => l.SubjectModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laboratoryWorkModel == null)
            {
                return NotFound();
            }

            return View(laboratoryWorkModel);
        }

        // GET: LaboratoryWork/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Title");
            return View();
        }

        // POST: LaboratoryWork/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectId,Number,Price")] LaboratoryWorkModel laboratoryWorkModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laboratoryWorkModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Title", laboratoryWorkModel.SubjectId);
            return View(laboratoryWorkModel);
        }

        // GET: LaboratoryWork/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratoryWorkModel = await _context.LaboratoryWorks.FindAsync(id);
            if (laboratoryWorkModel == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Title", laboratoryWorkModel.SubjectId);
            return View(laboratoryWorkModel);
        }

        // POST: LaboratoryWork/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectId,Number,Price")] LaboratoryWorkModel laboratoryWorkModel)
        {
            if (id != laboratoryWorkModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratoryWorkModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratoryWorkModelExists(laboratoryWorkModel.Id))
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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Title", laboratoryWorkModel.SubjectId);
            return View(laboratoryWorkModel);
        }

        // GET: LaboratoryWork/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratoryWorkModel = await _context.LaboratoryWorks
                .Include(l => l.SubjectModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laboratoryWorkModel == null)
            {
                return NotFound();
            }

            return View(laboratoryWorkModel);
        }

        // POST: LaboratoryWork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laboratoryWorkModel = await _context.LaboratoryWorks.FindAsync(id);
            _context.LaboratoryWorks.Remove(laboratoryWorkModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratoryWorkModelExists(int id)
        {
            return _context.LaboratoryWorks.Any(e => e.Id == id);
        }
    }
}
