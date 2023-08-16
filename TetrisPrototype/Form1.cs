using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisPrototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            loadCanvas();

            currentShape = getRandomShapeWithCenterAligned();

            timer.Tick += timer1_Tick;
            timer.Interval = 400;
            timer.Start();
            this.KeyDown += Form1_KeyDown;
            currentShape = getRandomShapeWithCenterAligned();
            nextShape = getNextShape();
        }

        Bitmap canvasBitmap;
        Graphics canvasGraphics;
        Bitmap workingBitmap;
        Graphics workingGraphics;
        int canvasWidth = 15;
        int canvasHeight = 20;
        int[,] canvasDotArray;
        int dotSize = 20;
        int currentX;
        int currentY;
        int score;
        Shape currentShape;
        Shape nextShape;
        Timer timer = new Timer();

        private void loadCanvas()
        {
            pictureBox1.Width = canvasWidth * dotSize;
            pictureBox1.Height = canvasHeight * dotSize;

            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //canvasGraphics = Graphics.FromImage(canvasBitmap);
            //canvasGraphics.FillRectangle(Brushes.LightGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap);
                    canvasGraphics.FillRectangle(Brushes.LightGray, i * dotSize + 1, j * dotSize + 1, dotSize - 2, dotSize - 2);
                }
            }

            pictureBox1.Image = canvasBitmap;

            canvasDotArray = new int[canvasWidth, canvasHeight];
        }
        private Shape getRandomShapeWithCenterAligned()
        {
            var shape = ShapesHandler.GetRandomShapes();

            currentX = 7;
            currentY = -shape.Height;
            return shape;
        }
        private bool moveShapeIfPossible(int moveDown = 0, int moveSide = 0) // zemine ulastiysa ya da baska bir blocka, basa dondurur
        {
            var newX = currentX + moveSide;
            var newY = currentY + moveDown;

            if (newX < 0 || newX + currentShape.Width > canvasWidth || newY + currentShape.Height > canvasHeight) // zemine ya da kenarlara geldi mi
                return false;

            for (int i = 0; i < currentShape.Width; i++) // baska bir blocka degdi mi
            {
                for (int j = 0; j < currentShape.Height; j++) 
                {
                    if (newY + j > 0 && canvasDotArray[newX + i, newY + j] == 1 && currentShape.Dots[j, i] == 1)
                        return false;
                }
            }

            currentX = newX;
            currentY = newY;

            drawShape();
            return true;
        }

        

        private void drawShape() 
        {
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);

            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] ==1)
                    {
                        Brush br = new SolidBrush(Color.FromArgb((int)currentShape.shapeColor));
                        workingGraphics.FillRectangle(br, (currentX + i) * dotSize + 1, (currentY + j) * dotSize + 1, dotSize - 2, dotSize - 2);
                    }
                }
            }
            pictureBox1.Image = workingBitmap;
        }
        private void updateCanvasDotArrayWithCurrentShape() 
        {
            for (int i = 0; i < currentShape.Width; i++) 
            {
                for (int j = 0; j < currentShape.Height; j++) 
                {
                    if (currentShape.Dots[j,i] == 1) 
                    {
                        checkIfGameOver();
                        canvasDotArray[currentX + i, currentY + j] = 1;
                    }
                }
            }
        }
        private void checkIfGameOver()
        {
            if (currentY < 0) 
            {
                timer.Stop();
                MessageBox.Show("Game Over");
                Application.Restart();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var isMoveSuccess = moveShapeIfPossible(moveDown: 1);

            if (!isMoveSuccess) 
            {
                canvasBitmap = new Bitmap(workingBitmap);
                updateCanvasDotArrayWithCurrentShape();

                currentShape = getRandomShapeWithCenterAligned();

                currentShape = nextShape;
                nextShape = getNextShape();

                clearFilledRowAndUpdateScore();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) 
        {
            var verticalMove = 0;
            var horizontalMove =0;

            switch (e.KeyCode) 
            {
                case Keys.Left: // sola hareket
                    verticalMove --;
                    break;

                case Keys.Right: // saga hareket
                    verticalMove++;
                    break;

                case Keys.Down: // asagi hizli indirme
                    horizontalMove++;
                    break;

                case Keys.Up: // sekli saat yonunde dondurme
                    currentShape.turn();
                    break;

                default:
                    return;
            }

            var isMoveSuccess = moveShapeIfPossible(horizontalMove, verticalMove); // sekli dondurmaya calisiyor fakat seklin donmemesi gerekiyorsa
            if (!isMoveSuccess && e.KeyCode == Keys.Up)
                currentShape.rollback();
        }

        public void clearFilledRowAndUpdateScore() // dolan satiri temizler, socre ve level tutar
        {
            for (int i = 0; i < canvasHeight; i++) 
            {
                int j;
                for (j = canvasWidth - 1; j >= 0; j--) 
                {
                    if (canvasDotArray[j, i] == 0)
                        break;
                }
                if (j == -1) 
                {
                    score++;
                    lbl_score.Text = "Score: " + score*10;
                    lbl_Level.Text = "Level: " + score / 10;
                    timer.Interval -= 20; // hizi arttirir

                    for (j = 0; j < canvasWidth; j++) 
                    {
                        for (int k = i; k > 0; k--) 
                        {
                            canvasDotArray[j, k] = canvasDotArray[j, k - 1]; 
                        }
                        canvasDotArray[j, 0] = 0;
                    }
                }
            }
            for (int i = 0; i < canvasWidth; i++) 
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap); // 1 e esitse black boya degilse gray boya.
                    canvasGraphics.FillRectangle(canvasDotArray[i, j] == 1 ? Brushes.Black : Brushes.LightGray, i * dotSize + 1, j * dotSize + 1, dotSize - 2, dotSize - 2); 
                    //Brush br = new SolidBrush(Color.FromArgb((int)shapeColor));
                    //canvasGraphics.FillRectangle(canvasDotArray[i, j] == 1 ? br : Brushes.LightGray, i * dotSize + 1, j * dotSize + 1, dotSize - 2, dotSize - 2);
                }
            }
            pictureBox1.Image = canvasBitmap;
        }

        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;
        private Shape getNextShape() // Gelecek siradaki sekli yanda gosterme
        {
            var shape = getRandomShapeWithCenterAligned();

            nextShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
            nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);
            nextShapeGraphics.FillRectangle(Brushes.LightGray, 0, 0, nextShapeBitmap.Width, nextShapeBitmap.Height);

            var startX = (6 - shape.Width) / 2;
            var startY = (6 - shape.Height) / 2;

            for (int i = 0; i < shape.Height; i++)
            {
                for (int j = 0; j < shape.Width; j++)
                {
                   Brush br = new SolidBrush(Color.FromArgb((int)shape.shapeColor));
                   nextShapeGraphics.FillRectangle(shape.Dots[i, j]== 1 ? br: Brushes.LightGray, (startX+j) * dotSize + 1, (startY+i) * dotSize + 1, dotSize - 2, dotSize - 2);
                 //nextShapeGraphics.FillRectangle(shape.Dots[i, j] == 1 ? Brushes.Black : Brushes.LightGray, (startX + j) * dotSize+1, (startY + i) * dotSize+1, dotSize-2, dotSize-2);
                }
            }
            pictureBox2.Size= nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }

    }
    
}
