using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Admin
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPostCreate(Student student)
        {
            ViewData["curStudent"] = student;
        }

        public void OnPostEdit()
        {

        }
    }
}
