﻿using System;
using System.Linq;  // LINQ 쿼리 수행을 위해 반드시 포함해야 하는 네임스페이스
using System.Collections.Generic;

namespace Unit8_9_1_LINQ2
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

            // where 구문, SELECT * FROM people WHERE ...
            var ageOver30 = from person in people
                            where person.Age > 30
                            select person;

            foreach (var item in ageOver30)
            {
                Console.WriteLine(item);
            }

            var endWithS = from person in people
                           where person.Name.EndsWith("s")
                           select person;

            foreach (var item in endWithS)
            {
                Console.WriteLine(item);
            }

            // SELECT * FROM people ORDER BY...
            var ageSort = from person in people
                          orderby person.Age    // 나이순으로 정렬(ascending)
                          orderby person.Age descending // 내림차순
                          select person;

            foreach (var item in ageSort)
            {
                Console.WriteLine(item);
            }

            // SELECT * FROM people GROUP BY ...
            var addrGruop = from person in people
                            group person by person.Address;

            foreach (var itemGroup in addrGruop)
            {
                Console.WriteLine(string.Format("[{0}]", itemGroup.Key));
                foreach (var item in itemGroup)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }

            // 형변환
            var nameAgeList = from person in people
                              group new { Name = person.Name, Age = person.Age } by person.Address;

            foreach (var itemGroup in nameAgeList)
            {
                Console.WriteLine(string.Format("[{0}]", itemGroup.Key));
                foreach (var item in itemGroup)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }


            // join
            var nameToLangList = from person in people
                                 join language in languages on person.Name equals language.Name
                                 select new { Name = person.Name, Age = person.Age, Language = language.Language };
            foreach(var item in nameToLangList)
            {
                Console.WriteLine(item);
            }

            // Outer Join 후처리
            var nameToLangAllList = from person in people
                                 join language in languages on person.Name equals language.Name into lang
                                 from language in lang.DefaultIfEmpty(new MainLanguage())
                                 select new { Name = person.Name, Age = person.Age, Language = language.Language };

            foreach (var item in nameToLangAllList)
            {
                Console.WriteLine(item);
            }

        }
    }
}