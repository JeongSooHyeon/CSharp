using System;
using System.Linq.Expressions;

namespace Ex8_10_ExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterExpression leftExp = Expression.Parameter(typeof(int), "a");
            ParameterExpression rightExp = Expression.Parameter(typeof(int), "b");
            BinaryExpression addExp = Expression.Add(leftExp, rightExp);

            Expression<Func<int, int, int>> addLambda =
                Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(
                    addExp, new ParameterExpression[] { leftExp, rightExp }
                );

            Console.WriteLine(addLambda.ToString());

            Func<int, int, int> addFunc = addLambda.Compile();
            Console.WriteLine(addFunc(10, 2));
        }
    }
}
