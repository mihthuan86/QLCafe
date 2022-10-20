
using QuanLyCafe;
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
    public partial class PlusTable : Form
    {
        private DataTable table;     
        int checkA = 1;
        int checkB = -1;
        public PlusTable()
        {
            InitializeComponent();
        }
        public PlusTable(string nameTableFrom,string idTableFrom)
            : this()
        {
            loadDataTable(idTableFrom);
            cbbTableA.Text = nameTableFrom;
        }

        //Load len cho nguoi dung xem thoi
        private void loadDataTable(string idTable)
        {
            int index=0;
            DataProvider provider = new DataProvider();
            table = provider.execQuery("select maban,tenban from ban");          
            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbbTableA.Items.Add(table.Rows[i][1].ToString());
                if(table.Rows[i][0].ToString() == idTable)
                {
                    index = i;
                }
                cbbTableB.Items.Add(table.Rows[i][1].ToString());
            }

            bill_load(index,txtTotalA,panelA);
        }

        //Huy bo
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int bill_load(int index,TextBox txtTotal,Panel panel)
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
        //Ham load cac mon ban A -- ban chuyen
        private void cbbTableA_TextChanged(object sender, EventArgs e)
        {
            int index = cbbTableA.SelectedIndex;
            
            if(index!=-1)
             checkA = bill_load(index,txtTotalA,panelA);
           /*}
            catch(Exception ex)
            {
                //Dieu kien sai
                //MessageBox.Show("Không thể chọn bàn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(ex.Message);
                conditionA = false;
*/        }     
        //Ham load cac mon ban B --ban den
        private void cbbTableB_TextChanged(object sender, EventArgs e)
        {
            int index = cbbTableB.SelectedIndex;         
            if (index != -1)
               checkB = bill_load(index, txtTotalB, panelB);

            /* try
             {
                 //DK dung
                 DataProvider provider = new DataProvider();
                 datatableB = provider.loadFoodTable(cbbTableB.Text);
                 dgvTableB.DataSource = datatableB;
                 txtTotalB.Text = datatableB.Rows[0][2].ToString();
                 conditionB = true;
             }
             catch
             {
                 //DK sai
                 MessageBox.Show("Không thể chọn bàn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 conditionB = false;
             }*/
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Kiem tra dieu kien truoc
            if (cbbTableA.Text != cbbTableB.Text && checkA==1 && checkB==1)
            {
                DialogResult ms = MessageBox.Show("Bạn có muốn gộp bàn " + cbbTableA.Text + " vào bàn " + cbbTableB.Text + " không?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                if (ms == DialogResult.Yes)
                {
                    //gop ban
                    plussTable();
                    MessageBox.Show("Đã chuyển bàn gộp thành công ", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (ms == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lại bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ham gộp ban
        private void plussTable()
        {
            int indexA = cbbTableA.SelectedIndex;
            int indexB = cbbTableB.SelectedIndex;
            DataProvider provider = new DataProvider();
            DataTable tableA = provider.execQuery("USP_LaychitietHDTheoBan @maban , @trangthai", new object[] { table.Rows[indexA][0].ToString(), 0 });
            //insertA->B
            object hdB = provider.execScalar("select mahoadon from hoadon where maban =" + table.Rows[indexB][0].ToString() + " and trangthaihoadon = 0");
            for(int i = 0; i < tableA.Rows.Count; i++)
            {
                provider.execNonQuery("USP_InsertBillInfo @mahd , @madu , @sl",
                    new object[] { hdB.ToString(), tableA.Rows[i][1].ToString(), tableA.Rows[i][3].ToString() });
            }

            provider.execNonQuery("USP_XoaBill @mahoadon", new object[] { tableA.Rows[0][0] });
           
        }
    }
}
