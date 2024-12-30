using Food_Order_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;

namespace Food_Order_System.Controllers
{
    public class CategoryController : Controller
    {
        ProjectContext _db;
        public CategoryController(ProjectContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var CategoryList = await _db.TblCategory.ToListAsync();

            return View(CategoryList);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CategoryList = await _db.TblCategory.ToListAsync();
            ViewBag.CategoryList = CategoryList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category obj)
        {
            try
            {
                await _db.TblCategory.AddAsync(obj);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Insert Successe";
            }
            catch (Exception ex) { }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var CategoryList = await _db.TblCategory.ToListAsync();
            ViewBag.CategoryList = CategoryList;
            var row = await _db.TblCategory.Where(a => a.Category_ID == id).FirstOrDefaultAsync();
            return View(row);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category obj)
        {
            try
            {
                _db.Entry(obj).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ItemList = await _db.TblItem.Where(a => a.Category_ID == id).ToListAsync();
                if (ItemList.Count > 0)
                {
                    TempData["Message"] = "Can't Delete.as " + ItemList.Count + " Products Exits";
                }
                else
                {
                    var row = await _db.TblCategory.Where(a => a.Category_ID == id).FirstOrDefaultAsync();
                    _db.TblCategory.Remove(row);
                    await _db.SaveChangesAsync();
                    TempData["Message"] = "Delete Success";
                }
            }
            catch (Exception ex) { }
            return RedirectToAction("Index", "Category");
        }
    }
}
