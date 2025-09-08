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
    public partial class Form11 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            reset_overall();
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 3000000;//3000 sec
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }

        public void reset_overall()
        {
            ageingdays.Value = 0;
            workqueuestatus.SelectedIndex = -1;
            riskid_search.Text = string.Empty;
            batchid_search.Text = string.Empty;
            approvalteam_search.Text = string.Empty;
            completionmonth_search.CustomFormat = " ";
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
                cmd.CommandText = "select ID,RequestID,ProcessType,ApprovalTeam,ReceivedDate,CompletionDate,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,Breaches,TypeofBreaches,TypeofError,DRDProcess,QualityParameters,PrincipleType,RiskID,BatchID,UploadDate,UploadedBy,WorkQueueStatus from dbo.tbl_randomizer_qualityandapprovals_archive_dotnet with(nolock) order by CompletionDate desc ";
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

        public void datagridview1_display_riskid()
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
                cmd.CommandText = "select ID,RequestID,ProcessType,ApprovalTeam,ReceivedDate,CompletionDate,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,Breaches,TypeofBreaches,TypeofError,DRDProcess,QualityParameters,PrincipleType,RiskID,BatchID,UploadDate,UploadedBy,WorkQueueStatus from dbo.tbl_randomizer_qualityandapprovals_archive_dotnet with(nolock) where RiskID like @RiskID order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@RiskID","%"+ riskid_search.Text + "%");
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

        public void datagridview1_display_batchid()
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
                cmd.CommandText = "select ID,RequestID,ProcessType,ApprovalTeam,ReceivedDate,CompletionDate,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,Breaches,TypeofBreaches,TypeofError,DRDProcess,QualityParameters,PrincipleType,RiskID,BatchID,UploadDate,UploadedBy,WorkQueueStatus from dbo.tbl_randomizer_qualityandapprovals_archive_dotnet with(nolock) where BatchID like @BatchID order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@BatchID", "%" + batchid_search.Text + "%");
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

        public void datagridview1_display_approvalteam()
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
                cmd.CommandText = "select ID,RequestID,ProcessType,ApprovalTeam,ReceivedDate,CompletionDate,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,Breaches,TypeofBreaches,TypeofError,DRDProcess,QualityParameters,PrincipleType,RiskID,BatchID,UploadDate,UploadedBy,WorkQueueStatus from dbo.tbl_randomizer_qualityandapprovals_archive_dotnet with(nolock) where ApprovalTeam like @ApprovalTeam order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@ApprovalTeam", "%" + approvalteam_search.Text + "%");
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

        public void datagridview1_display_completionmonth()
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
                cmd.CommandText = "select ID,RequestID,ProcessType,ApprovalTeam,ReceivedDate,CompletionDate,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,Breaches,TypeofBreaches,TypeofError,DRDProcess,QualityParameters,PrincipleType,RiskID,BatchID,UploadDate,UploadedBy,WorkQueueStatus from dbo.tbl_randomizer_qualityandapprovals_archive_dotnet with(nolock) where convert(date,dateadd(dd,1,eomonth(CompletionDate,-1))) = convert(date,dateadd(dd,1,eomonth(@CompletionDate,-1))) order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@CompletionDate",completionmonth_search.Value.Date);
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

        public void datagridview1_display_workqueuestatus()
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
                cmd.CommandText = "select ID,RequestID,ProcessType,ApprovalTeam,ReceivedDate,CompletionDate,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,Breaches,TypeofBreaches,TypeofError,DRDProcess,QualityParameters,PrincipleType,RiskID,BatchID,UploadDate,UploadedBy,WorkQueueStatus from dbo.tbl_randomizer_qualityandapprovals_archive_dotnet with(nolock) where WorkQueueStatus = @WorkQueueStatus order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@WorkQueueStatus", workqueuestatus.Text);
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

        public void datagridview1_display_ageingdays()
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
                cmd.CommandText = "select ID,RequestID,ProcessType,ApprovalTeam,ReceivedDate,CompletionDate,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,Breaches,TypeofBreaches,TypeofError,DRDProcess,QualityParameters,PrincipleType,RiskID,BatchID,UploadDate,UploadedBy,WorkQueueStatus from dbo.tbl_randomizer_qualityandapprovals_archive_dotnet with(nolock) where dbo.get_WorkedDays(CompletionDate,GETDATE()) = @ageingdays and WorkQueueStatus = 'Pending' order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@ageingdays", ageingdays.Value);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            datagridview1_display_overall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void completionmonth_search_ValueChanged(object sender, EventArgs e)
        {
            completionmonth_search.CustomFormat = "dd-MMMM-yyyy";
            if (completionmonth_search.Text.Trim() == string.Empty)
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_completionmonth();
            }
        }

        private void completionmonth_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completionmonth_search.CustomFormat = " ";
            }
        }

        private void workqueuestatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                workqueuestatus.SelectedIndex = -1;
            }
        }

        private void workqueuestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(workqueuestatus.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_workqueuestatus();
            }
        }

        private void riskid_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(riskid_search.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_riskid();
            }
        }

        private void batchid_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(batchid_search.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_batchid();
            }
        }

        private void approvalteam_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(approvalteam_search.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_approvalteam();
            }
        }

        public void update_status_complete()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    if (row.Cells["txtFinalStatus"].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells["txtFinalStatus"].Value) == true)
                        {
                            //DataGridViewRow dgvrow = dataGridView1.CurrentRow;
                            conn.ConnectionString = connectionstringtxt;
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "usp_randomizer_qualityandapprovals_archive_edit_complete_dotnet";
                            cmd.Parameters.AddWithValue("@ID", row.Cells["txtID"].Value.ToString());
                            cmd.Parameters.AddWithValue("@IntID", Environment.UserName.ToString());
                            cmd.Parameters.AddWithValue("@DateTime",DateTime.Now.ToLocalTime());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("WorkQueue Status Changed successfully");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        public void update_status_pending()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    if (row.Cells["txtFinalStatus"].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells["txtFinalStatus"].Value) == true)
                        {
                            //DataGridViewRow dgvrow = dataGridView1.CurrentRow;
                            conn.ConnectionString = connectionstringtxt;
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "usp_randomizer_qualityandapprovals_archive_edit_pending_dotnet";
                            cmd.Parameters.AddWithValue("@ID", row.Cells["txtID"].Value.ToString());
                            cmd.Parameters.AddWithValue("@IntID", Environment.UserName.ToString());
                            cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToLocalTime());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("WorkQueue Status Changed successfully");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_status_complete();
            datagridview1_display_overall();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update_status_pending();
            datagridview1_display_overall();
        }

        private void ageingdays_ValueChanged(object sender, EventArgs e)
        {
            if (ageingdays.Value <= 0)
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_ageingdays();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in dataGridView1.Rows)
            {
                if (myrow.Cells["txtWorkQueueStatus"].Value.ToString() == "Completed")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (myrow.Cells["txtWorkQueueStatus"].Value.ToString() == "Pending")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
    }
}
