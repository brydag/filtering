using System.Linq.Expressions;

namespace FilteringMechanism.FilterOperators
{
    public class OrOperator:IFilteringCollectionOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.Or(left, right);
        }
    }
}