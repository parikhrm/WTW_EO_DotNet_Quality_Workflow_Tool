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
using System.Data.OleDb;
using System.Configuration;
using System.IO;


namespace Workflow
{
    public partial class Batch_OMS_Bulk_Upload : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public Batch_OMS_Bulk_Upload()
        {
            InitializeComponent();
        }

        private void Batch_OMS_Bulk_Upload_Load(object sender, EventArgs e)
        {
            reset_overall();
            adminlevel_check_list();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.excelfilepath.Text = openFileDialog1.FileName;
            }
        }

        public void reset_overall()
        {
            excelfilepath.Text = string.Empty;
            excelsheetname.Text = string.Empty;
            button3.Visible = false;
            id.Text = string.Empty;
            comments.Text = string.Empty;
            batch_date.CustomFormat = " ";
            datagridview_display_overall();
        }

        public void adminlevel_check_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                obj_empdetails.associate_list_check_batchomsbulkupload_overall(dtaa, Environment.UserName.ToString());
                checkaccesslevel.DataSource = dtaa;
                checkaccesslevel.DisplayMember = "Batch_OMS_BulkUpload_Access";
                conn.Close();
                checkaccesslevel.Visible = false;
                if (checkaccesslevel.Text == "Admin")
                {
                    dataGridView1.Enabled = true;
                    completed.Enabled = true;
                    button5.Enabled = true;
                }
                else if (checkaccesslevel.Text == "ReadWrite")
                {
                    dataGridView1.Enabled = true;
                    completed.Enabled = false;
                    button5.Enabled = false;
                }
                else
                {
                    dataGridView1.Enabled = false;
                    completed.Enabled = false;
                    button5.Enabled = false;
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
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
                if (string.IsNullOrEmpty(searchby_entityid.Text) && searchby_batchdate.Text.Trim() == string.Empty && string.IsNullOrEmpty(searchby_entityname.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select ID,Batch,OMS,Batch_Date,Approval_ReceivedDate,EntityName,EntityID,Status,ActionedBy,Project_Tag,Approval_Comment,UploadedBy,UploadedDateTime,LastUpdatedBy from dbo.tbl_approvals_batch_oms_bulk_upload_archive_dotnet with(nolock) where IsDeleted = 0 order by ID asc";
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_batchomsbulkupload_datagridview_search_dotnet]";
                    if (string.IsNullOrEmpty(searchby_entityid.Text))
                    {
                        cmd.Parameters.AddWithValue("@entityid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@entityid", searchby_entityid.Text);
                    }
                    if (searchby_batchdate.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@batch_date",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@batch_date", searchby_batchdate.Value.Date);
                    }
                    if (string.IsNullOrEmpty(searchby_entityname.Text))
                    {
                        cmd.Parameters.AddWithValue("@entityname",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@entityname", searchby_entityname.Text);
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

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(excelsheetname.Text))
            {
                MessageBox.Show("Please enter excel sheet name");
            }
            else
            {
                string messsage = "Do you want to upload these records?";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(messsage, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    try
                    {
                        button3.Enabled = true;
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        excelfilepath.Text +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + excelsheetname.Text + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                    }
                    catch (Exception ab)
                    {
                        MessageBox.Show("Rows Uploaded Unsuccessfully");
                        MessageBox.Show("Error Generated Details :" + ab.ToString());
                    }
                }
                else
                {
                    excelfilepath.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(excelsheetname.Text))
            {
                MessageBox.Show("Please enter excel sheet name");
            }
            else
            {
                string messsage = "Do you want to upload these records?";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(messsage, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    try
                    {
                        button3.Enabled = true;
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        excelfilepath.Text +
                                        ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                                        //";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + excelsheetname.Text + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        
                    }
                    catch (Exception ab)
                    {
                        MessageBox.Show("Rows Uploaded Unsuccessfully");
                        MessageBox.Show("Error Generated Details :" + ab.ToString());
                    }
                }
                else
                {
                    excelfilepath.Focus();
                }
            }

            if (dataGridView1.RowCount > 0)
            {
                string messsage = "Do you want to upload these records in the final table?";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(messsage, title, buttons);
                if (result == DialogResult.Yes)
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
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "truncate table dbo.tbl_approvals_batch_oms_bulk_upload_daily_dotnet";
                        cmd.ExecuteNonQuery();

                        string pathconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        excelfilepath.Text +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                        OleDbConnection conne = new OleDbConnection(pathconn);
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into dbo.tbl_approvals_batch_oms_bulk_upload_daily_dotnet (Batch,OMS,EntityName,EntityID,Status,Project_Tag,Approval_Comment,UploadedBy,UploadedDateTime,MachineName,BatchID,Profile_Link) values('" + row.Cells["txtBatch"].Value + "','" + row.Cells["txtOMS"].Value + "','" + row.Cells["txtEntityName"].Value + "','" + row.Cells["txtEntityID"].Value + "','" + row.Cells["txtStatus"].Value + "','" + row.Cells["txtProject_Tag"].Value + "','" + row.Cells["txtApproval_Comment"].Value + "','" + Environment.UserName.ToString() + "','" + DateTime.Now.ToLongDateString() + "','" + Environment.MachineName.ToString() + "','" + row.Cells["txtBatchID"].Value + "','" + row.Cells["txtProfile_Link"].Value + "')";
                            cmd.ExecuteNonQuery();

                        }

                        if (batch_date.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please update Batch Date");
                        }
                        else
                        {

                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "dbo.usp_approvals_batch_oms_bulk_upload_archive_dotnet";
                            cmd.Parameters.AddWithValue("@uploadedby", Environment.UserName.ToString());
                            cmd.Parameters.AddWithValue("@batchdate", batch_date.Value.Date);
                            cmd.Parameters.Add("@message", SqlDbType.NVarChar, 2000);
                            cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            string uploadmessage = cmd.Parameters["@message"].Value.ToString();
                            MessageBox.Show("" + uploadmessage.ToString());
                            cmd.Parameters.Clear();
                            datagridview_display_overall();
                            reset_overall();
                            conn.Close();
                        }


                    }

                    catch (Exception ab)
                    {
                        MessageBox.Show("Rows uploaded unsuccessfully into final table");
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        datagridview_display_overall();
                        MessageBox.Show("Error Generated Details :" + ab.ToString());
                        reset_overall();
                    }
                }
                else
                {
                    excelfilepath.Focus();
                }
            }
            else
            {
                MessageBox.Show("There are no records to be uploaded");
            }
             
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //if (dataGridView1.CurrentRow != null)
            //{
            //    try
            //    {
            //        DataGridViewRow dgvrow = dataGridView1.CurrentRow;
            //        conn.ConnectionString = connectionstringtxt;
            //        cmd.Connection = conn;
            //        conn.Open();
            //        cmd.Parameters.Clear();
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.CommandText = "dbo.usp_approvals_update_projecttag_batch_oms_update_dotnet";
            //        cmd.Parameters.AddWithValue("@ID", dgvrow.Cells["txtID"].Value);
            //        if (string.IsNullOrEmpty(dgvrow.Cells["txtProject_Tag"].Value.ToString()))
            //        {
            //            cmd.Parameters.AddWithValue("@Project_Tag", DBNull.Value);
            //        }
            //        else
            //        {
            //            cmd.Parameters.AddWithValue("@Project_Tag", dgvrow.Cells["txtProject_Tag"].Value.ToString());
            //        }
            //        if (string.IsNullOrEmpty(dgvrow.Cells["txtApproval_Comment"].Value.ToString()))
            //        {
            //            cmd.Parameters.AddWithValue("@Approval_Comment",DBNull.Value);
            //        }
            //        else
            //        {
            //            cmd.Parameters.AddWithValue("@Approval_Comment", dgvrow.Cells["txtApproval_Comment"].Value.ToString());
            //        }
            //        cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 500);
            //        cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
            //        cmd.ExecuteNonQuery();
            //        string leavemessage2 = cmd.Parameters["@Message"].Value.ToString();
            //        if (!string.IsNullOrEmpty(leavemessage2))
            //        {
            //            MessageBox.Show("" + leavemessage2.ToString());
            //        }
            //        else
            //        {
            //            MessageBox.Show("Records Updated Successfully");
            //        }
            //        datagridview_display_overall();
            //    }

            //    catch (Exception ab)
            //    {
            //        MessageBox.Show("Error Generated Details :" + ab.ToString());
            //        datagridview_display_overall();

            //    }
            //}
             
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://wtwonlineap.sharepoint.com/:x:/r/sites/tctnonclient_edskycoms/_layouts/15/Doc.aspx?sourcedoc=%7B2ED25E04-0849-411B-8D4F-B6F6C4E51FD2%7D&file=Batch_OMS_Bulk_Approval_Template.xlsx&action=default&mobileredirect=true");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void pending_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    bool isselected = Convert.ToBoolean(item.Cells["txtCheckValue"].Value);
                    if (isselected)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }

                        cmd.Parameters.Clear();
                        conn.ConnectionString = connectionstringtxt;
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update dbo.tbl_approvals_batch_oms_bulk_upload_archive_dotnet set Status = 'Completed', LastUpdatedDateTime = @LastUpdatedDateTime, LastUpdatedBy = @LastUpdatedBy, Approval_ReceivedDate = getdate()  where ID = @ID";
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(item.Cells["txtID"].Value));
                        cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                        cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        
                        conn.Close();
                    }
                }
                MessageBox.Show("Status Updated Successfully");
                datagridview_display_overall();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in dataGridView1.Rows)
            {
                if (myrow.Cells["txtStatus"].Value.ToString() == "Completed")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (myrow.Cells["txtStatus"].Value.ToString() == "Pending")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string messsage = "Do you want to update the record?";
            //string title = "Message Box";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(messsage, title, buttons);
            //if (result == DialogResult.Yes)
            //{
            if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    id.Text = row.Cells["txtID"].Value.ToString();
                    comments.Text = row.Cells["txtApproval_Comment"].Value.ToString();
                    project_tag.Text = row.Cells["txtProject_Tag"].Value.ToString();
                }
            //}
            //else
            //{
            //    id.Focus();
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                cmd.Parameters.Clear();
                //conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                if (!string.IsNullOrEmpty(comments.Text))
                {
                    cmd.CommandText = "update dbo.tbl_approvals_batch_oms_bulk_upload_archive_dotnet set approval_comment = @comments, lastupdateddatetime = @lastupdateddatetime, lastupdatedby = @lastupdatedby where ID = @id";
                    cmd.Parameters.AddWithValue("@id", id.Text);
                    cmd.Parameters.AddWithValue("@comments", comments.Text);
                    cmd.Parameters.AddWithValue("@lastupdateddatetime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                }
                else if (!string.IsNullOrEmpty(project_tag.Text))
                {
                    cmd.CommandText = "update dbo.tbl_approvals_batch_oms_bulk_upload_archive_dotnet set project_tag = @project_tag, lastupdateddatetime = @lastupdateddatetime, lastupdatedby = @lastupdatedby where ID = @id";
                    cmd.Parameters.AddWithValue("@id", id.Text);
                    cmd.Parameters.AddWithValue("@project_tag", project_tag.Text);
                    cmd.Parameters.AddWithValue("@lastupdateddatetime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                }
                else if (!string.IsNullOrEmpty(comments.Text) && !string.IsNullOrEmpty(project_tag.Text))
                {
                    cmd.CommandText = "update dbo.tbl_approvals_batch_oms_bulk_upload_archive_dotnet set approval_comment = @comments, project_tag = @project_tag, lastupdateddatetime = @lastupdateddatetime, lastupdatedby = @lastupdatedby where ID = @id";
                    cmd.Parameters.AddWithValue("@id", id.Text);
                    cmd.Parameters.AddWithValue("@comments", comments.Text);
                    cmd.Parameters.AddWithValue("@project_tag", project_tag.Text);
                    cmd.Parameters.AddWithValue("@lastupdateddatetime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                cmd.Parameters.Clear();
                reset_overall();
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details" + ab.ToString());
            }
        }

        private void searchby_entityid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void batch_date_ValueChanged(object sender, EventArgs e)
        {
            batch_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void batch_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                batch_date.CustomFormat = " ";
            }
        }

        private void searchby_batchdate_ValueChanged(object sender, EventArgs e)
        {
            searchby_batchdate.CustomFormat = "dd-MMMM-yyyy";
            datagridview_display_overall();
        }

        private void searchby_batchdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_batchdate.CustomFormat = " ";
            }
            datagridview_display_overall();
        }

        private void searchby_entityname_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }
    }
}
