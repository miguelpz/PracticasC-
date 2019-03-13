using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodosDijkstra
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] matrizAdyacencia = { { -1, 16, 10, 5, -1, -1, -1, -1 }, { 16, -1, 2, -1, -1, 4, 6, -1 },
                                        { 10, 2, -1, 4, 10, 12, -1, -1 }, { 5, -1, 4, -1, 15, -1, -1,- 1},
                                        { -1, -1, 10, 15, -1, 3, -1, 5 }, { -1, 4, 12, -1, 3, -1, 8, 16 },
                                        { -1, 6 , -1, -1, -1, 8, -1, 7 }, { -1, -1, -1, -1, 5, 16, 7, -1} };

            //RutaService rs = new RutaService();


            //string resultado = rs.ObtenerRutaMasCorta(matrizAdyacencia, 3, 7);

            Path pathInicial = new Path();
            pathInicial.Camino.Add(0);

            Nodos nodicos = new Nodos(matrizAdyacencia);



            Path resultado = nodicos.IniciarAlgoritmo(7, pathInicial);


        }
    }
}
