using System.Linq.Expressions;

namespace FilteringMechanism.FilterOperators.Interfaces
{
    public interface IFilteringCollectionOperator
    {
        Expression CreateExpression(Expression left, Expression right);
    }
}