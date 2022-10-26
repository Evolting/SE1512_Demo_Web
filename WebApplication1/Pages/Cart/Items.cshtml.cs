using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Cart
{
    public class ItemsModel : PageModel
    {
        public void OnGet()
        {
            String jsonCart = HttpContext.Session.GetString("jsonCart");

            CartDetail c = new CartDetail();
            if (jsonCart != null)
            {
                c = Newtonsoft.Json.JsonConvert.DeserializeObject<CartDetail>(jsonCart);
            }

            ViewData["cart"] = c;
        }

        public void OnPostDelete(int Id)
        {
            String jsonCart = HttpContext.Session.GetString("jsonCart");

            CartDetail c = new CartDetail();
            if (jsonCart != null)
            {
                c = Newtonsoft.Json.JsonConvert.DeserializeObject<CartDetail>(jsonCart);
                c.removeItem(Id);

                c.Total = c.getTotalMoney();
            }

            ViewData["cart"] = c;
            jsonCart = Newtonsoft.Json.JsonConvert.SerializeObject(c);
            HttpContext.Session.SetString("jsonCart", jsonCart);
        }

        public void OnPostChangeQuantity(int Id, int amount)
        {
            String jsonCart = HttpContext.Session.GetString("jsonCart");

            CartDetail c = new CartDetail();
            if (jsonCart != null)
            {
                c = Newtonsoft.Json.JsonConvert.DeserializeObject<CartDetail>(jsonCart);
                c.getExactItem(Id).Quantity = amount;

                c.Total = c.getTotalMoney();
            }

            ViewData["cart"] = c;
            jsonCart = Newtonsoft.Json.JsonConvert.SerializeObject(c);
            HttpContext.Session.SetString("jsonCart", jsonCart);
        }
    }
}
