using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Products
{
    public class AddModel : PageModel
    {
        NorthwindContext context = new NorthwindContext();

        public void OnGet()
        {
            List<Supplier> suppliers = context.Suppliers.ToList();
            List<Category> categories = context.Categories.ToList();

            ViewData["suppliers"] = suppliers;
            ViewData["categories"] = categories;
        }

        public IActionResult OnPost(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();

            return Redirect("/Products/List");
        }
    }
}
