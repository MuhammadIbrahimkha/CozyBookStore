using CozyBookStore2.Data;
using CozyBookStore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CozyBookStore2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDb context;

        // In-memory list to simulate a database for now.

        //private static List<Product> products = new List<Product>()
        //{
        //    new Product { Id = 1, Name = "C#", Description = "A programming language book", Price = 23.44m, ImageUrl = "c#.png"},

        //    new Product { Id = 2, Name = "ASP.NET CORE", Description = "A framework for backend developement in .NET", Price = 44.34m, ImageUrl = "dotnetcore.jpg"},

        //};

        public ProductsController(ApplicationDb context)
        {
            this.context = context;
        }




        // GET: /Products

        public async Task<IActionResult> Index()  // Means Get all the products.
        {
            var task = await context.Products.ToListAsync();
            return View(task);
        }


        // GET: /Products/Details/{id}
    
    
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    
    
        // GET: /Products/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,ImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                // Simulate adding to the database

                //product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
              await context.Products.AddAsync(product);

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to the index action.
            }

            return View(product);
        }


        // GET: /Products/Edit/1

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // POST: /Products/Edit/1


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Attach the modified product and mark it as updated
                    context.Products.Attach(product);
                    context.Entry(product).State = EntityState.Modified;

                    await context.SaveChangesAsync();
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

        // Helper method to check if a product exists
        private bool ProductExists(int id)
        {
            return context.Products.Any(p => p.Id == id);
        }


        // GET: /Products/Delete/{id}

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: /Products/Delete/{id}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Simulate deleting from the database.

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
               context.Products.Remove(product);
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
