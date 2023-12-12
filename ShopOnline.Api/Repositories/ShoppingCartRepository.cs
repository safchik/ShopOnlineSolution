using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepositiry
    {
     
        private readonly ShopOnlineDBContext shopOnlineDbContext;

        public ShoppingCartRepository(ShopOnlineDBContext shopOnlineDBContext)
        {
            this.shopOnlineDbContext = shopOnlineDBContext;
            
        }
        public Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
