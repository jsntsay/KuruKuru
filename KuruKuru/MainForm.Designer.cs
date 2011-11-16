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
            this.vkCodeLbl = new System.Windows.Forms.Label();
            this.vkTitle = new System.Windows.Forms.Label();
            this.shiftModTitle = new System.Windows.Forms.Label();
            this.shiftLbl = new System.Windows.Forms.Label();
            this.ctrlLbl = new System.Windows.Forms.Label();
            this.ctrlModTitle = new System.Windows.Forms.Label();
            this.altLbl = new System.Windows.Forms.Label();
            this.altModTitle = new System.Windows.Forms.Label();
            this.scancodeTitle = new System.Windows.Forms.Label();
            this.scLbl = new System.Windows.Forms.Label();
            this.flagsTitle = new System.Windows.Forms.Label();
            this.flagsLbl = new System.Windows.Forms.Label();
            this.scmTitle = new System.Windows.Forms.Label();
            this.scmLbl = new System.Windows.Forms.Label();
            this.vkmTitle = new System.Windows.Forms.Label();
            this.vkmLbl = new System.Windows.Forms.Label();
            this.miscLbl = new System.Windows.Forms.Label();
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
            // vkCodeLbl
            // 
            this.vkCodeLbl.AutoSize = true;
            this.vkCodeLbl.Location = new System.Drawing.Point(248, 13);
            this.vkCodeLbl.Name = "vkCodeLbl";
            this.vkCodeLbl.Size = new System.Drawing.Size(50, 13);
            this.vkCodeLbl.TabIndex = 4;
            this.vkCodeLbl.Text = "(vkCode)";
            // 
            // vkTitle
            // 
            this.vkTitle.AutoSize = true;
            this.vkTitle.Location = new System.Drawing.Point(190, 13);
            this.vkTitle.Name = "vkTitle";
            this.vkTitle.Size = new System.Drawing.Size(24, 13);
            this.vkTitle.TabIndex = 5;
            this.vkTitle.Text = "VK:";
            // 
            // shiftModTitle
            // 
            this.shiftModTitle.AutoSize = true;
            this.shiftModTitle.Location = new System.Drawing.Point(190, 54);
            this.shiftModTitle.Name = "shiftModTitle";
            this.shiftModTitle.Size = new System.Drawing.Size(50, 13);
            this.shiftModTitle.TabIndex = 6;
            this.shiftModTitle.Text = "shiftMod:";
            // 
            // shiftLbl
            // 
            this.shiftLbl.AutoSize = true;
            this.shiftLbl.Location = new System.Drawing.Point(248, 55);
            this.shiftLbl.Name = "shiftLbl";
            this.shiftLbl.Size = new System.Drawing.Size(52, 13);
            this.shiftLbl.TabIndex = 7;
            this.shiftLbl.Text = "(shiftmod)";
            // 
            // ctrlLbl
            // 
            this.ctrlLbl.AutoSize = true;
            this.ctrlLbl.Location = new System.Drawing.Point(248, 70);
            this.ctrlLbl.Name = "ctrlLbl";
            this.ctrlLbl.Size = new System.Drawing.Size(47, 13);
            this.ctrlLbl.TabIndex = 9;
            this.ctrlLbl.Text = "(ctrlmod)";
            // 
            // ctrlModTitle
            // 
            this.ctrlModTitle.AutoSize = true;
            this.ctrlModTitle.Location = new System.Drawing.Point(190, 69);
            this.ctrlModTitle.Name = "ctrlModTitle";
            this.ctrlModTitle.Size = new System.Drawing.Size(45, 13);
            this.ctrlModTitle.TabIndex = 8;
            this.ctrlModTitle.Text = "ctrlMod:";
            // 
            // altLbl
            // 
            this.altLbl.AutoSize = true;
            this.altLbl.Location = new System.Drawing.Point(248, 89);
            this.altLbl.Name = "altLbl";
            this.altLbl.Size = new System.Drawing.Size(44, 13);
            this.altLbl.TabIndex = 11;
            this.altLbl.Text = "(altmod)";
            // 
            // altModTitle
            // 
            this.altModTitle.AutoSize = true;
            this.altModTitle.Location = new System.Drawing.Point(190, 88);
            this.altModTitle.Name = "altModTitle";
            this.altModTitle.Size = new System.Drawing.Size(42, 13);
            this.altModTitle.TabIndex = 10;
            this.altModTitle.Text = "altMod:";
            // 
            // scancodeTitle
            // 
            this.scancodeTitle.AutoSize = true;
            this.scancodeTitle.Location = new System.Drawing.Point(190, 26);
            this.scancodeTitle.Name = "scancodeTitle";
            this.scancodeTitle.Size = new System.Drawing.Size(59, 13);
            this.scancodeTitle.TabIndex = 13;
            this.scancodeTitle.Text = "Scancode:";
            // 
            // scLbl
            // 
            this.scLbl.AutoSize = true;
            this.scLbl.Location = new System.Drawing.Point(248, 26);
            this.scLbl.Name = "scLbl";
            this.scLbl.Size = new System.Drawing.Size(60, 13);
            this.scLbl.TabIndex = 12;
            this.scLbl.Text = "(scancode)";
            // 
            // flagsTitle
            // 
            this.flagsTitle.AutoSize = true;
            this.flagsTitle.Location = new System.Drawing.Point(190, 41);
            this.flagsTitle.Name = "flagsTitle";
            this.flagsTitle.Size = new System.Drawing.Size(49, 13);
            this.flagsTitle.TabIndex = 15;
            this.flagsTitle.Text = "dwFlags:";
            // 
            // flagsLbl
            // 
            this.flagsLbl.AutoSize = true;
            this.flagsLbl.Location = new System.Drawing.Point(248, 41);
            this.flagsLbl.Name = "flagsLbl";
            this.flagsLbl.Size = new System.Drawing.Size(35, 13);
            this.flagsLbl.TabIndex = 14;
            this.flagsLbl.Text = "(flags)";
            // 
            // scmTitle
            // 
            this.scmTitle.AutoSize = true;
            this.scmTitle.Location = new System.Drawing.Point(190, 128);
            this.scmTitle.Name = "scmTitle";
            this.scmTitle.Size = new System.Drawing.Size(53, 13);
            this.scmTitle.TabIndex = 19;
            this.scmTitle.Text = "SC (mod):";
            // 
            // scmLbl
            // 
            this.scmLbl.AutoSize = true;
            this.scmLbl.Location = new System.Drawing.Point(248, 128);
            this.scmLbl.Name = "scmLbl";
            this.scmLbl.Size = new System.Drawing.Size(50, 13);
            this.scmLbl.TabIndex = 18;
            this.scmLbl.Text = "(SC mod)";
            // 
            // vkmTitle
            // 
            this.vkmTitle.AutoSize = true;
            this.vkmTitle.Location = new System.Drawing.Point(190, 115);
            this.vkmTitle.Name = "vkmTitle";
            this.vkmTitle.Size = new System.Drawing.Size(53, 13);
            this.vkmTitle.TabIndex = 17;
            this.vkmTitle.Text = "VK (mod):";
            // 
            // vkmLbl
            // 
            this.vkmLbl.AutoSize = true;
            this.vkmLbl.Location = new System.Drawing.Point(248, 115);
            this.vkmLbl.Name = "vkmLbl";
            this.vkmLbl.Size = new System.Drawing.Size(48, 13);
            this.vkmLbl.TabIndex = 16;
            this.vkmLbl.Text = "(vk mod)";
            // 
            // miscLbl
            // 
            this.miscLbl.AutoSize = true;
            this.miscLbl.Location = new System.Drawing.Point(190, 198);
            this.miscLbl.Name = "miscLbl";
            this.miscLbl.Size = new System.Drawing.Size(34, 13);
            this.miscLbl.TabIndex = 20;
            this.miscLbl.Text = "(misc)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 263);
            this.Controls.Add(this.miscLbl);
            this.Controls.Add(this.scmTitle);
            this.Controls.Add(this.scmLbl);
            this.Controls.Add(this.vkmTitle);
            this.Controls.Add(this.vkmLbl);
            this.Controls.Add(this.flagsTitle);
            this.Controls.Add(this.flagsLbl);
            this.Controls.Add(this.scancodeTitle);
            this.Controls.Add(this.scLbl);
            this.Controls.Add(this.altLbl);
            this.Controls.Add(this.altModTitle);
            this.Controls.Add(this.ctrlLbl);
            this.Controls.Add(this.ctrlModTitle);
            this.Controls.Add(this.shiftLbl);
            this.Controls.Add(this.shiftModTitle);
            this.Controls.Add(this.vkTitle);
            this.Controls.Add(this.vkCodeLbl);
            this.Controls.Add(this.rotateBBtn);
            this.Controls.Add(this.rotateTBtn);
            this.Controls.Add(this.rotateLBtn);
            this.Controls.Add(this.rotateRBtn);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rotateRBtn;
        private System.Windows.Forms.Button rotateLBtn;
        private System.Windows.Forms.Button rotateTBtn;
        private System.Windows.Forms.Button rotateBBtn;
        private System.Windows.Forms.Label vkCodeLbl;
        private System.Windows.Forms.Label vkTitle;
        private System.Windows.Forms.Label shiftModTitle;
        private System.Windows.Forms.Label shiftLbl;
        private System.Windows.Forms.Label ctrlLbl;
        private System.Windows.Forms.Label ctrlModTitle;
        private System.Windows.Forms.Label altLbl;
        private System.Windows.Forms.Label altModTitle;
        private System.Windows.Forms.Label scancodeTitle;
        private System.Windows.Forms.Label scLbl;
        private System.Windows.Forms.Label flagsTitle;
        private System.Windows.Forms.Label flagsLbl;
        private System.Windows.Forms.Label scmTitle;
        private System.Windows.Forms.Label scmLbl;
        private System.Windows.Forms.Label vkmTitle;
        private System.Windows.Forms.Label vkmLbl;
        private System.Windows.Forms.Label miscLbl;
    }
}

