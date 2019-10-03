using System.Linq.Expressions;
using filtering.Models;
using FilteringMechanism.FilterOperators;
using FilteringMechanism.FilterOperators.LogicalOperators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Filtering.Tests.LogicalOperatorsTests
{
    [TestClass]
    public class OrOperatorTests
    {
        [TestMethod]
        public void CreateExpressionTest1()
        {
            // Arrange
            var parameterExpression = Expression.Parameter(typeof(Employee), "sample");
            var expressionProperty = Expression.Property(parameterExpression, nameof(Employee.FirstName));
            var containsOperator = new ContainsOperator();

            Expression leftExpression = containsOperator.CreateExpression(expressionProperty, Expression.Constant("xxx"));
            Expression rightExpression = containsOperator.CreateExpression(expressionProperty, Expression.Constant("yyy"));

            Expression expectedExpression = Expression.Or(leftExpression, rightExpression);

            var _operator = new OrOperator();

            // Act
            Expression resultExpression = _operator.CreateExpression(leftExpression, rightExpression);

            // Assert
            Assert.AreEqual(expectedExpression.ToString(), resultExpression.ToString(), "Expression not correct");
        }
    }
}