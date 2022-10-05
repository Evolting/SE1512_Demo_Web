using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class ListModel : PageModel
    {
        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public void OnGet(int Id, string Name)
        {
            ViewData["id"] = Id;
            ViewData["name"] = Name;
        }

        public void OnPost()
        {

        }
    }
}
