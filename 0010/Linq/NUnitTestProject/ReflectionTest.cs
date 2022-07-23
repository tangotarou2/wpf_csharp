using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;

namespace NUnitTestProject
{
    class ReflectionTest
    {

        //https://qiita.com/gushwell/items/91436bd1871586f6e663
        [Test]
        public void Test1()
        {
            try {
                Console.WriteLine("Test1");

                {
                    List<string> obj = new List<string>();
                    Type type = obj.GetType();
                    Assert.That(type.IsGenericType);
                }

                {
                    List<int> list = new List<int>();
                    Type type = list.GetType();
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>)) {
                        Console.WriteLine("List<T>");
                        Assert.That(true);
                    } else {
                        Assert.That(false);
                    }


                }

            } catch (Exception) {
                Assert.Fail();
            }
        }

        public class TestReflectionHello
        {

            public int MyProperty {
                get;
                set;
            }

            public void Hello()
            {
                Console.WriteLine("hello!");
            }
            static public int Hoge(string name) {
                return 99;
            }


        }

        [Test]
        public void Test2()
        {
            try {
                Console.WriteLine("Test2");


                var obj = new TestReflectionHello();

                // method 呼び出し
                {

                    Type type = obj.GetType();
                    MethodInfo method = type.GetMethod("Hello");
                    method.Invoke(obj, null);
                }


                //静的メソッドを呼び出す (引数あり)
                {
                    Type type = obj.GetType();
                    MethodInfo method = type.GetMethod("Hoge", BindingFlags.Static | BindingFlags.Public);
                    Type rtype = method.ReturnType;
                    Console.WriteLine($"rtype.FullName {rtype.FullName}");
                }

                //メソッドの戻り値の型を得る
                {
                    Type type = obj.GetType();
                    MethodInfo method = type.GetMethod("Hoge", BindingFlags.Static | BindingFlags.Public);
                    Type rtype = method.ReturnType;
                    Console.WriteLine($"rtype.FullName {rtype.FullName}");

                }

                //　プロパティ
                {
                    int val = 15;
                    obj.MyProperty = val;
                    Type type = obj.GetType();
                    PropertyInfo prop = type.GetProperty("MyProperty");
                    int? value = prop.GetValue(obj) as int?;
                    Console.WriteLine(value);
                    Assert.That(val == value);

                }
                Console.WriteLine("exit Test2");

            } catch (Exception) {
                Assert.Fail();
            }
        }

        [Test]
        public void Test3()
        {
            try {
                int val = 100;
                Assert.That(val == 100);


            } catch (Exception) {
                Assert.Fail();
            }
        }


    }
}
