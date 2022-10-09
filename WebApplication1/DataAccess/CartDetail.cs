using System.Linq;

namespace WebApplication1.DataAccess
{
    public class CartDetail
    {
        public int Id { get; set; }
        public List<ItemInCart> Items { get; set; }
        public decimal Total { get; set; }

        public CartDetail()
        {
            Items = new List<ItemInCart>();
        }

        public void setItems(List<ItemInCart> items)
        {
            this.Items = items;
        }

        public List<ItemInCart> getItems()
        {
            return Items;
        }
        // số lượng 1 sản phẩm trong giỏ - khách sẽ mua

        public int getItemQuantity(int id)
        {
            return getExactItem(id).Quantity;
        }

        public ItemInCart getExactItem(int id)
        {
            foreach (ItemInCart i in Items)
            {
                int productId = i.Product.ProductId;
                if (productId == id)
                {
                    return i;
                }
            }
            return null;
        }
        // add 1 sản phẩm vào giỏ, nếu có rồi thì tăng số lượng

        public void addItem(ItemInCart i)
        {
            if (getExactItem(i.Product.ProductId) != null)
            {
                ItemInCart inCart = getExactItem(i.Product.ProductId);
                inCart.Quantity = inCart.Quantity + i.Quantity;
            }
            else
            {
                Items.Add(i);
            }
        }
        //loại sản phẩm khỏi giỏ

        public void removeItem(int id)
        {
            if (getExactItem(id) != null)
            {
                Items.Remove(getExactItem(id));
            }
        }
        //tổng tiền của cả giỏ hàng – sẽ add vào bảng Order

        public decimal getTotalMoney()
        {
            decimal t = 0;

            foreach (ItemInCart i in Items)
            {
                t += (i.Quantity * (decimal) i.Product.UnitPrice);
            }
            return t;
        }
    }
}
