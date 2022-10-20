
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
    public partial class ReplaceTable : Form
    {
        private DataTable table;
        private string idStaff;
        private int checkF = 1;
        private int checkT = -1;
        public ReplaceTable()
        {
            InitializeComponent();
        }
        public ReplaceTable(string nameTableFrom,string idTableFrom, string idStaff) : this()
        {
            loadDataTable(idTableFrom);
            cbbTableFrom.Text = nameTableFrom;
            this.idStaff = idStaff;
        }

        //Load len cho nguoi dung chon ban
        private void loadDataTable(string idTable)
        {
            int index = 0;
            DataProvider provider = new DataProvider();
            table = provider.execQuery("select maban,tenban from ban");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbbTableFrom.Items.Add(table.Rows[i][1].ToString());
                if (table.Rows[i][0].ToString() == idTable)
                {
                    index = i;
                }
                cbbTableTo.Items.Add(table.Rows[i][1].ToString());
            }

            bill_load(index, txtTotal, panelFrom);
        }
        private int bill_load(int index, TextBox txtTotal, Panel panel)
        {
            panel.Controls.Clear();
            txtTotal.Text = "";
            DataProvider provider = new DataProvider();
            DataTable tableLoad = provider.execQuery("USP_LoadDSHoaDon @maban , @trangthai", new object[] { table.Rows[index][0].ToString(), 0 });
            //Load thong tin cac mon trong bill 
            if (table.Rows.Count > 0)
            {
                int y = 10;
                for (int i = 0; i < tableLoad.Rows.Count; i++)
                {
                    Label lbl = new Label()
                    {
                        Name = "btnFB" + i,
                        Text = (i + 1) + ".  " + tableLoad.Rows[i][1].ToString() + "  X  " + tableLoad.Rows[i][2].ToString() + "        " + tableLoad.Rows[i][3].ToString(),
                        Width = panel.Width - 20,
                        Height = 20,
                        Location = new Point(5, y)
                    };
                    y += 25;
                    panel.Controls.Add(lbl);
                    var resutl = provider.execScalar("USP_TongTienHD @mahd", new object[] { tableLoad.Rows[0][0] });
                    txtTotal.Text = resutl.ToString();
                }
                //MessageBox.Show(index.ToString());
                return 1;
            }
            return -1;
        }
        //Nhan nut Chuyen ban
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Dieu kien chuyen ban
            if (checkF==1 && checkT==1  && cbbTableFrom.Text != cbbTableTo.Text && cbbTableTo.Text != "")
            {
                DialogResult ms = MessageBox.Show("Bạn có muốn chuyển bàn " + cbbTableFrom.Text + " đến bàn " + cbbTableTo.Text + " không?", 
                    "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                //chuyen ban
                if (ms == DialogResult.Yes)
                {
                    moveTable();
                    MessageBox.Show("Đã chuyển bàn thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (ms == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                if (cbbTableTo.SelectedIndex != -1)
                {
                    gopban();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn lại bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void gopban()
        {
            DialogResult ms = MessageBox.Show("Bàn chuyển tới đã mở, bạn có muốn gộp bàn không?", 
                "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
            if (ms == DialogResult.Yes)
            {
                PlusTable addF = new PlusTable(cbbTableFrom.SelectedText, table.Rows[cbbTableFrom.SelectedIndex][0].ToString());
                addF.ShowDialog();
                
                this.Close();
            }
            else if (ms == DialogResult.No)
            {
                this.Close();
            }
        }

        //Ham chuyen ban
        private void moveTable()
        {
            int indexF = cbbTableFrom.SelectedIndex;
            int indexT = cbbTableTo.SelectedIndex;
            object idBillFrom;
            DataProvider provider = new DataProvider();           
            provider.execNonQuery("Update Ban set trangthaiban = 1 where maban = " + table.Rows[indexT][0].ToString());//Mở bàn       
            idBillFrom = provider.execScalar("select mahoadon,maban,trangthaihoadon from hoadon where maban = "
                + table.Rows[indexF][0].ToString() + " and trangthaihoadon=0").ToString();
            provider.execNonQuery("update hoadon set maban = "
                + table.Rows[indexT][0].ToString() + " where mahoadon = " + idBillFrom.ToString());
            provider.execNonQuery("Update Ban set trangthaiban = 0 where maban = " + table.Rows[indexF][0].ToString());//Mở bàn       
        }


        //Kiem tra ban A
        private void cbbTableFrom_TextChanged(object sender, EventArgs e)
        {
            int index = cbbTableTo.SelectedIndex;
            if(index!=-1)
               checkF = bill_load(index, txtTotal, panelFrom);
        }
        //Kiem tra ban B
        private void cbbTableTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCheckTableB();
        }
        private void loadCheckTableB()
        {
            int index = cbbTableTo.SelectedIndex;
            DataProvider provider = new DataProvider();
            DataTable tableTo = provider.execQuery("select * from ban where maban =" 
                + table.Rows[index][0].ToString());
            if (tableTo.Rows[0][2].ToString() == "0")
            {
                checkT = 1;
            }
            else checkT = -1;
        }
    }
}
