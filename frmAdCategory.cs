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
    public partial class frmAdCategory : Form
    {
        public frmAdCategory()
        {
            InitializeComponent();
        }

        private void frmAdCategory_Load(object sender, EventArgs e)
        {
            loadCategory();
        }

        //ham load thong tin
        private void loadCategory()
        {
            try
            {
                DataProvider provider = new DataProvider();
                DataTable table = provider.execQuery("select * from DANHMUCDOUONG");
                dgvResult.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Không thể tải dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Them moi
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                if (name != "")
                {
                    DataProvider provider = new DataProvider();
                    provider.execNonQuery("USP_Add_Category @tendanhmuc", new object[] { name });
                    MessageBox.Show("Thêm thành công!", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.ResetText();
                    loadCategory();
                }
                else
                {
                    MessageBox.Show("Tên mới trống!", "Thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Khi click chon => datagidview
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvResult.CurrentCell.RowIndex;
            lblText.Text = dgvResult.Rows[t].Cells[1].Value.ToString();
            lblText.Tag = dgvResult.Rows[t].Cells[0].Value.ToString();
        }

        //Xoa 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    DataProvider provider = new DataProvider();
                    provider.execNonQuery("USP_Del_Category @tendanhmuc", new object[] { lblText.Text });
                    MessageBox.Show("Xóa thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCategory();
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Không thể xóa danh mục này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //cHINH SUA
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider provider = new DataProvider();
                provider.execNonQuery("USP_Update_Category @madanhmuc , @tendanhmuc", new object[] { lblText.Tag.ToString(), txtName.Text.ToString() });
                MessageBox.Show("Sửa thành công!", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadCategory();
                txtName.ResetText();
            }
            catch
            {
                MessageBox.Show("Không thể chỉnh sửa danh mục này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}