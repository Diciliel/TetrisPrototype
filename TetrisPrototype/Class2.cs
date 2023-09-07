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
                    shapeColor = 0xFF845ec2,
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
                    shapeColor = 0xff00c9a7,
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
                    shapeColor = 0xFFFF6F91,
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
                    shapeColor = 0xFFFF8066,
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
                    shapeColor = 0xFFF9F871,
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
                    shapeColor = 0xFF0081CF,
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
                    shapeColor = 0xFFFFC75F,
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
