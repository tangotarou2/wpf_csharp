using NUnit.Framework;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject
{
    class FIleIOTest
    {
        [SetUp]
        public void Setup()
        {
        }


        //https://ufcpp.net/study/csharp/lib_file.html#stream
        [Test]
        public void Test1()
        {
            try{
                Console.WriteLine("StreamWriter enter");

                string write_data = "ABCDEF";
                string read_data = "";
                string golden_answer = write_data;

                // ファイルにテキストを書き出し。
                using (StreamWriter w = new StreamWriter(@"test.txt")) {
                    
                    Console.WriteLine("StreamWriter 2");

                    w.WriteLine(write_data);
                    //w.WriteLine("WriteLine では末尾に改行文字が加えられます。");
                    //int n = 5;
                    //double x = 3.14;
                    //w.Write("書式指定出力もできます → n = {0}, x = {1}", n, x);


                }
                Console.WriteLine("StreamWriter 3");

                // ファイルからテキストを読み出し。
                using (StreamReader r = new StreamReader(@"test.txt")) {
                    string line;
                    while ((line = r.ReadLine()) != null) // 1行ずつ読み出し。
                    {
                        read_data = line;
                        Console.WriteLine(line);
                        break;
                    }
                    Console.WriteLine("StreamWriter 4");

                }
                Console.WriteLine("StreamWriter 5");

                Assert.That(golden_answer == read_data);

            } catch (Exception){
                Assert.Fail();
            }

        }



        [Test]
        public void Testn()
        {
            Assert.Pass();
        }



    }
}
