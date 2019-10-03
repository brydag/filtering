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
    public class TrimOperatorTests
    {
        [TestMethod]
        public void CreateExpressionTest1()
        {
            // Arrange
            Expression parameterExpression = Expression.Parameter(typeof(Employee), "sample");
            Expression expressionProperty = Expression.Property(parameterExpression, nameof(Employee.FirstName));
            Expression expressionConstant = Expression.Constant("xxx");

            MethodInfo methodInfoContains = expressionProperty.Type.GetMethod("Contains", new[] { typeof(string) });
            MethodInfo methodInfoTrim = expressionProperty.Type.GetMethod("Trim", System.Type.EmptyTypes);
            
            Expression expressionConstantTrim = Expression.Call(expressionConstant, methodInfoTrim ?? throw new InvalidOperationException());
            Expression expressionLeftTrim = Expression.Call(expressionProperty, methodInfoTrim);

            Expression expectedExpression = Expression.Call(expressionLeftTrim,
                                            methodInfoContains ?? throw new InvalidOperationException(),
                                            expressionConstantTrim);

            var decorator = new TrimDecorator(new ContainsOperator());

            // Act
            Expression resultExpression = decorator.CreateExpression(expressionProperty, expressionConstant);

            // Assert
            Assert.AreEqual(expectedExpression.ToString(), resultExpression.ToString(), "Expression not correct");
        }

    }
}