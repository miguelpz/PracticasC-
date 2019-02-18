using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rebel.WS.Data;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IRebelRepository>();

            mock.Setup(m => m.GetRegister(It.IsAny<string>())).Returns((RebelRegister value) => { return value = new RebelRegister { name = "prueba" }; });

        }
    }
}
