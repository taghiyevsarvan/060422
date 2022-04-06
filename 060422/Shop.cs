using System;
using System.Collections.Generic;
using System.Text;

namespace _060422
{
    internal class Shop
    {
        List<Order> _orders;

        public Shop()
        {
            _orders = new List<Order>();
        }

        public void AddOrder(Order _order)
        {
            _orders.Add(_order);
        }



        public double GetOrderAvg()
        {
            double totalAmount = 0;
            foreach (var item in _orders)
            {
                totalAmount=totalAmount + item.TotalAmount;
            }
            return totalAmount/(_orders.Count);
        }

        public double GetOrdersAvg(DateTime dateTime)
        {
            double totalAmount = 0;
            var filterdAvg = _orders.FindAll(order => order.CreatedAt >= dateTime);
            foreach (var item in filterdAvg)
            {
                totalAmount = totalAmount + item.TotalAmount;
            }
            totalAmount = totalAmount/(filterdAvg.Count);
            return totalAmount;
        }

        public void RemoveOrderByNo(int? no)
        {
            if (no == null)
                throw new NullReferenceException("no null ola bilmez");
            var removeNo = _orders.Find(o => o.No == no);
            if(removeNo == null)
                throw new Exception("bele group yoxdur");
            _orders.Remove(removeNo);
        }
        public List<Order> FilterOrderByPrice(double minPrice, double maxPrice)
        {
            var filtredPrice = _orders.FindAll(order => order.TotalAmount >= minPrice && order.TotalAmount <= maxPrice);
            if (filtredPrice.Count == 0)
                throw new Exception("Xeta");
            return filtredPrice;
        }


        public List<Order> GetAllOrders()
        {
            //bu metodu ozum elave etdim order elave edenden sonra hamisin caqirimasi ucun;
            List<Order> ordersCopy = new List<Order>();
            ordersCopy.AddRange(_orders);
            return ordersCopy;
        }
    }
}
