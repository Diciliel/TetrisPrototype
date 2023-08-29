namespace TetrisPrototype
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_score = new System.Windows.Forms.Label();
            this.lbl_Next = new System.Windows.Forms.Label();
            this.lbl_Level = new System.Windows.Forms.Label();
            this.lbl_new = new System.Windows.Forms.Label();
            this.lbl_stop = new System.Windows.Forms.Label();
            this.lbl_cont = new System.Windows.Forms.Label();
            this.lbl_exit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(372, 183);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 120);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_score.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_score.Location = new System.Drawing.Point(368, 52);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(76, 20);
            this.lbl_score.TabIndex = 2;
            this.lbl_score.Text = "SCORE:";
            // 
            // lbl_Next
            // 
            this.lbl_Next.AutoSize = true;
            this.lbl_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Next.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_Next.Location = new System.Drawing.Point(369, 153);
            this.lbl_Next.Name = "lbl_Next";
            this.lbl_Next.Size = new System.Drawing.Size(38, 16);
            this.lbl_Next.TabIndex = 2;
            this.lbl_Next.Text = "Next";
            // 
            // lbl_Level
            // 
            this.lbl_Level.AutoSize = true;
            this.lbl_Level.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbl_Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Level.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_Level.Location = new System.Drawing.Point(369, 81);
            this.lbl_Level.Name = "lbl_Level";
            this.lbl_Level.Size = new System.Drawing.Size(49, 16);
            this.lbl_Level.TabIndex = 2;
            this.lbl_Level.Text = "Level:";
            // 
            // lbl_new
            // 
            this.lbl_new.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_new.Enabled = false;
            this.lbl_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_new.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_new.Location = new System.Drawing.Point(372, 324);
            this.lbl_new.Name = "lbl_new";
            this.lbl_new.Size = new System.Drawing.Size(100, 23);
            this.lbl_new.TabIndex = 3;
            this.lbl_new.Text = "NEW";
            this.lbl_new.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_new.Click += new System.EventHandler(this.lbl_new_Click);
            // 
            // lbl_stop
            // 
            this.lbl_stop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_stop.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_stop.Location = new System.Drawing.Point(372, 361);
            this.lbl_stop.Name = "lbl_stop";
            this.lbl_stop.Size = new System.Drawing.Size(100, 23);
            this.lbl_stop.TabIndex = 3;
            this.lbl_stop.Text = "STOP";
            this.lbl_stop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_stop.Click += new System.EventHandler(this.lbl_stop_Click);
            // 
            // lbl_cont
            // 
            this.lbl_cont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_cont.Enabled = false;
            this.lbl_cont.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_cont.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_cont.Location = new System.Drawing.Point(372, 397);
            this.lbl_cont.Name = "lbl_cont";
            this.lbl_cont.Size = new System.Drawing.Size(100, 23);
            this.lbl_cont.TabIndex = 3;
            this.lbl_cont.Text = "CONTINUE";
            this.lbl_cont.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_cont.Click += new System.EventHandler(this.lbl_cont_Click);
            // 
            // lbl_exit
            // 
            this.lbl_exit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_exit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_exit.Location = new System.Drawing.Point(372, 432);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(100, 23);
            this.lbl_exit.TabIndex = 3;
            this.lbl_exit.Text = "EXIT";
            this.lbl_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(502, 521);
            this.Controls.Add(this.lbl_cont);
            this.Controls.Add(this.lbl_stop);
            this.Controls.Add(this.lbl_exit);
            this.Controls.Add(this.lbl_new);
            this.Controls.Add(this.lbl_Next);
            this.Controls.Add(this.lbl_Level);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.Label lbl_Next;
        private System.Windows.Forms.Label lbl_Level;
        private System.Windows.Forms.Label lbl_new;
        private System.Windows.Forms.Label lbl_stop;
        private System.Windows.Forms.Label lbl_cont;
        private System.Windows.Forms.Label lbl_exit;
    }
}

