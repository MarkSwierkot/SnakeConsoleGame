using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food  
    {
         private int posX;
         private int posY;

         public Food()
        {
            this.posX = 2;
            this.posY = 2;
        }
        public Food(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }
        public int GetPosX()
        {
            return posX;
        }
        public int GetPosY()
        {
            return posY;
        }
        public void SetPosY(int PosY)
        {
            posY = PosY;
        }
        public void SetPosX(int PosX)
        {
            posX = PosX;
        }

        public void ShowSnakePosition()
        {
            Console.WriteLine("X: " + posX + " Y: " + posY);
        }
        public void UpdatePosition(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }
    }
}
