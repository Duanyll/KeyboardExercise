namespace KeybordExercise
{
    partial class SinpleExerciseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinpleExerciseForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.wordLabel1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.FingerPictureBox = new System.Windows.Forms.PictureBox();
            this.infoLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FingerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // wordLabel1
            // 
            this.wordLabel1.AutoSize = true;
            this.wordLabel1.Font = new System.Drawing.Font("Consolas", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordLabel1.Location = new System.Drawing.Point(12, 9);
            this.wordLabel1.Name = "wordLabel1";
            this.wordLabel1.Size = new System.Drawing.Size(524, 66);
            this.wordLabel1.TabIndex = 1;
            this.wordLabel1.Text = " - - - - - - - -";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(52, 78);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(456, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Location = new System.Drawing.Point(50, 106);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(59, 12);
            this.infoLabel1.TabIndex = 10;
            this.infoLabel1.Text = "用时 - 秒";
            // 
            // infoLabel3
            // 
            this.infoLabel3.AutoSize = true;
            this.infoLabel3.Location = new System.Drawing.Point(455, 104);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(53, 12);
            this.infoLabel3.TabIndex = 12;
            this.infoLabel3.Text = "进度 --%";
            // 
            // FingerPictureBox
            // 
            this.FingerPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("FingerPictureBox.Image")));
            this.FingerPictureBox.Location = new System.Drawing.Point(558, 12);
            this.FingerPictureBox.Name = "FingerPictureBox";
            this.FingerPictureBox.Size = new System.Drawing.Size(122, 112);
            this.FingerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FingerPictureBox.TabIndex = 0;
            this.FingerPictureBox.TabStop = false;
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.Location = new System.Drawing.Point(242, 104);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(77, 12);
            this.infoLabel2.TabIndex = 13;
            this.infoLabel2.Text = "速度 - 字/分";
            // 
            // SinpleExerciseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 137);
            this.Controls.Add(this.infoLabel2);
            this.Controls.Add(this.infoLabel3);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.wordLabel1);
            this.Controls.Add(this.FingerPictureBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.Name = "SinpleExerciseForm";
            this.Text = "练习中";
            this.Load += new System.EventHandler(this.SinpleExerciseForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SinpleExerciseForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.FingerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FingerPictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label wordLabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.Label infoLabel2;
    }
}