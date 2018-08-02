namespace IJ9_10
{

    class Player
    {
        public Health Health;
        public Map Map;
        public Vector2 Position;

        public void Update()
        {
            if (Position.X < Map.Width)
            {
                Position.X++;
                if (Map.GetCell(Position.X, Position.Y) == '#')
                {
                    Health.ApplyDamage(10);
                }
            }
        }
    }

    class Vector2
    {
        public int X, Y;

        public static Vector2 operator +(Vector2 vector, int i)
        {
            vector.X += i;
            vector.Y += i;
            return vector;
        }

        public static Vector2 operator -(Vector2 vector, int i)
        {
            vector.X -= i;
            vector.Y -= i;
            return vector;
        }

        public static Vector2 operator *(Vector2 vector, int i)
        {
            vector.X *= i;
            vector.Y *= i;
            return vector;
        }

        public static Vector2 operator +(Vector2 vector1, Vector2 vector2)
        {
            vector1.X += vector2.X;
            vector1.Y += vector2.Y;
            return vector1;
        }

        public static Vector2 operator -(Vector2 vector1, Vector2 vector2)
        {
            vector1.X -= vector2.X;
            vector1.Y -= vector2.Y;
            return vector1;
        }

        public static Vector2 operator *(Vector2 vector1, Vector2 vector2)
        {
            vector1.X *= vector2.X;
            vector1.Y *= vector2.Y;
            return vector1;
        }
    }

    class Health
    {
        public float Value;

        public bool IsAlive
        {
            get
            {
                return Value > 0;
            }
        }

        public void ApplyDamage(float damage)
        {
            Value -= damage;
        }
    }

    class Map
    {
        public char[,] Cells;

        public char GetCell(int x, int y)
        {
            return Cells[x, y];
        }

        public int Width
        {
            get
            {
                return Cells.GetLength(0);
            }
        }

        public int Heigth
        {
            get
            {
                return Cells.GetLength(1);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}


