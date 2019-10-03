using System.Linq.Expressions;
using filtering.Models;
using FilteringMechanism.FilterOperators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Filtering.Tests.OperatorsTests
{
    [TestClass]
    public class EqualOperatorTests
    {
        [TestMethod]
        public void CreateExpressionTest1()
        {
            // Arrange
            Expression parameterExpression = Expression.Parameter(typeof(Employee), "sample");
            Expression expressionProperty = Expression.Property(parameterExpression, nameof(Employee.FirstName));
            Expression expressionConstant = Expression.Constant("xxx");

            Expression expectedExpression = Expression.Equal(expressionProperty, expressionConstant);

            var _operator = new EqualOperator();

            // Act
            Expression resultExpression = _operator.CreateExpression(expressionProperty, expressionConstant);

            // Assert
            Assert.AreEqual(expectedExpression.ToString(), resultExpression.ToString(), "Expression not correct");
        }
    }
}