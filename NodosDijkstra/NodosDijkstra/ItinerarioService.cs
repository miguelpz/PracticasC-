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
        public List<int> caminoRecorrido;
        private int trango = 0;
        public int nodoInicial;
        

        public Dijkstra(int paramRango, int[,] paramArreglo, int nodoInicial)
        {
            
            L = new int[paramRango, paramRango];
            C = new int[paramRango];
            D = new int[paramRango];
            caminoRecorrido = new List<int>();
            rango = paramRango;

            this.nodoInicial = nodoInicial;

            caminoRecorrido.Add(nodoInicial);


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

            //// Descartar los nodos anteriores al inicial para iniciar desde alli las averiguaciones.
            //for (int x = 0; x < NodoInicial+1; x++)
            //{
            //    C[x] = -1;
            //}

            C[nodoInicial] = -1;

            // La situacion actual de distancias en el vector de distancias, correspondientes al nodo inicial. 
            for (int i = 0; i < rango; i++)
            {
                D[i] = L[nodoInicial, i];

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
            caminoRecorrido.Add(minNodo); // Registro del numero de nodo que asume la menor distancia  y es a partir del cual examinos los caminos a los que accede.

            for (int i = 0; i < rango; i++)
            {
                if (L[minNodo, i] < 0) // Tomando nodo minimo averiguado a ver a que nodos conduce en matriz adyacencia.
                    continue;

                if (D[i] < 0)  // si no hay peso asignado
                {
                    D[i] = minValor + L[minNodo, i];  // como evalumos a parrtir del minimo nodo hay que sumar lo que ha cosado llegar con este.

                    continue;
                }

                if ((D[minNodo] + L[minNodo, i]) < D[i])
                { // Solo actualizar distancia siempre que la averguada(minima + el peso que hay) sea inferior ala que hay.
                    D[i] = minValor + L[minNodo, i];
                    

                }
            }
        }
              
        public string ObtenerRuta (int nodoFinal)
        {
           
            CorrerDijkstra();

            string caminoResult = "";

            foreach (int i in caminoRecorrido)
            {
                caminoResult += i.ToString();
                if (i == nodoFinal) break;              
            }

            int distancia = D[nodoFinal];

            return JsonConvert.SerializeObject(new { Camino = caminoResult, Distancia = distancia });



            
           


            




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






