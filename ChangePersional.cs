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
    public partial class ChangePersional : Form
    {
        public string matk;
        public ChangePersional()
        {
            InitializeComponent();
        }
        public ChangePersional(string user,string name,string pass,string matk):this()
        {
            //load thog tin len
            txtUser.Text = user;
            txtName.Text = name;
            txtPass.Text = pass;
            this.matk = matk;
        }

        //Dong
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Luu tt moi
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                Save(txtUser.Text, txtName.Text, txtPass.Text);
                MessageBox.Show("Đã thay đổi", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Thông tin không hợp lệ", "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ham Luu tt moi
        private void Save(string user,string name,string pass)
        {
            DataProvider provider = new DataProvider();
            provider.execNonQuery("USP ChangeAccount @matk , @ten , @mk , @tennv",new object[] {matk,user,name,pass});
        }
    }
}
