using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitTestProject
{
    /*
     https://qiita.com/OXamarin/items/eddc9f7f01b691631887
     */
    public class ActionTest : TestBass
    {
        [SetUp]
        public void Setup()
        {

        }

        private int MyAdd(int x){
            return x+1;
        }

        public delegate void Action<in T>(T obj);



        [Test]
        public void test3()
        {
            int value = 99;
            Action<int> del_func = delegate (int a) {
                Console.WriteLine("anonymous method is executed. a+1={0}.\n", a + 1);
            };
            del_func(value);
        }


        private void Print(string message1, string message2, string message3)
        {
            return ;
        }

        [Test]
        public void Test1()
        {
            try {
                // Lambda式は、ActionかFuncクラスのインスタンスを生成 

                //Actionクラスは戻り値のない関数 ->Func<void>もできない
                Action< string, string, string> action = Print;

                //　これはできない。
                // Action<int, int> action_add = MyAdd;

            } catch (Exception e) {
                DebugLog(e.ToString());
            }
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            try {

     
            } catch (Exception e) {
                DebugLog(e.ToString());
            }
            Assert.Pass();
        }

    }
}
