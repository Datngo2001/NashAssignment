using CustomerSite.Interfaces;
using CustomerSite.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerSite.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        private readonly IProductService productService;
        private readonly ICartService cartService;

        public CartModel(IProductService productService, ICartService cartService)
        {
            this.productService = productService;
            this.cartService = cartService;
        }

        public ActionResult OnGet()
        {
            return Page();  
        }

        public async Task<ActionResult> OnGetAddToCardAsync(int productId)
        {
            var product = await productService.GetProductBriefByIdAsync(productId);
            if (product == null)
                return NotFound("Can not find product");

            var cart = cartService.GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productId);
            if (cartitem != null)
            {
                cartitem.quantity++;
            }
            else
            {
                cart.Add(new CartItemViewModel() { quantity = 1, product = product });
            }

            cartService.SaveCartSession(cart);

            return Page();
        }
    }
}
