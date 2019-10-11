using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        public decimal Balance { get; private set; } = 0;
        private List<CateringItem> items = new List<CateringItem>();

        //Methods
        public decimal AddMoneyEquation(int nums)
        {
            Balance += nums;
            return Balance;
        }

        public string AddToShoppingCart(CateringItem item, int desiredQty)
        {
                items.Add(item);
                item.ItemQty -= desiredQty;
            return "";
        }
    }
}
