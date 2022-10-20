using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe
{
    internal class DataProvider
    {
        string conSTR = @"Data Source=DESKTOP-KMNS09Q\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True";
        public DataTable execQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection con = new SqlConnection(conSTR))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(data);

                con.Close();
            }

            return data;
        }
        public int execNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection con = new SqlConnection(conSTR))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteNonQuery();

                con.Close();
            }

            return data;
        }
        //Phương thức này trả về giá trị hàng đầu tiên và cột đầu tiên của kết quả truy vấn.
        //Using: dùng để giải phóng bộ nhớ khi kết nối đã đóng
        public object execScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection con = new SqlConnection(conSTR))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteScalar();

                con.Close();
            }

            return data;
        }
    }
}
