using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Orders
{
    public class ListModel : PageModel
    {
        private NorthwindContext context = new NorthwindContext();

        public void OnGet(int Id)
        {
            List<Employee> employees;

            if (Id == 0)
            {
                employees = context.Employees.Include(x => x.Orders).Take(30).ToList();
            }
            else
            {
                employees = context.Employees.Where(e => e.EmployeeId == Id).Include(x => x.Orders).Take(30).ToList();
            }

            ViewData["employees"] = employees;
        }
    }
}
