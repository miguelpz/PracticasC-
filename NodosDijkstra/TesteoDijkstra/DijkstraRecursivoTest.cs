using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodosDijkstra;

namespace TesteoDijkstra
{
    [TestClass]
    public class DijkstraRecursivoTest
    {

        int[,] matrizAdyacencia = { { -1, 16, 10, 5, -1, -1, -1, -1 }, { 16, -1, 2, -1, -1, 4, 6, -1 },
                                        { 10, 2, -1, 4, 10, 12, -1, -1 }, { 5, -1, 4, -1, 15, -1, -1,- 1},
                                        { -1, -1, 10, 15, -1, 3, -1, 5 }, { -1, 4, 12, -1, 3, -1, 8, 16 },
                                        { -1, 6 , -1, -1, -1, 8, -1, 7 }, { -1, -1, -1, -1, 5, 16, 7, -1} };

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Nodos nodosRecursivo = new Nodos(matrizAdyacencia);
            Path pathInicial = new Path();
            int nodoInicial;
            int nodoFinal;
            Path resultado;

            // Act
            nodoInicial = 0;
            nodoFinal = 7;
            pathInicial.Camino.Add(nodoInicial);


            // Assert
            int[] correctSecuence = { 0, 3, 2, 1, 5, 4, 7 };

            resultado = nodosRecursivo.IniciarAlgoritmo(nodoFinal, pathInicial);
            Assert.IsTrue(resultado.Camino.ToArray().SequenceEqual(correctSecuence) && resultado.Distancia==23);
        }
    }
}
