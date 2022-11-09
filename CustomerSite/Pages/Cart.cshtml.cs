using CustomerSite.Interfaces;
using CustomerSite.Models.Cart;
using CustomerSite.Services;
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

        [BindProperty]
        public List<CartItemViewModel> CartItems { get; set; }

        public ActionResult OnGet()
        {
            CartItems = cartService.GetCartItems();
            return Page();
        }

        public async Task<ActionResult> OnGetAddToCartAsync([FromQuery] int productId)
        {
            var product = await productService.GetProductBriefByIdAsync(productId);
            if (product == null)
                return NotFound("Can not find product");

            var cart = cartService.GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == productId);
            if (cartitem != null)
            {
                cartitem.Quantity++;
            }
            else
            {
                cart.Add(new CartItemViewModel() { Quantity = 1, Product = product });
            }

            cartService.SaveCartSession(cart);

            CartItems = cart;
            return Page();
        }

        public ActionResult OnGetRemoveFromCartAsync(int productId)
        {
            var cart = cartService.GetCartItems();

            var cartitem = cart.Find(p => p.Product.Id == productId);

            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }

            cartService.SaveCartSession(cart);

            CartItems = cart;
            return Page();
        }
    }
}
