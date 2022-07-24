using NUnit.Framework;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;


//https://atmarkit.itmedia.co.jp/ait/articles/1804/25/news021.html
namespace NUnitTestProject
{
    class RefInOutTest
    {
        [SetUp]
        public void Setup()
        {
        }

        struct SampleStruct {
            public int X;
        }

        


        static void SampleMethodOut(out SampleStruct s)
        {
            //s.X = 3.0; // この行はコンパイルエラー（未割り当てのパラメーターの使用）
            s = new SampleStruct();
            s.X = 4;
        }


        static void SampleMethodNone( int[] a, int val)
        {
            a[0] = val;
            a = new int[5];  
            a[1] = val;

        }
        static void SampleMethodIn(in int[] a, int val )
        {
            a[0] = val;
            // a = new int[5];  // この行はコンパイルエラー
            a[1] = val;
        }
        static void SampleMethodRef(ref int[] a,int val )
        {
            a[0] = val;
            a = new int[5];//かける
            a[1] = val;
        }

        static void SampleMethodOut(out int[] a, int val )
        {
            // a[0] = 2; // この行はコンパイルエラー（未割り当てのパラメーターの使用）
            a = new int[5];
            a[0] = val;
        }

        static void ChangeValue1(int target, int val)
        {
            target = val;
        }
        static void ChangeValue2(ref int target, int val)
        {
            target = val;

        }



        [Test]
        public void Test1()
        {

            // ref
            {
                var data = new int[1] { 0 };
                SampleMethodRef(ref data, 3); // refがいる
                Assert.That(data[0] == 0); // これはひっかけ問題
                Assert.That(data[1] == 3);
            }


            // out
            {
                var obj = new SampleStruct();
                SampleMethodOut(out obj);
                //SampleMethodOut(ref obj);  // これはrefで コンパイルエラー
                Assert.That(obj.X == 4);

            }


            //　変数１個
            {
                int x = 9;
                ChangeValue1(x, 10);
                Assert.That(x == 9);

                ChangeValue2( ref x, 10);
                Assert.That(x == 10);

            }

            // in 配列
            {
                //　inパラメーター修飾子を使って参照型を参照渡しする場合、オブジェクトの内容は変更されることがある
                //　（次のコード）。

                int[] a = { 1, 1, 1 };

                SampleMethodNone(a,999);// 配列は反映される
                Assert.That(a[0] == 999);


                SampleMethodIn(a, 10);
                Assert.That(a[0] == 10);

                SampleMethodIn(a, 11);
                Assert.That(a[1] == 11);


                SampleMethodIn(in a, 12); // inは書いても書かなくてもよい
                Assert.That(a[1] == 12);

                SampleMethodOut(out a, 13);
                Assert.That(a[0] == 13);

            }

        }



    }
}
