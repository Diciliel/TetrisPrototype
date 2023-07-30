namespace TetrisPrototype
{
    partial class frmTetris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_ng = new System.Windows.Forms.Label();
            this.lbl_pause = new System.Windows.Forms.Label();
            this.lbl_con = new System.Windows.Forms.Label();
            this.lbl_quit = new System.Windows.Forms.Label();
            this.lbl_level = new System.Windows.Forms.Label();
            this.lbl_score = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_ng
            // 
            this.lbl_ng.BackColor = System.Drawing.Color.Yellow;
            this.lbl_ng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_ng.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_ng.ForeColor = System.Drawing.Color.Red;
            this.lbl_ng.Location = new System.Drawing.Point(310, 40);
            this.lbl_ng.Name = "lbl_ng";
            this.lbl_ng.Size = new System.Drawing.Size(70, 25);
            this.lbl_ng.TabIndex = 0;
            this.lbl_ng.Text = "NEW GAME";
            this.lbl_ng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ng.Click += new System.EventHandler(this.lbl_ng_Click);
            // 
            // lbl_pause
            // 
            this.lbl_pause.BackColor = System.Drawing.Color.Yellow;
            this.lbl_pause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_pause.Enabled = false;
            this.lbl_pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_pause.ForeColor = System.Drawing.Color.Red;
            this.lbl_pause.Location = new System.Drawing.Point(310, 80);
            this.lbl_pause.Name = "lbl_pause";
            this.lbl_pause.Size = new System.Drawing.Size(70, 25);
            this.lbl_pause.TabIndex = 0;
            this.lbl_pause.Text = "PAUSE";
            this.lbl_pause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_pause.Click += new System.EventHandler(this.lbl_pause_Click);
            // 
            // lbl_con
            // 
            this.lbl_con.BackColor = System.Drawing.Color.Yellow;
            this.lbl_con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_con.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_con.Enabled = false;
            this.lbl_con.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_con.ForeColor = System.Drawing.Color.Red;
            this.lbl_con.Location = new System.Drawing.Point(310, 120);
            this.lbl_con.Name = "lbl_con";
            this.lbl_con.Size = new System.Drawing.Size(70, 25);
            this.lbl_con.TabIndex = 0;
            this.lbl_con.Text = "CONTINUE";
            this.lbl_con.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_con.Click += new System.EventHandler(this.lbl_con_Click);
            // 
            // lbl_quit
            // 
            this.lbl_quit.BackColor = System.Drawing.Color.Yellow;
            this.lbl_quit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_quit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_quit.ForeColor = System.Drawing.Color.Red;
            this.lbl_quit.Location = new System.Drawing.Point(310, 160);
            this.lbl_quit.Name = "lbl_quit";
            this.lbl_quit.Size = new System.Drawing.Size(70, 25);
            this.lbl_quit.TabIndex = 0;
            this.lbl_quit.Text = "QUIT";
            this.lbl_quit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_quit.Click += new System.EventHandler(this.lbl_quit_Click);
            // 
            // lbl_level
            // 
            this.lbl_level.AutoSize = true;
            this.lbl_level.Location = new System.Drawing.Point(310, 240);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(55, 13);
            this.lbl_level.TabIndex = 1;
            this.lbl_level.Text = "LEVEL : 0";
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.Location = new System.Drawing.Point(310, 280);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(59, 13);
            this.lbl_score.TabIndex = 1;
            this.lbl_score.Text = "SCORE : 0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 561);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.lbl_level);
            this.Controls.Add(this.lbl_pause);
            this.Controls.Add(this.lbl_quit);
            this.Controls.Add(this.lbl_con);
            this.Controls.Add(this.lbl_ng);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTetris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TetrisPrototype";
            this.Load += new System.EventHandler(this.frmTetris_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTetris_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ng;
        private System.Windows.Forms.Label lbl_pause;
        private System.Windows.Forms.Label lbl_con;
        private System.Windows.Forms.Label lbl_quit;
        private System.Windows.Forms.Label lbl_level;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.Timer timer1;
    }
}

