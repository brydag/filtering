using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace filtering
{
    public class FilterCollection<T>: IFilterElement
    {
        public IList<IFilterElement> Elements { get; set; }
        public FilterCollectionOperator Operator { get; set; }

        public Expression CreateExpression(Expression expression)
        {
            Expression bodyCondition = Elements.First().CreateExpression(expression);

            foreach (var filterElement in Elements.Skip(1))
            {
                // sample.TissueType.Name.Contains("xxx")
                var right = filterElement.CreateExpression(expression);

                //sample.TissueType.Name.Contains("xxx") || sample.Fixative.Name.Contains("yyy")
                switch (Operator)
                {
                    case FilterCollectionOperator.And:
                        bodyCondition = Expression.And(bodyCondition, right);
                        break;
                    case FilterCollectionOperator.Or:
                        bodyCondition = Expression.Or(bodyCondition, right);
                        break;
                }

            }

            // sample => sample.TissueType.Name.Contains("xxx")
            return Expression.Lambda<Func<T, bool>>((MethodCallExpression)bodyCondition, (ParameterExpression)expression);
        }
    }
}
