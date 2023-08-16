using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TetrisPrototype
{
    static class ShapesHandler
    {
        private static Shape[] shapesArray;
        static ShapesHandler()
        {

            shapesArray = new Shape[]
            {
                new Shape
                {
                    Width = 2,
                    Height = 2,
                    shapeColor = 0xFFFF0000,
                    Dots =new int[,]
                    {
                        {1,1},
                        {1,1}
                    }
                },
                new Shape
                {
                    Width=1,
                    Height=4,
                    shapeColor = 0xFF00FF00,
                    Dots =new int [,]
                    {
                        {1},
                        {1},
                        {1},
                        {1}
                    }
                },
                new Shape
                {
                    Width=3,
                    Height=2,
                    shapeColor = 0xFFFFFF00,
                    Dots = new int [,]
                    {
                        {0,1,0},
                        {1,1,1},
                    }
                },
                new Shape
                {
                    Width=3,
                    Height=2,
                    shapeColor = 0xFFFF00FF,
                    Dots = new int [,]
                    {
                        {0,0,1},
                        {1,1,1},
                    }
                },
                new Shape
                {
                    Width=3,
                    Height=2,
                    shapeColor = 0xFF00FF00,
                    Dots = new int [,]
                    {
                        {1,0,0},
                        {1,1,1},
                    }
                },
                new Shape
                {
                    Width=3,
                    Height=2,
                    shapeColor = 0xFF00FFFF,
                    Dots = new int [,]
                    {
                        {1,1,0},
                        {0,1,1},
                    }
                },
                new Shape
                {
                    Width=3,
                    Height=2,
                    shapeColor = 0xFF7FFFFF,
                    Dots = new int [,]
                    {
                        {0,1,1},
                        {1,1,0},
                    }
                }
            };
        
        }
        public static Shape GetRandomShapes()
        {
            var shape = shapesArray[new Random().Next(shapesArray.Length)];
            return shape;
        }

    }
}
