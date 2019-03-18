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
        public Path BaseMetodoTest(int nodoInicial, int nodoFinal)
        {           
            int rango = (int)Math.Sqrt(matrizAdyacencia.Length);                             
            return new Dijkstra(rango, matrizAdyacencia, nodoInicial).ObtenerRuta(nodoFinal);          
        }

        [TestMethod]
        public void Secuencia01Test()
        {
            Path resultado = BaseMetodoTest(0, 7);
            int[] correctSecuence = { 0, 3, 2, 1, 5, 4, 7 };
            Assert.IsTrue(resultado.Camino.ToArray().SequenceEqual(correctSecuence) && resultado.Distancia == 23);
        }

        [TestMethod]
        public void Secuencia02Test()
        {
            Path resultado = BaseMetodoTest(0, 6);
            int[] correctSecuence = { 0, 3, 2, 1, 6 };
            Assert.IsTrue(resultado.Camino.ToArray().SequenceEqual(correctSecuence) && resultado.Distancia == 17);
        }

        [TestMethod]
        public void Secuencia03Test()
        {
            Path resultado = BaseMetodoTest(1, 7);
            int[] correctSecuence = { 1,5,4,7 };
            Assert.IsTrue(resultado.Camino.ToArray().SequenceEqual(correctSecuence) && resultado.Distancia == 12);
        }

        [TestMethod]
        public void Secuencia04Test()
        {
            Path resultado = BaseMetodoTest(2, 4);
            int[] correctSecuence = { 2,1,5,4 };
            Assert.IsTrue(resultado.Camino.ToArray().SequenceEqual(correctSecuence) && resultado.Distancia == 9);
        }

        [TestMethod]
        public void Secuencia05Test()
        {
            Path resultado = BaseMetodoTest(4, 7);
            int[] correctSecuence = { 4, 7 };
            Assert.IsTrue(resultado.Camino.ToArray().SequenceEqual(correctSecuence) && resultado.Distancia == 5);
        }


    }
}
