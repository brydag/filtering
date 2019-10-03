using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism.FilterOperators.LogicalOperators
{
    public class AndOperator:IFilteringCollectionOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.And(left, right);
        }
    }
}