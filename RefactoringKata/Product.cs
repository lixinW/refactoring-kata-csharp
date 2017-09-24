using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using RefactoringKata.Enums;
using RefactoringKata.Helper;

namespace RefactoringKata
{
    public class Product
    {
        private Dictionary<string, string> _JsonDisplayProperties;
        public string Code { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        private ProductAttributesJsonWrapper _ProductJsonFormat = new ProductAttributesJsonWrapper(); 
        public Product(string code, Color color, Size size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
        }

        public StringBuilder GetProductJson()
        {
            _JsonDisplayProperties = new Dictionary<string, string>
            {
                {"code",Code},
                {"color",Color.ToString()},
                {"size",Size.ToString()},
                {"price",Price.ToString(CultureInfo.InvariantCulture)},
                {"currency",Currency}
            };
            return GetJsonFormatFromProperty();
        }

        private StringBuilder GetJsonFormatFromProperty()
        {
            return _ProductJsonFormat.WrapWithCurelyBracket(GetProductInfoJson());
        }

        private StringBuilder GetProductInfoJson()
        {
            var sb = new StringBuilder();
            foreach (var kv in _JsonDisplayProperties)
            {
                GetProductAttributeJson(_JsonDisplayProperties, kv, sb);
            }
            return sb;
        }

        private void GetProductAttributeJson(Dictionary<string, string> JsonDisplayProperties, KeyValuePair<string, string> kv, StringBuilder sb)
        {
            if (kv.Value == Size.SIZE_NOT_APPLICABLE.ToString())
                return;

            _ProductJsonFormat.WrapPropertyKey(sb, kv.Key);

            if (IsLastAttribute(JsonDisplayProperties, kv))
            {
                _ProductJsonFormat.WrapLastAttribute(sb, kv);
                return;
            }
            _ProductJsonFormat.WrapProperyValue(sb, kv.Value);
        }

        private static bool IsLastAttribute(Dictionary<string, string> JsonDisplayProperties, KeyValuePair<string, string> kv)
        {
            return kv.Key == JsonDisplayProperties.Last().Key;
        }
    }
}
