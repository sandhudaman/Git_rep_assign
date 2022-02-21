///I, <Damanpreet_Singh>, student number <000741359>, certify that all code submitted is my own work;
///that I have not copied it from any other source. 
///I also certify that I have not allowed my work to be copied by others.

using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentTwo
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            string expStr = checkexp();

            makeExp(expStr);

        }

        /// <summary>
        /// This method will check String ot make sure it obeys Rpn and will return a string 
        /// </summary>
        /// <returns>returns a string if expression Corrent </returns>
        public static string checkexp() 
        {
            //String expStr = "15 7 1 1 + - / 3 * 2 1 1 + + -";
            String expStr = "";
            bool goodString = false;

            //This loop will be used for evaluating string for Reverse Equation
            while (goodString == false)
            {

                Console.WriteLine("Please enter a Reverse Polish Expression **with spaces after Each Character: ");
                expStr = Console.ReadLine();


                List<char> express = new List<char>()
                { '0','1','2','3','4','5','6','7','8','9'};
                List<char> expOpr = new List<char>()
                { '+','-','/','*','^'};

                string[] words = expStr.Split(' ');
                int strLength = words.Length;
                int correctWord = 0;
                int correctOpr = 0;
                int totalWord;
                //loop to count integer and operators to make sure they are enough to solve equation
                foreach (string to in words)
                {
                    if (express.Contains(to[0]))
                    {
                        correctWord++;
                    }
                    if (expOpr.Contains(to[0]))
                    {
                        correctOpr++;
                    }

                }
                totalWord = correctWord + correctOpr;

                //Console.WriteLine($" correct words {correctWord},Correct Opr {correctOpr}, str length{strLength}");
                //This if statement checks if the format is correct 
                if ((totalWord == strLength) && (correctOpr == correctWord - 1)
                    && (express.Contains(words[0][0])) && (expOpr.Contains(words[words.Length - 1][0])))
                {
                    goodString = true;
                }
                else
                {
                    Console.WriteLine("Equation provided invalid Please Try Again!!");
                }


            }

            return expStr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expStr"></param>
        public static void makeExp( string expStr)
        {
            string[] words = expStr.Split(' ');

            List<Expression> toList = new List<Expression>();

            var mathVisitor = new MathExpressionVisitor();

            //These parameters were used to make + - / * ^ to expressions
            // declare and initialize the left parameter expression, represented as the variable x,y
            var leftParameterExpression = Expression.Parameter(typeof(double), "x");
            var rightParameterExpression = Expression.Parameter(typeof(double), "y");

            // Loop to make nades of each component of string 
            foreach (string to in words)
            {
                // tried to use switch case that was giving me issues so used if else 
                if (to == "+" || to == "-" || to == "/" || to == "*" || to == "^")
                {
                    if (to =="+")
                    {
                        var binaryExpression = Expression.Add(leftParameterExpression, rightParameterExpression);
                        toList.Add(mathVisitor.Visit(binaryExpression));
                    }
                    else if (to == "-")
                    {
                        var binaryExpression = Expression.Subtract(leftParameterExpression, rightParameterExpression);
                        toList.Add(mathVisitor.Visit(binaryExpression));

                    }
                    else if (to == "/")
                    {
                        var binaryExpression = Expression.Divide(leftParameterExpression, rightParameterExpression);
                        toList.Add(mathVisitor.Visit(binaryExpression));

                    }
                    else if (to == "*")
                    {
                        var binaryExpression = Expression.Multiply(leftParameterExpression, rightParameterExpression);
                        toList.Add(mathVisitor.Visit(binaryExpression));

                    }
                    else if (to == "^")
                    {
                        var binaryExpression = Expression.Power(leftParameterExpression, rightParameterExpression);
                        toList.Add(mathVisitor.Visit(binaryExpression));

                    }
                }
                // else to process Constant
                else
                {
                    double x = Convert.ToDouble(to.ToString());
                    var paraExp = Expression.Constant( x,typeof(double));
                    toList.Add(paraExp);

                };

            }
            

        
            int Counter = 0;
            int maxCount = toList.Count;
            // while Loop will Iterate until two expressions are left in List
            // List[0] will be the answer to the screen
            while (toList.Count > 2)
            {
                //IF else For every nodeType
                if (toList[Counter].NodeType == ExpressionType.Add) {

                    //Console.WriteLine(Counter);
                    var x = (ConstantExpression)toList[Counter - 1];
                    var y = (ConstantExpression)toList[Counter - 2];
                    var binaryExpression = Expression.Add(leftParameterExpression, rightParameterExpression);
                    var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);

                    var result = lambdaExpression.Compile()((double)y.Value, (double)x.Value);

                    toList[Counter - 2] = Expression.Constant(result, typeof(double));

                    toList.Remove(toList[Counter]);
                    toList.Remove(toList[Counter-1]);

                    
                    Console.WriteLine($"Added Sum to list :{result}");
                    Counter = Counter - 2;
                    //Console.WriteLine($"After Counter - 2 :{Counter}");

                }
                else if (toList[Counter].NodeType == ExpressionType.Subtract)
                {

                    //Console.WriteLine(Counter);
                    var x = (ConstantExpression)toList[Counter - 1];
                    var y = (ConstantExpression)toList[Counter - 2];
                    var binaryExpression = Expression.Subtract(leftParameterExpression, rightParameterExpression);
                    var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);

                    var result = lambdaExpression.Compile()((double)y.Value, (double)x.Value);

                    toList[Counter - 2] = Expression.Constant(result, typeof(double));
                    toList.Remove(toList[Counter]);
                    toList.Remove(toList[Counter - 1]);

                    
                    Console.WriteLine($"Added Subtract to list :{result}");
                    Counter = Counter - 2;
                    //Console.WriteLine($"After Counter - 2 :{Counter}");

                }

                else if (toList[Counter].NodeType == ExpressionType.Multiply)
                {
                    //Console.WriteLine(Counter);

                    var x = (ConstantExpression)toList[Counter - 1];
                    var y = (ConstantExpression)toList[Counter - 2];
                    var binaryExpression = Expression.Multiply(leftParameterExpression, rightParameterExpression);
                    var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);

                    var result = lambdaExpression.Compile()((double)y.Value, (double)x.Value);

                    toList[Counter - 2] = Expression.Constant(result, typeof(double));

                    toList.Remove(toList[Counter]);
                    toList.Remove(toList[Counter - 1]);

                    
                    Console.WriteLine($"Added Multiply to list:{result}");
                    Counter = Counter - 2;
                    //Console.WriteLine($"After Counter - 2 :{Counter}");

                }
                else if (toList[Counter].NodeType == ExpressionType.Divide)
                {
                    //Console.WriteLine(Counter);

                    var x = (ConstantExpression)toList[Counter - 1];
                    var y = (ConstantExpression)toList[Counter - 2];
                    var binaryExpression = Expression.Divide(leftParameterExpression, rightParameterExpression);
                    var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);

                    var result = lambdaExpression.Compile()((double)y.Value, (double)x.Value);

                    toList[Counter - 2] = Expression.Constant(result, typeof(double));
                    toList.Remove(toList[Counter]);
                    toList.Remove(toList[Counter - 1]);

                    
                    Console.WriteLine($"Added Divide  to list:{result}");
                    Counter = Counter - 2;
                    //Console.WriteLine($"After Counter - 2 :{Counter}");

                }
                else if (toList[Counter].NodeType == ExpressionType.Divide)
                {
                    //Console.WriteLine(Counter);

                    var x = (ConstantExpression)toList[Counter - 1];
                    var y = (ConstantExpression)toList[Counter - 2];
                    var binaryExpression = Expression.Divide(leftParameterExpression, rightParameterExpression);
                    var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);

                    var result = lambdaExpression.Compile()((double)y.Value, (double)x.Value);

                    toList[Counter - 2] = Expression.Constant(result, typeof(double));
                    toList.Remove(toList[Counter]);
                    toList.Remove(toList[Counter - 1]);


                    Console.WriteLine($"Added Divide  to list:{result}");
                    Counter = Counter - 2;
                    //Console.WriteLine($"After Counter - 2 :{Counter}");

                }
                else if (toList[Counter].NodeType == ExpressionType.Power)
                {
                    //Console.WriteLine(Counter);

                    var x = (ConstantExpression)toList[Counter - 1];
                    var y = (ConstantExpression)toList[Counter - 2];
                    var binaryExpression = Expression.Power(leftParameterExpression, rightParameterExpression);
                    var lambdaExpression = Expression.Lambda<Func<double, double, double>>
                        (binaryExpression, leftParameterExpression, rightParameterExpression);

                    var result = lambdaExpression.Compile()((double)y.Value, (double)x.Value);

                    toList[Counter - 2] = Expression.Constant(result, typeof(double));
                    toList.Remove(toList[Counter]);
                    toList.Remove(toList[Counter - 1]);


                    Console.WriteLine($"Added Power to list :{result}");
                    Counter = Counter - 2;
                    //Console.WriteLine($"After Counter - 2 :{Counter}");

                }

                Counter++;
                if (Counter == maxCount) 
                { break; }

            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            //Printing out result
            Console.WriteLine($"Result of Equation {toList[0]}");

        }

        
    }
}
