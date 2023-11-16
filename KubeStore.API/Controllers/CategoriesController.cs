using Microsoft.AspNetCore.Mvc;
using KubeStore.API.Services.Interfaces;
using KubeStore.API.ViewModels;

namespace KubeStore.API.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	[Produces("application/json")]
	public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
			_categoryService = categoryService;
        }

        // GET: Categories
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllCategories();
            return Ok(result);
        }


        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create([FromBody] CategoryVM category)
        {
            if(ModelState.IsValid)
            {
                var resp = await _categoryService.CreateCategory(category);
                if(resp.Success)
                {
                    return CreatedAtAction(nameof(Index), resp.Resource);
                }
                else
                {
                    return BadRequest("Failed to Create");
                }
            }

            return BadRequest(ModelState);
        }



        //// GET: Categories/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null || _context.Categories == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Categories
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        //// GET: Categories/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        category.Id = Guid.NewGuid();
        //        _context.Add(category);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}

        // GET: Categories/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null || _context.Categories == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Category category)
        //{
        //    if (id != category.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(category);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CategoryExists(category.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}

        // GET: Categories/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null || _context.Categories == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Categories
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        // POST: Categories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    if (_context.Categories == null)
        //    {
        //        return Problem("Entity set 'ApplicationDBContext.Categories'  is null.");
        //    }
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category != null)
        //    {
        //        _context.Categories.Remove(category);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CategoryExists(Guid id)
        //{
        //  return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
