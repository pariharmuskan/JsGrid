using JsGrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Application.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientDbContext context;
        public ClientController(ClientDbContext context)
        {
            this.context = context;
        }

        public IActionResult ClientIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReadData()
        {
            var data = context.Clients.ToList();
            return Json(data);
        }

       


        [HttpPost]
        public IActionResult Insert(Client c)
        {
          
                context.Clients.Add(c);
                context.SaveChanges();
                return Json("ClientIndex");
            

        }
        [HttpPut]
        public IActionResult Edit21(Client p)
        {
            if (p != null)
            {
                context.Clients.Update(p);
                context.SaveChanges();
            }

            return Json("ClientIndex");
        }
        public IActionResult Destroy(int id)
        {
            var emp = context.Clients.FirstOrDefault(x => x.ID == id);

            context.Clients.Remove(emp);
            context.SaveChanges();
            return new JsonResult(emp);
        }

    }
}
















//public IActionResult Privacy()
//{
//    return View();
//}
//[HttpPost]
//public IActionResult Privacy(Product model)
//{
//    if (ModelState.IsValid)
//    {
//        var emp = new Product()
//        {
//            ProductName = model.ProductName,
//            ProductDescription = model.ProductDescription,
//            Categories = model.Categories,


//        };
//        context.Products.Add(emp);
//        context.SaveChanges();
//        TempData["error"] = "Record Saved SuccessFully!";
//        return RedirectToAction("Index");
//    }
//    else
//    {
//        TempData["message"] = "Empty Field Can't Submit";
//        return View(model);
//    }

//}
//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//public IActionResult Error()
//{
//    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//}