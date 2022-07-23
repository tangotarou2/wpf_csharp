using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace NUnitTestProject
{
    class Hairetsu
    {

        [Test]
        public void Test1()
        {
            try {
                int val = 100;
                Assert.That(val == 100);

                // 普通の配列
                // 変数 = new 型名[配列の長さ]
                var array = new int[3];

                // 配列の要素ごとに値を代入
                array[0] = 5;
                array[1] = 10;

                // 初期データを指定 
                var array2 = new int[] { 0, 5, 10 };
                string[] cats = {"黒猫", "三毛猫", "ぶち", "はちわれ"};

                // ジャグ配列での初期化
                int[][] jagged = new int[][]
                {
                    new[] {1, 2, 3},
                    new[] {4, 5, 6, 7}
                };

                // 四角配列での初期化
                int[,] grid = new int[,]
                {
                    {1, 1, 1},
                    {2, 2, 2},
                    {3, 3, 3}
                };


                Assert.That(jagged[0][0] ==1);


            } catch (Exception) {
                Assert.Fail();
            }
        }
    }
}
