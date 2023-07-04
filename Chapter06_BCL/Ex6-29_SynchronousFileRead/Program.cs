using System.Text;

using (FileStream fs = new FileStream(@"C:\windows\system32\drivers\etc\HOSTS", 
    FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
{
    byte[] buf = new byte[fs.Length];
    fs.Read(buf, 0, buf.Length);

    string txt = Encoding.UTF8.GetString(buf);
    Console.WriteLine(txt);
}