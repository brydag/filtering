using System.Linq;
using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism.FilterOperators
{
    public class CountOperator:IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            var methodInfo = typeof(Enumerable).GetMethods()
                .First(method => method.Name == "Count" && method.GetParameters().Length == 1)
                .MakeGenericMethod(typeof(object));

            var expressionCall = Expression.Call(methodInfo, left);

            return Expression.Equal(expressionCall, right);
        }
    }
}