namespace QuanLyCafe
{
    partial class PlusTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlusTable));
            this.btnAccept = new System.Windows.Forms.Button();
            this.groupBoxA = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalA = new System.Windows.Forms.TextBox();
            this.cbbTableA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalB = new System.Windows.Forms.TextBox();
            this.cbbTableB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelA = new System.Windows.Forms.Panel();
            this.panelB = new System.Windows.Forms.Panel();
            this.groupBoxA.SuspendLayout();
            this.groupBoxB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Silver;
            this.btnAccept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccept.BackgroundImage")));
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAccept.Location = new System.Drawing.Point(417, 138);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(82, 75);
            this.btnAccept.TabIndex = 14;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // groupBoxA
            // 
            this.groupBoxA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBoxA.Controls.Add(this.panelA);
            this.groupBoxA.Controls.Add(this.label4);
            this.groupBoxA.Controls.Add(this.label3);
            this.groupBoxA.Controls.Add(this.txtTotalA);
            this.groupBoxA.Controls.Add(this.cbbTableA);
            this.groupBoxA.Controls.Add(this.label1);
            this.groupBoxA.Location = new System.Drawing.Point(12, 12);
            this.groupBoxA.Name = "groupBoxA";
            this.groupBoxA.Size = new System.Drawing.Size(399, 442);
            this.groupBoxA.TabIndex = 24;
            this.groupBoxA.TabStop = false;
            this.groupBoxA.Text = "Từ bàn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 22);
            this.label4.TabIndex = 25;
            this.label4.Text = "VNĐ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(95, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tổng:";
            // 
            // txtTotalA
            // 
            this.txtTotalA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalA.Location = new System.Drawing.Point(163, 82);
            this.txtTotalA.Name = "txtTotalA";
            this.txtTotalA.Size = new System.Drawing.Size(158, 21);
            this.txtTotalA.TabIndex = 23;
            this.txtTotalA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbbTableA
            // 
            this.cbbTableA.BackColor = System.Drawing.Color.Silver;
            this.cbbTableA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTableA.FormattingEnabled = true;
            this.cbbTableA.Location = new System.Drawing.Point(163, 36);
            this.cbbTableA.Name = "cbbTableA";
            this.cbbTableA.Size = new System.Drawing.Size(219, 30);
            this.cbbTableA.TabIndex = 21;
            this.cbbTableA.TextChanged += new System.EventHandler(this.cbbTableA_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(80, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "Số bàn:";
            // 
            // groupBoxB
            // 
            this.groupBoxB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBoxB.Controls.Add(this.panelB);
            this.groupBoxB.Controls.Add(this.label2);
            this.groupBoxB.Controls.Add(this.label5);
            this.groupBoxB.Controls.Add(this.txtTotalB);
            this.groupBoxB.Controls.Add(this.cbbTableB);
            this.groupBoxB.Controls.Add(this.label6);
            this.groupBoxB.Location = new System.Drawing.Point(505, 12);
            this.groupBoxB.Name = "groupBoxB";
            this.groupBoxB.Size = new System.Drawing.Size(403, 442);
            this.groupBoxB.TabIndex = 25;
            this.groupBoxB.TabStop = false;
            this.groupBoxB.Text = "Vào bàn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "VNĐ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(95, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 22);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tổng:";
            // 
            // txtTotalB
            // 
            this.txtTotalB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalB.Location = new System.Drawing.Point(163, 82);
            this.txtTotalB.Name = "txtTotalB";
            this.txtTotalB.Size = new System.Drawing.Size(160, 21);
            this.txtTotalB.TabIndex = 23;
            this.txtTotalB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbbTableB
            // 
            this.cbbTableB.BackColor = System.Drawing.Color.Silver;
            this.cbbTableB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTableB.FormattingEnabled = true;
            this.cbbTableB.Location = new System.Drawing.Point(163, 36);
            this.cbbTableB.Name = "cbbTableB";
            this.cbbTableB.Size = new System.Drawing.Size(221, 30);
            this.cbbTableB.TabIndex = 21;
            this.cbbTableB.TextChanged += new System.EventHandler(this.cbbTableB_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(80, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Từ bàn:";
            // 
            // panelA
            // 
            this.panelA.Location = new System.Drawing.Point(34, 126);
            this.panelA.Name = "panelA";
            this.panelA.Size = new System.Drawing.Size(346, 296);
            this.panelA.TabIndex = 26;
            // 
            // panelB
            // 
            this.panelB.Location = new System.Drawing.Point(22, 126);
            this.panelB.Name = "panelB";
            this.panelB.Size = new System.Drawing.Size(346, 296);
            this.panelB.TabIndex = 27;
            // 
            // PlusTable
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(926, 472);
            this.Controls.Add(this.groupBoxB);
            this.Controls.Add(this.groupBoxA);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlusTable";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gộp bàn";
            this.TopMost = true;
            this.groupBoxA.ResumeLayout(false);
            this.groupBoxA.PerformLayout();
            this.groupBoxB.ResumeLayout(false);
            this.groupBoxB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.GroupBox groupBoxA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalA;
        private System.Windows.Forms.ComboBox cbbTableA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalB;
        private System.Windows.Forms.ComboBox cbbTableB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelA;
        private System.Windows.Forms.Panel panelB;
    }
}