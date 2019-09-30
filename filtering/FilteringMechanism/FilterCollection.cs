using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using filtering;
using FilteringMechanism.FilterOperators;

namespace FilteringMechanism
{
    public class FilterCollection<T>: IFilterElement
    {
        public IList<IFilterElement> Elements { get; set; }
        public IFilteringCollectionOperator Operator { get; set; }

        public Expression CreateExpression(Expression expression)
        {
            //return Elements.Aggregate(expression, (expression1, element) => element.CreateExpression(expression1));


            //Elements.Aggregate((left, right) => left.CreateExpression(expression));
            // Can be replaced with Elements.Agreggate
            Expression result = Elements.First().CreateExpression(expression);

            foreach (var filterElement in Elements.Skip(1))
            {
                // sample.TissueType.Name.Contains("xxx")
                var right = filterElement.CreateExpression(expression);

                //sample.TissueType.Name.Contains("xxx") || sample.Fixative.Name.Contains("yyy")
               result = Operator.CreateExpression(result, right);
            }
            return result;
        }
    }
}
