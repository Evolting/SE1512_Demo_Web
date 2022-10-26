using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        public void OnGet()
        {
            String jsonCart = HttpContext.Session.GetString("jsonCart");

            CartDetail c = new CartDetail();
            if (jsonCart != null)
            {
                c = Newtonsoft.Json.JsonConvert.DeserializeObject<CartDetail>(jsonCart);
            }
        }
    }
}
