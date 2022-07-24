using NUnit.Framework;　
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;


//参考：https://qiita.com/kerochan/items/13bbbbb14c3a309c7ec4

namespace NUnitTestProject
{

    //セル。要素と次のセルを格納するフィールドを持つ。
    public class Cell
    {
        public Object Item { set; get; }
        public Cell Next { set; get; }

        //新たにセルが作られたとき、各フィールドに値を代入する。
        public Cell(Object item)
        {
            Item = item;
        }
    }
    class Array : IEnumerable
    {
        //先頭のセルを格納するフィールド。
        public Cell Head;

        //空のセル(フィールドがnullなセル。要素の格納はできない)を作成する
        public Array() { Head = new Cell(null); }

        public IEnumerator GetEnumerator() { return new ArrayEnumerator(this); }//

        //反復子のクラス
        class ArrayEnumerator : IEnumerator
        {
            Cell CurrentCell;
            Array Array;

            public ArrayEnumerator(Array array)
            {
                this.Array = array;
                //初めにどのセルを指し示すのかを決める。          
                CurrentCell = null;
            }
            //現在指し示されているセルの要素を返す
            public Object Current { get { return CurrentCell.Item; } }

            //返り値のbool値は、ちゃんと動かせたかどうかという情報。
            //true(矢印を動かせた)、false(もうこれ以上矢印を動かせない)
            public bool MoveNext()
            {
                //現在指し示しているセルの次のセル(Next)があるかどうかを調べる。、
                if (CurrentCell == null)
                    //矢印の位置を初期位置(Head)に戻す。
                    CurrentCell = Array.Head;
                else
                    //矢印を動かす。
                    CurrentCell = CurrentCell.Next;

                //条件文が同じなので統合したくなるが、それはできない。
                if (CurrentCell == null)
                    return false;
                return true;

            }
            //先頭位置を元に戻す
            public void Reset() { CurrentCell = null; }
        }



        /// <summary>
        /// セルを新規に追加するメソッド。
        /// </summary>
        public void Add(Object item)
        {
            //現在のヘッドを一時的に保存
            var temphead = Head;
            //先頭のセルを、追加したセルに切り替える。
            Head = new Cell(item);
            //先頭のセルのもつ、次のセルを格納するフィールドに追加するセルを代入。
            Head.Next = temphead;
        }
    }


    class ArrayEnumerator : IEnumerator
    {
        Cell CurrentCell;
        Array Array;

        public ArrayEnumerator(Array array)
        {
            this.Array = array;
            CurrentCell = null;
        }

        //矢印が指し示すセルの要素を返す
        public Object Current { get { return CurrentCell.Item; } }

        //返り値は、ちゃんと動かせたかどうか。
        //true(矢印を動かせた)、false(もうこれ以上矢印を動かせない)
        public bool MoveNext()
        {
            //現在指し示しているセルの次のセル(Next)があるかどうかを調べる。、
            if (CurrentCell == null)
                //矢印の位置を初期位置(Head)に戻す。
                CurrentCell = Array.Head;
            else
                //矢印を動かす。
                CurrentCell = CurrentCell.Next;

            //条件文が同じなので統合したくなるが、それはできない。
            if (CurrentCell == null)
                return false;
            return true;
        }

        //先頭位置を元に戻す
        public void Reset() { CurrentCell = null; }

    }


    class IEnumerableTest
    {

    //自分で　IEnumerable/Enumratorを実装するテスト
        [Test]
        public void Test3()
        {
            try {
                Console.WriteLine("Test3");

                var myarray = new Array();
                myarray.Add("hoge");
                myarray.Add("moge");

                foreach ( Object obj in myarray) {
                    Console.WriteLine(obj as string);

                }
                int val = 100;
                Assert.That(val == 100);

            } catch (Exception) {
                Console.WriteLine("Exception");

                Assert.Fail();
            }
        }

    }
}
