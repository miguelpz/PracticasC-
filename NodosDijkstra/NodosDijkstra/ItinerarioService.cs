using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NodosDijkstra
{
    public class Dijkstra
    {
        private int rango = 0;
        private int[,] L;   //matriz de adyacencia
        public int[] C;    //arreglo de nodos
        public int[] D;    //arreglo de distancias
        public int[] DP;   //arreglo complementario a distancias para almacenar provinencias       
        private int trango = 0;
        public int nodoInicial;
                
        public Dijkstra(int paramRango, int[,] paramArreglo, int nodoInicial)
        {
            L = new int[paramRango, paramRango];
            C = new int[paramRango];
            D = new int[paramRango];
            DP = new int[paramRango];
            
            rango = paramRango;

            this.nodoInicial = nodoInicial;
                              
            // Copiar la matriz de adyacencias que viene por parámetro.
            for (int i = 0; i < rango; i++)
            {
                for (int j = 0; j < rango; j++)
                {
                    L[i, j] = paramArreglo[i, j];
                }
            }

            // Inicializar vector de nodos con 0 a n-1.
            for (int i = 0; i < rango; i++)
            {
                C[i] = i;
                
            }
          
            C[nodoInicial] = -1;

            // La situacion actual de distancias en el vector de distancias, correspondientes al nodo inicial. 
            for (int i = 0; i < rango; i++)
            {
                D[i] = L[nodoInicial, i];
                DP[i] = nodoInicial;
            }

            D[nodoInicial] = 0;
        }

        
        //Rutina de solución 
        public void SolDijkstra()
        {
            int minValor = Int32.MaxValue;
            int minNodo = 0;

            // En vector de distancias averiguar cual es la minima y a que nodo corresponde. 
            // descaranto nodos ya visitados.
            for (int i = 0; i < rango; i++)
            {
                if (C[i] == -1)
                    continue;

                if (D[i] > 0 && D[i] < minValor)
                {
                    minValor = D[i];
                    minNodo = i;                    
                }
            }

            C[minNodo] = -1;
            // REGISTRAMOS DISTANCIAS EN EL VECTOR DE DISTANCIAS
            
            for (int i = 0; i < rango; i++)
            {
                if (L[minNodo, i] < 0) // Tomando nodo minimo averiguado a ver a que nodos conduce en matriz adyacencia.
                    continue;

                if (D[i] < 0)  // si no hay peso asignado
                {
                    D[i] = minValor + L[minNodo, i];  // como evalumos a parrtir del minimo nodo hay que sumar lo que ha cosado llegar con este.
                    DP[i] = minNodo;
                    continue;
                }

                if ((D[minNodo] + L[minNodo, i]) < D[i])
                { // Solo actualizar distancia siempre que la averguada(minima + el peso que hay) sea inferior ala que hay.
                    D[i] = minValor + L[minNodo, i];
                    DP[i]= minNodo;
                    
                    
                }
            }
        }

        // Usaremos el registro paralelo a D DP. En D se guardaban las distancias mas cortas y en DP de donde provenian.
        // Para obtener ruta se va hacia atrás tilizando el registro DP.
        public Path ObtenerRuta (int nodoFinal)
        {
           
            CorrerDijkstra();

            Path resultado = new Path();
            
            int siguiente = nodoFinal;

            resultado.Camino.Add(nodoFinal);

            do
            {
                siguiente = DP[siguiente];
                resultado.Camino.Add(siguiente);

            } while (siguiente !=nodoInicial);

            resultado.Distancia = D[nodoFinal];

            resultado.Camino.Reverse();

            return resultado;
        }
        
        //Funcion de implementacion del algoritmo
        public void CorrerDijkstra()
        {
            for (trango = nodoInicial; trango < rango-1; trango++)
            {
                SolDijkstra();
              
            }       
        }        
    }
}






