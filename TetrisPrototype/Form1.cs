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
    public partial class frmTetris : Form
    {
        Label[] kare = new Label[200]; // 10x20lik kare olusturmak icin 200 karelik dizi
        Label pano;
        int say; // sayac

        public frmTetris()
        {
            InitializeComponent();
        }

        private void frmTetris_Load(object sender, EventArgs e)
        {
            say = 0;
            for (int j = 1; j <= 20; j++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    kare[say] = new Label();
                    kare[say].Location = new System.Drawing.Point(26*i, 26*j);
                    kare[say].Name = "kare" + say;
                    kare[say].Size = new System.Drawing.Size(25, 25);
                    kare[say].BackColor = Color.Blue;
                    kare[say].ForeColor = Color.Yellow;
                    kare[say].Text = say.ToString();
                    kare[say].TabIndex = say;
                    Controls.Add(this.kare[say]); // karelerin forma eklenmesini saglar.
                    kare[say].Visible = true;
                    say += 1;
                }
            }
            
            pano = new Label();
            pano.Location = new System.Drawing.Point(25, 25);
            pano.Name = "pano";
            pano.Size = new System.Drawing.Size(261, 521);
            pano.BackColor = Color.Cyan;
            Controls.Add(pano);

            lbl_con.BackColor = Color.Azure;
            lbl_pause.BackColor = Color.Azure;
        }

        private void lbl_ng_Click(object sender, EventArgs e)
        {
            panoClear();
            timer1.Start();
            lbl_ng.Enabled = false;
            lbl_ng.BackColor = Color.Azure;
            lbl_pause.Enabled = true;
            lbl_pause.BackColor = Color.Yellow;
            lbl_quit.Enabled = false;
            lbl_quit.BackColor = Color.Azure;

            say = 5;
            kare[say].BackColor = Color.Red;
            timer1.Interval = 1000;

        }

        private void lbl_pause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            lbl_con.Enabled = true;
            lbl_con.BackColor = Color.Yellow;
            lbl_pause.Enabled = false;
            lbl_pause.BackColor = Color.Azure;
            lbl_quit.Enabled = true;
            lbl_quit.BackColor = Color.Yellow;
        }

        private void lbl_con_Click(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_con.Enabled = false;
            lbl_con.BackColor = Color.Azure;
            lbl_pause.Enabled = true;
            lbl_pause.BackColor = Color.Yellow;
            lbl_quit.Enabled = false;
            lbl_quit.BackColor = Color.Azure;
        }

        private void lbl_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (kare[5].BackColor == Color.Red && kare[15].BackColor == Color.Red)
            {
                timer1.Stop();
                MessageBox.Show("Game Over");
                lbl_ng.Enabled = true;
                lbl_ng.BackColor = Color.Yellow;
                lbl_pause.Enabled = false;
                lbl_pause.BackColor = Color.Azure;
                lbl_quit.Enabled = true;
                lbl_quit.BackColor = Color.Yellow;
                return;
            }
            if (say + 10 > 200) // asagi inme animasyonu.
            {
                say = 5;
                kare[say].BackColor = Color.Red;
                return;
            }
            if (kare[say + 10].BackColor == Color.Red) // dolu blogu kontrol eder.
            {
                say = 5;
                kare[say].BackColor = Color.Red;
                return;
            }

            kare[say].BackColor = Color.Blue;
            say += 10;
            kare[say].BackColor = Color.Red;
        }

        void panoClear()
        {
            for (int i = 1; i < 200; i++)
            {
                kare[i].BackColor = Color.Blue;
            }
        }

        private void frmTetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) 
            {
                if (say % 10 == 0) 
                {
                    return;
                }
                kare[say].BackColor=Color.Blue;
                say--;
                kare[say].BackColor = Color.Red;
            }
            if (e.KeyCode == Keys.Right) 
            {
                if (say % 10 == 9) 
                {
                    return;
                }
                kare[say].BackColor=Color.Blue;
                say++;
                kare[say].BackColor = Color.Red;    
            }
        }
    }
}
