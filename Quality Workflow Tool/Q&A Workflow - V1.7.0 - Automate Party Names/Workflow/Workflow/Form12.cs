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
using Excel = Microsoft.Office.Interop.Excel;

namespace Workflow
{
    public partial class Form12 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            reset_overall();
        }

        public void reset_overall()
        {
            status_list();
            requestid.Text = string.Empty;
            comments_reportingmanager.Text = string.Empty;
            status_reportingmanager.SelectedIndex = -1;
            comments_final.Text = string.Empty;
            status_final.SelectedIndex = -1;
            insert.Enabled = true;
            update.Enabled = false;
            datagridview_display_overall();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj_form1 = new Form1();
            obj_form1.Show();
        }

        public void status_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Status obj_status = new Status();
                DataTable dtaa = new DataTable();
                obj_status.status_reportingmanager(dtaa);
                obj_status.status_final(dtaa);
                status_reportingmanager.DataSource = dtaa;
                status_reportingmanager.DisplayMember = "Status";
                status_final.DataSource = dtaa;
                status_final.DisplayMember = "Status";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_ecsworkflow_ecs_insert_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@RequestID",requestid.Text);
                if(string.IsNullOrEmpty(comments_reportingmanager.Text))
                {
                    cmd.Parameters.AddWithValue("@Comments_ReportingManager",DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Comments_ReportingManager",comments_reportingmanager.Text);
                }
                if (string.IsNullOrEmpty(status_reportingmanager.Text))
                {
                    cmd.Parameters.AddWithValue("@Status_ReportingManager", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Status_ReportingManager", status_reportingmanager.Text);
                }
                if (string.IsNullOrEmpty(comments_final.Text))
                {
                    cmd.Parameters.AddWithValue("@Comments_Final", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Comments_Final", comments_final.Text);
                }
                if (string.IsNullOrEmpty(status_final.Text))
                {
                    cmd.Parameters.AddWithValue("@Status_Final", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Status_Final", status_final.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedDateTime",DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName",Environment.MachineName.ToString());

                if (string.IsNullOrEmpty(requestid.Text))
                {
                    MessageBox.Show("Please update Request ID");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
            
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_ecsworkflow_ecs_update_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@RequestID", requestid.Text);
                if (string.IsNullOrEmpty(comments_reportingmanager.Text))
                {
                    cmd.Parameters.AddWithValue("@Comments_ReportingManager", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Comments_ReportingManager", comments_reportingmanager.Text);
                }
                if (string.IsNullOrEmpty(status_reportingmanager.Text))
                {
                    cmd.Parameters.AddWithValue("@Status_ReportingManager", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Status_ReportingManager", status_reportingmanager.Text);
                }
                if (string.IsNullOrEmpty(comments_final.Text))
                {
                    cmd.Parameters.AddWithValue("@Comments_Final", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Comments_Final", comments_final.Text);
                }
                if (string.IsNullOrEmpty(status_final.Text))
                {
                    cmd.Parameters.AddWithValue("@Status_Final", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Status_Final", status_final.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());

                if (string.IsNullOrEmpty(requestid.Text))
                {
                    MessageBox.Show("Please update Request ID");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string messsage = "Do you want to update the record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    requestid.Text = row.Cells["txtRequestID"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txtComments_ReportingManager"].Value.ToString()))
                    {
                        comments_reportingmanager.Text = string.Empty;
                    }
                    else
                    {
                        comments_reportingmanager.Text = row.Cells["txtComments_ReportingManager"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtStatus_ReportingManager"].Value.ToString()))
                    {
                        status_reportingmanager.SelectedIndex = -1;
                    }
                    else
                    {
                        status_reportingmanager.Text = row.Cells["txtStatus_ReportingManager"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtComments_Final"].Value.ToString()))
                    {
                        comments_final.Text = string.Empty;
                    }
                    else
                    {
                        comments_final.Text = row.Cells["txtComments_Final"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtStatus_Final"].Value.ToString()))
                    {
                        status_final.Text = string.Empty;
                    }
                    else
                    {
                        status_final.Text = row.Cells["txtStatus_Final"].Value.ToString();
                    }
                }
                update.Enabled = true;
                insert.Enabled = false;
            }
            else
            {
                update.Enabled = false;
                insert.Enabled = true;
            }
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
                if (string.IsNullOrEmpty(searchby_requestid.Text))
                {
                    cmd.CommandText = "select RequestID,Comments_ReportingManager,Status_ReportingManager,Comments_Final,Status_Final,LastUpdatedBy from dbo.tbl_approvals_raisedispute_dotnet with(nolock) where isdeleted = 0";
                }
                else
                {
                    cmd.CommandText = "select RequestID,Comments_ReportingManager,Status_ReportingManager,Comments_Final,Status_Final,LastUpdatedBy from dbo.tbl_approvals_raisedispute_dotnet with(nolock) where isdeleted = 0 and requestid = @RequestIDparam";
                    cmd.Parameters.AddWithValue("@RequestIDparam", searchby_requestid.Text);
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

        private void searchby_requestid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_ECSWorkflow_ECS_RawData_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }
    }
}
