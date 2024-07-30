using Microsoft.AspNetCore.Mvc;
using ProyectoNo1_Cristhian_Bonilla.Interfaces;
using ProyectoNo1_Cristhian_Bonilla.Models;
using ProyectoNo1_Cristhian_Bonilla.Utils;

namespace ProyectoNo1_Cristhian_Bonilla.Controllers
{
    public class CartController : Controller
    {
        private readonly IUsersService _usersService;

        public CartController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet]
        public IActionResult Cart()
        {
            List<Products> products = HttpContext.Session.GetObjectFromJson<List<Products>>("CartStore");
            if (products == null)
            {
                products = new List<Products>();
            }
            return View(products);
        }
        //permite eliminar un vuelo del carrito
        [HttpPost]
        public IActionResult Eliminar(int index)
        {
            List<Products> products = HttpContext.Session.GetObjectFromJson<List<Products>>("CartStore");
            products.RemoveAt(index);
            HttpContext.Session.SetObjectAsJson("CartStore", products);
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            try
            {
                List<Products> products = HttpContext.Session.GetObjectFromJson<List<Products>>("CartStore");
                if (products == null)
                {
                    products = new List<Products>();
                }
                Users userSession = HttpContext.Session.GetObjectFromJson<Users>("CurrentUser");
                foreach (var product in products)
                {
                    userSession.Historical.Add(new Historical
                    {
                        ProductName = product.ProductName,
                        Brand = product.Brand,
                        Model = product.Model,
                        Category = product.Category,
                        Price = product.Price,
                        StockQuantity = product.StockQuantity,
                        Processor = product.Processor,
                        RAM = product.RAM,
                        Storage = product.Storage,
                        GraphicsCard = product.GraphicsCard,
                        OperatingSystem = product.OperatingSystem,
                        Weight = product.Weight,
                        Dimensions = product.Dimensions,
                        BatteryLife = product.BatteryLife,
                        Ports = product.Ports,
                        Connectivity = product.Connectivity,
                        Color = product.Color,
                        Warranty = product.Warranty,
                        Description = product.Description,
                        Image = product.Image
                    });
                }
                await _usersService.UpdateUser(userSession);
                //elimina los vuelos pagados del carrito
                HttpContext.Session.Remove("CartStore");

                return View();
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
