using Microsoft.AspNetCore.Mvc;
using ProyectoNo1_Cristhian_Bonilla.Interfaces;
using ProyectoNo1_Cristhian_Bonilla.Models;

namespace ProyectoNo1_Cristhian_Bonilla.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Products product, IFormFile ImageFile)
        {
            try
            {
                var productAdded = await _productsService.Add(product, ImageFile);
                if (productAdded != null)
                {
                    return View(product);
                }
                else
                {
                    ViewData["Message"] = "Error al agregar el producto";
                    return View(product);
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "Error al agregar el producto." + ex.InnerException?.Message;
                return View(product);
            }
        }

        
    }
   
}
