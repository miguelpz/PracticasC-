using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodosDijkstra
{
    public class Nodos
    {
        private List<Path> listaPath;
        private int[,] matriz;
        private int rangoMatriz;

        public Nodos(int[,] matriz)
        {
            listaPath = new List<Path>();
            rangoMatriz = (int)Math.Sqrt(matriz.Length);
            this.matriz = matriz;
        }



        public Path IniciarAlgoritmo(int nodoFinal, Path path)
        {

            int x = path.Camino.Last();

            for (int y = 0; y < rangoMatriz; y++)
            {
                if (x == 0 && y == 3)
                {

                }



                if (matriz[x, y] == -1 || path.Camino.Contains(y)) continue;

                if (y == nodoFinal)
                {
                    Path caminoBifurca = path.Copy();
                    listaPath.Add(caminoBifurca);

                    caminoBifurca.Camino.Add(y);
                    caminoBifurca.Distancia += matriz[x, y];
                }
                else
                {
                    Path caminoBifurca = path.Copy();
                    listaPath.Add(caminoBifurca);
                    caminoBifurca.Camino.Add(y);
                    caminoBifurca.Distancia += matriz[x, y];
                    IniciarAlgoritmo(nodoFinal, caminoBifurca);


                }


            }

            return listaPath.Where(o => o.Camino.Last() == nodoFinal && o.Distancia ==
                        listaPath.Where(o2 => o2.Camino.Last() == nodoFinal).Select(o2 => o2.Distancia).Min()).FirstOrDefault();





        }
    }
}
