using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism.FilterOperatorsExtensions
{
    public abstract class FilteringOperatorDecorator : IFilteringOperator
    {
        protected IFilteringOperator Operator;
        public abstract Expression CreateExpression(Expression left, Expression right);

        protected FilteringOperatorDecorator(IFilteringOperator filteringOperator)
        {
            Operator = filteringOperator;
        }
    }
}