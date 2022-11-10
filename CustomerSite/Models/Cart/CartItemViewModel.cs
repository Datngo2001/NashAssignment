using CommonModel.Product;

namespace CustomerSite.Models.Cart
{
    public class CartItemViewModel
    {
        public int Quantity { set; get; }
        public ProductDto Product { set; get; }
    }
}
