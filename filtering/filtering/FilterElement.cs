using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace filtering
{
    public class FilterElement: IFilterElement
    {
        public string Property { get; set; }
        public object Value  { get; set; }
        public FilteringOperator Operator { get; set; }

        public Expression CreateExpression(Expression expression)
        {
            MethodInfo method = null;

            // sample.TissueType.Name
            var path = Expression.Property(expression, Property);

            switch (Operator)
            {
                case FilteringOperator.Equals:
                    break;
                case FilteringOperator.NotEqauls:
                    break;
                default:
                    method = FilteringExtension.GetContainsMethod(path);
                    break;

            }

            // sample.TissueType.Name.Contains("xxx")
            return Expression.Call(path, method, Expression.Constant(Value));
        }

    }
}
