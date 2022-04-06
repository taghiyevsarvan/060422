using System;
using System.Collections.Generic;
using System.Text;

namespace _060422
{
    internal class Order
    {
        private static int _no;
        public Order()
        {
            _no++;
            No = _no;
        }
        public int No { get;}
        public int ProductCount { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        public string ShowInfo()
        {
            return $"No: {this.No} - Product count: {this.ProductCount} - Total amount: {this.TotalAmount} - Created at: {this.CreatedAt}";
        }
    }
}
