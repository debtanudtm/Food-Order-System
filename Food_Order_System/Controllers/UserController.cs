using Food_Order_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Order_System.Controllers
{
    public class UserController : Controller
    {
        ProjectContext _db;
            public UserController(ProjectContext db)
        {
            _db=db;
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
            if (searchString != null)
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
        public IActionResult BuyNow()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BuyNow(int id, User obj)
        {
            try
            {
                var Itemdetails = await _db.TblItem.Where(a => a.Item_ID == id).FirstOrDefaultAsync();
                obj.Item_ID = id;
                obj.Item_Name = Itemdetails.Item_Name;
                obj.Order_Amount = Itemdetails.Item_Price;
                obj.Order_Date = System.DateTime.Now;

                await _db.TblUser.AddAsync(obj);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Order Placed,Arrived in 15-20 minutes.";
            }
            catch (Exception ex) { }
            return RedirectToAction("Index");
        }

    }
}