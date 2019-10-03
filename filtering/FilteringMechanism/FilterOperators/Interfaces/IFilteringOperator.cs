using System.Linq.Expressions;

namespace FilteringMechanism.FilterOperators.Interfaces
{
    public interface IFilteringOperator
    {
        Expression CreateExpression(Expression left, Expression right);
    }
}