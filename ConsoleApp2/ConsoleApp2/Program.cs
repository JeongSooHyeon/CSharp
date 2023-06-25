/*
 * 5.2.3 애플리케이션 구성 파일 : app.config
 */

using System;
using System.Configuration;

class Program
{
    static void Main(string[] args)
    {
        //string txt = ConfigurationSettings.AppSettings["AdminEmailAddress"];
        string txt = ConfigurationManager.AppSettings["AdminEmailAddress"];
        Console.WriteLine(txt); // 출력 결과 : admin@sysnet.pe.kr

        //txt = ConfigurationSettings.AppSettings["Delay"];
        txt = ConfigurationManager.AppSettings["Delay"];
        int delay = int.Parse(txt);
        Console.WriteLine(delay);   // 출력 결과 : 5000
    }
}