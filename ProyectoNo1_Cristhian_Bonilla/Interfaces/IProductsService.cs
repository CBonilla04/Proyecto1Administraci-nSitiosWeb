using ProyectoNo1_Cristhian_Bonilla.Models;

namespace ProyectoNo1_Cristhian_Bonilla.Interfaces
{
    public interface IProductsService
    {
        Task<Products> Add(Products product, IFormFile image);
        Task<List<Products>> GetByCategory(string category);
        Task<List<Products>> GetAll();
    }
}
