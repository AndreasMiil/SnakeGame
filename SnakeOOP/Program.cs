using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point snakeTail = new Point(15, 15, 's');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();

            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '$');
            Point food = foodGenerator.GenerateFood();
            food.Draw();
            score++;

            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }
                Thread.Sleep(300);
            }

            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
          }
           
        public static void WriteGameOver(String score)
        {
            int xoffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(xoffset, yOffset++);
            WriteText("=========================", xoffset, yOffset++);
            WriteText("     Game Over    ", xoffset+1, yOffset++); 
            yOffset++;
            WriteText($"You scored {score} points", xoffset+ 2, yOffset++);
            WriteText("", xoffset+1, yOffset++);
            WriteText("=========================", xoffset, yOffset++);
        }
      
        public static void WriteText(String text, int xoffset, int yOffset)
        {
            Console.SetCursorPosition(xoffset, yOffset);
            Console.WriteLine(text);
        }

       
        }
     
 }

