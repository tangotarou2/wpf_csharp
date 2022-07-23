using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Linq
{
    public class TestBass
    {
        public void DebugLog(string sz)
        {
            Console.WriteLine(sz);
        }
        public void Debug_Log(string sz){
            DebugLog(sz);
        }
    }

    public class Linq01 : TestBass
    {
        

        public void  test01(){

            {
                List<int> list = new List<int> { 1, 5, -2, 3, -9, 6 };
                var szOut = "";

                IEnumerable<int> result = list
                .Select(val => val + 1)
                .Where(index => index % 2 == 0);

                foreach (int item in result)
                {
                    szOut += item.ToString() + ",";
                }
                Debug_Log(szOut);

            }
        }
        public class PersonTestClass
        {
            public string Name { get; private set; }
            public int Age { get; private set; }
            public bool IsMan { get; private set; }

            public PersonTestClass(string _name, int _age, bool _isMan)
            {
                Name = _name;
                Age = _age;
                IsMan = _isMan;
            }
        }


        /*
         * OrderByDescending
         ThenByDescending
         */
        public void test3()
        {


            List<PersonTestClass> personList = new List<PersonTestClass>();
            personList.Add(new PersonTestClass("bee", 18, true));    //
            personList.Add(new PersonTestClass("dante", 30, true));  //
            personList.Add(new PersonTestClass("alisa", 45, false));
            personList.Add(new PersonTestClass("yosiko", 20, false));
            personList.Add(new PersonTestClass("nobu", 22, true));   //
            personList.Add(new PersonTestClass("hana", 30, false));
            personList.Add(new PersonTestClass("kuro", 30, true));   //

            IEnumerable<PersonTestClass> orderDataPersonList = personList.OrderByDescending(dt => dt.Age)
                          .ThenBy(dt => dt.IsMan)
                          .ThenByDescending(dt => dt.Name);

            var szMsg = "";
            foreach (PersonTestClass obj in orderDataPersonList)
            {
                szMsg += obj.Name + obj.Age + " " + obj.IsMan.ToString() + "\n";
            }
            Debug_Log(szMsg);


        }


        public void test_FizzBuzz()
        {
            var list = new List<int>();
            list = Enumerable.Range(1, 20).ToList();

            var fizzBuff = list.Select(i => {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    return "FizzBuzz";
                }
                if (i % 3 == 0)
                {
                    return "Fizz";
                }
                if (i % 5 == 0)
                {
                    return "Buzz";
                }
                return i.ToString();
            });

            var szMsg = "";
            foreach (var obj in fizzBuff)
            {
                szMsg += obj + ",";
            }
            Debug_Log(szMsg);

        }


        public void main()
        {
            test3();
            Console.ReadKey();

        }
    }//class
}// ns
