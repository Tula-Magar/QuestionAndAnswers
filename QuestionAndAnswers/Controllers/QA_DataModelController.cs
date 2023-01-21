using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestionAndAnswers.Data;
using QuestionAndAnswers.Models;

namespace QuestionAndAnswers.Controllers
{
    public class QA_DataModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QA_DataModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QA_DataModel
        public async Task<IActionResult> Index()
        {
              return View(await _context.QA_DataModel.ToListAsync());
        }

        // GET: QA_DataModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QA_DataModel == null)
            {
                return NotFound();
            }

            var qA_DataModel = await _context.QA_DataModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qA_DataModel == null)
            {
                return NotFound();
            }

            return View(qA_DataModel);
        }

        // GET: QA_DataModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QA_DataModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] QA_DataModel qA_DataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qA_DataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qA_DataModel);
        }

        // GET: QA_DataModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QA_DataModel == null)
            {
                return NotFound();
            }

            var qA_DataModel = await _context.QA_DataModel.FindAsync(id);
            if (qA_DataModel == null)
            {
                return NotFound();
            }
            return View(qA_DataModel);
        }

        // POST: QA_DataModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] QA_DataModel qA_DataModel)
        {
            if (id != qA_DataModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qA_DataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QA_DataModelExists(qA_DataModel.Id))
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
            return View(qA_DataModel);
        }

        // GET: QA_DataModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QA_DataModel == null)
            {
                return NotFound();
            }

            var qA_DataModel = await _context.QA_DataModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qA_DataModel == null)
            {
                return NotFound();
            }

            return View(qA_DataModel);
        }

        // POST: QA_DataModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QA_DataModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QA_DataModel'  is null.");
            }
            var qA_DataModel = await _context.QA_DataModel.FindAsync(id);
            if (qA_DataModel != null)
            {
                _context.QA_DataModel.Remove(qA_DataModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QA_DataModelExists(int id)
        {
          return _context.QA_DataModel.Any(e => e.Id == id);
        }
    }
}
