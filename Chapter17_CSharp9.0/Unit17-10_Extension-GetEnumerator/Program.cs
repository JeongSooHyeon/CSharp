using System.Collections.Generic;

public class Computer
{
    List<Device> _parts;

    public Computer()
    {
        _parts = new List<Device>()
        {
            new Device() { Name = "CPU" },
            new Device() { Name = "MotherBoard" },
        };
    }

    public Device[] GetDevices()
    {
        return _parts.ToArray();
    }

    // GetNumerator 메서드 구현
    public PartList GetEnumerator()
    {
        return new PartList(this);
    }

    public class PartList
    {
        Device[] _devices;
        public PartList(Computer computer) { _devices = computer.GetDevices(); }

        int _current = -1;

        // GetEnumerator로 반환하는 타입은 Currnet, MoveNext를 제공
        public Device Current
        {
            get { return _devices[_current]; }
        }

        public bool MoveNext()
        {
            if (_current >= _devices.Length - 1)
            {
                return false;
            }

            _current++;
            return true;
        }
    }
}
public record Device
{
    public string Name { get; init; }
}





// 보통은 GetEnumerator 메서드를 제공하는 경우는 많지 않다.
// 대부분 GetDevices 메서드 정도만 제공하는 것이 일반적

public class Notebook
{
    List<Device> _parts;

    public Notebook()
    {
        _parts = new List<Device>()
        {
            new Device() {Name="CPU"},
            new Device(){Name="MotherBoard"},
        };
    }

    public Device[] GetDevices()
    {
        return _parts.ToArray();
    }



}

class Program
{
    static void Main(string[] args)
    {
        Computer my = new Computer();

        foreach (Device device in my)
        {
            System.Console.WriteLine(device.Name);
        }


        Notebook notebook = new Notebook();

        foreach (Device device in notebook) // 확장 메서드를 받아들여 열거
        {
            System.Console.WriteLine(device.Name);
        }


    }
}

public static class NotebookExtension
{
    // 외부 개발자가 GetEnumerator 확장 메서드를 제공
    public static IEnumerator<Device> GetEnumerator(this Notebook instance)
    {
        foreach (Device device in instance.GetDevices())
        {
            yield return device;
        }
    }
}