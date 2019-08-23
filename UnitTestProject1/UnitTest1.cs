using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Reflection;

namespace UnitTestProject1
{
    [Obfuscation]
    public interface ITest1
    {
        string Value { get; set; }
    }

    public interface ITest2
    {
        string Value { get; set; }
    }

    [Obfuscation]
    public interface ITest3
    {
        string Value { get; set; }
    }

    internal class Test3 : ITest3
    {
        public string Value { get; set; }
    }

    [Obfuscation]
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestObfuscation()
        {
            var obfuscationAttribute = typeof(UnitTest1).GetCustomAttribute<ObfuscationAttribute>();
#if OBFUSCAR
            Assert.IsNull(obfuscationAttribute);
#else
            Assert.IsNotNull(obfuscationAttribute);
#endif
        }

        [TestMethod]
        public void TestMethod1()
        {
            var test = Mock.Of<ITest1>();
            test.Value = "314";
            Assert.AreEqual("314", test.Value);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var test = Mock.Of<ITest2>();
            test.Value = "314";
            Assert.AreEqual("314", test.Value);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var test = Mock.Of<ITest3>();
            test.Value = "314";
            Assert.AreEqual("314", test.Value);
        }
    }
}