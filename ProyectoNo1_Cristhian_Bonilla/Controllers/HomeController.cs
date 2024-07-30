using Microsoft.AspNetCore.Mvc;
using ProyectoNo1_Cristhian_Bonilla.Interfaces;
using ProyectoNo1_Cristhian_Bonilla.Models;
using ProyectoNo1_Cristhian_Bonilla.Utils;

namespace ProyectoNo1_Cristhian_Bonilla.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService _productsService;

        public HomeController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(List<Products> products)
        {
            try
                {
                products = await _productsService.GetAll();
                return View(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] Products product)
        {
            try
            {
                List<Products> carList = HttpContext.Session.GetObjectFromJson<List<Products>>("CartStore");
                if (carList == null)
                {
                    carList = new List<Products>();
                }

                carList.Add(product);
                HttpContext.Session.SetObjectAsJson("CartStore", carList);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            

        }

        [HttpGet]
        public IActionResult GetCartItemCount()
        {
            List<Products> ProductList = HttpContext.Session.GetObjectFromJson<List<Products>>("CartStore");
            int itemCount = ProductList?.Count ?? 0;
            return Json(new { count = itemCount });
        }

    }
}
