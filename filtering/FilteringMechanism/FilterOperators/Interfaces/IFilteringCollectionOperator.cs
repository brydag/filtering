using System.Linq.Expressions;

namespace FilteringMechanism.FilterOperators
{
    public interface IFilteringCollectionOperator
    {
        Expression CreateExpression(Expression left, Expression right);
    }
}