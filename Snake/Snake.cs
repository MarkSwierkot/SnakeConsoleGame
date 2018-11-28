using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public int posX;
        public int posY;

        public Snake()
        {
            int posX = 0;
            int posY = 0;
        }
        public Snake(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }
        public int returnSnakeX()
        {
            return posX;
        }
        public int returnSnakeY()
        {
            return posY;
        }
       public void setX(int x)
        {
            this.posX = x;
        }
        public void setY(int y)
        {
            this.posY = y;
        }
        public void UpdateSnakePosition(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }

        public void moveUp()
        {
            this.posY--;
        }
        public void moveDown()
        {
            this.posY++;
        }
        public void moveLeft()
        {
            this.posX--;
        }
        public void moveRight()
        {
            this.posX++;
        }
        public void ShowSnakePosition()
        {
            Console.WriteLine("X: " + posX + " Y: " + posY);
        }

    }
}
