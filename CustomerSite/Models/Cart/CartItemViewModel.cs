using CommonModel.Product;

namespace CustomerSite.Models.Cart
{
    public class CartItemViewModel
    {
        public int quantity { set; get; }
        public ProductDto product { set; get; }
    }
}
