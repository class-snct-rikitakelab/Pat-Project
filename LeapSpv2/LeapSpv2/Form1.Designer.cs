namespace LeapSpv2
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
            this.label1 = new System.Windows.Forms.Label();
            this.BTconnection = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lconn = new System.Windows.Forms.Label();
            this.ldisconn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check Device Status";
            this.label1.UseMnemonic = false;
            // 
            // BTconnection
            // 
            this.BTconnection.FormattingEnabled = true;
            this.BTconnection.Location = new System.Drawing.Point(31, 129);
            this.BTconnection.Name = "BTconnection";
            this.BTconnection.Size = new System.Drawing.Size(120, 95);
            this.BTconnection.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(167, 128);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Leap Motion status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sphero status";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(167, 157);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lconn
            // 
            this.lconn.BackColor = System.Drawing.Color.White;
            this.lconn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lconn.Location = new System.Drawing.Point(31, 64);
            this.lconn.Name = "lconn";
            this.lconn.Size = new System.Drawing.Size(100, 20);
            this.lconn.TabIndex = 8;
            this.lconn.Text = "Connected";
            this.lconn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ldisconn
            // 
            this.ldisconn.BackColor = System.Drawing.Color.White;
            this.ldisconn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ldisconn.Location = new System.Drawing.Point(152, 64);
            this.ldisconn.Name = "ldisconn";
            this.ldisconn.Size = new System.Drawing.Size(100, 20);
            this.ldisconn.TabIndex = 9;
            this.ldisconn.Text = "Disconnected";
            this.ldisconn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ldisconn);
            this.Controls.Add(this.lconn);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.BTconnection);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Device Status";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox BTconnection;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lconn;
        private System.Windows.Forms.Label ldisconn;

    }
}

