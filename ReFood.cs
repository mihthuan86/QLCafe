
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
    public partial class ReFood : Form
    {
        private DataTable datatable, table;
        private bool condition = true;
        public ReFood()
        {
            InitializeComponent();
        }
        public ReFood(string nameTableFrom,string idTableFrom)
            : this()
        {
            loadDataTable();
            cbbTable.Text = nameTableFrom;
            label7.Tag = idTableFrom;
            label7.Visible = false;
            loadFood();
        }
        //Load len cho nguoi dung chon ban
        private void loadDataTable()
        {
            DataProvider provider = new DataProvider();
            table = provider.execQuery("select maban,tenban from ban");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbbTable.Items.Add(table.Rows[i][1].ToString());
            }
        }

        
        private void cbbTable_TextChanged(object sender, EventArgs e)
        {
            if (cbbTable.SelectedIndex != -1)
            {
                label7.Tag = table.Rows[cbbTable.SelectedIndex][0];
                loadFood();
            }
        }
        private void loadFood()
        {
            DataProvider provider = new DataProvider();
            datatable = provider.execQuery("USP_LaychitietHDTheoBan @maban , @trangthai", new object[] { label7.Tag.ToString(), "0" });
            var resutl = provider.execScalar("USP_TongTienHD @mahd", new object[] { datatable.Rows[0][0] });
            txtTotal.Text = resutl.ToString();
            if (cbbFood.Items.Count < datatable.Rows.Count)
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    cbbFood.Items.Add(datatable.Rows[i][2].ToString());
                }
        }
        private void cbbFood_TextChanged(object sender, EventArgs e)
        {
            cbbCount.Value = Int16.Parse(datatable.Rows[cbbFood.SelectedIndex][3].ToString());
        }

        //Nhan nut va thuc hien giam mon
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cbbCountReF.Value <= cbbCount.Value && condition == true && cbbFood.Text != "")
            {
                DialogResult ms = MessageBox.Show("Bạn có muốn bỏ " + cbbCountReF.Text + " món " + cbbFood.Text + " ở bàn " + cbbTable.Text + " không?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                if (ms == DialogResult.Yes)
                {
                    //Bo mon
                    reFood();
                    MessageBox.Show("Đã bỏ món thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (ms == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Không thể giảm món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //sua bill
        private void reFood()
        {
            //sua bill            
            DataProvider provider = new DataProvider();
            provider.execNonQuery("USP_DeleFood @mahd , @madu , @sl",
                new object[] { datatable.Rows[0][0].ToString(), datatable.Rows[cbbFood.SelectedIndex][1].ToString(),cbbCountReF.Value.ToString() });
            var count = provider.execScalar("Select count(*) from chitiethoadon where mahoadon = " + datatable.Rows[0][0].ToString());
            if (count.ToString() == "0")
            {
                provider.execNonQuery("Update Hoadon set trangthaihoadon = -1 where mahoadon=" + datatable.Rows[0][0].ToString());
                provider.execNonQuery("Update Ban set trangthaiban = 0 where maban=" + label7.Tag.ToString());
            }

        }


        //Huy bo
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
