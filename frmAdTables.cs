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
    public partial class frmAdTables : Form
    {
        public frmAdTables()
        {
            InitializeComponent();
        }

        private void frmAdTables_Load(object sender, EventArgs e)
        {
            loadTable();
        }
        //ham load thong tin
        private void loadTable()
        {
            try
            {
                DataProvider provider = new DataProvider();
                DataTable table = provider.execQuery("select maban as \"Mã Bàn\", tenban as \"Tên Bàn\", trangthaiban as \"Trang thái bàn\"\r\nfrom Ban");
                dgvResult.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Không thể tải bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //click vao bang
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvResult.CurrentCell.RowIndex;
            lblText.Text = dgvResult.Rows[t].Cells[1].Value.ToString();
            lblText.Tag = dgvResult.Rows[t].Cells[0].Value.ToString();
        }

        //Them ban
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                if (name != "")
                {
                    DataProvider provider = new DataProvider();

                    provider.execNonQuery("USP_Add_Table @tenban", new object[] { name });

                    provider.execNonQuery("USP_Add_Table @tenban", new object[] {name});
                    loadTable();
                    MessageBox.Show("Đã thêm bàn thành công!", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tên bàn trống kìa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Không thể thêm bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xoa ban
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    DataProvider provider = new DataProvider();

                    provider.execNonQuery("USP_Del_Table @tenban", new object[] { lblText.Text });


                   
                    provider.execNonQuery("USP_Del_Table @tenban", new object[] { lblText.Text });
                
                    loadTable();
                    MessageBox.Show("Đã xóa bàn thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Không thể xóa bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua ban
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    DataProvider provider = new DataProvider();
                    provider.execNonQuery("USP_Update_Table @maban , @tenban", new object[] { lblText.Tag.ToString(), txtName.Text.ToString() });
                    loadTable();
                    MessageBox.Show("Đã sửa bàn thành công!", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.ResetText();
                }
                else
                {
                    MessageBox.Show("Tên bàn trống kìa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)

            /*{
                MessageBox.Show(ex.Message);
            }*/

            {
                MessageBox.Show(ex.Message);
            }
            /*{
                MessageBox.Show("Không thể sửa bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}