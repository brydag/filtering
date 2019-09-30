using System.Linq.Expressions;
using filtering;

namespace FilteringMechanism.FilterOperators
{
    public class LessThanOperator: IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.LessThan(left, right);
        }
    }
}