using System;
using System.Linq.Expressions;
using System.Reflection;
using filtering;
using filtering.Models;
using FilteringMechanism.FilterOperators;
using FilteringMechanism.FilterOperatorsExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Filtering.Tests.FilterOperatorsExtensionsTests
{
    [TestClass]
    public class ToLowerOperatorTests
    {
        [TestMethod]
        public void CreateExpressionTest1()
        {
            // Arrange
            Expression parameterExpression = Expression.Parameter(typeof(Employee), "sample");
            Expression expressionProperty = Expression.Property(parameterExpression, nameof(Employee.FirstName));
            Expression expressionConstant = Expression.Constant("xxx");

            MethodInfo methodInfoContains = expressionProperty.Type.GetMethod("Contains", new[] { typeof(string) });
            MethodInfo methodInfoToLower = expressionProperty.Type.GetMethod("ToLower", System.Type.EmptyTypes);

            Expression expressionConstantToLower = Expression.Call(expressionConstant, methodInfoToLower ?? throw new InvalidOperationException());
            Expression expressionLeftToLower = Expression.Call(expressionProperty, methodInfoToLower);

            Expression expectedExpression = Expression.Call(expressionLeftToLower,
                                            methodInfoContains ?? throw new InvalidOperationException(),
                                            expressionConstantToLower);
            
            var decorator = new ToLowerDecorator(new ContainsOperator());

            // Act
            Expression resultExpression = decorator.CreateExpression(expressionProperty, expressionConstant);

            // Assert
            Assert.AreEqual(expectedExpression.ToString(), resultExpression.ToString(), "Expression not correct");
        }

    }
}