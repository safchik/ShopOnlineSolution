using ShopOnline.Models.Dtos;
using ShopOnlineSolution.Web.Services.Contracts;
using System.Net.Http.Json;

namespace ShopOnlineSolution.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient httpClient;
        public ShoppingCartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<CartItemToAddDto>("api/ShoppingCart", cartItemToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartItemDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else 
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CartItemDto>> GetItems(int userId)
        {
            try
            {
                var responce = await httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

                if (responce.IsSuccessStatusCode)
                {
                    if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemDto>();
                    }
                    return await responce.Content.ReadFromJsonAsync<IEnumerable<CartItemDto>>();                
                }
                else
                {
                    var message = await responce.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {responce.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
