using System;
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
        public static int TIMER =500;
        public static int RESULT = 1;

       

        static void Main(string[] args)
        {
            // Array defines two dimensional array, used in the program as a board for Snake
            int[,] Array = new int[GAME_SIZE, GAME_SIZE];

            // Predator, is a List of Snake type, which stores snake parts, starting from its head
            List<Snake> Predator = new List<Snake>();
           
            Snake head = new Snake((GAME_SIZE-1)/2, (GAME_SIZE - 1) / 2);
            Food apple = new Food();
            Random ranodmiser = new Random();

            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;

            bool ButtonPressed = false;
            bool Eaten = true;
           
            //Populate list with first element - head - snake at the beggining must have at least head
            Predator.Add(head); 
            Array[Predator[0].returnSnakeX(), Predator[0].returnSnakeX()] = 1;
    
       
            string direction = "LEFT";

          
     
            while (true)
            {
 
                time1 = DateTime.Now;
                ButtonPressed = false;


                //If boolean variable Eaten is set to true, which means that snake's head has met with apple object, generate new random x and y, 
                // change Apple Position and set again Eaten to false
                if(Eaten)
                {
                    int x = ranodmiser.Next(0, GAME_SIZE);
                    int y = ranodmiser.Next(0, GAME_SIZE);

                    apple.UpdateSnakePosition(x, y);
                    Eaten = false;
                }

                while (true)
                {
                    time2 = DateTime.Now;

                    if (time2.Subtract(time1).TotalMilliseconds > TIMER) { break; }
                    if(Console.KeyAvailable)
                    {
                        ConsoleKeyInfo input = Console.ReadKey(true);

                        if(input.Key.Equals(ConsoleKey.UpArrow) && direction != "DOWN" && ButtonPressed == false)
                        {
                            direction = "UP";
                            ButtonPressed = true;
                        }
                        if (input.Key.Equals(ConsoleKey.DownArrow) && direction != "UP" && ButtonPressed == false)
                        {
                            direction = "DOWN";
                            ButtonPressed = true;
                        }
                        if (input.Key.Equals(ConsoleKey.LeftArrow) && direction != "RIGHT" && ButtonPressed == false)
                        {
                            direction = "LEFT";
                            ButtonPressed = true;
                        }
                         if (input.Key.Equals(ConsoleKey.RightArrow) && direction != "LEFT" && ButtonPressed == false)
                        {
                            direction = "RIGHT";
                            ButtonPressed = true;
                        }

                    }

                }

                int targetY, targetX;

                try
                {
                    switch (direction)
                {
                  
                    case "LEFT":
                        {
                            
                                zeroArray(Array);

                                Array[apple.posX, apple.posY] = 1;

                                if (Predator.Count == 1)
                                {
                                    Predator[0].moveLeft();
                                    Array[Predator[0].posX, Predator[0].posY] = 1;
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
                                Array[Predator[0].posX, Predator[0].posY]= 1;
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
                            zeroArray(Array);
                            Array[apple.posX, apple.posY] = 1;
                            if (Predator.Count == 1)
                            {
                                Predator[0].moveRight();
                                Array[Predator[0].posX, Predator[0].posY] = 1;
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
                                Array[Predator[0].posX, Predator[0].posY] = 1;
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

                }
                catch (Exception ex)
                {
                    Console.Write("GAME OVER");
                }

                updateArray(Array);


                // Condition below, determines if Snake's head, has met with apple
                // Then it creates new object - eaten apple, which then is populated with posX and posY, and inserted to the beggining of the Predator list

                if (apple.posX == Predator.First().posX && apple.posY == Predator.First().posY) 
                {
                    Snake eatenApple = new Snake();
                    RESULT++;
                    eatenApple.setX(apple.posX);
                    eatenApple.setY(apple.posY);

                    Predator.Insert(0, eatenApple);
                    Array[apple.posX, apple.posY] = 0;
                    Eaten = true;
                }
              
                
                Thread.Sleep(TIMER);   
            }

         
        }
        public static void updateArray(int[,] array)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.WriteLine("RESULT: " + RESULT);

            for (int i = 0; i < GAME_SIZE ; i++)
            {
               
                for (int j = 0; j < GAME_SIZE; j++)
                {
                    
                    if (array[j,i] == 0)
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



   
    }
}
