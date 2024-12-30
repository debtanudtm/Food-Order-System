using Food_Order_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Order_System.Controllers
{
    public class ItemController : Controller
    {
        ProjectContext _db;
        IWebHostEnvironment _env;
        public ItemController(ProjectContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index(string? searchString)
        {
            var ItemList = await (from t2 in _db.TblCategory
                                     join
                                     t3 in _db.TblItem
                                     on t2.Category_ID equals t3.Category_ID
                                     select new Item
                                     {
                                         Item_ID = t3.Item_ID,
                                         Item_Name = t3.Item_Name,
                                         Item_image = t3.Item_image,
                                         Item_Price = t3.Item_Price,
                                         Category_Name = t2.Category_Name
                                     }).ToListAsync();
            if(searchString!=null) 
            {
                ItemList = await (from t2 in _db.TblCategory
                                      join
                                      t3 in _db.TblItem
                                      on t2.Category_ID equals t3.Category_ID
                                      where t3.Item_Name.Contains(searchString)
                                      select new Item
                                      {
                                          Item_ID = t3.Item_ID,
                                          Item_Name = t3.Item_Name,
                                          Item_image = t3.Item_image,
                                          Item_Price = t3.Item_Price,
                                          Category_Name = t2.Category_Name
                                      }
                                      ).ToListAsync();
                ViewBag.SearchText = searchString;

            }
            if (ItemList.Count == 0)
            {
                ViewBag.Message = "No Record Found !";
            }

            return View(ItemList);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CategoryList = await _db.TblCategory.ToListAsync();
            ViewBag.CategoryList = CategoryList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Item obj)
        {
            try
            {
                if (obj.Pic_File != null)
                    obj.Item_image = uploadfile(obj);
                await _db.TblItem.AddAsync(obj);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Insert Successe";
            }
            catch (Exception ex) { }
            return RedirectToAction("Index");
        }
        public string uploadfile(Item obj)
        {
            string filename = "";

            string dir = Path.Combine(_env.WebRootPath, "Picture");
            filename = Guid.NewGuid().ToString() + "_" + obj.Pic_File.FileName;
            string path = Path.Combine(dir, filename);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                obj.Pic_File.CopyTo(filestream);
            }
            return filename;
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var CategoryList = await _db.TblCategory.ToListAsync();
            ViewBag.CategoryList = CategoryList;
            var row = await _db.TblItem.Where(a=>a.Item_ID == id).FirstOrDefaultAsync();
            return View(row);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Item obj)
         {
            try
            {
                if (obj.Pic_File != null)
                {
                    var imgpath = Path.Combine(_env.WebRootPath, "Picture", obj.Item_image);
                    System.IO.File.Delete(imgpath);
                    obj.Item_image = uploadfile(obj);
                }
                _db.Entry(obj).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                TempData["Massage"] = "Update Success";

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
                var row = await _db.TblItem.Where(a => a.Item_ID == id).FirstOrDefaultAsync();
                _db.TblItem.Remove(row);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Delete Successe";
            }
            catch (Exception ex) { }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var ItemList = await (from t2 in _db.TblCategory
                                     join
                                     t3 in _db.TblItem
                                     on t2.Category_ID equals t3.Category_ID
                                     where t3.Item_ID == id
                                     select new Item
                                     {
                                         Item_ID = t3.Item_ID,
                                         Item_Name = t3.Item_Name,
                                         Item_image = t3.Item_image,
                                         Item_Price = t3.Item_Price,
                                         Category_Name = t2.Category_Name
                                     }).FirstOrDefaultAsync();

            return View(ItemList);
        }

    }
}

