﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        public static int GAME_SIZE = 17;
        public static int TIMER = 750;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int[,] Array = new int[GAME_SIZE, GAME_SIZE];

            List<Snake> Predator = new List<Snake>();

            Snake head = new Snake((GAME_SIZE-1)/2, (GAME_SIZE - 1) / 2);
            Food apple = new Food();
            Random ranodmiser = new Random();


            Predator.Add(head);
  
            Array[Predator[0].posX, Predator[0].posY] = 1;
    
       
            string direction = "LEFT";
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            string buttonpressed = "no";

            bool eaten = true;

     
            while (true)
            {

                time1 = DateTime.Now;
                buttonpressed = "no";

                if(eaten)
                {
                    int x = ranodmiser.Next(0, GAME_SIZE);
                    int y = ranodmiser.Next(0, GAME_SIZE);

                    apple.UpdateSnakePosition(x, y);
                    eaten = false;
                }

                while (true)
                {
                    time2 = DateTime.Now;
                    if (time2.Subtract(time1).TotalMilliseconds > 190) { break; }
                    if(Console.KeyAvailable)
                    {
                        ConsoleKeyInfo input = Console.ReadKey(true);

                        if(input.Key.Equals(ConsoleKey.UpArrow) && direction != "DOWN" && buttonpressed == "no")
                        {
                            direction = "UP";
                            buttonpressed = "yes";
                        }
                        if (input.Key.Equals(ConsoleKey.DownArrow) && direction != "UP" && buttonpressed == "no")
                        {
                            direction = "DOWN";
                            buttonpressed = "yes";
                        }
                        if (input.Key.Equals(ConsoleKey.LeftArrow) && direction != "RIGHT" && buttonpressed == "no")
                        {
                            direction = "LEFT";
                            buttonpressed = "yes";
                        }
                         if (input.Key.Equals(ConsoleKey.RightArrow) && direction != "LEFT" && buttonpressed == "no")
                        {
                            direction = "RIGHT";
                            buttonpressed = "yes";
                        }

                    }

                }

                int targetY, targetX;


                switch (direction)
                {
                  
                    case "LEFT":
                        {

                            zeroArray(Array);

                            Array[apple.posX, apple.posY] = 1;

                            if (Predator.Count == 1)
                            {
                                Predator[0].moveLeft();
                                Array[Predator[0].returnSnakeX(), Predator[0].returnSnakeY()] = 1;
                            }
                            else
                            {
                                Predator.RemoveAt(Predator.Count - 1);
                                Array[Predator[Predator.Count - 1].posX, Predator[Predator.Count - 1].posY] = 0;

                                targetX = Predator.First().posX;
                                targetY = Predator.First().posY;


                                Snake snake = new Snake(targetX - 1, targetY);
                                Predator.Insert(0, snake);


                                foreach (Snake part in Predator)
                                {
                                    Array[part.posX, part.posY] = 1;
                                }

                            }


                           
                            break;
                        }
                     case "UP":
                        {
                            zeroArray(Array);
                            Array[apple.posX, apple.posY] = 1;
                            if (Predator.Count == 1)
                            {
                                Predator[0].moveUp();
                                Array[Predator[0].returnSnakeX(), Predator[0].returnSnakeY()] = 1;
                            }
                            else
                            {

                                Predator.RemoveAt(Predator.Count - 1);
                                Array[Predator[Predator.Count - 1].posX, Predator[Predator.Count - 1].posY] = 0;

                                targetX = Predator.First().posX;
                                targetY = Predator.First().posY;


                                Snake snake = new Snake(targetX, targetY - 1);
                                Predator.Insert(0, snake);


                                foreach (Snake part in Predator)
                                {
                                    Array[part.posX, part.posY] = 1;
                                }
                            }
                            break;
                        }
                    case "RIGHT":
                        {
                            zeroArray(Array); Array[apple.posX, apple.posY] = 1;
                            if (Predator.Count == 1)
                            {
                                Predator[0].moveRight();
                                Array[Predator[0].returnSnakeX(), Predator[0].returnSnakeY()] = 1;
                            }
                            else
                            {
                                Predator.RemoveAt(Predator.Count - 1);
                                Array[Predator[Predator.Count - 1].posX, Predator[Predator.Count - 1].posY] = 0;

                                targetX = Predator.First().posX;
                                targetY = Predator.First().posY;


                                Snake snake = new Snake(targetX + 1, targetY);
                                Predator.Insert(0, snake);


                                foreach (Snake part in Predator)
                                {
                                    Array[part.posX, part.posY] = 1;
                                }
                            }
                        
                            break;
                        }
                    case "DOWN":
                        {
                            zeroArray(Array); Array[apple.posX, apple.posY] = 1;
                            if (Predator.Count == 1)
                            {
                                Predator[0].moveDown();
                                Array[Predator[0].returnSnakeX(), Predator[0].returnSnakeY()] = 1;
                            }
                            else
                            {
                                Predator.RemoveAt(Predator.Count - 1);
                                Array[Predator[Predator.Count - 1].posX, Predator[Predator.Count - 1].posY] = 0;

                                targetX = Predator.First().posX;
                                targetY = Predator.First().posY;


                                Snake snake = new Snake(targetX, targetY + 1);
                                Predator.Insert(0, snake);


                                foreach (Snake part in Predator)
                                {
                                    Array[part.posX, part.posY] = 1;
                                }
                            }
                            break;

                        }
             
                   
                   
                }


               
                updateArray(Array);


                // Condition below, determines if Snake's head, has met with apple
                // Then it creates new object - eaten apple, which then is populated with posX and posY, and inserted to the beggining of the Predator list

                if (apple.posX == Predator.First().posX && apple.posY == Predator.First().posY) 
                {
                    Snake eatenApple = new Snake();

                    eatenApple.setX(apple.posX);
                    eatenApple.setY(apple.posY);

                    Predator.Insert(0, eatenApple);
                    Array[apple.posX, apple.posY] = 0;
                    eaten = true;
                }
              
                
                Thread.Sleep(TIMER);   
            }

            Console.ReadKey();
        }
        public static void updateArray(int[,] array)
        {
            for (int i = 0; i < GAME_SIZE ; i++)
            {
                for (int j = 0; j < GAME_SIZE; j++)
                {
                    
                    if(array[j,i] == 0)
                    {
                        Console.Write("   ");
                    }
              
                    else
                    {
                        Console.Write(" o ");
                    }
                 
                }
                Console.WriteLine();
                Console.WriteLine();
            }

        }



        // This method draws ins


        public static void zeroArray(int[,] array)
        {
            for (int i = 0; i < GAME_SIZE; i++)
            {
                for (int j = 0; j < GAME_SIZE; j++)
                {
                    array[j, i] = 0;
                }
             
            }

        }



        public static void InsertInArray(int[,] array, int posX, int posY)
        {

        }

    }
}