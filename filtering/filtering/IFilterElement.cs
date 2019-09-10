using System.Linq.Expressions;

namespace filtering
{
    public interface IFilterElement
    {
        Expression CreateExpression(Expression expression);
    }
}