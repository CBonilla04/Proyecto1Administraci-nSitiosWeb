using Microsoft.AspNetCore.Mvc;
using ProyectoNo1_Cristhian_Bonilla.Interfaces;
using ProyectoNo1_Cristhian_Bonilla.Models;
using ProyectoNo1_Cristhian_Bonilla.Utils;

namespace ProyectoNo1_Cristhian_Bonilla.Controllers
{
    public class HistoricalController : Controller
    {
        private readonly IHistoricalService _historicalService;

        public HistoricalController(IHistoricalService historicalService)
        {
            _historicalService = historicalService;
        }
        [HttpGet]
        public async Task<IActionResult> Data(List<Historical> historical)
        {
            try
                {
                Users userSession = HttpContext.Session.GetObjectFromJson<Users>("CurrentUser");

                historical = await _historicalService.GetAll(userSession);
                return View(historical);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
    }
}
