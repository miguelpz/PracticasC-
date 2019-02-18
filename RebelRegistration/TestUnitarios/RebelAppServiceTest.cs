using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rebel.WS.Data.Repositorios;
using Rebel.WS.Domain;
using Rebel.WS.Application;

namespace TestUnitarios
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class RebelAppServiceTest
    {

        private MockRebelRepository repository;
        private RegistrationService registrationService;
        private RebelAppServices rebelAppServices;

        public RebelAppServiceTest()
        {
            repository = new MockRebelRepository();
            registrationService = new RegistrationService(repository);
            rebelAppServices = new RebelAppServices(registrationService);
        }

        [TestMethod]
        public void RegistroNumeroParametrosCorrectos()
        {
            List<string> lista = new List<string>
            {
                "nombre","planeta"
            };

            string result = rebelAppServices.RebelRegister(lista);

            Assert.AreEqual("OK", result);
        }

        [TestMethod]
        public void RegistroNumeroParametrosIncorrectos()
        {
            List<string> lista = new List<string>
            {
                "nombre"
            };

            string result = rebelAppServices.RebelRegister(lista);

            Assert.AreEqual("Insuficientes Parámetros", result);
        }

        [TestMethod]
        public void RegistroRebeldeDuplicado()
        {
            List<string> lista = new List<string>
            {
                "Lucke","tatuin"
            };

            string result = rebelAppServices.RebelRegister(lista);

            Assert.AreEqual("Este rebelde ya está registrado", result);
        }
    }
}
