using System.Linq.Expressions;
using filtering;

namespace FilteringMechanism.FilterOperators
{
    public class AndOperator:IFilteringCollectionOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            return Expression.And(left, right);
        }
    }
}