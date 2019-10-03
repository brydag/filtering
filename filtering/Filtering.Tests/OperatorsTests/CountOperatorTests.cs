using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using filtering.Models;
using FilteringMechanism.FilterOperators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Filtering.Tests.OperatorsTests
{
    [TestClass]
    public class CountOperatorTests
    {
        [TestMethod]
        public void CreateExpressionTest1()
        {
            // Arrange
            Expression parameterExpression = Expression.Parameter(typeof(Employee), "sample");
            Expression expressionProperty = Expression.Property(parameterExpression, nameof(Employee.Subordinates));
            Expression expressionConstant = Expression.Constant(2);

            MethodInfo methodInfo = typeof(Enumerable).GetMethods()
                .First(method => method.Name == "Count" && method.GetParameters().Length == 1)
                .MakeGenericMethod(typeof(object));

            var expressionCount = Expression.Call(methodInfo, expressionProperty);

            Expression expectedExpression = Expression.Equal(expressionCount, expressionConstant);

            var _operator = new CountOperator();

            // Act
            Expression resultExpression = _operator.CreateExpression(expressionProperty, expressionConstant);

            // Assert
            Assert.AreEqual(expectedExpression.ToString(), resultExpression.ToString(), "Expression not correct");
        }
    }
}
