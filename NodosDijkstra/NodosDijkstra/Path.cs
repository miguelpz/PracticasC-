using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodosDijkstra
{
    public class Path
    {
        public Path(int nodoOrigen)
        {
            Camino = new List<int>();
            Distancia = 0;
            Camino.Add(nodoOrigen);

        }
        public Path()
        {

            Camino = new List<int>();
            Distancia = 0;
        }




        public List<int> Camino { get; set; }
        public int Distancia { get; set; }

        public Path Copy(Path path, int nodoVisitado, int distanciaRecorrida)
        {
            Path nuevoPath = new Path();

            path.Camino.ForEach(o => nuevoPath.Camino.Add(o));
            nuevoPath.Camino.Add(nodoVisitado);


            Distancia = path.Distancia;

            nuevoPath.Distancia += distanciaRecorrida;


            return nuevoPath;
        }
        public Path Copy()
        {
            Path nuevoPath = new Path();

            this.Camino.ForEach(o => nuevoPath.Camino.Add(o));
            nuevoPath.Distancia = this.Distancia;


            return nuevoPath;
        }


    }
}
