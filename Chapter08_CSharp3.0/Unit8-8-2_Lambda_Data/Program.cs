using System;
using System.Linq.Expressions;

namespace Unit8_8_2_Lambda_Data
{
    class Program
    {
        delegate int MyAdd(int a, int b);

        static void Main(string[] args)
        {
            MyAdd myFunc = (a, b) => a + b;
            Console.WriteLine("10 + 2 == " + myFunc(10, 2));

            // 람다 식을 Expression 객체로 다루기
            Expression<Func<int, int, int>> exp = (a, b) => a + b;

            // 람다 식 본체의 루트는 이항 연산자인 + 기호
            BinaryExpression opPlus = exp.Body as BinaryExpression;
            Console.WriteLine(opPlus.NodeType);

            // 이항 연산자의 좌측 연산자를 나타내는 표현식
            ParameterExpression left = opPlus.Left as ParameterExpression;
            Console.WriteLine(left.NodeType + " : " + left.Name);

            // 이항 연산자의 우츨 연산자를 나타내는 표현식
            ParameterExpression right = opPlus.Right as ParameterExpression;
            Console.WriteLine(right.NodeType + " : " + right.Name);


            // Compile 메서드
            Func<int, int, int> func = exp.Compile();
            Console.WriteLine(func(10, 2));
        }
    }
}
