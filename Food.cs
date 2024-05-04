using Raylib_cs;
using System;
using System.Numerics;

namespace Main.FoodLogic
{
    public class Food
    {
        public Vector2 Position {get; set;}
        public Texture2D Texture {get; set;}

        public Food(List<Vector2> SnakeBody)
        {
            Image image = Raylib.LoadImage("Graphics/BetterFood.png");
            Texture = Raylib.LoadTextureFromImage(image);
            Raylib.UnloadImage(image);
            Position = GenerateRandomPos(SnakeBody);
        }

        ~Food()
        {
            Raylib.UnloadTexture(Texture);
        }

        public void Draw()
        {
            Raylib.DrawTexture(Texture, (int)(Globals.Offset + Position.X * Globals.Cell_Size), (int)(Globals.Offset + Position.Y * Globals.Cell_Size), Color.White);
        }

        public Vector2 GenerateRandomCell()
        {
            float x = Raylib.GetRandomValue(0, (int)(Globals.Cell_Count -1));
            float y = Raylib.GetRandomValue(0, (int)(Globals.Cell_Count -1));

            return new Vector2(x, y);
        }

        public Vector2 GenerateRandomPos(List<Vector2> SnakeBody)
        {
            Vector2 position = GenerateRandomCell();
            while(Globals.ElementInList(position, SnakeBody))
            {
                GenerateRandomCell();
            }
            return position;
        }
    }
}