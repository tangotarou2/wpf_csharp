using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NUnitTestProject
{

    public class TestBass
    {
        public void Debug_Write(string sz)
        {
            Console.Write(sz);
        }
        public void DebugLog(string sz)
        {
            Console.WriteLine(sz);
        }
        public void Debug_Log(string sz)
        {
            DebugLog(sz);
        }

        public static bool ApproximatelyEqualEpsilon(float a, float b, float epsilon)
        {
            const float floatNormal = (1 << 23) * float.Epsilon;
            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            float diff = Math.Abs(a - b);

            if (a == b) {
                // Shortcut, handles infinities
                return true;
            }

            if (a == 0.0f || b == 0.0f || diff < floatNormal) {
                // a or b is zero, or both are extremely close to it.
                // relative error is less meaningful here
                return diff < (epsilon * floatNormal);
            }

            // use relative error
            return diff / Math.Min((absA + absB), float.MaxValue) < epsilon;
        }

        public static bool Approximately(float x, float y)
        {
            float gosa = 0.01f;
            if ((x-gosa) < y && y < x+gosa) {
                return true;
            }
            return false;
        }
        public static bool Approximately(double x, double y)
        {
            var gosa = 0.01;
            if ((x-gosa) < y && y < x+gosa) {
                return true;
            }
            return false;
        }
    }

    class LinqTest1 : TestBass
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
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


            string ans = "2,6,4,-8,";
            bool ret = szOut.Equals(ans);
            Assert.That(ret);
        }

        [Test] public void Test2()
        {

            List<int> list = Enumerable.Range(1, 20).ToList(); // Rangeも実は便利
            IEnumerable<string> fizzBuzz = list.Select(i =>
            {
                if (i % 3 == 0)
                {
                    if (i % 5 == 0)
                    {
                        return "FizzBuzz";
                    }
                    return "Fizz";
                }
                if (i % 5 == 0)
                {
                    return "Buzz";
                }
                return i.ToString();
            }
            );



            var szMsg = "";
            foreach (var obj in fizzBuzz)
            {
                szMsg += obj + ",";
            }
            //  DebugLog(szMsg);



            var ans = "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz,16,17,Fizz,19,Buzz,";
            //ans += "hoge";
            Assert.That(ans.Equals(szMsg));

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

        [Test] public void Test3()
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
          //  Debug_Log(szMsg);


            var ans = "alisa45 False\nhana30 False\nkuro30 True\ndante30 True\nnobu22 True\nyosiko20 False\nbee18 True\n";
            Assert.That(ans.Equals(szMsg));

        }

        [Test]
        public void Test4()
        {
            var szMsg = "";
            var ans = "";
            Assert.That(ans.Equals(szMsg));

        }

    }


}
