using System.Collections.Generic;
using System.Text;

namespace RefactoringKata.Helper
{
    public class StringBuilderWrapper
    {
        public virtual void WrapWithQuotes(StringBuilder sb, string str)
        {
            sb.Append("\"");
            sb.Append(str);
            sb.Append("\", ");
        }

        public virtual void WrapPropertyKey(StringBuilder sb, string key)
        {
            sb.Append("\"");
            sb.Append(key);
            sb.Append("\": ");
        }

        public virtual void WrapProperyValue(StringBuilder sb, string value)
        {
            throw new System.NotImplementedException();
        }

        public virtual void WrapLastAttribute(StringBuilder sb, KeyValuePair<string, string> kv)
        {
            throw new System.NotImplementedException();
        }

        public virtual StringBuilder WrapWithCurelyBracket(StringBuilder content)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append(content);
            sb.Append("}");
            return sb;
        }
    }
}