using System.Linq.Expressions;
using filtering;

namespace FilteringMechanism.FilterOperators
{
    public class NotEqualOperator:IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }
    }
}
