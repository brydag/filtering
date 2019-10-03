using System.Linq.Expressions;
using filtering.Models;
using FilteringMechanism.FilterOperators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Filtering.Tests.OperatorsTests
{
    [TestClass]
    public class NotEqualOperatorTests
    {
        [TestMethod]
        public void CreateExpressionTest1()
        {
            // Arrange
            Expression parameterExpression = Expression.Parameter(typeof(Employee), "sample");
            Expression expressionProperty = Expression.Property(parameterExpression, nameof(Employee.Age));
            Expression expressionConstant = Expression.Constant(20);

            Expression expectedExpression = Expression.NotEqual(expressionProperty, expressionConstant);

            var _operator = new NotEqualOperator();

            // Act
            Expression resultExpression = _operator.CreateExpression(expressionProperty, expressionConstant);

            // Assert
            Assert.AreEqual(expectedExpression.ToString(), resultExpression.ToString(), "Expression not correct");
        }
    }
}