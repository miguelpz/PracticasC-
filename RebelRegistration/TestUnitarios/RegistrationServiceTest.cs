using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rebel.WS.Data.Repositorios;
using Rebel.WS.Domain;
using System;
using System.Collections.Generic;

namespace TestUnitarios
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class RegistrationServiceTest
    {
        private MockRebelRepository repository;
        private RegistrationService registrationService;

        public RegistrationServiceTest()
        {
            repository = new MockRebelRepository();
            registrationService= new RegistrationService(repository);
        }     

        [TestMethod]
        public void RegistroNumeroParametrosCorrectos()
        {
            List<string> lista = new List<string>
            {
                "nombre","planeta"
            };

            string result = registrationService.Register(lista);

            Assert.AreEqual("OK", result);
        }

        [TestMethod]
        public void RegistroNumeroParametrosIncorrectos()
        {
            List<string> lista = new List<string>
            {
                "nombre"
            };

            string result = registrationService.Register(lista);

            Assert.AreEqual("Insuficientes Parámetros", result);
        }

        [TestMethod]
        public void RegistroRebeldeDuplicado()
        {
            List<string> lista = new List<string>
            {
                "Lucke","tatuin"
            };
                  
            Assert.AreEqual(true, registrationService.isRegister("Lucke"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Se espera un error en la creacion (forzado)")]
        public void FalloGuardarRegistros()
        {
            List<string> lista = new List<string>
            {
                "otronombre","otroplaneta"
            };
         
            repository.ForzarFalloAlCrear();

            string result = registrationService.Register(lista);         
        }
    }
}
