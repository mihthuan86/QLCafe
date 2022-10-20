using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{

    public partial class frmLogin : Form
    {
        DataProvider dataProvider;
        public frmLogin()
        {
            InitializeComponent();
            dataProvider = new DataProvider();
        }
        public bool DangNhap(string tendangnhap, string matkhau)
        {
            DataTable dt = dataProvider.execQuery("USP_Dangnhap @tendangnhap , @matkhau ", new object[] { tendangnhap, matkhau });
            return dt.Rows.Count > 0;
        }

        public DataTable LayTaiKhoan(string tendangnhap)
        {
            DataTable dt = dataProvider.execQuery("select * from TAIKHOAN where tendangnhap = '" + tendangnhap + "'");

            return dt;
        }
        public bool KiemtrataikhoanBiKhoa(string tendn)
        {
            DataTable dt = dataProvider.execQuery("select * from dbo.TAIKHOAN where tendangnhap = '" + tendn + "' and trangthaitk = 1");
            return dt.Rows.Count > 0;
        }
        //Show hoặc Hide mật khẩu
        private void ckbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShow.Checked)
            {
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true;
            }
        }
        //Button Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Xác nhận thoát
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        //Button Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string tendangnhap = txtUserName.Text;
            string matkhau = txtPassWord.Text;
            if (txtUserName.Text == "" || txtPassWord.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (KiemtrataikhoanBiKhoa(tendangnhap))
            {
                MessageBox.Show("Tài khoản này đã bị khóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DangNhap(tendangnhap, matkhau))
            {
                DataTable tk = LayTaiKhoan(tendangnhap);
                frmMain f = new frmMain(tk);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        
    }
}
