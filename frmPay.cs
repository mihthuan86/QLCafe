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
    public partial class frmPay : Form
    {
        string idbill = "";
        public frmPay()
        {
            InitializeComponent();
        }
        public frmPay(string nameT,string idT,string Total)
            : this()
        {
            txtNameTable.Text = nameT;
            txtNameTable.Tag = idT;
            txtTotal.Text = Total;
            loadDataBill();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Load len cho nguoi dung xem thoi
        
        private void loadDataBill()
        {
            try
            {
                //Don rac
                pnlBill.Controls.Clear();
                DataProvider dataProvider = new DataProvider();
                DataTable table = dataProvider.execQuery("USP_LoadDSHoaDon @maban , @trangthai", new object[] { txtNameTable.Tag.ToString() , 0 });
                //Load thong tin cac mon trong bill 
                int y = 10;
                idbill = table.Rows[0][0].ToString();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Label lbl = new Label()
                    {
                        Name = "btnFB" + i,                     
                        Text = (i + 1) + ".  " + table.Rows[i][1].ToString() + "  X  " + table.Rows[i][2].ToString()+"        " + table.Rows[i][3].ToString(),
                        Width = pnlBill.Width - 20,
                        Height = 20,
                        Location = new Point(5, y)
                    };
                    y += 25;
                    pnlBill.Controls.Add(lbl);
                }
            }
            catch
            {
            }
        }

        //nhan nut chap nhan thanh toan
        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thanh toán " + txtNameTable.Text + "\nTổng tiền: " + txtTotal.Text + " VNĐ", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
            if (ms == DialogResult.Yes)
            {
                //Tih tien
                setTableNull();
                ConfirmBill();
                MessageBox.Show("Đã thanh toán " + txtNameTable.Text, "Xong",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else if (ms == DialogResult.No)
            {
                this.Close();
            }
        }

        //set ban ve rong
        public void setTableNull()
        {
            DataProvider dataProvider = new DataProvider();
            dataProvider.execNonQuery("Update Ban set trangthaiban = 0 where maban=" + txtNameTable.Tag.ToString());
        }

        //Xoa het bill trong ban
        public void ConfirmBill()
        {
            DataProvider dataProvider = new DataProvider();
            dataProvider.execNonQuery("Update Hoadon set trangthaihoadon = 1 where mahoadon=" + idbill);
        }
    }
}
