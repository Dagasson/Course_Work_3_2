using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Course_Work.Models;
using Course_Work.Context;
using Course_Work.Repository;

namespace Course_Work.Controllers
{
    public class HomeController : Controller
    {

        dbcontext db;
        private readonly OrdersRepository OrdersRepo;
        public HomeController(dbcontext context)
        {
            db = context;
            OrdersRepo = new OrdersRepository(db);
        }

        public IActionResult Index()
        {
            return View(db.Shops.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.ShopId = id;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Buy(Orders order)
        {
            User user = db.Users.Where(t => t.UserName == User.Identity.Name).FirstOrDefault();
            
            db.Order.Add(
                new Orders {
                    UserId = user.Id,
                    ShopId = order.ShopId,
                    Adress = order.Adress,
                    DateOfOrder = Convert.ToDateTime(DateTime.Today.ToShortDateString())
                }
                );
           
            db.SaveChanges();
            return RedirectToAction("/Index");
        }

        [HttpPost]
        public IActionResult Find(string FoodName)
        {
            IEnumerable<Shop> foods = db.Shops.Where(t => t.Name.ToLower().Contains(FoodName.ToLower()));

            return View(foods);
        }


    }
}
