namespace KuruKuru
{
    partial class MainForm
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
            trayIcon.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rotateRBtn = new System.Windows.Forms.Button();
            this.rotateLBtn = new System.Windows.Forms.Button();
            this.rotateTBtn = new System.Windows.Forms.Button();
            this.rotateBBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rotateRBtn
            // 
            this.rotateRBtn.Location = new System.Drawing.Point(26, 13);
            this.rotateRBtn.Name = "rotateRBtn";
            this.rotateRBtn.Size = new System.Drawing.Size(143, 45);
            this.rotateRBtn.TabIndex = 0;
            this.rotateRBtn.Text = "rotate right";
            this.rotateRBtn.UseVisualStyleBackColor = true;
            this.rotateRBtn.Click += new System.EventHandler(this.rotateRBtn_Click);
            // 
            // rotateLBtn
            // 
            this.rotateLBtn.Location = new System.Drawing.Point(26, 64);
            this.rotateLBtn.Name = "rotateLBtn";
            this.rotateLBtn.Size = new System.Drawing.Size(143, 45);
            this.rotateLBtn.TabIndex = 1;
            this.rotateLBtn.Text = "rotate left";
            this.rotateLBtn.UseVisualStyleBackColor = true;
            this.rotateLBtn.Click += new System.EventHandler(this.rotateLBtn_Click);
            // 
            // rotateTBtn
            // 
            this.rotateTBtn.Location = new System.Drawing.Point(26, 115);
            this.rotateTBtn.Name = "rotateTBtn";
            this.rotateTBtn.Size = new System.Drawing.Size(143, 45);
            this.rotateTBtn.TabIndex = 2;
            this.rotateTBtn.Text = "rotate top";
            this.rotateTBtn.UseVisualStyleBackColor = true;
            this.rotateTBtn.Click += new System.EventHandler(this.rotateTBtn_Click);
            // 
            // rotateBBtn
            // 
            this.rotateBBtn.Location = new System.Drawing.Point(26, 166);
            this.rotateBBtn.Name = "rotateBBtn";
            this.rotateBBtn.Size = new System.Drawing.Size(143, 45);
            this.rotateBBtn.TabIndex = 3;
            this.rotateBBtn.Text = "rotate bottom";
            this.rotateBBtn.UseVisualStyleBackColor = true;
            this.rotateBBtn.Click += new System.EventHandler(this.rotateBBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.rotateBBtn);
            this.Controls.Add(this.rotateTBtn);
            this.Controls.Add(this.rotateLBtn);
            this.Controls.Add(this.rotateRBtn);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rotateRBtn;
        private System.Windows.Forms.Button rotateLBtn;
        private System.Windows.Forms.Button rotateTBtn;
        private System.Windows.Forms.Button rotateBBtn;
    }
}

