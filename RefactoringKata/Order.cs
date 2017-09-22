using System.Collections.Generic;
using System.Text;
using RefactoringKata.Helper;

namespace RefactoringKata
{
    public class Order
    {
        private readonly int id;
        private readonly List<Product> _products = new List<Product>();

        public Order(int id)
        {
            this.id = id;
        }

        public int GetOrderId()
        {
            return id;
        }

        public int GetProductsCount()
        {
            return _products.Count;
        }

        public Product GetProduct(int j)
        {
            return _products[j];
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void GetOrderInfoJson(int i, StringBuilder sb)
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
                StringBuilderWrapper.WrapPropertyKey(sb,kv.Key);
                StringBuilderWrapper.WrapProperyValue(sb,kv.Value);
            }
            //sb.Append("\"id\": ");
            //sb.Append(GetOrderId());
            //sb.Append(", ");
            //sb.Append("\"products\": [");

            //sb.Append(GetProdcutListJson());

            if (GetProductsCount() > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            sb.Append("]");
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