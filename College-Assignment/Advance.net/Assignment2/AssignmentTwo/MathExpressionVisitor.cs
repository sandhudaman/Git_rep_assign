using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AssignmentTwo
{
    public class MathExpressionVisitor:ExpressionVisitor
    {

        
        public override Expression Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                    return this.VisitBinary((BinaryExpression)node);
                case ExpressionType.Subtract:
                    return this.VisitBinary((BinaryExpression)node);
                case ExpressionType.Multiply:
                    return this.VisitBinary((BinaryExpression)node);
                case ExpressionType.Divide:
                    return this.VisitBinary((BinaryExpression)node);
                case ExpressionType.Power:
                    return this.VisitBinary((BinaryExpression)node);
                case ExpressionType.Constant:
                    return this.VisitConstant((ConstantExpression)node);
                    // we can safely cast the expression to a binary expression
                    // because all the above types in our case statement
                    // are all expression types that only support a binary expression
                    

                // add the default case so that we can safely
                // ignore any expressions that do not have the above expression types
                default:
                    // always call base.methodname, in our case we are calling base.Visit(node);
                    // otherwise we will enter Infinite Recursion(Loop) 
                 
                    return base.Visit(node);
            }
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            // visit the right side of the binary expression
            var right = this.Visit(node.Right);

            // visit the left side of the binary expression
            var left = this.Visit(node.Left);
            switch (node.NodeType)

            {
                case ExpressionType.Add:

                    
                    return Expression.Add( left, right); 

                case ExpressionType.Subtract:
                    
                    return Expression.Subtract( left, right);

                case ExpressionType.Multiply:
                    
                    return Expression.Multiply( left, right);

                case ExpressionType.Divide:
                    
                    return Expression.Divide(left, right);

                case ExpressionType.Power:

                    Console.WriteLine("here in Power");
                    return Expression.Power( left, right);

  
                // add the default case so that we can safely
                // ignore any expressions that do not have the above expression types
                default:
                    // always call base.methodname, in our case
                    // we are calling base.VisitBinary(node);
                    return base.VisitBinary(node);
            }
            }

            protected override Expression VisitConstant(ConstantExpression node)
            {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    Console.WriteLine("IN Const");
                    return Expression.Constant(node) ;

                // add the default case so that we can safely
                // ignore any expressions that do not have the above expression types
                default:
                    // always call base.methodname, in our case
                    // we are calling base.VisitBinary(node);
                    return base.Visit(node);
            }

        }
    }
}