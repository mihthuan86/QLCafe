using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmAdAccount : Form
    {
        DataTable tableData;
        public frmAdAccount()
        {
            InitializeComponent();
        }
        private void Account_Load(object sender, EventArgs e)
        {
            load();
        }
        //ham load thong tin
        private void load()
        {
            DataProvider provider = new DataProvider();
            DataTable tableView = provider.execQuery("USP_LoadAccount");
            dgvResult.DataSource = tableView;
            tableData = provider.execQuery("select * from TAIKHOAN");
        }
        private void clear()
        {
            txtUsername.ResetText();
            txtDisplayname.ResetText();
            txtPassword.ResetText();
            txtCMND.ResetText();
            txtEmail.ResetText();
            txtSDT.ResetText();
            ckbAdmin.Checked = false;          
        }
        

        //Them tai khoan
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            {
                string username = txtUsername.Text;
                string displayname = txtDisplayname.Text;
                string password = txtPassword.Text;
                DateTime ngaysinh = dateTimePicker1.Value;
                string gioitinh = cob_GioiTinh.Text;
                string cmnd = txtCMND.Text;
                string email = txtEmail.Text;
                string sdt = txtSDT.Text;
                string type = "0";
                if (ckbAdmin.Checked == true)
                {
                    type = "1";        //admin 
                }
                DataProvider provider = new DataProvider();
                DataTable checkExist = provider.execQuery("select * from TaiKhoan where tendangnhap = '" + username+"'");
                if (checkExist.Rows.Count <= 0)
                {
                    if (username == "" || password == "")
                    {
                        MessageBox.Show("Nhập tên đăng nhập hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        provider.execNonQuery("USP_Add_Account @tendangnhap , @matkhau , @tennv , " +
                            "@ngaysinh , @gioitinh , @cmnd , @email , @sdt , @loaitk", new object[] { displayname, password, username, ngaysinh, gioitinh, cmnd, email, sdt, type });
                        MessageBox.Show("Thêm thành công!\n Tài khoản " + displayname + " đã được thêm.", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                        clear();
                    }
                }
                else
                {
                    MessageBox.Show("Đã có tên đăng nhập này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                }
            }
            /*catch
            {
                MessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        //Xoa tai khoan
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa tài khoản không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    string name = txtUsername.Text;
                    if (name == "admin")
                    {
                        MessageBox.Show("Không được Xoá tài khoản Admin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                    DataProvider provider = new DataProvider();
                    provider.execNonQuery("USP_XoaTaiKhoan @mataikhoan", new object[] { label12.Tag.ToString() });
                    MessageBox.Show("Xóa thành công!\n Tài khoản " + name + " đã được xóa.", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    clear();
                    }
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua tai khoan
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string displayname = txtDisplayname.Text;
                string password = txtPassword.Text;
                DateTime ngaysinh = Convert.ToDateTime(dateTimePicker1.Text);
                string gioitinh = cob_GioiTinh.Text;
                string cmnd = txtCMND.Text;
                string email = txtEmail.Text;
                string sdt = txtSDT.Text;
                string type = "0";
                if (ckbAdmin.Checked == true)
                {
                    type = "1";
                }
                DataProvider provider = new DataProvider();
                provider.execNonQuery("USP_SuaThongTinTaiKhoan @mataikhoan , @tendangnhap , @matkhau , " +
                    "@tennv , @ngaysinh , @gioitinh, @cmnd , @email , @sdt , " +
                    "@loaitk", new object[] { label12.Tag.ToString(), displayname, password, username, ngaysinh, gioitinh, cmnd, email, sdt, type, });
                MessageBox.Show("Chỉnh sửa thành công!\n Tài khoản đã chỉnh sửa.", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                clear();
            }
            catch
            {
                MessageBox.Show("Không sửa được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Lock_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbTrangthai.Visible == true)//mở khoá
                {
                    DialogResult ms = MessageBox.Show("Bạn có muốn mở khoá tài khoản " + txtUsername.Text + " hay không?",
                    "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                    if (ms == DialogResult.Yes)
                    {
                        DataProvider provider = new DataProvider();
                        provider.execNonQuery("USP_Unlock @id", new object[] { label12.Tag.ToString() });
                        load();
                    }
                }
                else//khoá
                {
                    DialogResult ms = MessageBox.Show("Bạn có muốn khoá tài khoản " + txtUsername.Text + " hay không?",
                    "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                    if (ms == DialogResult.Yes)
                    {
                        if (txtUsername.Text == "admin")
                        {
                            MessageBox.Show("Không được khoá tài khoản Admin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                        DataProvider provider = new DataProvider();
                        provider.execNonQuery("USP_Lock @id", new object[] { label12.Tag.ToString() });
                        load();
                        }
                    }
                }
            }
            catch{ }
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int index = e.RowIndex;
                    //label14.Text = index.ToString();
                    txtUsername.Text = tableData.Rows[index]["tendangnhap"].ToString();
                    txtDisplayname.Text = tableData.Rows[index]["tennv"].ToString();
                    txtPassword.Text = tableData.Rows[index]["matkhau"].ToString();
                    dateTimePicker1.Text = tableData.Rows[index]["ngaysinh"].ToString();
                    cob_GioiTinh.Text = tableData.Rows[index]["gioitinh"].ToString();
                    txtCMND.Text = tableData.Rows[index]["cmnd"].ToString();
                    txtEmail.Text = tableData.Rows[index]["email"].ToString();
                    txtSDT.Text = tableData.Rows[index]["sdt"].ToString();
                    if (tableData.Rows[index]["loaitk"].ToString() == "1")
                        ckbAdmin.Checked = true;
                    else
                        ckbAdmin.Checked = false;
                    if (tableData.Rows[index]["trangthaitk"].ToString() == "1")
                    {
                        lbTrangthai.Text = "Tài khoản này đã bị khoá";
                        lbTrangthai.ForeColor = ColorTranslator.FromHtml("red");
                        lbTrangthai.Visible = true;
                    }
                    else
                    {
                        lbTrangthai.Visible = false;
                    }
                    label12.Tag = tableData.Rows[index][0].ToString();
                }
            }
            catch { }
        }
    }
}
