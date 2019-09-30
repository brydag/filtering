using System.Linq.Expressions;
using filtering;

namespace FilteringMechanism.FilterOperators
{
    public class RangeOperator: IFilteringOperator
    {
        public Expression CreateExpression(Expression left, Expression right)
        {
            //TissueSample.NumberOfSamples => 1 && TissueSample.NumberOfSamples <= 1

            var leftSide = Expression.GreaterThanOrEqual(left, right);
            var rightSide = Expression.LessThanOrEqual(left, right);

            return Expression.And(leftSide, rightSide);
        }
    }
}