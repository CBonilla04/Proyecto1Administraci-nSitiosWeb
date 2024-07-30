using ProyectoNo1_Cristhian_Bonilla.Models;

namespace ProyectoNo1_Cristhian_Bonilla.Interfaces
{
    public interface IHistoricalService
    {
        Task<List<Historical>> GetAll(Users userSession);
        Task<bool> Add(List<Historical> products);
    }
}
