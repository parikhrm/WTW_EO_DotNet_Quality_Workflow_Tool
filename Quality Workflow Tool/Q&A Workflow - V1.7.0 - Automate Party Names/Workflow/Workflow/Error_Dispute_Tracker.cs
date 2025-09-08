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
    public partial class Error_Dispute_Tracker : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";

        public Error_Dispute_Tracker()
        {
            InitializeComponent();
        }

        private void Error_Dispute_Tracker_Load(object sender, EventArgs e)
        {

            associatename_checkaccess();
            searchby_reportingmanager_list();
            reset_overall();
        }

        public void reset_overall()
        {
            associate_access.Visible = false;
            if (associate_access.Text == "Admin")
            {
                final_dispute_status.Enabled = true;
                additional_comments.Enabled = true;
                lm_comments.Enabled = true;
                dispute_closure_date.Enabled = true;
            }
            else
            {
                final_dispute_status.Enabled = false;
                additional_comments.Enabled = false;
                lm_comments.Enabled = false;
                dispute_closure_date.Enabled = false;
            }
            ia_qa_requestID.Text = string.Empty;
            dispute_raised_date.CustomFormat = " ";
            dispute_description.Text = string.Empty;
            dispute_closure_date.CustomFormat = " ";
            final_dispute_status.SelectedIndex = -1;
            lm_comments.Text = string.Empty;
            additional_comments.Text = string.Empty;
            datagridview_display_overall();
            insert.Enabled = true;
            update.Enabled = false;
            ia_qa_requestID.Enabled = true;
        }

        public void associatename_checkaccess()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                obj_empdetails.associate_list_check_access_overall(dtaa,Environment.UserName.ToString());
                associate_access.DataSource = dtaa;
                associate_access.DisplayMember = "Dispute_Tracker_Access";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void searchby_empname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                obj_empdetails.associate_list_dispute_tracker(dtaa, searchby_reportingmanagername.Text);
                searchby_empname.DataSource = dtaa;
                searchby_empname.DisplayMember = "EmpName";
                conn.Close();
                searchby_empname.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void searchby_reportingmanager_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                obj_empdetails.reportingmanager_list_dispute_tracker (dtaa);
                searchby_reportingmanagername.DataSource = dtaa;
                searchby_reportingmanagername.DisplayMember = "ReportingManager";
                conn.Close();
                searchby_reportingmanagername.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void dispute_raised_date_ValueChanged(object sender, EventArgs e)
        {
            dispute_raised_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void dispute_raised_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                dispute_raised_date.CustomFormat = " ";
            }
        }

        private void dispute_closure_date_ValueChanged(object sender, EventArgs e)
        {
            dispute_closure_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void dispute_closure_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                dispute_closure_date.CustomFormat = " ";
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
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
                cmd.CommandText = "dbo.usp_error_dispute_tracker_insert_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@IA_QA_RequestID", ia_qa_requestID.Text);
                cmd.Parameters.AddWithValue("@Dispute_Raised_Date", dispute_raised_date.Value.Date);
                if (string.IsNullOrEmpty(dispute_description.Text))
                {
                    cmd.Parameters.AddWithValue("@Dispute_Description", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Dispute_Description", dispute_description.Text);
                }
                if (dispute_closure_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Dispute_Closure_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Dispute_Closure_Date", dispute_closure_date.Value.Date);
                }
                if (string.IsNullOrEmpty(final_dispute_status.Text))
                {
                    cmd.Parameters.AddWithValue("@Final_Dispute_Status", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Final_Dispute_Status", final_dispute_status.Text);
                }
                if (string.IsNullOrEmpty(additional_comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Additional_Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Additional_Comments", additional_comments.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName",Environment.MachineName.ToString());
                if (string.IsNullOrEmpty(lm_comments.Text))
                {
                    cmd.Parameters.AddWithValue("@LM_Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@LM_Comments", lm_comments.Text);
                }
                
                //If conditions
                if (string.IsNullOrEmpty(ia_qa_requestID.Text))
                {
                    MessageBox.Show("Please update IA QA RequestID");
                }
                else if (dispute_raised_date.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Dispute Raised Date");
                }
                else if (dispute_closure_date.Text.Trim() != string.Empty && string.IsNullOrEmpty(final_dispute_status.Text))
                {
                    MessageBox.Show("Please update Final Dispute Status");
                }
                else if (dispute_closure_date.Text.Trim() == string.Empty && !string.IsNullOrEmpty(final_dispute_status.Text))
                {
                    MessageBox.Show("Please update Dispute Closure Date");
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
                cmd.CommandText = "dbo.usp_error_dispute_tracker_update_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@IA_QA_RequestID", ia_qa_requestID.Text);
                cmd.Parameters.AddWithValue("@Dispute_Raised_Date", dispute_raised_date.Value.Date);
                if (string.IsNullOrEmpty(dispute_description.Text))
                {
                    cmd.Parameters.AddWithValue("@Dispute_Description", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Dispute_Description", dispute_description.Text);
                }
                if (dispute_closure_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Dispute_Closure_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Dispute_Closure_Date", dispute_closure_date.Value.Date);
                }
                if (string.IsNullOrEmpty(final_dispute_status.Text))
                {
                    cmd.Parameters.AddWithValue("@Final_Dispute_Status", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Final_Dispute_Status", final_dispute_status.Text);
                }
                if (string.IsNullOrEmpty(additional_comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Additional_Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Additional_Comments", additional_comments.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                if (string.IsNullOrEmpty(lm_comments.Text))
                {
                    cmd.Parameters.AddWithValue("@LM_Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@LM_Comments", lm_comments.Text);
                }
                
                //If conditions
                if (string.IsNullOrEmpty(ia_qa_requestID.Text))
                {
                    MessageBox.Show("Please update IA QA RequestID");
                }
                else if (dispute_raised_date.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Dispute Raised Date");
                }
                else if (dispute_closure_date.Text.Trim() != string.Empty && string.IsNullOrEmpty(final_dispute_status.Text))
                {
                    MessageBox.Show("Please update Final Dispute Status");
                }
                else if (dispute_closure_date.Text.Trim() == string.Empty && !string.IsNullOrEmpty(final_dispute_status.Text))
                {
                    MessageBox.Show("Please update Dispute Closure Date");
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

                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(searchby_ia_qa_requestid.Text) && string.IsNullOrEmpty(searchby_empname.Text) && string.IsNullOrEmpty(searchby_reportingmanagername.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select a.IA_QA_RequestID,a.Dispute_Raised_Date,a.Dispute_Description,a.Dispute_Closure_Date,a.Final_Dispute_Status,a.Additional_Comments,a.LastUpdatedBy,a.LastUpdatedDateTime,a.LM_Comments,b.ApprovalTeam as QC_Checker_Name,b.AssociateName,c.[Reporting Manager],b.CompletionDate as ErrorMarkedDate,b.BatchID as KYC_WFT_ID,b.QualityParameters,b.PartyName,b.PrincipalName,b.TypeofError from dbo.vw_error_dispute_tracker_daily_dotnet a inner join dbo.vw_approvals_daily_dotnet b on a.IA_QA_RequestID = b.RequestID inner join dbo.tbl_emp_details c with(nolock) on b.AssociateName = c.EmpName where 1=1 order by a.Dispute_Raised_Date desc";
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_approvals_workflow_error_dispute_tracker_datagridview_search_dotnet";
                    if (string.IsNullOrEmpty(searchby_ia_qa_requestid.Text))
                    {
                        cmd.Parameters.AddWithValue("@requestid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@requestid", searchby_ia_qa_requestid.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_empname.Text))
                    {
                        cmd.Parameters.AddWithValue("@empname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@empname", searchby_empname.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_reportingmanagername.Text))
                    {
                        cmd.Parameters.AddWithValue("@reportingmanager", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@reportingmanager", searchby_reportingmanagername.Text);
                    }
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

        private void searchby_ia_qa_requestid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 obj_form3 = new Form3();
            obj_form3.Show();
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
                    insert.Enabled = false;
                    update.Enabled = true;
                    ia_qa_requestID.Enabled = false;

                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    ia_qa_requestID.Text = row.Cells["txtIA_QA_RequestID"].Value.ToString();
                    dispute_raised_date.Text = row.Cells["txtDispute_Raised_Date"].Value.ToString();
                    dispute_raised_date.CustomFormat = "dd-MMMM-yyyy";
                    if (string.IsNullOrEmpty(row.Cells["txtDispute_Description"].Value.ToString()))
                    {
                        dispute_description.Text = string.Empty;
                    }
                    else
                    {
                        dispute_description.Text = row.Cells["txtDispute_Description"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtDispute_Closure_Date"].Value.ToString()))
                    {
                        dispute_closure_date.CustomFormat = " ";
                    }
                    else
                    {
                        dispute_closure_date.Text = row.Cells["txtDispute_Closure_Date"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtFinal_Dispute_Status"].Value.ToString()))
                    {
                        final_dispute_status.SelectedIndex = -1;
                    }
                    else
                    {
                        final_dispute_status.Text = row.Cells["txtFinal_Dispute_Status"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtLM_Comments"].Value.ToString()))
                    {
                        lm_comments.Text = string.Empty;
                    }
                    else
                    {
                        lm_comments.Text = row.Cells["txtLM_Comments"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtAdditional_Comments"].Value.ToString()))
                    {
                        additional_comments.Text = string.Empty;
                    }
                    else
                    {
                        additional_comments.Text = row.Cells["txtAdditional_Comments"].Value.ToString();
                    }
                }
            }
            else
            {
                insert.Enabled = true;
                update.Enabled = false;
                ia_qa_requestID.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://app.powerbi.com/groups/81c3ab7d-0a2a-46f2-b54f-38eb239011a1/reports/20155e5a-a6d3-46d7-8a52-cfe9bd664249/ReportSection31a41de679b2bcefa277?experience=power-bi");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void searchby_empname_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_reportingmanagername_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
            searchby_empname_list();
        }

        
    }
}
