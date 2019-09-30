using System.Linq.Expressions;

namespace filtering
{
    public interface IFilteringOperator
    {
        Expression CreateExpression(Expression left, Expression right);
    }
}