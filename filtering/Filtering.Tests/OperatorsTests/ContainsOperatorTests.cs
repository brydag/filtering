using System;
using System.Linq.Expressions;
using System.Reflection;
using filtering.Models;
using FilteringMechanism.FilterOperators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Filtering.Tests.OperatorsTests
{
    [TestClass]
    public class ContainsOperatorTests
    {
        [TestMethod]
        public void CreateExpressionTest1()
        {
            // Arrange
            Expression parameterExpression = Expression.Parameter(typeof(Employee), "sample");
            Expression expressionProperty = Expression.Property(parameterExpression, nameof(Employee.FirstName));
            Expression expressionConstant = Expression.Constant("xxx");

            MethodInfo methodInfo = expressionProperty.Type.GetMethod("Contains", new[] {typeof(string)});

            Expression expectedExpression = Expression.Call(expressionProperty,
                                            methodInfo ?? throw new InvalidOperationException(),
                                            expressionConstant);

            var _operator = new ContainsOperator();

            // Act
            Expression resultExpression = _operator.CreateExpression(expressionProperty, expressionConstant);

            // Assert
            Assert.AreEqual(expectedExpression.ToString(), resultExpression.ToString(), "Expression not correct");
        }
    }
}