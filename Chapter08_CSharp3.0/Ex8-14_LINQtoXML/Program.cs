using System;
using System.Linq;  // LINQ 쿼리 수행을 위해 반드시 포함해야 하는 네임스페이스
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;

namespace Ex8_14_LINQtoXML
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1} in {2}", Name, Age, Address);
        }
    }

    class MainLanguage
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "Tom", Age = 63, Address = "Korea" },
                new Person { Name = "Winnie", Age = 40, Address = "Tibet" },
                new Person { Name = "Anders", Age = 47, Address = "Sudan" },
                new Person { Name = "Hans", Age = 25, Address = "Tibet" },
                new Person { Name = "Eureke", Age = 32, Address = "Sudan" },
                new Person { Name = "Hawk", Age = 15, Address = "Korea" },
            };

            List<MainLanguage> languages = new List<MainLanguage>
            {
                new MainLanguage{Name="Anders", Language="Delphi"},
                new MainLanguage{Name="Anders", Language="C#"},
                new MainLanguage{Name="Tom", Language="Borland C++"},
                new MainLanguage{Name="Hans", Language="Visual C++"},
                new MainLanguage{Name="Winnie", Language="R"}
            };

            string txt = @"
                        <people>
                            <person name='anders' age='47'/>
                            <person name='winnie' age='13'/>
                        </people>";

            StringReader sr = new StringReader(txt);

            var xml = XElement.Load(sr);

            var query = from person in xml.Elements("person")
                        select person;

            foreach (var item in query)
            {
                Console.WriteLine(item.Attribute("name").Value + " : " + item.Attribute("age").Value);
            }
        }
    }
}