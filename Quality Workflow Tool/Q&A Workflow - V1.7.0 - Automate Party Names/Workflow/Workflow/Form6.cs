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
    public partial class Form6 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            reset_overall();
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 3000000;//3000 sec
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
        }

        public void reset_overall()
        {
            ageingdays.Value = 0;
            workqueuestatus.SelectedIndex = -1;
            datagridview1_display_overall();
            completionmonth_search.CustomFormat = " ";
            
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
                            cmd.CommandText = "dbo.usp_randomizer_kyc_archive_edit_complete_dotnet";
                            cmd.Parameters.AddWithValue("@ID", row.Cells["txtID"].Value.ToString());
                            cmd.Parameters.AddWithValue("@IntID",Environment.UserName.ToString());
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
                            cmd.CommandText = "dbo.usp_randomizer_kyc_archive_edit_pending_dotnet";
                            cmd.Parameters.AddWithValue("@ID", row.Cells["txtID"].Value.ToString());
                            cmd.Parameters.AddWithValue("@IntID", Environment.UserName.ToString());
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
                cmd.CommandText = "select Requestid,SourceType,EmpName,ReceivedDate,PrincipleName,PartyName,MatchCriteria,MatchCategory,DunsNumber,RequestSourceName,ReferenceId,CompletionDate,INTID,UniqueID,WorkQueueStatus,UpdatedBy_WorkQueueStatus, case when WorkQueueStatus = 'Completed' then null else dbo.get_WorkedDays(CompletionDate,GETDATE()) end as AgeingDays,ID from dbo.tbl_randomizer_kyc_archive_dotnet with(nolock) order by CompletionDate desc ";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
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

        public void datagridview1_display_workqueue()
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
                cmd.CommandText = "select Requestid,SourceType,EmpName,ReceivedDate,PrincipleName,PartyName,MatchCriteria,MatchCategory,DunsNumber,RequestSourceName,ReferenceId,CompletionDate,INTID,UniqueID,WorkQueueStatus,UpdatedBy_WorkQueueStatus, dbo.get_WorkedDays(CompletionDate,GETDATE()) as AgeingDays,ID from dbo.tbl_randomizer_kyc_archive_dotnet with(nolock) where WorkQueueStatus = @WorkQueueStatusparam  order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@WorkQueueStatusparam",workqueuestatus.Text);
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
                cmd.CommandText = "select Requestid,SourceType,EmpName,ReceivedDate,PrincipleName,PartyName,MatchCriteria,MatchCategory,DunsNumber,RequestSourceName,ReferenceId,CompletionDate,INTID,UniqueID,WorkQueueStatus,UpdatedBy_WorkQueueStatus, dbo.get_WorkedDays(CompletionDate,GETDATE()) as AgeingDays,ID from dbo.tbl_randomizer_kyc_archive_dotnet with(nolock) where dbo.get_WorkedDays(CompletionDate,GETDATE()) = @ageingdays and WorkQueueStatus = 'Pending' order by CompletionDate desc ";
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

        public void datagridview1_display_requestid()
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
                cmd.CommandText = "select Requestid,SourceType,EmpName,ReceivedDate,PrincipleName,PartyName,MatchCriteria,MatchCategory,DunsNumber,RequestSourceName,ReferenceId,CompletionDate,INTID,UniqueID,WorkQueueStatus,UpdatedBy_WorkQueueStatus, dbo.get_WorkedDays(CompletionDate,GETDATE()) as AgeingDays,ID from dbo.tbl_randomizer_kyc_archive_dotnet with(nolock) where requestid like @requestidparam order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@requestidparam", "%" + requestid_search.Text + "%");
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

        public void datagridview1_display_partyname()
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
                cmd.CommandText = "select Requestid,SourceType,EmpName,ReceivedDate,PrincipleName,PartyName,MatchCriteria,MatchCategory,DunsNumber,RequestSourceName,ReferenceId,CompletionDate,INTID,UniqueID,WorkQueueStatus,UpdatedBy_WorkQueueStatus, dbo.get_WorkedDays(CompletionDate,GETDATE()) as AgeingDays,ID from dbo.tbl_randomizer_kyc_archive_dotnet with(nolock) where partyname like @partynameparam order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@partynameparam", "%" + partyname_search.Text + "%");
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

        public void datagridview1_display_empname()
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
                cmd.CommandText = "select Requestid,SourceType,EmpName,ReceivedDate,PrincipleName,PartyName,MatchCriteria,MatchCategory,DunsNumber,RequestSourceName,ReferenceId,CompletionDate,INTID,UniqueID,WorkQueueStatus,UpdatedBy_WorkQueueStatus, dbo.get_WorkedDays(CompletionDate,GETDATE()) as AgeingDays,ID from dbo.tbl_randomizer_kyc_archive_dotnet with(nolock) where empname like @empnameparam order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@empnameparam", "%" + empname_search.Text + "%");
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
                cmd.CommandText = "select Requestid,SourceType,EmpName,ReceivedDate,PrincipleName,PartyName,MatchCriteria,MatchCategory,DunsNumber,RequestSourceName,ReferenceId,CompletionDate,INTID,UniqueID,WorkQueueStatus,UpdatedBy_WorkQueueStatus, dbo.get_WorkedDays(CompletionDate,GETDATE()) as AgeingDays,ID from dbo.tbl_randomizer_kyc_archive_dotnet with(nolock) where convert(date,dateadd(dd,1,eomonth(completiondate,-1))) = convert(date,dateadd(dd,1,eomonth(@completiondate,-1))) order by CompletionDate desc ";
                cmd.Parameters.AddWithValue("@completiondate", completionmonth_search.Text);
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

        private void workqueuestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(workqueuestatus.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_workqueue();
            }
        }

        private void ageingdays_ValueChanged(object sender, EventArgs e)
        {
            datagridview1_display_ageingdays();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datagridview1_display_overall();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void requestid_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(requestid_search.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_requestid();
            }
        }

        private void partyname_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(partyname_search.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_partyname();
            }
        }

        private void empname_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(empname_search.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_empname();
            }
        }

        private void completionmonth_ValueChanged(object sender, EventArgs e)
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

        private void completionmonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completionmonth_search.CustomFormat = " ";
            }
        }
    }
}
