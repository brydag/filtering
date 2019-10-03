using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FilteringMechanism.FilterOperators.Interfaces;

namespace FilteringMechanism
{
    public class FilterCollection<T>: IFilterElement
    {
        public IList<IFilterElement> Elements { get; set; }
        public IFilteringCollectionOperator Operator { get; set; }

        public Expression CreateExpression(Expression expression)
        {
            Expression first = Elements.First().CreateExpression(expression);

            return Elements.Skip(1)
                .Aggregate(first, (result, element) => 
                    Operator.CreateExpression(result, element.CreateExpression(expression)));
        }
    }
}
