using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TetrisPrototype
{
    class Shape
    {
        public int Width;
        public int Height;
        public int[,] Dots;
        public uint shapeColor;
        private int[,] backupDots;
        public int[,] canvasDotArray;

        public Shape() { }
        public Shape(Shape shape) 
        {
            Width = shape.Width;
            Height = shape.Height;
            Dots = shape.Dots;
            shapeColor = shape.shapeColor;
            backupDots = shape.backupDots;
            canvasDotArray = shape.canvasDotArray;
        }
        public void turn() // sekli dondurur
        {
            backupDots = Dots;
            Dots = new int[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Dots[i, j] = backupDots[Height - 1-j, i];
                }
            }
            var temp = Width;
            Width = Height;
            Height = temp;
        }
        public void rollback() // sekil donerken baska sekle degiyor mu
        {
            Dots = backupDots;

            var temp = Width;
            Width= Height;
            Height = temp;
        }

    }
}
