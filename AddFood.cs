
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmAddFood : Form
    {
        string idTable;
        string idFood;
        string idStaff;
        public frmAddFood()
        {
            InitializeComponent();
        }
        public frmAddFood(string idTable, string idFood, string sttTable,string nameTable,string nameFood,string idStaff)
            : this()
        {
            loadFood();
            //chon gia tri goi y
            txtBan.Text = nameTable;
            cbbFood.Text = nameFood;
            txtSTT.Text = sttTable;
            this.idTable = idTable;
            this.idFood = idFood;
            this.idStaff = idStaff;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ham load thong tin
        private void loadFood()
        {
            DataProvider dataProvider = new DataProvider();
            DataTable table = dataProvider.execQuery("select madouong,tendouong from DOUONG");
            cbbFood.DataSource = table;
            cbbFood.DisplayMember = "tendouong";
            cbbFood.ValueMember = "madouong";
        }

        //Ham Mở bàn
        public void openTable()
        {
            DataProvider dataProvider = new DataProvider();
            dataProvider.execNonQuery("Update Ban set trangthaiban = 1 where maban ="+idTable);//Mở bàn
            dataProvider.execNonQuery("USP_InsertBill @matk , @maban", new object[] {idStaff, idTable });//thêm bill
        }

        //Them mon moi
        public void addFood(string idBill)
        {
            DataProvider dataProvider = new DataProvider();
            dataProvider.execNonQuery(" USP_InsertBillInfo @mahd , @madu , @sl",new object[] { idBill, cbbFood.SelectedValue.ToString(), cbbCount.Value.ToString()});
        }
       //khi nhan nut chap nhan them mon
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataProvider dataProvider = new DataProvider();
            string idBill;
            try
            {
                int sl = int.Parse(cbbCount.Value.ToString());
                if (sl < 10 && sl > 0)
                {
                    //Kiem tra ban trong k
                    if (txtSTT.Text == "TRỐNG")
                    {
                        //Neu ban trong thi mo ban moi va them mon
                        openTable();
                    }
                    idBill = dataProvider.execScalar("select mahoadon,maban,trangthaihoadon from hoadon where maban=" + idTable + " and trangthaihoadon=0").ToString();
                    addFood(idBill);
                    this.Close();
                    MessageBox.Show("Thêm món thành công!", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại số lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch 
            {
                MessageBox.Show("Thêm món không thành công!", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
   
        //Ham tra ve don gia mon hien tai
    }
}
