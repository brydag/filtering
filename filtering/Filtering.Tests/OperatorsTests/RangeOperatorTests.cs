using System.Linq.Expressions;
using filtering.Models;
using FilteringMechanism.FilterOperators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Filtering.Tests.OperatorsTests
{
    [TestClass]
    public class RangeOperatorTests
    {
        [TestMethod]
        public void CreateExpressionTest1()
        {
            // Arrange
            Expression parameterExpression = Expression.Parameter(typeof(Employee), "sample");
            Expression expressionProperty = Expression.Property(parameterExpression, nameof(Employee.Age));
            Expression expressionConstant = Expression.Constant(10);

            var leftSide = Expression.GreaterThanOrEqual(expressionProperty, expressionConstant);
            var rightSide = Expression.LessThanOrEqual(expressionProperty, expressionConstant);

            Expression expectedExpression = Expression.And(leftSide, rightSide);

            var _operator = new RangeOperator();

            // Act
            Expression resultExpression = _operator.CreateExpression(expressionProperty, expressionConstant);

            // Assert
            Assert.AreEqual(expectedExpression.ToString(), resultExpression.ToString(), "Expression not correct");
        }
    }
}