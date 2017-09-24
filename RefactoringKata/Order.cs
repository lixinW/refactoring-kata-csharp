using System.Collections.Generic;
using System.Linq;
using System.Text;
using RefactoringKata.Helper;

namespace RefactoringKata
{
    public class Order
    {
        private readonly int id;
        private readonly List<Product> _products = new List<Product>();
        private OrderAttribuitesJsonWrapper _OrderJsonFormat = new OrderAttribuitesJsonWrapper();

        public Order(int id)
        {
            this.id = id;
        }

        public int GetOrderId()
        {
            return id;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void GetOrderJson(StringBuilder sb)
        {
            sb.Append("{");
            GetOrderInfoJson(sb);
            sb.Append("}, ");
        }

        private void GetOrderInfoJson(StringBuilder sb)
        {
            var _orderProperties = new Dictionary<string, string>
            {
                {"id",GetOrderId().ToString()},
                {"products",GetProdcutListJson().ToString()}
            };

            foreach (var kv in _orderProperties)
            {
                _OrderJsonFormat.WrapPropertyKey(sb,kv.Key);
                _OrderJsonFormat.WrapProperyValue(sb,kv.Value);
                if( kv.Key != _orderProperties.Last().Key)
                _OrderJsonFormat.InsertCommaAsPartition(sb);
            }

        }

        private StringBuilder GetProdcutListJson()
        {
            var sb = new StringBuilder();
            foreach (var product in _products)
            {
                sb.Append(product.GetProductJson());
            }
            return sb;
        }
    }
}