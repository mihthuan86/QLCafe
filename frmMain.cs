using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace QuanLyCafe
{
    public partial class frmMain : Form
    {
        
        //username va password
        private string username;
        private string password;
        //Bill
        string strBill;
        public frmMain()
        {
            InitializeComponent();
            //Load nhanh danh sach ban va thuc don
            loaddataTable();
            loaddataCategory();
            timer1.Start();
            
        }
      
        public frmMain(DataTable tk) : this()
        {
            username = tk.Rows[0][1].ToString();
            password = tk.Rows[0][2].ToString();
            lblName.Text = tk.Rows[0][3].ToString();
            lblName.Tag = tk.Rows[0][0].ToString();
            if (tk.Rows[0][9].ToString()== "1")
            {
                lblName.ForeColor = ColorTranslator.FromHtml("red");
                tmiAdmin.Visible = true;
            }
            timer1.Start();
           
        }

        //Su kien thoat from
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        //Ham Load TABLE 
        private void loaddataTable()
        {           
            try
            {
                pnlTable.Controls.Clear();
                DataProvider dataProvider = new DataProvider();
                DataTable table = dataProvider.execQuery("USP_LayDanhSachBan");              
                int x = 10;
                int y = 10;
                for (int i = 0; i < table.Rows.Count; i++)
                {                   
                    Button btn = new Button()
                    {
                        Name = "btnTable" + i,
                        Text = table.Rows[i][1].ToString(),
                        Tag = table.Rows[i][0].ToString(),
                        Width = 100,
                        Height = 50,
                        Location = new Point(x, y),
                    };
                    //Set trang thai ban
                    if (table.Rows[i][2].ToString() == "0")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("snow");
                        //Ban Trong contextmenu 2
                        btn.ContextMenuStrip = cmnSubTable2;
                    }
                    else if (table.Rows[i][2].ToString() == "1")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("lime");
                        //Ban Trong contextmenu full option
                        btn.ContextMenuStrip = cmnSubTable;
                    }
                    else if (table.Rows[i][2].ToString() == "2")
                    {
                        btn.BackColor = ColorTranslator.FromHtml("red");
                        //Ban Trong contextmenu khoa
                        btn.ContextMenuStrip = cmnSubTable3;
                    }
                    //Xu ly vi tri button, rat cong phu :)
                    if (x < pnlTable.Width - 220)
                    {
                        x += 110;
                    }
                    else
                    {
                        x = 10;
                        y += 60;
                    }
                    btn.MouseClick += new MouseEventHandler(btnTable_MouseClick);
                    //btn.MouseHover += new EventHandler(btnTable_MouseHover);
                    pnlTable.Controls.Add(btn);
                }
            }
            catch
            {
                MessageBox.Show("Không thể tải bàn!", "Lỗi...");
            }
           
        }
        //Ham load BILL
        public void loaddataBill()
        {
            
            try{
                //Don rac
                    pnlBill.Controls.Clear();
                if (txtNameTable.Tag != null)
                {
                    strBill = "";
                    DataProvider dataProvider = new DataProvider();
                    DataTable table = dataProvider.execQuery("USP_LoadDSHoaDon @maban , @trangthai", new object[] { txtNameTable.Tag.ToString(), 0 });
                    //Load thong tin cac mon trong bill 
                    int y = 10;
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        //Thêm vào bill
                        strBill += (i + 1) + ".     " + table.Rows[i][2].ToString() + "  X  " + table.Rows[i][3].ToString() + "\n";
                        Label lbl = new Label()
                        {
                            Name = "btnFB" + i,
                            //in ra man hinh tung mon nhu vay no moi dep :)
                            Text = (i + 1) + ".  " + table.Rows[i][1].ToString() + "  X  " + table.Rows[i][2].ToString() + "        " + table.Rows[i][3].ToString(),
                            Width = pnlBill.Width - 20,
                            Height = 20,
                            Location = new Point(5, y)
                        };
                        y += 25;
                        pnlBill.Controls.Add(lbl);
                    }

                    var resutl = dataProvider.execScalar("USP_TongTienHD @mahd", new object[] { table.Rows[0][0] });
                    txtTotal.Text = resutl.ToString();
                }
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
           
        }
        
        //Ham Load CATEGORY
        private void loaddataCategory()
        {
            
            try{
                //Don rac
                pnlCategory.Controls.Clear();
                DataProvider dataProvider = new DataProvider();
                DataTable table = dataProvider.execQuery("USP_LDSDanhMuc");
                int x = 10;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Button btn = new Button()
                    {
                        Name = "btnFood" + i,
                        Text = table.Rows[i][1].ToString(), //name category
                        Tag = table.Rows[i][0].ToString(),
                        Width = 120,
                        Height = pnlCategory.Height - 40,
                        Location = new Point(x, pnlCategory.Location.Y - 20),
                        BackColor = ColorTranslator.FromHtml("Snow"),
                    };
                    x += 130;
                    pnlCategory.Controls.Add(btn);
                    btn.Click += new EventHandler(btnCategory_Click);
                }
                //mở food đầu tiên 1 food dau tien
                loaddataFood(table.Rows[0][0].ToString());
            }
            catch
            {
            }
            
        }

        //Ham Load Food
        private void loaddataFood(string idCategory)
        {
           try
            {
                //Don rac
                pnlFood.Controls.Clear();
                DataProvider dataProvider = new DataProvider();
                DataTable table = dataProvider.execQuery("USP_LayDanhSachDoUong @madangmuc",new object[] {idCategory});
                txtNameFood.Text = table.Rows[0][1].ToString(); //ten cua thang food hien tai
                txtNameFood.Tag = table.Rows[0][0].ToString();
                txtPriceFood.Text = table.Rows[0][2].ToString();  //gia cua thang food hien tai
                int y = 10;
                
                for (int i = 0; i < table.Rows.Count; i++)
                {                  
                    Button btn = new Button()
                    {
                        Name = "btnFood" + i,
                        Text = table.Rows[i][1].ToString(), //name foods                      
                        Tag = table.Rows[i][2].ToString()+";" +table.Rows[i][0].ToString(),
                        Width = pnlFood.Width - 40,
                        Height = 50,
                        Location = new Point(pnlFood.Location.X, y),
                        BackColor = ColorTranslator.FromHtml("Snow"),
                    };
                    y += 60;
                    btn.Click += new EventHandler(btnFB_Click);
                    pnlFood.Controls.Add(btn);
                }
            }
            catch
            {
            }
           
        }

        /*private void btnTable_MouseHover(object sender, EventArgs e)
        {
            ClickTable(sender, e);
        }*/

        //Su kien Mouseclick vao btnTABLE
        private void btnTable_MouseClick(object sender, EventArgs e)
        {
            ClickTable(sender, e);
        }
        private void ClickTable(object sender, EventArgs e)
        {
            //tra ve trang thai ban theo mau sac cua btnTable
            if (((Button)sender).BackColor.ToString() == "Color [Snow]")
            {
                txtSTT.Text = "TRỐNG";
                txtTotal.Text = "";
            }
            else if (((Button)sender).BackColor.ToString() == "Color [Lime]")
            {
                txtSTT.Text = "ONLINE";
            }
            else if (((Button)sender).BackColor.ToString() == "Color [Red]")
            {
                txtSTT.Text = "ĐẶT TRƯỚC";
                txtTotal.Text = "";
            }
            //tra ve ten ban
            txtNameTable.Text = ((Button)sender).Text;
            txtNameTable.Tag = ((Button)sender).Tag.ToString();           
            if(txtSTT.Text=="ONLINE")
             loaddataBill();
            else
            {
                pnlBill.Controls.Clear();
            }
        }

        //Su kien click btnCATEGORY
        private void btnCategory_Click(object sender, EventArgs e)
        {
            string idCate = ((Button)sender).Tag.ToString();
            //Load mon theo yeu cau click cua Category
            loaddataFood(idCate);
        }

        //Su kiem click btnFood
        private void btnFB_Click(object sender, EventArgs e)
        {
            //Gan text button mon an => text groupbox . cho no dep
            string[] subString = ((Button)sender).Tag.ToString().Split(';');
            txtNameFood.Text = ((Button)sender).Text;          
            txtPriceFood.Text = subString[0];
            txtNameFood.Tag = subString[1];
        }

        //Ham xu ly Category
        private void tmiCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdCategory frm = new frmAdCategory();
                frm.ShowDialog();
                this.Show();
                loaddataCategory();
            }
            catch{}
        }

        //di den quan ly food
        private void tmiFood_Click(object sender, EventArgs e)
        {

            
            try
            {
                frmAdFood frm = new frmAdFood();
                frm.ShowDialog();
                this.Show();
                loaddataCategory();
            }

            catch{}
            

        }

        //di den quan ly table
        private void tmiTable_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdTables frm = new frmAdTables();
                frm.ShowDialog();
                this.Show();
                loaddataTable();
            }
            catch{}
            
        }

        
        private void tmiAccount_Click(object sender, EventArgs e)
        {
            /*try
            {*/
                frmAdAccount frm = new frmAdAccount();
                frm.ShowDialog();
                this.Show();
            //}
            //catch{}
        }

        //Neu kich thuoc table thay doi thi load lai table cho phu hop
        private void gpbTable_SizeChanged(object sender, EventArgs e)
        {
            loaddataTable();
        }
        //Su kien nhan button them mon
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            AddFood();
        }
        private void AddFood()
        {
           try
            {
                if (txtSTT.Text == "ONLINE")
                {
                    frmAddFood addF = new frmAddFood(txtNameTable.Tag.ToString(), txtNameFood.Tag.ToString(), txtSTT.Text,txtNameTable.Text,txtNameFood.Text,lblName.Tag.ToString());
                    addF.ShowDialog();
                    this.Show();
                    loaddataTable();
                    loaddataBill();
                }
                else if (txtSTT.Text == "ĐẶT TRƯỚC")
                {
                    MessageBox.Show("Bàn đã được đặt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtSTT.Text == "TRỐNG")
                {
                    DialogResult ms = MessageBox.Show("Bàn này đang trống. Mở bàn nhé?", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ms == DialogResult.Yes)
                    {
                        frmAddFood addF = new frmAddFood(txtNameTable.Tag.ToString(), txtNameFood.Tag.ToString(), txtSTT.Text, txtNameTable.Text, txtNameFood.Text,lblName.Tag.ToString());
                        addF.ShowDialog();
                        this.Show();
                        loaddataTable();
                        loaddataBill();
                    }
                }
            }
            catch { }
        }

        //Nhan nut thanh toan
        private void btnPay_Click(object sender, EventArgs e)
        {
            PayFood();
        }
        private void PayFood()
        {
            
            try{
                if (txtSTT.Text == "ONLINE")
                {
                    frmPay addF = new frmPay(txtNameTable.Text,txtNameTable.Tag.ToString(),txtTotal.Text);
                    addF.ShowDialog();
                    this.Show();
                    txtNameTable.Text = "";
                    txtNameTable.Tag = null;
                    loaddataTable();
                    loaddataBill();
                }
                else if (txtSTT.Text == "ĐẶT TRƯỚC")
                {
                    MessageBox.Show("Bàn đã được đặt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtSTT.Text == "TRỐNG")
                {
                    MessageBox.Show("Bàn này đang trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                
            }
        }

        //Nut chuyen ban
        private void btnReplaceTable_Click(object sender, EventArgs e)
        {
            ReplaceTable();
        }
        private void ReplaceTable()
        {
            
            
                if (txtSTT.Text == "ONLINE")
                {
                    ReplaceTable addF = new ReplaceTable(txtNameTable.Text,txtNameTable.Tag.ToString(), lblName.Tag.ToString());
                    addF.ShowDialog();
                    this.Show();
                    txtNameTable.Text = "";
                    txtNameTable.Tag = null;
                    loaddataTable();
                    loaddataBill();
                }
                else if (txtSTT.Text == "ĐẶT TRƯỚC")
                {
                    MessageBox.Show("Bàn đã được đặt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtSTT.Text == "TRỐNG")
                {
                    MessageBox.Show("Bàn này đang trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            
        }

        //Gop ban
        private void btnPlusTable_Click(object sender, EventArgs e)
        {
            PlusTable();
        }
        private void PlusTable()
        {
           
                if (txtSTT.Text == "ONLINE")
                {
                    PlusTable addF = new PlusTable(txtNameTable.Text,txtNameTable.Tag.ToString());
                    addF.ShowDialog();
                    this.Show();
                    loaddataTable();
                    txtNameTable.Text = "";
                    txtNameTable.Tag = null;
                    loaddataBill();
                }
                else if (txtSTT.Text == "ĐẶT TRƯỚC")
                {
                    MessageBox.Show("Bàn đã được đặt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtSTT.Text == "TRỐNG")
                {
                    MessageBox.Show("Bàn này đang trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        //Tra mon
        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnFood();
        }
        private void ReturnFood()
        {
            
                if (txtSTT.Text == "ONLINE")
                {
                    ReFood addF = new ReFood(txtNameTable.Text,txtNameTable.Tag.ToString());
                    addF.ShowDialog();
                    this.Show();
                    txtNameTable.Text = "";
                    txtNameTable.Tag = null;
                    loaddataTable();
                    loaddataBill();
                }
                else if (txtSTT.Text == "ĐẶT TRƯỚC")
                {
                    MessageBox.Show("Bàn đã được đặt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtSTT.Text == "TRỐNG")
                {
                    MessageBox.Show("Bàn này đang trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            
        }

        //Khoa man hinh
        private void btnBlock_Click(object sender, EventArgs e)
        {
            Block addF = new Block(username, lblName.Text, password);
            addF.ShowDialog();
            this.Show();
        }

        //In hoa don
        private void btnPrint_Click(object sender, EventArgs e)
        {
           try
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch
            {
                MessageBox.Show("Không thể in hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //PrintDocument
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Chuoi hoa don
            string HoaDon = "";
            HoaDon += "\n" + txtNameMan.Text + "\n";
            HoaDon += "\n" + txtAdress.Text + "\n\n\n";
            HoaDon += "\n" + "           HÓA ĐƠN " + txtNameTable.Text + "        \n\n\n";
            HoaDon += strBill;
            HoaDon += "\n\n\nThời gian: " + datetime.Value.ToShortTimeString() + ". " + datetime.Value.ToShortDateString() + "\n";
            HoaDon += "\nTổng cộng: " + txtTotal.Text + " VNĐ\n";
            e.Graphics.DrawString(HoaDon, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 100, 200);
            
        }

        //Sua tai khoan
        private void tmiChange_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePersional addF = new ChangePersional(username, lblName.Text, password,lblName.Tag.ToString());
                addF.ShowDialog();
                this.Show();
                loaddataTable();
                loaddataBill();
            }
            catch
            {
                MessageBox.Show("Không thể thay đổi thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Logout
        private void tmiLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //load context menu ban online
        private void cmnSubTable_Opening(object sender, CancelEventArgs e)
        {
        }
        //menu context SubTable
        private void tsmThemMon_Click(object sender, EventArgs e)
        {
            AddFood();
        }
        private void tsmTraMon_Click(object sender, EventArgs e)
        {
            ReturnFood();
        }
        private void tsmThanhToan_Click(object sender, EventArgs e)
        {
            PayFood();
        }
        private void tsmChuyenBan_Click(object sender, EventArgs e)
        {
            ReplaceTable();
        }
        private void tsmGopBan_Click(object sender, EventArgs e)
        {
            PlusTable();
        }


        //Context Menu ban trong
        private void cmnSubTable2_Opening(object sender, CancelEventArgs e)
        {
        }
        private void tmsThemMon2_Click(object sender, EventArgs e)
        {
            AddFood();
        }
        //Dat ban
        private void tsmDatBan_Click(object sender, EventArgs e)
        {
           try
            {
                DataProvider dataProvider = new DataProvider();
                int result = dataProvider.execNonQuery("USP_DatBan @trangthai , @maban",new object[] {2,txtNameTable.Tag.ToString()});
                if (result > 0)
                {
                    MessageBox.Show("Đặt bàn thành công");
                    loaddataTable();
                }
                else MessageBox.Show("lỗi");
            }
            catch { }
           
        }


        //Context Menu ban trong
        private void cmnSubTable3_Opening(object sender, CancelEventArgs e)
        {
        }
        //Mo ban
        private void tsmMoBan_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider dataProvider = new DataProvider();
                int result = dataProvider.execNonQuery("USP_DatBan @trangthai , @maban", new object[] {0, txtNameTable.Tag.ToString() });
                if (result > 0)
                {
                    MessageBox.Show("Mở bàn thành công");
                    loaddataTable();
                }
                else MessageBox.Show("lỗi");
            }
            catch { }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToLongTimeString();
        }

        private void tmiThongKe_Click(object sender, EventArgs e)
        {
            frmQuanlythongke frm = new frmQuanlythongke();
            frm.ShowDialog();
            this.Show();
        }
    }
}
