﻿namespace LeapSpv2
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.forwardB = new System.Windows.Forms.PictureBox();
            this.backwardB = new System.Windows.Forms.PictureBox();
            this.leftB = new System.Windows.Forms.PictureBox();
            this.rightB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.forwardB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backwardB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorB)).BeginInit();
            this.SuspendLayout();
            // 
            // forwardB
            // 
            this.forwardB.Image = ((System.Drawing.Image)(resources.GetObject("forwardB.Image")));
            this.forwardB.InitialImage = null;
            this.forwardB.Location = new System.Drawing.Point(147, 54);
            this.forwardB.Name = "forwardB";
            this.forwardB.Size = new System.Drawing.Size(80, 89);
            this.forwardB.TabIndex = 0;
            this.forwardB.TabStop = false;
            // 
            // backwardB
            // 
            this.backwardB.Image = ((System.Drawing.Image)(resources.GetObject("backwardB.Image")));
            this.backwardB.Location = new System.Drawing.Point(147, 247);
            this.backwardB.Name = "backwardB";
            this.backwardB.Size = new System.Drawing.Size(80, 88);
            this.backwardB.TabIndex = 1;
            this.backwardB.TabStop = false;
            // 
            // leftB
            // 
            this.leftB.Image = ((System.Drawing.Image)(resources.GetObject("leftB.Image")));
            this.leftB.Location = new System.Drawing.Point(49, 150);
            this.leftB.Name = "leftB";
            this.leftB.Size = new System.Drawing.Size(80, 90);
            this.leftB.TabIndex = 2;
            this.leftB.TabStop = false;
            // 
            // rightB
            // 
            this.rightB.Image = ((System.Drawing.Image)(resources.GetObject("rightB.Image")));
            this.rightB.Location = new System.Drawing.Point(247, 150);
            this.rightB.Name = "rightB";
            this.rightB.Size = new System.Drawing.Size(80, 90);
            this.rightB.TabIndex = 3;
            this.rightB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sphero Controller";
            // 
            // colorB
            // 
            this.colorB.Image = ((System.Drawing.Image)(resources.GetObject("colorB.Image")));
            this.colorB.Location = new System.Drawing.Point(147, 150);
            this.colorB.Name = "colorB";
            this.colorB.Size = new System.Drawing.Size(80, 88);
            this.colorB.TabIndex = 5;
            this.colorB.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.colorB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rightB);
            this.Controls.Add(this.leftB);
            this.Controls.Add(this.backwardB);
            this.Controls.Add(this.forwardB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.Text = "Controller";
            ((System.ComponentModel.ISupportInitialize)(this.forwardB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backwardB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox forwardB;
        private System.Windows.Forms.PictureBox backwardB;
        private System.Windows.Forms.PictureBox leftB;
        private System.Windows.Forms.PictureBox rightB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox colorB;
    }
}