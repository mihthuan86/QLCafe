
namespace QuanLyCafe
{
    partial class frmQuanlythongke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanlythongke));
            this.dgvQuanlythongke = new System.Windows.Forms.DataGridView();
            this.cbbtendouong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbtennhanvien = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnthongke = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnthongkebanchay = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dgvdouongbanchay = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn = new System.Windows.Forms.Label();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongbanbc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlythongke)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdouongbanchay)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuanlythongke
            // 
            this.dgvQuanlythongke.AllowUserToAddRows = false;
            this.dgvQuanlythongke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuanlythongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanlythongke.Location = new System.Drawing.Point(6, 20);
            this.dgvQuanlythongke.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvQuanlythongke.Name = "dgvQuanlythongke";
            this.dgvQuanlythongke.RowHeadersWidth = 51;
            this.dgvQuanlythongke.RowTemplate.Height = 29;
            this.dgvQuanlythongke.Size = new System.Drawing.Size(878, 258);
            this.dgvQuanlythongke.TabIndex = 0;
            // 
            // cbbtendouong
            // 
            this.cbbtendouong.FormattingEnabled = true;
            this.cbbtendouong.Location = new System.Drawing.Point(171, 29);
            this.cbbtendouong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbtendouong.Name = "cbbtendouong";
            this.cbbtendouong.Size = new System.Drawing.Size(223, 24);
            this.cbbtendouong.TabIndex = 8;
            this.cbbtendouong.SelectedIndexChanged += new System.EventHandler(this.cbbtendouong_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tên danh mục đồ uống:";
            // 
            // cbbtennhanvien
            // 
            this.cbbtennhanvien.FormattingEnabled = true;
            this.cbbtennhanvien.Location = new System.Drawing.Point(114, 29);
            this.cbbtennhanvien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbtennhanvien.Name = "cbbtennhanvien";
            this.cbbtennhanvien.Size = new System.Drawing.Size(250, 24);
            this.cbbtennhanvien.TabIndex = 6;
            this.cbbtennhanvien.SelectedIndexChanged += new System.EventHandler(this.cbbtennhanvien_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ:";
            // 
            // btnthongke
            // 
            this.btnthongke.Location = new System.Drawing.Point(7, 58);
            this.btnthongke.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnthongke.Name = "btnthongke";
            this.btnthongke.Size = new System.Drawing.Size(878, 29);
            this.btnthongke.TabIndex = 2;
            this.btnthongke.Text = "Thống kê";
            this.btnthongke.UseVisualStyleBackColor = true;
            this.btnthongke.Click += new System.EventHandler(this.btnthongke_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(488, 21);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(345, 22);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.Value = new System.DateTime(2021, 10, 8, 0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(102, 21);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(324, 22);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2021, 10, 8, 0, 0, 0, 0);
            // 
            // btnthongkebanchay
            // 
            this.btnthongkebanchay.Location = new System.Drawing.Point(132, 20);
            this.btnthongkebanchay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnthongkebanchay.Name = "btnthongkebanchay";
            this.btnthongkebanchay.Size = new System.Drawing.Size(366, 26);
            this.btnthongkebanchay.TabIndex = 9;
            this.btnthongkebanchay.Text = "Thống kê đồ uống bán chạy";
            this.btnthongkebanchay.UseVisualStyleBackColor = true;
            this.btnthongkebanchay.Click += new System.EventHandler(this.btnthongkebanchay_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox8);
            this.panel3.Controls.Add(this.groupBox6);
            this.panel3.Controls.Add(this.btn);
            this.panel3.Location = new System.Drawing.Point(904, 8);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(605, 443);
            this.panel3.TabIndex = 2;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dgvdouongbanchay);
            this.groupBox8.Location = new System.Drawing.Point(7, 114);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(591, 327);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Danh sách đồ uống bán chạy";
            // 
            // dgvdouongbanchay
            // 
            this.dgvdouongbanchay.AllowUserToAddRows = false;
            this.dgvdouongbanchay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdouongbanchay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdouongbanchay.Location = new System.Drawing.Point(0, 19);
            this.dgvdouongbanchay.Margin = new System.Windows.Forms.Padding(2);
            this.dgvdouongbanchay.Name = "dgvdouongbanchay";
            this.dgvdouongbanchay.RowHeadersWidth = 62;
            this.dgvdouongbanchay.RowTemplate.Height = 33;
            this.dgvdouongbanchay.Size = new System.Drawing.Size(583, 306);
            this.dgvdouongbanchay.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnthongkebanchay);
            this.groupBox6.Location = new System.Drawing.Point(7, 58);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(591, 53);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Thống kê đồ uống bán chạy";
            // 
            // btn
            // 
            this.btn.AutoSize = true;
            this.btn.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn.Location = new System.Drawing.Point(43, 10);
            this.btn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(546, 46);
            this.btn.TabIndex = 0;
            this.btn.Text = "THỐNG KÊ ĐỒ UỐNG BÁN CHẠY";
            this.btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTong
            // 
            this.txtTong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtTong.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtTong.Location = new System.Drawing.Point(547, 14);
            this.txtTong.Margin = new System.Windows.Forms.Padding(2);
            this.txtTong.Name = "txtTong";
            this.txtTong.ReadOnly = true;
            this.txtTong.Size = new System.Drawing.Size(339, 39);
            this.txtTong.TabIndex = 1;
            this.txtTong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(409, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tổng cộng";
            // 
            // txtTongbanbc
            // 
            this.txtTongbanbc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTongbanbc.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtTongbanbc.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtTongbanbc.Location = new System.Drawing.Point(274, 11);
            this.txtTongbanbc.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongbanbc.Name = "txtTongbanbc";
            this.txtTongbanbc.ReadOnly = true;
            this.txtTongbanbc.Size = new System.Drawing.Size(317, 39);
            this.txtTongbanbc.TabIndex = 13;
            this.txtTongbanbc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(136, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tổng cộng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvQuanlythongke);
            this.groupBox1.Location = new System.Drawing.Point(10, 170);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(890, 282);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách hóa đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnthongke);
            this.groupBox2.Location = new System.Drawing.Point(9, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(890, 91);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống kê theo ngày";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbbtennhanvien);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(10, 102);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(432, 63);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thống kê theo nhân viên";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbbtendouong);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(448, 102);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(451, 63);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thống kê theo danh mục đồ uống";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtTong);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(9, 451);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(890, 50);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tổng doanh thu";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.txtTongbanbc);
            this.groupBox7.Location = new System.Drawing.Point(904, 451);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(598, 50);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tổng doanh thu";
            // 
            // frmQuanlythongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 510);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmQuanlythongke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thống kê";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlythongke)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdouongbanchay)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvQuanlythongke;
        private System.Windows.Forms.Button btnthongke;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbtendouong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbtennhanvien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnthongkebanchay;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvdouongbanchay;
        private System.Windows.Forms.Label btn;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTongbanbc;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}