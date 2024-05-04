using System;
using Main.GameLogic;
using System.Numerics;
using Raylib_cs;

namespace Main
{
    
    public class Globals
    {
        public const float Offset = 75;
        public const float Cell_Count = 25;
        public const float Cell_Size = 30;
        public const int WindowX = (int)(2*Offset + Cell_Size * Cell_Count);
        public const int WindowY = (int)(2*Offset + Cell_Size * Cell_Count);
        public static double LastUpdateTime = 0;

        public static bool Event_Triggered(double interval)
        {
            double Current_Time = Raylib.GetTime();
            if(Current_Time - LastUpdateTime >= interval)
            {
                LastUpdateTime = Current_Time;
                return true;
            }
            
            return false;
        }

        public static bool Vector2Equals(Vector2 a, Vector2 b)
        {
            if(a.X == b.X && a.Y == b.Y)
            {
                return true;
            }
            return false;
        }

        public static bool ElementInList(Vector2 element, List<Vector2> list)
        {
            foreach(var item in list)
            {
                if(item.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

    }
    
    class Program
    {
        public static void Main()
        {
            
            Vector2 position = new Vector2(Globals.Offset - 5, Globals.Offset -5);
            Rectangle rect = new Rectangle(position, new Vector2(Globals.Cell_Count * Globals.Cell_Size + 10, Globals.Cell_Count * Globals.Cell_Size + 10));

            Raylib.InitWindow(Globals.WindowX, Globals.WindowY, "Starting Window");
            Raylib.SetTargetFPS(60);
            Game game = new Game();

            while(Raylib.WindowShouldClose() == false)
            {
                
                Raylib.BeginDrawing();
                if(Globals.Event_Triggered(0.25f))
                {
                    game.Update();
                }

                //Inputs
                if(Raylib.IsKeyPressed(KeyboardKey.W) && game.Snake.Direction.Y != 1)
                {
                    game.Snake.Direction = new Vector2(0, -1);
                    game.Running = true;
                }
                if(Raylib.IsKeyPressed(KeyboardKey.S) && game.Snake.Direction.Y != -1)
                {
                    game.Snake.Direction =  new Vector2(0, 1);
                    game.Running = true;
                }
                if(Raylib.IsKeyPressed(KeyboardKey.A) && game.Snake.Direction.X != 1)
                {
                    game.Snake.Direction = new Vector2(-1, 0);
                    game.Running = true;
                }
                if(Raylib.IsKeyPressed(KeyboardKey.D) && game.Snake.Direction.X != -1)
                {
                    game.Snake.Direction = new Vector2(1, 0);
                    game.Running = true;
                }

                Raylib.ClearBackground(Color.Blue);
                Raylib.DrawText("Starting Window", 20, 20, 25, Color.Black);
                Raylib.DrawRectangleLinesEx(rect, 5, Color.Black);
                Raylib.DrawText("~Retro Snake~", 70, 20, 40, Color.Black);
                Raylib.DrawText("Score: " + game.Score, 70, (int)(Globals.Offset + Globals.Cell_Size * Globals.Cell_Count + 10), 40, Color.Black);
                game.Draw();
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }


    }


}
