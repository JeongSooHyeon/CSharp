int DuckTypingCall(dynamic target, dynamic item)
{
    return target.IndexOf(item);
}

string txt = "test func";
List<int> list = new List<int> { 1, 2, 3, 4, 5 };

Console.WriteLine(DuckTypingCall(txt, "test"));
Console.WriteLine(DuckTypingCall(list, 3));