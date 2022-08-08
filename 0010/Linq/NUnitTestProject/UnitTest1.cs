using NUnit.Framework;
using System;

namespace NUnitTestProject
{
    public class UnitTests : TestBass
    {
        [SetUp]
        public void Setup()
        {
 
        }

        [Test]
        public void Test1()
        {
            try {

            } catch (Exception e) {
                DebugLog(e.ToString());
            }
            Assert.Pass();
        }
    }
}