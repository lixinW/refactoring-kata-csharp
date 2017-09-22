using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringKata.Helper
{
    internal class StringBuilderWrapper
    {
        private static void WrapWithQuotes(StringBuilder sb, string str)
        {
            sb.Append("\"");
            sb.Append(str);
            sb.Append("\", ");
        }

        public static void WrapPropertyKey(StringBuilder sb, string key)
        {
            sb.Append("\"");
            sb.Append(key);
            sb.Append("\": ");
        }

        public static void WrapProperyValue(StringBuilder sb, string value)
        {
            double i;
            if (Double.TryParse(value, out i))
            {
                sb.Append(value);
                sb.Append(", ");
                return;
            }
            WrapWithQuotes(sb, value);

        }

        public static void WrapLastAttribute(StringBuilder sb, KeyValuePair<string, string> kv)
        {
            double i;
            if (Double.TryParse(kv.Value, out i))
            {
                sb.Append(kv.Value);
                sb.Append("}");
                return;
            }
            sb.Append("\"");
            sb.Append(kv.Value);
            sb.Append("\"}}");
        }

        public static StringBuilder WrapWithCurelyBracket(StringBuilder content)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append(content);
            sb.Append("}");
            return sb;
        }
    }
}