using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusPedido.Entities.Enuns;
using System.Globalization;

namespace StatusPedido.Entities
{
    class Order
    {
        private object CulturalInfo;

        public DateTime Momment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { 
        }

        public Order(DateTime momment, OrderStatus orderstatus, Client client)
        {
            Momment = momment;
            Status = orderstatus;
            Client = client;
        }
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order momment: " + Momment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Status:" + Status);
            sb.Append("Client: " + Client);
            sb.Append("Order Items:");
                foreach (OrderItem item in Items)
            {
                sb.Append(item.ToString());
            }
            sb.AppendLine("Total Price: " + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
