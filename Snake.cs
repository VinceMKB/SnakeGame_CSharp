using Raylib_cs;
using System;
using System.Numerics;

namespace Main.Character
{
    public class Snake
    {
        public List<Vector2> Body {get; set;} = new List<Vector2>{new Vector2(6, 9), new Vector2(5, 9), new Vector2(4, 9)};
        public Vector2 Direction {get; set;} = new Vector2(1, 0);
        public bool Add_Segment {get; set;} = false;

        public void Draw()
        {
            for(int i = 0; i < Body.Count; i++)
            {
                float x = Body[i].X;
                float y = Body[i].Y;
                Rectangle segment = new Rectangle(Globals.Offset + x * Globals.Cell_Size, Globals.Offset + y * Globals.Cell_Size, Globals.Cell_Size, Globals.Cell_Size);
                Raylib.DrawRectangleRounded(segment, 0.5f, 6, Color.Black);
            }
        }

        public void Update()
        {
            
            Body.Insert(0, Body[0] + Direction);
            if(Add_Segment == true)
            {
                Add_Segment = false;
            }
            else
            {
                Body.RemoveAt(Body.Count -1);
            }
        }

        public void Reset()
        {
            Body = new List<Vector2>{new Vector2(6, 9), new Vector2(5, 9), new Vector2(4, 9)};
            Direction = new Vector2(1, 0);
            Add_Segment = false;
        }
    }
    
}