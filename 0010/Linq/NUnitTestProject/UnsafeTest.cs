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
    class UnsafeTest
    {
        [Test]
        public void Test1()
        {

            unsafe {

                int* p; //ポインタの宣言
                int n = 10;
                p = &n; //pにnのアドレスを代入している
                Console.WriteLine((int)p);

            }

            unsafe {
                int n;
                int* pn = &n;        // n のアドレスをポインター pn に代入。
                byte* p = (byte*)pn; // 違う型のポインターに無理やり代入可能。

                *p = 0x78; // n の最初の1バイト目に 0x78 を代入
                ++p;
                *p = 0x56; // n の2バイト目に 0x56 を代入
                ++p;
                *p = 0x34; // n の3バイト目に 0x34 を代入
                ++p;
                *p = 0x12; // n の4バイト目に 0x12 を代入

                var ans = 0x12345678;
                //var ans = 0x78563412;

                Assert.That(ans == n);
            }

            //{
            //    int size = 8;
            //    byte[] managedArray = new byte[size];
            //    Marshal.Copy(src, managedArray, 0, size);
            //}


        }

        [Test]
        public void Test2()
        {
            try {
                unsafe {
                    byte[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                    int size = Marshal.SizeOf(array[0]) * array.Length;
                    IntPtr intPtr = Marshal.AllocHGlobal(size);

                    Marshal.Copy(array, 0, intPtr, size);

                    Marshal.FreeHGlobal(intPtr);


                }

                unsafe {
                    byte[] array = { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };
                    int size = Marshal.SizeOf(array[0]) * array.Length;
                    IntPtr intPtr = Marshal.AllocHGlobal(size);
                    Marshal.Copy(array, 0, intPtr, size);

                    byte t_b = Marshal.ReadByte(intPtr);
                    var t_i = Marshal.ReadInt32(intPtr);
                    Assert.That(t_b == 0x41);
                    Assert.That(t_i == 0x44434241);

                    Console.WriteLine(t_b.ToString());


                    Marshal.WriteByte(intPtr, 0xFF);
                    byte t_writetest = Marshal.ReadByte(intPtr);
                    Assert.That(t_writetest == 0xFF);


                    //Marshal.WriteInt16(intPtr, 0x0123);
                    //Marshal.WriteInt32(intPtr, 0x0123_4567);
                    //Marshal.WriteInt64(intPtr, 0x0123_4567_89ab_cdef);
                    //}
                    Marshal.FreeHGlobal(intPtr);
                }


                    //Assert.That(false);

                } catch (Exception ) {
                Assert.Fail();

            }
        }

        [Test]
        public void Test3()
        {
            try {


                unsafe {
                    const int N = 10;
                    const int MAX = 99;
                    int* x = stackalloc int[N]; // 配列をスタック上に確保
                    Random rand = new Random();

                    // 配列 x に乱数を代入
                    for (int i = 0; i<N; ++i) {
                        x[i] = rand.Next(MAX);
                        Console.Write("{0}, ", x[i]);
                    }
                    Console.Write('\n');

                    // 配列 x を整列
                    for (int i = 0; i<N; ++i)
                        for (int j = i+1; j<N; ++j)
                            if (x[i] > x[j]) {
                                int tmp = x[i];
                                x[i] = x[j];
                                x[j] = tmp;
                            }

                    // 整列結果を出力
                    for (int i = 0; i<N; ++i) {
                        Console.Write("{0}, ", x[i]);
                    }
                    Console.Write('\n');
                }

            } catch (Exception ) {
                Assert.Fail();

            }
        }


        // https://ufcpp.net/study/csharp/sp_unsafe.html
        [Test]
        public void Test4()
        {
            try {
                unsafe {
                    Console.Write("Test4\n");
                    int n;
                    int* pn = &n;        // n のアドレスをポインター pn に代入。
                    byte* p = (byte*)pn; // 違う型のポインターに無理やり代入可能。

                    *p = 0x78; // n の最初の1バイト目に 0x78 を代入
                    ++p;
                    *p = 0x56; // n の2バイト目に 0x56 を代入
                    ++p;
                    *p = 0x34; // n の3バイト目に 0x34 を代入
                    ++p;
                    *p = 0x12; // n の4バイト目に 0x12 を代入

                    var ans = 0x12345678;

                    Assert.That(ans == n);
                }

                { // C# 7.3から
                    Span<int> x1 = stackalloc int[3] { 0xEF, 0xBB, 0xBF };
                    Span<int> x3 = stackalloc[] { 0xEF, 0xBB, 0xBF };

                    // C# 8.0から
                    for (int i = 0; i < 2; i++) {
                        // 別関数を挟めば大丈夫(ローカル関数でも可)
                        loopBody();

                        void loopBody()
                        {
                            Span<byte> _ = stackalloc byte[10];
                        }
                    }
                }

            } catch (Exception) {
             //   Assert.Fail();
            }
        }
    }
}
