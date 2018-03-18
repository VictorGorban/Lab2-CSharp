namespace Lab2_CSharp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PBBefore = new System.Windows.Forms.PictureBox();
            this.LabelAfter = new System.Windows.Forms.Label();
            this.LabelBefore = new System.Windows.Forms.Label();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.ButtonProcess = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PBAfter = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBBefore)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // PBBefore
            // 
            this.PBBefore.BackColor = System.Drawing.SystemColors.Control;
            this.PBBefore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBBefore.Image = global::Lab2_CSharp.Properties.Resources.ru_default_large_default;
            this.PBBefore.Location = new System.Drawing.Point(0, 0);
            this.PBBefore.Name = "PBBefore";
            this.PBBefore.Size = new System.Drawing.Size(462, 462);
            this.PBBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBBefore.TabIndex = 0;
            this.PBBefore.TabStop = false;
            // 
            // LabelAfter
            // 
            this.LabelAfter.AutoSize = true;
            this.LabelAfter.Font = new System.Drawing.Font("Sitka Small", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelAfter.Location = new System.Drawing.Point(662, 9);
            this.LabelAfter.Name = "LabelAfter";
            this.LabelAfter.Size = new System.Drawing.Size(58, 23);
            this.LabelAfter.TabIndex = 2;
            this.LabelAfter.Tag = "";
            this.LabelAfter.Text = "После";
            // 
            // LabelBefore
            // 
            this.LabelBefore.AutoSize = true;
            this.LabelBefore.Font = new System.Drawing.Font("Sitka Small", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelBefore.Location = new System.Drawing.Point(212, 9);
            this.LabelBefore.Name = "LabelBefore";
            this.LabelBefore.Size = new System.Drawing.Size(31, 23);
            this.LabelBefore.TabIndex = 3;
            this.LabelBefore.Tag = "";
            this.LabelBefore.Text = "До";
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Font = new System.Drawing.Font("Sitka Text", 13F);
            this.ButtonLoad.Location = new System.Drawing.Point(12, 410);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(113, 33);
            this.ButtonLoad.TabIndex = 4;
            this.ButtonLoad.Text = "Загрузить";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // ButtonProcess
            // 
            this.ButtonProcess.Font = new System.Drawing.Font("Sitka Text", 13F);
            this.ButtonProcess.Location = new System.Drawing.Point(316, 410);
            this.ButtonProcess.Name = "ButtonProcess";
            this.ButtonProcess.Size = new System.Drawing.Size(126, 33);
            this.ButtonProcess.TabIndex = 5;
            this.ButtonProcess.Text = "Обработать";
            this.ButtonProcess.UseVisualStyleBackColor = true;
            this.ButtonProcess.Click += new System.EventHandler(this.ButtonProcess_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(470, 410);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(429, 23);
            this.ProgressBar.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.PBBefore);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 370);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.PBAfter);
            this.panel2.Location = new System.Drawing.Point(470, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 370);
            this.panel2.TabIndex = 8;
            // 
            // PBAfter
            // 
            this.PBAfter.BackColor = System.Drawing.SystemColors.Control;
            this.PBAfter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBAfter.Image = ((System.Drawing.Image)(resources.GetObject("PBAfter.Image")));
            this.PBAfter.Location = new System.Drawing.Point(0, 0);
            this.PBAfter.Name = "PBAfter";
            this.PBAfter.Size = new System.Drawing.Size(462, 462);
            this.PBAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBAfter.TabIndex = 1;
            this.PBAfter.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(911, 469);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.ButtonProcess);
            this.Controls.Add(this.ButtonLoad);
            this.Controls.Add(this.LabelBefore);
            this.Controls.Add(this.LabelAfter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.PBBefore)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBBefore;
        private System.Windows.Forms.Label LabelAfter;
        private System.Windows.Forms.Label LabelBefore;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.Button ButtonProcess;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PBAfter;
    }
}

