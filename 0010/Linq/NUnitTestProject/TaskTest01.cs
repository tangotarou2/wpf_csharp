using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace NUnitTestProject
{
    class TaskTest01
    {
        private void HeavyMethod(int x)
        {
            Thread.Sleep(10); // てきとーに時間を潰す
            //  Console.WriteLine(x);
        }

        public async Task RunHeavyMethodAsync1()
        {
            for (var i = 0; i < 3; i++)
            {
                var x = i;
                await Task.Run(() => HeavyMethod(x)); // 「HeavyMethodを実行する」というタスクを開始し、完了するまで待機
            } // を、N回繰り返す
        } // というタスクを表す

        [Test]
        public async Task Test1()
        {
            await RunHeavyMethodAsync1();
            Assert.Pass();
        }

        [Test] public void Test2()
        {
            Func<int, int> func = (int val) => (val + 1); ;


            int a = func(10);
            Assert.Pass();
        }


    }
}
