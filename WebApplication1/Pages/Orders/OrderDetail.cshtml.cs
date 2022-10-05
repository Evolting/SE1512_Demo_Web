using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Orders
{
    public class OrderDetailModel : PageModel
    {
        private NorthwindContext context = new NorthwindContext();

        public void OnGet(int Id)
        {
            List<OrderDetail> orderDetails;

            orderDetails = context.OrderDetails.Where(x => x.OrderId == Id).ToList();

            ViewData["orderDetails"] = orderDetails;
            ViewData["Id"] = Id;
        }
    }
}
