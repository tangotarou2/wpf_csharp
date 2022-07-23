using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace NUnitTestProject
{

    class LamdaTest : TestBass
    {
        [SetUp]
        public void Setup()
        {
        }

        private async Task WaitForAsync(float seconds, Action action)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            action();
        }


        //https://qiita.com/toRisouP/items/98cc4966d392b7f21c30
        private void Do()
        {
            Console.WriteLine("Do!");
        }
        private void Print(string message1, string message2, string message3)
        {
            Console.WriteLine(message1);
            Console.WriteLine(message2);
            Console.WriteLine(message3);
        }

        private int CreateRandomNumber(int max)
        {
            var random = new Random();
            return random.Next(0, max);
        }

        private double CreateRandomNumber(int min, int max)
        {
            var random = new Random();
            var v = random.NextDouble(); // 0.0 - 1.0
            return (max - min) * v + min;
        }

        private int Add(int x, int y)
        {
            return x + y;
        }

        [Test]
        public void Test1()
        {
            {
                // Action型のデリゲートに、Do関数を登録
                Action action = Do;

                // デリゲート実行（Doが呼び出される）
                action();

                // Invoke()を呼んでもOK（Doが呼び出される）
                action.Invoke();
            }


            {
                Action<string, string, string> action = Print;
                action("Hello", "World", "!");
            }

            {
                Func<int, int> func = CreateRandomNumber;

                // CreateRandomNumber(100)が実行される
                var result = func(100);
                Assert.That( 0<= result && result  < 100);

            }

            {
                // 関数をデリゲートに登録
                Func<int, int, int> func1 = Add;

                // ラムダ式で作った関数を登録
                Func<int, int, int> func2 = (x, y) => x + y;
                // 呼び出し
                Console.WriteLine(func1(10, 20));
            }

            {
                Func<int, int, double> func = CreateRandomNumber;

                // CreateRandomNumber(0, 100)が実行される
                var result = func(0, 100);
            }


            {

                //Func<int, int, int> func2 = (x, y) => x + y;

                Func<int,int,int> func  = ( (x,y)  => (x+y) );
                var ret = func(1, 2);
                Assert.That(ret == 3);

            }
            Assert.Pass();
        }

        [Test]
        public async Task Test2()
        {
            Action action = () => { };
            await Task.Run( action ); 

            Assert.Pass();
        }


    }


}
