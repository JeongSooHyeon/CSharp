using System;

class Rectangle
{
    public int x { get; }
    public int y { get; }
    public int width { get; }
    public int height { get; }

    public Rectangle(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public void Deconstruct(out int x, out int y)
    {
        x = this.x;
        y = this.y;
    }

    public void Deconstruct(out int x, out int y, out int width, out int height)
    {
        x = this.x;
        y = this.y;
        width = this.width;
        height = this.height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rect = new Rectangle(5, 6, 20, 25);
        {
            (int x, int y) = rect;
            Console.WriteLine($"x == {x}, y == {y}");
        }
        {
            (int _, int _) = rect;  // 의미 없는 구문

            (int _, int y) = rect;
            Console.WriteLine($"y == {y}");
        }

        {
            (int x, int y, int width, int height) = rect;
            Console.WriteLine($"x == {x}, y == {y}, width = {width}, height = {height}");

            (int _, int _, int _, int _) = rect;    // 의미 없는 구문

            (int _, int _, int w, int h) = rect;
            Console.WriteLine($"w == {w}, h == {h}");

            (var _, var _, var _, var last) = rect;
            Console.WriteLine($"last == {last}");
        }
    }
}