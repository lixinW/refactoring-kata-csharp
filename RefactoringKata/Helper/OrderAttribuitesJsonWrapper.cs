using System.Text;

namespace RefactoringKata.Helper
{
    public class OrderAttribuitesJsonWrapper : StringBuilderWrapper
    {
        public override void WrapProperyValue(StringBuilder sb, string value)
        {
            if (value == string.Empty)
            {
                sb.Append("[]");
                return;
            }

            if (!value.Contains(","))
            {
                sb.Append(value);
                return;
            }
            WrapWithBracket(sb,value);
        }

        public void WrapWithBracket(StringBuilder sb,string value)
        {
            sb.Append("[");
            sb.Append(value);
            sb.Append("]");
        }

        public void InsertCommaAsPartition(StringBuilder sb)
        {
            sb.Append(", ");
        }
    }
}
