using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTesting;

namespace Testing {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            string result = Program.Algo();
            Assert.AreEqual("Algo", result);
        }

        [TestMethod]
        public void TestLogin() {
            bool result = Program.login("chicho69", "12345");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestLogin1() {
            bool result = Program.login("chicho69", "123dsda45");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestPrimo() {
            bool result = Program.EsPrimo(11);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestException() {
            Program.Exception();
        }
    }
}