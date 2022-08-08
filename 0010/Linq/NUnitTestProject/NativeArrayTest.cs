using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;


/*
これはUnityの拡張だった。
                 //NativeArray<Data> array = new NativeArray<Data>(10, Allocator.Temp);

UnsafeTestを参照。
 */
namespace NUnitTestProject
{
    class NativeArrayTest : TestBass
    {
        class Data
        {
            public float value = 0;
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            try {
                unsafe //unsafeブロックの宣言
                {
                    int* p; //ポインタの宣言
                    int n = 10;
                    p = &n; //pにnのアドレスを代入している
                    Assert.That(*p == 10);
                }
            } catch (Exception e) {
                DebugLog(e.ToString());
            }
        }

        [Test]
        public void Test2()
        {
            try {
                unsafe //unsafeブロックの宣言
                {
                    int* p; //ポインタの宣言
                    int n = 10;
                    p = &n; //pにnのアドレスを代入している
                    Assert.That(*p == 10);
                }
            } catch (Exception e) {
                DebugLog(e.ToString());
            }
        }

    }
}
