using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Products
{
    public class ListModel : PageModel
    {
        NorthwindContext context = new NorthwindContext();

        public void OnGet()
        {
            List<Product> products = context.Products.Include(p => p.Supplier).Include(p => p.Category).ToList();

            ViewData["products"] = products;
        }
    }
}
