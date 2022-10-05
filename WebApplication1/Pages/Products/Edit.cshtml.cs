using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Products
{
    public class EditModel : PageModel
    {
        NorthwindContext context = new NorthwindContext();

        public void OnGet(int Id)
        {
            List<Supplier> suppliers = context.Suppliers.ToList();
            List<Category> categories = context.Categories.ToList();
            Product product = context.Products.FirstOrDefault(p => p.ProductId == Id);

            ViewData["product"] = product;
            ViewData["suppliers"] = suppliers;
            ViewData["categories"] = categories;
        }

        public IActionResult OnPost(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();

            return Redirect("/Products/List");
        }
    }
}
