using System.Collections.Generic;
using System.Text;
using RefactoringKata.Helper;

namespace RefactoringKata
{
    public class Orders 
    {
        private List<Order> _orders = new List<Order>();
        private OrdersAttributeJsonWrapper _OrdersJsonFormat = new OrdersAttributeJsonWrapper();
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }


        public string GetOrdersJson()
        {
            var sb = new StringBuilder("{\"orders\": ");
            _OrdersJsonFormat.AppendOpenBracket(sb);
            if (_orders.Count == 0)
            {
                _OrdersJsonFormat.AppendCloseBracket(sb);
                _OrdersJsonFormat.AppendCloseCurleyBracket(sb);
                return sb.ToString();
            }
            foreach (var order in _orders)
            {
                order.GetOrderJson(sb);
             
            }
            _OrdersJsonFormat.RemoveLastElementComma(sb);
            _OrdersJsonFormat.AppendCloseBracket(sb);
            _OrdersJsonFormat.AppendCloseCurleyBracket(sb);
            return sb.ToString();
        }

            
    }
}
