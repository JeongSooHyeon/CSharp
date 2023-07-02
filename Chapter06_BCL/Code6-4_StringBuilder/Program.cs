using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        /*        // 비효율적인 문자열 연산
                string txt = "Hello World";

                for(int i=0; i<100000; i++)
                {
                    txt = txt + "1";
                }*/

        string txt = "Hello World";
         
        StringBuilder sb = new StringBuilder();
        sb.Append(txt);

        for(int i=0; i<300000; i++)
        {
            sb.Append("1");
        }

        string newText=sb.ToString();
    }
}

