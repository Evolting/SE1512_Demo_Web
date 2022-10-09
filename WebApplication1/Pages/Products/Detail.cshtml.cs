using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;
using System.Text.Json;
using Newtonsoft.Json;

namespace WebApplication1.Pages.Products
{
    public class DetailModel : PageModel
    {
        NorthwindContext context = new NorthwindContext();

        public void OnGet(int productId)
        {
            Product p = context.Products.Include(p => p.Category).Include(p => p.Supplier).FirstOrDefault(p => p.ProductId == productId);

            ViewData["product"] = p;
        }

        public IActionResult OnPostCart(int productId, int num)
        {
            Product p = context.Products.FirstOrDefault(p => p.ProductId == productId);

            ItemInCart i = new ItemInCart();
            i.Quantity = num;
            i.Product = p;

            CartDetail c = new CartDetail();
            String jsonCart = HttpContext.Session.GetString("jsonCart");
            if (jsonCart != null)
            {
                c = Newtonsoft.Json.JsonConvert.DeserializeObject<CartDetail>(jsonCart);
            }

            i.Id = c.Items.Count + 1;

            c.addItem(i);
            c.Total = c.getTotalMoney();

            jsonCart = Newtonsoft.Json.JsonConvert.SerializeObject(c);
            HttpContext.Session.SetString("jsonCart", jsonCart);

            return Redirect("/Cart/Items");
        }
    }
}
