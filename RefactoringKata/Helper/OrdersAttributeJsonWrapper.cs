using System.Text;

namespace RefactoringKata.Helper
{
    public class OrdersAttributeJsonWrapper: StringBuilderWrapper
    {
        public void AppendOpenBracket(StringBuilder sb)
        {
            sb.Append("[");
        }
        public void AppendCloseBracket(StringBuilder sb)
        {
            sb.Append("]");
        }

        public void AppendCloseCurleyBracket(StringBuilder sb)
        {
            sb.Append("}");
        }

        public void RemoveLastElementComma(StringBuilder sb)
        {
            sb.Remove(sb.Length-2, 2);
        }
    }
}
