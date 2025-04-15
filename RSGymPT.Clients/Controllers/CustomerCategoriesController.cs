using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSGymPT.Clients.Data;
using RSGymPT.Clients.Models;

namespace RSGymPT.Clients.Controllers
{
    public class CustomerCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CustomerCategories.Include(c => c.Category).Include(c => c.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CustomerCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerCategory = await _context.CustomerCategories
                .Include(c => c.Category)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerCategory == null)
            {
                return NotFound();
            }

            return View(customerCategory);
        }

        // GET: CustomerCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: CustomerCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CategoryId")] CustomerCategory customerCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", customerCategory.CategoryId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", customerCategory.CustomerId);
            return View(customerCategory);
        }

        // GET: CustomerCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerCategory = await _context.CustomerCategories.FindAsync(id);
            if (customerCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", customerCategory.CategoryId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", customerCategory.CustomerId);
            return View(customerCategory);
        }

        // POST: CustomerCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CategoryId")] CustomerCategory customerCategory)
        {
            if (id != customerCategory.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerCategoryExists(customerCategory.CustomerId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", customerCategory.CategoryId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", customerCategory.CustomerId);
            return View(customerCategory);
        }

        // GET: CustomerCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerCategory = await _context.CustomerCategories
                .Include(c => c.Category)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerCategory == null)
            {
                return NotFound();
            }

            return View(customerCategory);
        }

        // POST: CustomerCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerCategory = await _context.CustomerCategories.FindAsync(id);
            if (customerCategory != null)
            {
                _context.CustomerCategories.Remove(customerCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerCategoryExists(int id)
        {
            return _context.CustomerCategories.Any(e => e.CustomerId == id);
        }
    }
}
