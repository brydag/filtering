using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism.FilterOperators.LogicalOperators
{
    public class OrOperator:IFilteringCollectionOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.Or(left, right);
        }
    }
}