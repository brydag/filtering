using System.Linq.Expressions;

namespace FilteringMechanism
{
    public interface IFilterElement
    {
        Expression CreateExpression(Expression expression);
    }
}