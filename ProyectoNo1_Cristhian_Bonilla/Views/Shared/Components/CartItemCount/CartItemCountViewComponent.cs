using Microsoft.AspNetCore.Mvc;
using ProyectoNo1_Cristhian_Bonilla.Models;
using ProyectoNo1_Cristhian_Bonilla.Utils;

namespace ProyectoNo1_Cristhian_Bonilla.Views.Shared.Components.CartItemCount
{
    public class CartItemCountViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var products = HttpContext.Session.GetObjectFromJson<List<Products>>("CartStore");
            int itemCount = products?.Count ?? 0;
            ViewData["CartItemCount"] = itemCount;
            return View(itemCount);
        }
    }
}
