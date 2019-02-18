using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net.Http;
using Rebel.WS.API.Controllers;
using Rebel.WS.API;
using Rebel.WS.Application;
using Unity;

namespace TestUnitarios
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {

            var datos = new List<string>
            {
                "ususario","Naboo"
            };

            var datosJson = JsonConvert.SerializeObject(datos);
            var content = new StringContent(datosJson, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Content = content
            };

            var controller = new RegisterController(UnityConfig.Container.Resolve<IRebelAppServices>());
            controller.Request = request;
            string response = controller.GetRebelFromUri(datos);
            Assert.AreEqual("OK", response);

        }
    }
}
