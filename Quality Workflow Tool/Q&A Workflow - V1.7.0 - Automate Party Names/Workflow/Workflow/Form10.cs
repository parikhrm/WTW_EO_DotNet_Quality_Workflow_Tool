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
    public partial class Form10 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Randomizer_ApprovalsAndQuality_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
            datagridview1_display_overall();
        }

        public void datagridview1_display_overall()
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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_randomizer_qualityandapprovals_daily_dotnet with(nolock) order by ApprovalTeam";
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                button3.Enabled = true;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_randomizer_qualityandapprovals_archive_dotnet";
                cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@UploadedBy", Environment.UserName.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data exported successfully to work queue");
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Data export failed");
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void Form10_MouseHover(object sender, EventArgs e)
        {
            datagridview1_display_overall();
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            datagridview1_display_overall();
        }
    }
}
