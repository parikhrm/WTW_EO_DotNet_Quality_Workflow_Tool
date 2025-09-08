using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Workflow
{
    public partial class SearchTool_New_DataMart : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";

        public SearchTool_New_DataMart()
        {
            InitializeComponent();
        }

        private void principlename_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void SearchTool_New_DataMart_Load(object sender, EventArgs e)
        {

        }

        public void datagridview_display_overall()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_qualityworkflow_searchtool_new_datamart_dotnet";
                if (string.IsNullOrEmpty(principlename.Text))
                {
                    cmd.Parameters.AddWithValue("@principlename", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@principlename", principlename.Text);
                }
                if (string.IsNullOrEmpty(riskid.Text))
                {
                    cmd.Parameters.AddWithValue("@riskid", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@riskid", riskid.Text);
                }
                
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void riskid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }
    }
}
