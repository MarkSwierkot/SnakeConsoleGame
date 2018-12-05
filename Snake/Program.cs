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
        public static int TIMER = 500;
        public static int RESULT = 1;
        public static bool GAME = true;
        public static int HardnessLevel = 10;
   
        static void Main(string[] args)
        {
            Console.SetWindowSize(55,40);

            Console.ForegroundColor = ConsoleColor.DarkRed;  
            Console.WriteLine("\t   SNAKE GAME - Marek Swierkot 2018 Edition \n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t  \t Press E, M, H to start... \n");
            Console.WriteLine("\t  \t [E]asy, [M]edium, [H]ard \n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t     [SNAKE IS CONTROLLED WITH ARROWS] \n");

            Console.ForegroundColor = ConsoleColor.White;
            
             

            ConsoleKey key = Console.ReadKey(true).Key;

            if(key.Equals(ConsoleKey.E)) HardnessLevel = 15;
            if(key.Equals(ConsoleKey.M)) HardnessLevel = 40;
            if(key.Equals(ConsoleKey.H)) HardnessLevel = 50;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t CONSOLE SNAKE by Marek Swierkot");
            Console.ForegroundColor = ConsoleColor.White;
            // Array defines two dimensional array, used in the program as a board for Snake
            int[,] Array = new int[GAME_SIZE, GAME_SIZE];

            bool ButtonPressed = false;
            bool Eaten = true;
      
            // Default direction on start = LEFT
            string Direction = "LEFT";

            // Predator, is a List of Snake type, which stores snake parts, starting from its head
            List<Snake> Predator = new List<Snake>();
           
            Snake head = new Snake((GAME_SIZE-1)/2, (GAME_SIZE - 1) / 2);
            Food apple = new Food();
            Random ranodmiser = new Random();

            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;

           
            //Populate list with first element - head - snake at the beggining must have at least head
            Predator.Add(head); 
            Array[Predator[0].GetPosX(), Predator[0].GetPosX()] = 1;


            while (GAME)
            {

                time1 = DateTime.Now;
                ButtonPressed = false;

       
                //If boolean variable Eaten is set to true, which means that snake's head has met with apple object, generate new random x and y, 
                // change Apple Position and set again Eaten to false
                if (Eaten)
                {
                    int x = ranodmiser.Next(0, GAME_SIZE);
                    int y = ranodmiser.Next(0, GAME_SIZE);

                    apple.UpdatePosition(x, y);
                    Eaten = false;
                }

                while (true)
                {
                    time2 = DateTime.Now;

                    if (time2.Subtract(time1).TotalMilliseconds > TIMER) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo input = Console.ReadKey(true);

                        if (input.Key.Equals(ConsoleKey.UpArrow) && Direction != "DOWN" && ButtonPressed == false)
                        {
                            Direction = "UP";
                            ButtonPressed = true;
                        }
                        if (input.Key.Equals(ConsoleKey.DownArrow) && Direction != "UP" && ButtonPressed == false)
                        {
                            Direction = "DOWN";
                            ButtonPressed = true;
                        }
                        if (input.Key.Equals(ConsoleKey.LeftArrow) && Direction != "RIGHT" && ButtonPressed == false)
                        {
                            Direction = "LEFT";
                            ButtonPressed = true;
                        }
                        if (input.Key.Equals(ConsoleKey.RightArrow) && Direction != "LEFT" && ButtonPressed == false)
                        {
                            Direction = "RIGHT";
                            ButtonPressed = true;
                        }

                    }

                }

                int targetY, targetX;

                try
                {
                    
                    switch (Direction)
                    {
                        
                        case "LEFT":
                            {

                                ZeroArray(Array); // refreshemnt of array
                                Array[apple.GetPosX(), apple.GetPosY()] = 2;


                                if (Predator.Count == 1)
                                {
                                    Predator[0].MoveLeft();
                                    Array[Predator[0].GetPosX(), Predator[0].GetPosY()] = 1;
                                }
                                else
                                {
                                    Predator.RemoveAt(Predator.Count - 1);
                                    Array[Predator[Predator.Count - 1].GetPosX(), Predator[Predator.Count - 1].GetPosY()] = 0;

                                    targetX = Predator.First().GetPosX();
                                    targetY = Predator.First().GetPosY();


                                    Snake snake = new Snake(targetX - 1, targetY);
                                    Predator.Insert(0, snake);


                                    foreach (Snake part in Predator)
                                    {
                                        Array[part.GetPosX(), part.GetPosY()] = 1;
                                    }

                                }


                                break;
                            }
                        case "UP":
                            {
                                ZeroArray(Array);
                                Array[apple.GetPosX(), apple.GetPosY()] = 2;

                                if (Predator.Count == 1)
                                {
                                    Predator[0].MoveUp();
                                    Array[Predator[0].GetPosX(), Predator[0].GetPosY()] = 1;
                                }
                                else
                                {

                                    Predator.RemoveAt(Predator.Count - 1);
                                    Array[Predator[Predator.Count - 1].GetPosX(), Predator[Predator.Count - 1].GetPosY()] = 0;

                                    targetX = Predator.First().GetPosX();
                                    targetY = Predator.First().GetPosY();


                                    Snake snake = new Snake(targetX, targetY - 1);
                                    Predator.Insert(0, snake);


                                    foreach (Snake part in Predator)
                                    {
                                        Array[part.GetPosX(), part.GetPosY()] = 1;
                                    }
                                }
                                break;
                            }
                        case "RIGHT":
                            {
                                ZeroArray(Array);
                                Array[apple.GetPosX(), apple.GetPosY()] = 2;

                                if (Predator.Count == 1)
                                {
                                    Predator[0].MoveRight();
                                    Array[Predator[0].GetPosX(), Predator[0].GetPosY()] = 1;
                                }
                                else
                                {
                                    Predator.RemoveAt(Predator.Count - 1);
                                    Array[Predator[Predator.Count - 1].GetPosX(), Predator[Predator.Count - 1].GetPosY()] = 0;

                                    targetX = Predator.First().GetPosX();
                                    targetY = Predator.First().GetPosY();


                                    Snake snake = new Snake(targetX + 1, targetY);
                                    Predator.Insert(0, snake);


                                    foreach (Snake part in Predator)
                                    {
                                        Array[part.GetPosX(), part.GetPosY()] = 1;
                                    }
                                }

                                break;
                            }
                        case "DOWN":
                            {
                                ZeroArray(Array);
                                Array[apple.GetPosX(), apple.GetPosY()] = 2;

                                if (Predator.Count == 1)
                                {
                                    Predator[0].MoveDown();
                                    Array[Predator[0].GetPosX(), Predator[0].GetPosY()] = 1;
                                }
                                else
                                {
                                    Predator.RemoveAt(Predator.Count - 1);
                                    Array[Predator[Predator.Count - 1].GetPosX(), Predator[Predator.Count - 1].GetPosY()] = 0;

                                    targetX = Predator.First().GetPosX();
                                    targetY = Predator.First().GetPosY();


                                    Snake snake = new Snake(targetX, targetY + 1);
                                    Predator.Insert(0, snake);


                                    foreach (Snake part in Predator)
                                    {
                                        Array[part.GetPosX(), part.GetPosY()] = 1;
                                    }
                                }
                                break;

                            }



                    }

                }
                catch (Exception ex)
                {

                    GameOver();

                }

                UpdateArray(Array);


                // Condition below, determines if Snake's head, has met with apple
                // Then it creates new object - eaten apple, which then is populated with posX and posY, and inserted to the beggining of the Predator list

                if (apple.GetPosX() == Predator.First().GetPosX() && apple.GetPosY() == Predator.First().GetPosY())
                {
                    Snake eatenApple = new Snake();
                   

                    eatenApple.SetPosX(apple.GetPosX());
                    eatenApple.SetPosY(apple.GetPosY());

                    Predator.Insert(0, eatenApple);
                    Array[apple.GetPosX(), apple.GetPosY()] = 0;
                    Eaten = true;

                    if (TIMER > 100)
                    {
                       HardnessLevel = ranodmiser.Next(HardnessLevel - 5, HardnessLevel + 5);
                        TIMER -= HardnessLevel;

                    }

                    RESULT += (HardnessLevel/3);
                }

                if(Predator.Count > 3) // More than 3 because there's no point in checking if snake crashed into itself, if it's less than 4 segments long
                {
                    for(int i = 3; i < Predator.Count-1; i++)
                        {
                          if (Predator.First().GetPosX() == Predator[i + 1].GetPosX() && Predator.First().GetPosY() == Predator[i + 1].GetPosY())
                          {
                            GameOver();
                          }
                        }
                    }
              
                }

         
        }



        public static void UpdateArray(int[,] array)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("RESULT: " + RESULT);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
 
            for(int i =0; i < GAME_SIZE; i++)
            {
                Console.Write(" . ");
            }
            Console.WriteLine();
            for (int i = 0; i < GAME_SIZE ; i++)
            {
                Console.Write(".");
                for (int j = 0; j < GAME_SIZE; j++)
                {
                 
                    if (array[j,i] == 0)
                    {
                        Console.Write("   ");
                    }

                    if (array[j, i] == 1)
                    {
                        Console.Write(" o ");
                    }
                    if (array[j, i] == 2)
                    {
                        Console.Write(" * ");
                    }
                    if(j == GAME_SIZE-1)
                    {
                        Console.Write(".");
                    }
                  

                }
                Console.WriteLine();
                Console.WriteLine();
              
            }
            for (int i = 0; i < GAME_SIZE; i++)
            {
                Console.Write(" . ");
            }
        }

        private static void ZeroArray(int[,] array)
        {
            for (int i = 0; i < GAME_SIZE; i++)
            {
                for (int j = 0; j < GAME_SIZE; j++)
                {
                    array[j, i] = 0;
                } 
            }
        }
        public static void GameOver()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t   GAME IS OVER, YOUR RESULT: " + RESULT);
            Thread.Sleep(3500);


            GAME = false;
           

        }
       

   
    }
}
