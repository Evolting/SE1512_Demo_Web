using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Products
{
    public class DeleteModel : PageModel
    {
        NorthwindContext context = new NorthwindContext();

        public IActionResult OnGet(int Id)
        {
            Product product = context.Products.FirstOrDefault(p => p.ProductId == Id);

            context.Products.Remove(product);
            context.SaveChanges();

            return Redirect("/Products/List");
        }
    }
}
