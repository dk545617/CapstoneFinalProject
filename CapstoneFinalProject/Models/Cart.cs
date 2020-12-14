using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneFinalProject.Models
{
    public class Cart
    {
        public string CartId { get; set; }
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Menu menu, int quantity)
        {
            CartLine line = lineCollection
                .Where(m => m.MenuItem.MenuId == menu.MenuId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { MenuItem = menu, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Menu menu) => lineCollection.RemoveAll(l => l.MenuItem.MenuId == menu.MenuId);

        public virtual decimal ComputeTotalValue() => lineCollection.Sum(e => e.MenuItem.Price * e.Quantity);

        public void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;

    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Menu MenuItem { get; set; }
        public int Quantity { get; set; }
    }
}
