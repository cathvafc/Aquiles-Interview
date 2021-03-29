using System;
using System.Collections.Generic;
using System.Text;

namespace Aquiles_Interview.DTO
{
    class Celda
    {
        //Atributos
        
        bool isWhite = false;  //Indica si la celda es blanca o no, por defecto negra.
        int  distance = 0;  //Distancia mínima asginada desde la celda al origen, 0 por defecto.
        string stringDistance = "";
        int positionX = 0;
        int positionY = 0;

        //Por defecto es negro
        public Celda ()
        {
            stringDistance = "X";
        }

        //Si es blanco, se inicializa con true
        public Celda(bool isWhite)
        {
            this.isWhite = isWhite;
            distance = 0;
            stringDistance = "0";
        }

        //Getter para obtener si es White or not
        public bool GetIsWhite()
        {
            return isWhite;
        }

        //Getter para obtener la distancia mínima asignada a la celda
        public int GetDistance()
        {
            return distance;
        }

        //Getter para obtener la distancia mínima asignada a la celda en formato string
        public string GetStringDistance()
        {
            return stringDistance;
        }

        public void SetStringDistance(string value  )
        {
            stringDistance = value;
        }

        //Setter para modificar la distancia mínima asignada a la celda
        public void SetDistance(int distance)
        {
            this.distance = distance;
            this.stringDistance = distance.ToString();
        }

        //Setter para asignar la posición X a la celda
        public void SetX(int x)
        {
            positionX = x;
        }

        //Setter para asignar la posición Y a la celda
        public void SetY(int y)
        {
            positionY = y;
        }

        //Getter para obtener la posición X de la celda
        public int GetX()
        {
            return positionX;
        }

        //Getter para obtener la posición Y de la celda
        public int GetY()
        {
            return positionY;
        }

    }
}
