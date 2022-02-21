using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace Assignment2_unitTest
{
    [TestClass]
    public class UnitTest1
    {

        AssignmentTwo.MathExpressionVisitor c = new AssignmentTwo.MathExpressionVisitor();

        /// <summary>
        /// This Unit will Test Addition
        /// </summary>
        [TestMethod]
        public void TestAddExpr()
        {
            var leftParameterExpression = Expression.Parameter(typeof(double), "x");
            var rightParameterExpression = Expression.Parameter(typeof(double), "y");
            

            var binaryExpression = Expression.Add(leftParameterExpression, rightParameterExpression);
            var Ex = c.Visit(binaryExpression);
            var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);
            var expected = 9;
            var result = lambdaExpression.Compile()(4,5);

            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// This Unit will Test Multiplication
        /// </summary>
        [TestMethod]
        public void TestMultiplyExp()
        {

            var leftParameterExpression = Expression.Parameter(typeof(double), "x");
            var rightParameterExpression = Expression.Parameter(typeof(double), "y");


            var binaryExpression = Expression.Multiply(leftParameterExpression, rightParameterExpression);
            var Ex = c.Visit(binaryExpression);
            var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);
            var expected = 20 ;
            var result = lambdaExpression.Compile()(4, 5);

            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// This Unit will Test Divide
        /// </summary>
        [TestMethod]
        public void TestDivideExp()
        {

            var leftParameterExpression = Expression.Parameter(typeof(double), "x");
            var rightParameterExpression = Expression.Parameter(typeof(double), "y");


            var binaryExpression = Expression.Divide(leftParameterExpression, rightParameterExpression);
            var Ex = c.Visit(binaryExpression);
            var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);
            var expected = 1;
            var result = lambdaExpression.Compile()(5, 5);

            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// This Unit will Test Raised to power
        /// </summary>
        [TestMethod]
        public void TestPowerExp()
        {

            var leftParameterExpression = Expression.Parameter(typeof(double), "x");
            var rightParameterExpression = Expression.Parameter(typeof(double), "y");


            var binaryExpression = Expression.Power(leftParameterExpression, rightParameterExpression);
            var Ex = c.Visit(binaryExpression);
            var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);
            var expected = 25;
            var result = lambdaExpression.Compile()(5, 2);

            Assert.AreEqual(expected, result);

        }
    }
}
