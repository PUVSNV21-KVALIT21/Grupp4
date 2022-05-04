#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HakimLivsGrupp4.Data;
using HakimLivsGrupp4.Models;

namespace HakimLivsGrupp4.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,Description,Unit,UnitType,TableOfContent,Price,CategoryID,Stock,ImgPath")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,Description,Unit,UnitType,TableOfContent,Price,CategoryID,Stock,ImgPath")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        // POST: TestProducts/Create
        [HttpPost, ActionName("LoadTestData")]
        public async Task<ActionResult> LoadTestData()
        {
            try
            {
                if (!_context.Products.Any())
                {
                    string path = @"Data\BasProdukter1.csv";
                    string path2 = @"Data\BasKategorier1.csv";
                    string[] lines = System.IO.File.ReadAllLines(path, System.Text.Encoding.Latin1);
                    foreach (string line in lines)
                    {
                        var values = line.Split(';');
                        Product product = new Product();

                        product.Name = values[0];
                        product.Brand = values[1];
                        product.Description = values[2];
                        product.Unit = int.Parse(values[3]);
                        product.UnitType = values[4];
                        product.TableOfContent = values[5];
                        product.Price = decimal.Parse(values[6]);
                        product.CategoryID = int.Parse(values[7]);
                        product.Stock = int.Parse(values[8]);
                        product.ImgPath = values[9];
                       
                        _context.Products.Add(product);
                    }

                    string[] lines2 = System.IO.File.ReadAllLines(path2, System.Text.Encoding.Latin1);
                    foreach (string line in lines2)
                    {
                        var values = line.Split(';');
                        Category category = new Category();

                        category.Name = values[0];

                        _context.Categories.Add(category);
                    }

                    await _context.SaveChangesAsync();
                    return View(await _context.Products.ToListAsync());
                }
                return View(await _context.Products.ToListAsync());
            }
            catch
            {
                return View(await _context.Products.ToListAsync());
            }
        }

    }
}
