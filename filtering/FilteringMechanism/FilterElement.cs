using System;
using System.Linq;
using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism
{
    public class FilterElement: IFilterElement
    {
        public string Property { get; set; }
        public object Value  { get; set; }
        public IFilteringOperator Operator { get; set; }

        public Expression CreateExpression(Expression expression)
        {
            var propertySplit = Property.Split(Convert.ToChar("."));

            expression = propertySplit.Aggregate(expression, Expression.Property);

            return Operator.CreateExpression(expression, Expression.Constant(Value));
        }
    }
}