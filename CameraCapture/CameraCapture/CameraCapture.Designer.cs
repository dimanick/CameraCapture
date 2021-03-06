﻿namespace CameraCapture
{
    partial class CameraCapture
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
            this.CamImageBox0 = new Emgu.CV.UI.ImageBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.CamImageBox1 = new Emgu.CV.UI.ImageBox();
            this.CamImageBox2 = new Emgu.CV.UI.ImageBox();
            this.CamImageBox3 = new Emgu.CV.UI.ImageBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSavePath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // CamImageBox0
            // 
            this.CamImageBox0.Location = new System.Drawing.Point(11, 11);
            this.CamImageBox0.Name = "CamImageBox0";
            this.CamImageBox0.Size = new System.Drawing.Size(259, 222);
            this.CamImageBox0.TabIndex = 2;
            this.CamImageBox0.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(541, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(541, 41);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CamImageBox1
            // 
            this.CamImageBox1.Location = new System.Drawing.Point(276, 12);
            this.CamImageBox1.Name = "CamImageBox1";
            this.CamImageBox1.Size = new System.Drawing.Size(259, 222);
            this.CamImageBox1.TabIndex = 6;
            this.CamImageBox1.TabStop = false;
            // 
            // CamImageBox2
            // 
            this.CamImageBox2.Location = new System.Drawing.Point(12, 239);
            this.CamImageBox2.Name = "CamImageBox2";
            this.CamImageBox2.Size = new System.Drawing.Size(259, 222);
            this.CamImageBox2.TabIndex = 7;
            this.CamImageBox2.TabStop = false;
            // 
            // CamImageBox3
            // 
            this.CamImageBox3.Location = new System.Drawing.Point(276, 239);
            this.CamImageBox3.Name = "CamImageBox3";
            this.CamImageBox3.Size = new System.Drawing.Size(259, 222);
            this.CamImageBox3.TabIndex = 8;
            this.CamImageBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(541, 438);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(541, 70);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(75, 23);
            this.btnSavePath.TabIndex = 10;
            this.btnSavePath.Text = "Path...";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // CameraCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 469);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.CamImageBox3);
            this.Controls.Add(this.CamImageBox2);
            this.Controls.Add(this.CamImageBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.CamImageBox0);
            this.Name = "CameraCapture";
            this.Text = "Camera Capture";
            this.Load += new System.EventHandler(this.CameraCapture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox CamImageBox0;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSave;
        private Emgu.CV.UI.ImageBox CamImageBox1;
        private Emgu.CV.UI.ImageBox CamImageBox2;
        private Emgu.CV.UI.ImageBox CamImageBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSavePath;
    }
}

