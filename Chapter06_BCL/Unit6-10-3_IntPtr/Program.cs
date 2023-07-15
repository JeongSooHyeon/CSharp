Console.WriteLine(IntPtr.Size);

using(FileStream fs = new FileStream("test.dat", FileMode.Create))
{
    Console.WriteLine(fs.Handle);
}