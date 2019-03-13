using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodosDijkstra;

namespace TesteoDijkstra
{
    [TestClass]
    public class DijkstraTest
    {

        int[,] matrizAdyacencia = { { -1, 16, 10, 5, -1, -1, -1, -1 }, { 16, -1, 2, -1, -1, 4, 6, -1 },
                                        { 10, 2, -1, 4, 10, 12, -1, -1 }, { 5, -1, 4, -1, 15, -1, -1,- 1},
                                        { -1, -1, 10, 15, -1, 3, -1, 5 }, { -1, 4, 12, -1, 3, -1, 8, 16 },
                                        { -1, 6 , -1, -1, -1, 8, -1, 7 }, { -1, -1, -1, -1, 5, 16, 7, -1} };

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            int rango = (int)Math.Sqrt(matrizAdyacencia.Length);
            int nodoInicial = 0;
            int nodoFinal = 7;
           
            // Act
            Path resultado;
            resultado= new Dijkstra(rango, matrizAdyacencia, nodoInicial).ObtenerRuta(nodoFinal);
          
            // Assert
            int[] correctSecuence = { 0, 3, 2, 1, 5, 6, 4, 7 };          
            Assert.IsTrue(resultado.Camino.ToArray().SequenceEqual(correctSecuence) && resultado.Distancia == 23);
        }


        
    }
}
