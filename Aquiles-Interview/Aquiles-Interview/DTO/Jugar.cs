using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquiles_Interview.DTO
{
    class Jugar
    {
        //Atributos
        Celda[,] MatrizCeldas;
        int[,] MatrizConstruccion;
        int celdasBlancas;
        int celdasCalculadas;
        int distanciaActual;
        int dimensionMatriz;

        public Jugar(int dimensionMatriz, int[,] MatrizConstruccion)
        {
            this.dimensionMatriz = dimensionMatriz;
            MatrizCeldas = new Celda[dimensionMatriz, dimensionMatriz];
            this.MatrizConstruccion = MatrizConstruccion;
            celdasBlancas = 0;
            celdasCalculadas = 0;
            distanciaActual = 1;

        }

        //Método para resolver el tablero y calcular las distáncias mínimas.
        public void ResolverTablero()
        {
            //Inicializamos el tablero a partir de la matriz de construcción con los objetos celda y obtenemos cuantas celdas blancas tenemos.
            celdasBlancas = InicializarMatrizCeldas(MatrizCeldas, MatrizConstruccion);

            //Inicializamos el asterisco 
            MatrizCeldas[7, 0].SetDistance(999); //Añadimos una distáncia a la posición de salida para que no sea calculada.
            MatrizCeldas[7, 0].SetStringDistance("*");

            CostCalculationFunction();

        }
        private void CostCalculationFunction()
        {
            int aux = 0;          
            int CeldasFaltaPorAñadir = 0;
            Queue<Celda> ColaCeldasPorRecorrer = new Queue<Celda>();
            ColaCeldasPorRecorrer.Enqueue(MatrizCeldas[7, 0]); // Añadimos a la cola 
            List<int> DistanciasCalculadas = new List<int>(); // Lista donde guardaremos las distáncias calculadas para saber si podemos avanzar a la siguiente 

            while (celdasCalculadas < celdasBlancas && ColaCeldasPorRecorrer.Count > 0)
            {
                Celda casilla = ColaCeldasPorRecorrer.Dequeue();

                int i = casilla.GetY();
                int j = casilla.GetX();

                if (dimensionMatriz > i + 1)
                {

                    if (MatrizCeldas[i + 1, j].GetIsWhite() && MatrizCeldas[i + 1, j].GetDistance() == 0)//Comprobamos la celda de abajo si es blanca y su distáncia no está calculada
                    {
                        MatrizCeldas[i + 1, j].SetDistance(distanciaActual);
                        celdasCalculadas++;

                        DistanciasCalculadas.Add(distanciaActual);
                        ColaCeldasPorRecorrer.Enqueue(MatrizCeldas[i + 1, j]);
                    }
                }
                if (j > 0)
                {
                    if (MatrizCeldas[i, j - 1].GetIsWhite() && MatrizCeldas[i, j - 1].GetDistance() == 0)//Comprobamos la celda de la izquierda si es blanca y su distáncia no está calculada
                    {
                        MatrizCeldas[i, j - 1].SetDistance(distanciaActual);
                        celdasCalculadas++;

                        DistanciasCalculadas.Add(distanciaActual);
                        ColaCeldasPorRecorrer.Enqueue(MatrizCeldas[i, j - 1]);
                    }
                }
                if (i > 0)
                {
                    if (MatrizCeldas[i - 1, j].GetIsWhite() && MatrizCeldas[i - 1, j].GetDistance() == 0)//Comprobamos la celda de Arriba si es blanca y su distáncia no está calculada
                    {
                        MatrizCeldas[i - 1, j].SetDistance(distanciaActual);
                        celdasCalculadas++;

                        DistanciasCalculadas.Add(distanciaActual);
                        ColaCeldasPorRecorrer.Enqueue(MatrizCeldas[i - 1, j]);
                    }
                }

                if (dimensionMatriz > j + 1)
                {

                    if (MatrizCeldas[i, j + 1].GetIsWhite() && MatrizCeldas[i, j + 1].GetDistance() == 0)//Comprobamos la celda de la derecha si es blanca y su distáncia no está calculada
                    {
                        MatrizCeldas[i, j + 1].SetDistance(distanciaActual);
                        celdasCalculadas++;

                        DistanciasCalculadas.Add(distanciaActual);
                        ColaCeldasPorRecorrer.Enqueue(MatrizCeldas[i, j + 1]);
                    }
                }


                //Comprobamos que hayamos recorrido todos los mínimos antes de avanzar a la siguiente distáncia
                if (CeldasFaltaPorAñadir == 0)
                {
                    aux = 0;
                    foreach (int valor in DistanciasCalculadas)
                    {
                        
                        if (valor == distanciaActual - 1)
                        {
                            aux++;

                        }
                        CeldasFaltaPorAñadir = aux;
                    }
                }


                if (CeldasFaltaPorAñadir > 1)
                {
                    CeldasFaltaPorAñadir--;
                }
                else
                {
                    distanciaActual++; 
                    CeldasFaltaPorAñadir = 0;
                }

            }

        }

            //Método para rellenar la matriz de celdas con objetos celdas a partir de una matriz de 1(blanco) y 0(negro) 
            private int InicializarMatrizCeldas(Celda[,] MatrizCeldas, int[,] MatrizConstruccion)
            {

                int result = 0;

                for (int i = 0; i < dimensionMatriz; i++)
                {
                    for (int j = 0; j < dimensionMatriz; j++)
                    {
                        if (MatrizConstruccion[i, j] == 1)
                        {//Si el valor es 1, se crea el objeto celda con la propiedad isWhite a true.
                            Celda objeto = new Celda(true);
                            objeto.SetX(j);
                            objeto.SetY(i);
                            MatrizCeldas[i, j] = objeto;
                            result++; // Celdas blancas añadidas en la matriz de las cuales habrá que calcular su distancia mínima.
                        }
                        else
                        {//Si el valor es diferente de 1, se crea el objeto celda con la propiedad isWhite a false.
                            Celda objeto = new Celda();
                            objeto.SetX(j);
                            objeto.SetY(i);
                            MatrizCeldas[i, j] = objeto;
                        }
                    }
                }

                return result;
            }

            //Método para cambiar la matriz de construcción
            public void SetMatrizConstruccion(int[,] MatrizConstruccion)
            {
                this.MatrizConstruccion = MatrizConstruccion;
            }

            //Método para mostrar la matriz resultante con las distáncias calculadas
            public void MostrarMatriz()
            {
                for (int i = 0; i < dimensionMatriz; i++)
                {
                    Console.Write("\n");
                    for (int j = 0; j < dimensionMatriz; j++)
                    {
                        Console.Write(MatrizCeldas[i, j].GetStringDistance() + " ");
                    }
                }
            }
        
    }
}
