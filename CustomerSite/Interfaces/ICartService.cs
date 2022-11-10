using CustomerSite.Models.Cart;

namespace CustomerSite.Interfaces
{
    public interface ICartService
    {
        List<CartItemViewModel> GetCartItems();
        void ClearCart();
        void SaveCartSession(List<CartItemViewModel> ls);
    }
}
