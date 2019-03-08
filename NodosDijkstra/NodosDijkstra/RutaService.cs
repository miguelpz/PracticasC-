using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodosDijkstra
{
    public class RutaService
    {
        public string ObtenerRutaMasCorta (int[,] Matriz, int nodoInicial, int nodoFinal)
        {

            int rango = (int)Math.Sqrt(Matriz.Length);

            return new Dijkstra(rango, Matriz, nodoInicial).ObtenerRuta(nodoFinal);

        }


    }
}
