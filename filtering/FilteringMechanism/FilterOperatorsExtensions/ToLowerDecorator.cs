using System;
using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism.FilterOperatorsExtensions
{
    public class ToLowerDecorator : FilteringOperatorDecorator
    {
        public ToLowerDecorator(IFilteringOperator filteringOperator) : base(filteringOperator)
        {
        }

        public override Expression CreateExpression(Expression left, Expression right)
        {
            const string methodName = "ToLower";
            var methodInfo = left.Type.GetMethod(methodName, Type.EmptyTypes);

            if (methodInfo == null)
            {
                throw new ArgumentException(methodName, left.Type.Name);
            }

            var toLowerLeft = Expression.Call(left, methodInfo);     // czy zalozeniem jest ze zawsze operacje robimy na obu stronach
            var toLowerRight = Expression.Call(right, methodInfo);

            return Operator.CreateExpression(toLowerLeft, toLowerRight);
        }
    }
}