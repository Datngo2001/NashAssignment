using CustomerSite.Interfaces;
using CustomerSite.Models.Cart;
using Newtonsoft.Json;

namespace CustomerSite.Services
{
    public class CartService : ICartService
    {
        private readonly string CARTKEY = "cart";
        private readonly IHttpContextAccessor httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public List<CartItemViewModel> GetCartItems()
        {
            var session = getSession();
            var jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItemViewModel>>(jsoncart) ?? new List<CartItemViewModel>();
            }
            return new List<CartItemViewModel>();
        }

        public void ClearCart()
        {
            var session = getSession();
            session.Remove(CARTKEY);
        }

        public void SaveCartSession(List<CartItemViewModel> ls)
        {
            var session = getSession()  ;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        private ISession getSession()
        {
            if(httpContextAccessor.HttpContext == null)
            {
                throw new Exception("HttpContext is null");
            }
            return httpContextAccessor.HttpContext.Session;
        }
    }
}
