using System;
using Aquiles_Interview.DTO;

namespace Aquiles_Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] MatrizConstruccion = { { 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 0, 1, 0, 1, 0, 0, 1 }, { 0, 0, 1, 0, 0, 0, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 0 }, { 1, 0, 0, 1, 0, 0, 1, 1 }, { 1, 1, 1, 1, 0, 0, 0, 1 }, { 0, 1, 0, 1, 0, 1, 1, 1 }, { 1, 1, 0, 1, 1, 1, 0, 1 } };
            Jugar ejemplo = new Jugar(8,MatrizConstruccion);

            ejemplo.ResolverTablero();
            ejemplo.MostrarMatriz();
        }


    }
}
