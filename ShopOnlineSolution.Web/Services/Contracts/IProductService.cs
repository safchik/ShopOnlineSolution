using ShopOnline.Models.Dtos;

namespace ShopOnlineSolution.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
    }
}
