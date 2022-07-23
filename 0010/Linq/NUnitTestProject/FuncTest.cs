using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace NUnitTestProject
{

    class FuncTest : TestBass
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
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
