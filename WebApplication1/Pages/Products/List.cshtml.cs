using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Drawing;
using WebApplication1.DataAccess;

namespace WebApplication1.Pages.Products
{
    public class ListModel : PageModel
    {
        NorthwindContext context = new NorthwindContext();

        List<Product> classProducts;

        public void OnGet(int pageNumber)
        {
            List<Boolean> selected = new List<Boolean>();
            int pageSize = 10;
            if (pageNumber <= 0) pageNumber = 1;
            int offSet = (pageNumber - 1) * pageSize + 1;

            //List<Product> products = context.Products.Include(p => p.Supplier).Include(p => p.Category).ToList();
            List<Product> products = context.Products.Skip(offSet - 1).Include(p => p.Supplier).Include(p => p.Category).Take(pageSize).ToList();
            List<Category> categories = context.Categories.ToList();

            for (int i = 1; i <= categories.Count; i++)
            {
                selected.Add(false);
            }

            ////lay cac thong tin de hien thi thanh Pager
            int TotalProduct = context.Products.ToList().Count;
            int TotalPage = (TotalProduct / pageSize);
            if (TotalProduct % pageSize != 0) TotalPage++;
            ViewData["TotalPage"] = TotalPage;
            ViewData["CurrentPage"] = pageNumber;

            // lay products va data de hien thi len View
            ViewData["priceFrom"] = "";
            ViewData["priceTo"] = "";
            ViewData["products"] = products;
            ViewData["categories"] = categories;
            ViewData["selectCate"] = selected;
        }

        public void OnPostFilter(List<int> category, string searchName, decimal priceFrom, decimal priceTo)
        {
            List<Product> products;
            List<Boolean> selected = new List<Boolean>();
            List<Category> categories = context.Categories.ToList();

            if (category.Count > 0)
            {
                products = new List<Product>();

                foreach (var categoryId in category)
                {
                    List<Product> p = context.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Supplier).Include(p => p.Category).ToList();
                    products = products.Concat(p).OrderBy(p => p.ProductId).ToList();
                }


                for(int i=1; i<=categories.Count; i++)
                {
                    if (category.Contains(i)) selected.Add(true);
                    else selected.Add(false);
                }
            }
            else
            {
                products = context.Products.Include(p => p.Supplier).Include(p => p.Category).ToList();
                for (int i = 1; i <= categories.Count; i++)
                {
                    selected.Add(false);
                }
            }

            if (searchName != "" && searchName != null)
            {
                products = products.Where(p => p.ProductName.Contains(searchName)).ToList();
            }

            if (priceFrom != 0)
            {
                products = products.Where(p => p.UnitPrice >= priceFrom).ToList();
            }

            if (priceTo != 0)
            {
                products = products.Where(p => p.UnitPrice <= priceTo).ToList();
            }

            int pageSize = 10;
            int pageNumber = 1;
            int offSet = (pageNumber - 1) * pageSize + 1;

            
            int TotalProduct = products.Count;
            int TotalPage = (TotalProduct / pageSize);
            if (TotalProduct % pageSize != 0) TotalPage++;
            ViewData["TotalPage"] = TotalPage;
            ViewData["CurrentPage"] = pageNumber;

            ViewData["priceFrom"] = priceFrom == 0 ? "" : priceFrom.ToString();
            ViewData["priceTo"] = priceTo == 0 ? "" : priceTo.ToString();
            ViewData["searchName"] = searchName;
            ViewData["products"] = products.Skip(offSet - 1).Take(pageSize).ToList();
            ViewData["categories"] = categories;
            ViewData["selectCate"] = selected;
        }

        public void OnPostPaging(List<int> category, string searchName, decimal priceFrom, decimal priceTo, int pageNumber)
        {
            List<Product> products;
            List<Boolean> selected = new List<Boolean>();
            List<Category> categories = context.Categories.ToList();

            if (category.Count > 0)
            {
                products = new List<Product>();

                foreach (var categoryId in category)
                {
                    List<Product> p = context.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Supplier).Include(p => p.Category).ToList();
                    products = products.Concat(p).OrderBy(p => p.ProductId).ToList();
                }


                for (int i = 1; i <= categories.Count; i++)
                {
                    if (category.Contains(i)) selected.Add(true);
                    else selected.Add(false);
                }
            }
            else
            {
                products = context.Products.Include(p => p.Supplier).Include(p => p.Category).ToList();
                for (int i = 1; i <= categories.Count; i++)
                {
                    selected.Add(false);
                }
            }

            if (searchName != "" && searchName != null)
            {
                products = products.Where(p => p.ProductName.Contains(searchName)).ToList();
            }

            if (priceFrom != 0)
            {
                products = products.Where(p => p.UnitPrice >= priceFrom).ToList();
            }

            if (priceTo != 0)
            {
                products = products.Where(p => p.UnitPrice <= priceTo).ToList();
            }

            int pageSize = 10;
            if (pageNumber <= 0) pageNumber = 1;
            int offSet = (pageNumber - 1) * pageSize + 1;


            int TotalProduct = products.Count;
            int TotalPage = (TotalProduct / pageSize);
            if (TotalProduct % pageSize != 0) TotalPage++;
            ViewData["TotalPage"] = TotalPage;
            ViewData["CurrentPage"] = pageNumber;

            products = products.Skip(offSet - 1).Take(pageSize).ToList();

            ViewData["priceFrom"] = priceFrom == 0 ? "" : priceFrom.ToString();
            ViewData["priceTo"] = priceTo == 0 ? "" : priceTo.ToString();
            ViewData["searchName"] = searchName;
            ViewData["products"] = products;
            ViewData["categories"] = categories;
            ViewData["selectCate"] = selected;
        }
    }
}
