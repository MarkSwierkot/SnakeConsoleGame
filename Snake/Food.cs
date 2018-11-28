using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food  
    {
        public int posX;
        public int posY;

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
        public void setX(int x)
        {
            this.posX = x;
        }
        public void setY(int y)
        {
            this.posY = y;
        }
        public void ShowSnakePosition()
        {
            Console.WriteLine("X: " + posX + " Y: " + posY);
        }
        public void UpdateSnakePosition(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }
    }
}
