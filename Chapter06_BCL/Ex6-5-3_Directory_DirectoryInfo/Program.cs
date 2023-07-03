foreach(string txt in Directory.GetLogicalDrives())
{
    Console.WriteLine(txt);
}

string targetPath = @"C:\Windows\Microsoft.NET\Framework";
foreach(string txt in Directory.GetFiles(targetPath))
{
    Console.WriteLine(txt);
}

Console.WriteLine();

targetPath = @"C:\Windows\Microsoft.NET\Framework";
foreach(string txt in Directory.GetDirectories(targetPath))
{
    Console.WriteLine(txt);
}

Console.WriteLine();

targetPath = @"C:\Windows\Microsoft.NET\Framework";
foreach(string txt in Directory.GetFiles(targetPath, "*exe", SearchOption.AllDirectories))
{
    Console.WriteLine(txt);
}