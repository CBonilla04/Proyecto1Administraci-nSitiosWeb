using Microsoft.EntityFrameworkCore;
using ProyectoNo1_Cristhian_Bonilla.Interfaces;
using ProyectoNo1_Cristhian_Bonilla.Models;
using ProyectoNo1_Cristhian_Bonilla.Utils;

namespace ProyectoNo1_Cristhian_Bonilla.Services
{
    public class HistoricalService : IHistoricalService
    {
        private readonly AppDbContext _context;
        public HistoricalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(List<Historical> products)
        {
            try
                {
                await _context.Historicals.AddRangeAsync(products);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Historical>> GetAll(Users userSession)
        {
            try
                {
                var products = _context.Historicals.Where(x => x.User.Email == userSession.Email).ToListAsync();
                return await products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
