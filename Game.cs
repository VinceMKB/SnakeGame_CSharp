using Raylib_cs;
using System;
using Main.Character;
using Main.FoodLogic;
using System.Numerics;

namespace Main.GameLogic
{
    public class Game
    {
        public Snake Snake {get; set;} = new Snake();
        public Food Food {get; set;}
        public bool Running {get; set;} = true;
        public int Score {get; set;} = 0;

        public Game()
        {
            Food = new Food(Snake.Body);
        }

        public void Draw()
        {
            Food.Draw();
            Snake.Draw();
        }

        public void Update()
        {
            if(Running)
            {
                Snake.Update();
                Check_Collision_With_Edges();
                Check_Collision_With_Food();
                Check_Collision_With_Tail();
            }
        }

        public void Check_Collision_With_Food()
        {
            if(Globals.Vector2Equals(Snake.Body[0], Food.Position))
            {
                Food.Position = Food.GenerateRandomPos(Snake.Body);
                Snake.Add_Segment = true;
                Score += 10;
            }
        }

        public void Check_Collision_With_Edges()
        {
            if(Snake.Body[0].X == Globals.Cell_Count || Snake.Body[0].X == -1)
            {
                GameOver();
            }
            if(Snake.Body[0].Y == Globals.Cell_Count || Snake.Body[0].Y == -1)
            {
                GameOver();
            }
        }

        public void Check_Collision_With_Tail()
        {
            List<Vector2> headless_body = new List<Vector2>(Snake.Body);
            headless_body.RemoveAt(0);

            if(Globals.ElementInList(Snake.Body[0], headless_body))
            {
                GameOver();
            }
        }

        public void GameOver()
        {
            Snake.Reset();
            Food.Position = Food.GenerateRandomPos(Snake.Body);
            Running = false;
            Score = 0;
            Console.WriteLine("GameOver!");
        }
    }
}