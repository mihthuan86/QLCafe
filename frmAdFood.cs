using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmAdFood : Form
    {
        DataTable tableData;
        public frmAdFood()
        {
            InitializeComponent();
        }

        private void frmAdFood_Load(object sender, EventArgs e)
        {
            loadCobCate(cbbAddCate);
            load();
        }

        //ham load thong tin
        private void load()
        {
            try
            {
                DataProvider provider = new DataProvider();
                DataTable tableView = provider.execQuery("USP_LayTTDoUong");
                dgvResult.DataSource = tableView;
                tableData = provider.execQuery("select * from douong");
            }
            catch
            {
                MessageBox.Show("Tải không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //reset
        private void clear()
        {
            txtAddName.ResetText();
            cbbAddCate.ResetText();
            nudAddPrice.Value = 1000;
            cbbAddCate.Focus();
        }
        //click table

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int index = e.RowIndex;
                    txtAddName.Text = tableData.Rows[index][1].ToString();
                    cbbAddCate.SelectedValue = tableData.Rows[index][2].ToString();
                    nudAddPrice.Value = Int32.Parse(tableData.Rows[index][3].ToString());
                    label7.Tag = tableData.Rows[index][0].ToString();
                }
            }
            catch
            {
                //MessageBox.Show("Lỗi data!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //them mon
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                float price = Convert.ToInt64(nudAddPrice.Value);
                if (price < 100000 && price > 1000)
                {
                    string name = txtAddName.Text;
                    string nameCate = cbbAddCate.SelectedValue.ToString();
                    DataProvider provider = new DataProvider();
                    provider.execNonQuery("USP_Add_Food @tendouong , @madanhmuc , @dongia", new object[] { name, nameCate, price });
                    MessageBox.Show("Thêm thành công", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    load();
                }
                else
                {
                    MessageBox.Show("Kiểm tra đơn giá", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Xoa mon
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    string name = txtAddName.Text;
                    DataProvider provider = new DataProvider();
                    provider.execNonQuery("USP_Del_Food @tendouong", new object[] { name });
                    MessageBox.Show("Xóa thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    load();
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua mon
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
            string name = txtAddName.Text;
            string nameCate = cbbAddCate.SelectedValue.ToString();
            string price = nudAddPrice.Value.ToString();
            DataProvider provider = new DataProvider();

            provider.execNonQuery("USP_Update_Food @madouong , @tendouong  , @dongia", new object[] { label7.Tag.ToString(), name, price });
            MessageBox.Show("Sửa thành công!", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
            load();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadCobCate(ComboBox cobCate)
        {
            try
            {
                DataProvider provider = new DataProvider();               
                cobCate.DataSource = provider.execQuery("select * from DANHMUCDOUONG");
                cobCate.DisplayMember = "tendanhmuc";
                cobCate.ValueMember = "madanhmuc";
                //cobCate.Items.Add("Tất cả");
            }
            catch (Exception)
            {
                MessageBox.Show("Load dữ liệu không được");
            }
        }

        private void cbbAddCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                int textCate = (int)cbbAddCate.SelectedValue;
                DataProvider provider = new DataProvider();
                if(cbbAddCate.SelectedText.ToString() =="Tất Cả")
                {
                    load();
                }
                else
                {
                DataTable table = provider.execQuery("USP_LayTTDoUongTheoDanhMuc @madm",new object[] { textCate });
                dgvResult.DataSource = table;
                tableData = provider.execQuery("select * from douong where madanhmuc="+textCate);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);  
            }
        }

        private void cbbAddCate_TextChanged(object sender, EventArgs e)
        {
            /*int textCate = (int)cbbAddCate.SelectedValue;
            DataProvider provider = new DataProvider();
            DataTable table = provider.execQuery("USP_LayTTDoUongTheoDanhMuc @madm", new object[] { textCate });
            dgvResult.DataSource = table;*/
        }
    }
}