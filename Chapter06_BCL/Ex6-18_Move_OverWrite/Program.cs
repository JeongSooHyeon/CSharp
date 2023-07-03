using System.Text;

using (FileStream fs = new FileStream("test.log", FileMode.Create))
{
    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
    sw.WriteLine("Hello World");
    sw.WriteLine("Anderson");
    sw.Write(32000);
    sw.Flush();
}

string target = "d:\\temp\\test.dat";
if (File.Exists(target) == true)
{
    File.Delete(target);
}
File.Move("test.log", target);

