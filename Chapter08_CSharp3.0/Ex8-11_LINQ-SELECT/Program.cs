using System;
using System.Linq;  // LINQ 쿼리 수행을 위해 반드시 포함해야 하는 네임스페이스
using System.Collections.Generic;

namespace Ex8_11_LINQ_SELECT
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

            // IEnumerable<Person> all = from person in people select person;   
            var all = from person in people select person;  // LINQ
            // IEnumerable<Person> all = people.Select((elem) => elem); // 확장 메서드
/*            IEnumerable<Person> SelectFunc(List<Person> people) // 일반 메서드
            {
                foreach(var item in people)
                {
                    yield return item;
                }
            }*/
            foreach(var item in all)
            {
                Console.WriteLine(item);
            }

            // select 형변환
            // nameList의 타입은 IEnumerable<string>
            var nameList = from person in people
                           select person.Name;
            // var nameList = people.Select((elem) => elem.Name);   // Select 확장 메서드로 표현
            foreach(var item in nameList)
            {
                Console.WriteLine(item);
            }

            // 익명 타입을 select에 사용
            var dateList = from person in people
                           select new { Name = person.Name, Year = DateTime.Now.AddYears(-person.Age).Year };

            foreach (var item in dateList)
            {
                Console.WriteLine(string.Format("{0} - {1}", item.Name, item.Year));
            }

            // 확장 메서드로 표현
            var dateList2 = people.Select(
                (elem) => new { Name = elem.Name, Year = DateTime.Now.AddYears(-elem.Age).Year });
        }
    }
}
