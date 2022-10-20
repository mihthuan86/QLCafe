using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCafe
{ 
    public partial class frmQuanlythongke : Form
    {
        DataProvider provider = new DataProvider();
        public frmQuanlythongke()
        {
            InitializeComponent();
            loadTenNV();
            loadDMDoUong();
        }
        //load ten nv
        void loadTenNV()
        {
            cbbtennhanvien.DataSource = provider.execQuery("select * from taikhoan");
            cbbtennhanvien.DisplayMember = "tennv";
            cbbtennhanvien.ValueMember = "mataikhoan";
            cbbtennhanvien.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
        //load dm
        void loadDMDoUong()
        {
            cbbtendouong.DataSource = provider.execQuery("select * from DANHMUCDOUONG");
            cbbtendouong.DisplayMember = "tendanhmuc";
            cbbtendouong.ValueMember = "madanhmuc";
        }
        //Tạo sự kiện thống kê
        private void btnthongke_Click(object sender, EventArgs e)
        {
            double tongcong = 0;                    
            DateTime ngay1 = dateTimePicker1.Value;
            DateTime ngay2 = dateTimePicker2.Value;            
            DataTable dt = provider.execQuery("USP_ThongKe @giolapfrom , @giolapto",new object[] {ngay1,ngay2});
            dgvQuanlythongke.DataSource = dt;
            foreach (DataRow item in dt.Rows)
            {
                tongcong += int.Parse(item[4].ToString());
            }
            txtTong.Text = tongcong.ToString("#,###"); 
        }
        //Tạo sự kiện khi click cb
        private void cbbtennhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            double tongcong = 0;            
            DateTime ngay1 = dateTimePicker1.Value;
            DateTime ngay2 = dateTimePicker2.Value;
            if (cbbtennhanvien.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            int id = Convert.ToInt32(cbbtennhanvien.SelectedValue.ToString());
            DataTable dt = provider.execQuery("USP_ThongKeTheoNhanVien @id , @giolapfrom, @giolapto", new object[] {id,ngay1,ngay2});
            dgvQuanlythongke.DataSource = dt;
            foreach (DataRow item in dt.Rows)
            {
                tongcong += int.Parse(item[4].ToString());
            }
            txtTong.Text = tongcong.ToString("#,###");

        }
        //Tạo sự kiện khi click cb
        private void cbbtendouong_SelectedIndexChanged(object sender, EventArgs e)
        {
            double tongcong = 0;           
            if (cbbtendouong.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            int id = Convert.ToInt32(cbbtendouong.SelectedValue.ToString());
            DataTable dt = provider.execQuery("USP_ThongKeTheoDanhMuc @id",new object[] {id});
            dgvQuanlythongke.DataSource = dt;
            foreach (DataRow item in dt.Rows)
            {
                tongcong += int.Parse(item[4].ToString());
            }
            txtTong.Text = tongcong.ToString("#,###");
        }

        private void btnthongkebanchay_Click(object sender, EventArgs e)
        {
            double tongcong = 0;

            DataTable dt = provider.execQuery("USP_ThongKeBanChay");
            dgvdouongbanchay.DataSource = dt;
            foreach (DataRow item in dt.Rows)
            {
                tongcong += int.Parse(item[2].ToString());
            }
            txtTongbanbc.Text = tongcong.ToString("#,###");
        }
    }
}
