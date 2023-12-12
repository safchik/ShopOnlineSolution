using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepositiry shoppingCartRepositiry;
        private readonly IProductRepository productRepository;

        public ShoppingCartController(IShoppingCartRepositiry shoppingCartRepositiry, IProductRepository productRepository)
        {
            this.shoppingCartRepositiry = shoppingCartRepositiry;
            this.productRepository = productRepository;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                var cartItems = await this.shoppingCartRepositiry.GetItems(userId);

                if(cartItems == null)
                {
                    return NoContent();
                }

                var products = await this.productRepository.GetItems();

                if (products == null)
                {
                    throw new Exception("No products exist in the system");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
