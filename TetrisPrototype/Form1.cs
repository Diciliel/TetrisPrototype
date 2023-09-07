using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            var currentShape2 = getRandomShapeWithCenterAligned();
            currentShape = new Shape(currentShape2);

            timer.Tick += timer1_Tick;
            timer.Interval = 400;
            timer.Start();
            this.KeyDown += Form1_KeyDown;

            nextShape = getNextShape();
        }

        Bitmap canvasBitmap;
        Graphics canvasGraphics;
        Bitmap workingBitmap;
        Graphics workingGraphics;
        int canvasWidth = 10;
        int canvasHeight = 20;
        int[,] canvasDotArray;
        uint[,] canvasShapeColor;
        int dotSize = 20;
        int currentX;
        int currentY;
        int score;
        Shape currentShape;
        Shape nextShape;
        Timer timer = new Timer();

        private void loadCanvas()
        {
            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

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
            canvasShapeColor = new uint[canvasWidth, canvasHeight];
        }
        private Shape getRandomShapeWithCenterAligned()
        {
            var shape = ShapesHandler.GetRandomShapes();

            currentX = 4;
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
                    if (newY + j > 0 && canvasDotArray[newX + i, newY + j] > 0 && currentShape.Dots[j, i] > 0)
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
                    if (currentShape.Dots[j, i] > 0 )
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
                    if (currentShape.Dots[j,i] > 0) 
                    {
                        checkIfGameOver();
                        canvasDotArray[currentX + i, currentY + j] = 1;
                        canvasShapeColor[currentX + i, currentY + j] = currentShape.shapeColor;                  
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
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var isMoveSuccess = moveShapeIfPossible(moveDown: 1);

            if (!isMoveSuccess) 
            {
                canvasBitmap = new Bitmap(workingBitmap);
                updateCanvasDotArrayWithCurrentShape();

               // currentShape = getRandomShapeWithCenterAligned();

                currentShape = new Shape(nextShape);
                nextShape = getNextShape();

                clearFilledRowAndUpdateScore();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) 
        {
            var verticalMove = 0;
            var horizontalMove = 0;

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
            for (int i = 0; i < canvasHeight; i++) // her sirayi kontrol eder.
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
                    timer.Interval -= 10; // hizi arttirir

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

            for (int i = 0; i < canvasWidth; i++) // guncellenen DotArraye gore sekli cizer
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap); // 1 e esitse blue boya degilse gray boya.
                    Brush br = new SolidBrush(Color.FromArgb((int)canvasShapeColor[i, j]));
                    canvasGraphics.FillRectangle(canvasDotArray[i, j] == 1 ? br : Brushes.LightGray, i * dotSize + 1, j * dotSize + 1, dotSize - 2, dotSize - 2);                    
                }
            }
            pictureBox1.Image = canvasBitmap;
        }

        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;
        private Shape getNextShape() // Gelecek siradaki sekli yanda gosterme
        {
            var shape = getRandomShapeWithCenterAligned();

            nextShapeBitmap = new Bitmap(pictureBox2.Width,pictureBox2.Height);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);
                    nextShapeGraphics.FillRectangle(Brushes.LightGray, i * dotSize + 1, j * dotSize + 1, dotSize - 2, dotSize - 2);
                }
            }

            var startX = (6 - shape.Width) / 2;
            var startY = (6 - shape.Height) / 2;

            for (int i = 0; i < shape.Height; i++)
            {
                for (int j = 0; j < shape.Width; j++)
                {
                   Brush br = new SolidBrush(Color.FromArgb((int)shape.shapeColor));
                   nextShapeGraphics.FillRectangle(shape.Dots[i, j] == 1 ? br: Brushes.LightGray, (startX+j) * dotSize + 1, (startY+i) * dotSize + 1, dotSize - 2, dotSize - 2);
                }
            }
            pictureBox2.Size= nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }

        private void lbl_new_Click(object sender, EventArgs e)
        {
            timer.Start();
            lbl_new.Enabled = false;
            lbl_stop.Enabled = true;
            lbl_exit.Enabled = false;
        }

        private void lbl_stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lbl_cont.Enabled = true;
            lbl_stop.Enabled = false;
        }

        private void lbl_cont_Click(object sender, EventArgs e)
        {
            timer.Start();
            lbl_cont.Enabled = false;
            lbl_stop.Enabled = true;
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
