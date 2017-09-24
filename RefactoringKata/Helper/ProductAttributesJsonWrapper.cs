using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringKata.Helper
{
    public class ProductAttributesJsonWrapper:StringBuilderWrapper
    {
        public override void WrapProperyValue(StringBuilder sb, string value)
        {
            if (Double.TryParse(value, out _))
            {
                sb.Append(value);
                sb.Append(", ");
                return;
            }
            WrapWithQuotes(sb, value);
        }

        public override void WrapLastAttribute(StringBuilder sb, KeyValuePair<string, string> kv)
        {
            if (Double.TryParse(kv.Value, out _))
            {
                sb.Append(kv.Value);
                sb.Append("}");
                return;
            }
            sb.Append("\"");
            sb.Append(kv.Value);
            sb.Append("\"");
        }
    }
}
