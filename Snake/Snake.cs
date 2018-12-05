using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        private int posX;
        private int posY;

        public int GetPosX()
        {
            return posX;
        }
        public void SetPosX(int PosX)
        {
            posX = PosX;
        }
        public int GetPosY()
        {
            return posY;
        }
        public void SetPosY(int PosY)
        {
            posY = PosY;
        }

  
        public Snake()
        {
            posX = 0;
            posY = 0;
        }
        public Snake(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }
        public void UpdatePosition(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }

        public void MoveUp()
        {
            this.posY--;
        }
        public void MoveDown()
        {
            this.posY++;
        }
        public void MoveLeft()
        {
            this.posX--;
        }
        public void MoveRight()
        {
            this.posX++;
        }
     

    }
}
