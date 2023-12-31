﻿using System;

unsafe struct CSharpStructType
{
    public fixed int fields[2];
    public fixed long dummy[3];
}

class Continaer
{
    CSharpStructType _inst;

    public Continaer()
    {
        _inst = new CSharpStructType(); 
    }

    public unsafe void ProcessItem()
    {
        // C# 7.2 이전 접근 방법
        fixed(int *ptr = _inst.fields)
        {
            ptr[0] = 5;
            int n = ptr[2];
        }
        // C# 7.2 이전까지는 컴파일 에러
        _inst.fields[0] = 5;
        int n = _inst.fields[2];
    }
}
class Program
{
    unsafe static void Main(string[] args)
    {
        CSharpStructType item  = new CSharpStructType();
        item.fields[0] = 5;
        int n = item.fields[2];
    }
}


