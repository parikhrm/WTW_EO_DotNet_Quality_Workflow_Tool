using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workflow
{
    public partial class Sanctions_QC : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";

        public Sanctions_QC()
        {
            InitializeComponent();
        }

        private void Sanctions_QC_Load(object sender, EventArgs e)
        {

        }

        public void reset_overall()
        {
            party_name_lookup.Visible = false;
            party_name_lookup.SelectedIndex = -1;
            client_country_lookup.Visible = false;
            client_country_lookup.SelectedIndex = -1;
            legal_entity_name_lookup.Visible=false;
            legal_entity_name_lookup.SelectedIndex= -1;
            id.Enabled = false;
            id.Text = string.Empty;
            process.SelectedIndex = -1;
            month.CustomFormat = " ";
            requestid_batchid.Text = string.Empty;
            gcid_trackingid.Text = string.Empty;
            legal_entity_name.Text = string.Empty;
            party_name.Text = string.Empty;
            principal_name.Text = string.Empty;
            client_country.SelectedIndex = -1;
            client_risk_category.SelectedIndex = -1;
            global_sanctions.SelectedIndex = -1;
            type_of_global_sanctions.Text = string.Empty;
            regional_sanctions.SelectedIndex = -1;
            regional_sanctions_type.Text = string.Empty;
            sanctions_identified_date.CustomFormat = " ";
            sanctions_notified_date.CustomFormat = " ";
            completion_date.CustomFormat = " ";
            requestor_email_address.Text = string.Empty;
            segment.SelectedIndex = -1;
            lob.SelectedIndex = -1;
            region.SelectedIndex = -1;
            requestor_location.SelectedIndex = -1;
            sanctions_status.SelectedIndex = -1;
            comments.Text = string.Empty;
            insert.Enabled = true;
            update.Enabled = false;
            datagridview_display_overall();
        }

        public void segmentname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Global_Directory obj_global_directory = new Global_Directory();
                DataTable dtaa = new DataTable();
                obj_global_directory.segmentname_list(dtaa);
                segment.DataSource = dtaa;
                segment.DisplayMember = "SegmentName";
                conn.Close();
                segment.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void lob_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Global_Directory obj_global_directory = new Global_Directory();
                DataTable dtaa = new DataTable();
                obj_global_directory.lob_list(dtaa);
                lob.DataSource = dtaa;
                lob.DisplayMember = "LOB";
                conn.Close();
                lob.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void sub_region_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Global_Directory obj_global_directory = new Global_Directory();
                DataTable dtaa = new DataTable();
                obj_global_directory.sub_region_list(dtaa);
                region.DataSource = dtaa;
                region.DisplayMember = "Sub_Region_New";
                conn.Close();
                region.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void requestor_location_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Global_Directory obj_global_directory = new Global_Directory();
                DataTable dtaa = new DataTable();
                obj_global_directory.requestor_location_list(dtaa);
                requestor_location.DataSource = dtaa;
                requestor_location.DisplayMember = "Country";
                conn.Close();
                requestor_location.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void requestor_details()
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
                cmd.CommandText = "select * from dbo.vw_Globaldirectory_Upload_New where Requestor_Email_address = @Requestor_Email_address";
                cmd.Parameters.AddWithValue("@Requestor_Email_address",requestor_email_address.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                segment.DataSource = dt;
                segment.DisplayMember = "SegmentName";

                lob.DataSource = dt;
                lob.DisplayMember = "LOB";

                region.DataSource = dt;
                region.DisplayMember = "Sub_Region_New";

                requestor_location.DataSource = dt;
                requestor_location.DisplayMember = "Country";

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void request_details_kyc()
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
                cmd.CommandText = "select * from dbo.tbl_datamart_party with(nolock) where RequestID = @RequestID";
                cmd.Parameters.AddWithValue("@RequestID", requestid_batchid.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                party_name_lookup.DataSource = dt;
                party_name_lookup.DisplayMember = "PartyName";
                party_name.Text = party_name_lookup.Text;

                client_country_lookup.DataSource = dt;
                client_country_lookup.DisplayMember = "ClientCountry";
                client_country.Text = client_country_lookup.Text;

                legal_entity_name_lookup.DataSource = dt;
                legal_entity_name_lookup.DisplayMember = "LegalEntityName";
                legal_entity_name.Text = legal_entity_name_lookup.Text;

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

                if (string.IsNullOrEmpty(searchby_requestid_batchid.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 10 ID,Process,Month,RequestID_BatchID,GCID_TrackingID,WTW_Legal_Entity_Name,Party_Name,Principle_Name,Client_Country,Client_Risk_Category,Global_Sanctions,Type_Of_Global_Sanctions,Regional_Sanctions,Regional_Sanction_Type\r\n,Segment_Name\r\n,Sanctions_Identified_Date,Sanctions_Notified_Date,Request_Completion_Date,Requestor_Email_Address,LOB,Requestor_Location,Region,Sanctions_Status,Comments,Chaser1_Due_Date,Chaser2_Due_Date,Chaser1_Status,Chaser2_Status,LastUpdatedDateTime,LastUpdatedBy from dbo.tbl_sanctions_qc_daily_dotnet with(nolock) where IsDeleted = 0";
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_sanctions_qc_datagridview_search_dotnet";
                    if (string.IsNullOrEmpty(searchby_requestid_batchid.Text))
                    {
                        cmd.Parameters.AddWithValue("@requestid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@requestid", searchby_requestid_batchid.Text);
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


        private void month_ValueChanged(object sender, EventArgs e)
        {
            month.CustomFormat = "MMMM-yyyy";
        }

        private void month_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                month.CustomFormat = " ";
            }
        }

        private void sanctions_identified_date_ValueChanged(object sender, EventArgs e)
        {
            sanctions_identified_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void sanctions_identified_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                sanctions_identified_date.CustomFormat = " ";
            }
        }

        private void sanctions_notified_date_ValueChanged(object sender, EventArgs e)
        {
            sanctions_notified_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void sanctions_notified_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                sanctions_notified_date.CustomFormat = " ";
            }
        }

        private void completion_date_ValueChanged(object sender, EventArgs e)
        {
            completion_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void completion_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completion_date.CustomFormat = " ";
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to insert this record?";
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
                    cmd.Parameters.Clear();
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    //cmd.CommandText = "insert into tbl_approvals_daily_dotnet(processtype,drdprocess,approvalteam,receiveddate,receivedtime,completiondate,completiontime,noofemails,associatename,requestorbusinessunit,partyname,principalname,category,noofrecords,qualityparameters,TypeofBreaches,FeedbackGiven,TypeofError,NoofCriticalErrors,NoofMinorErrors,Comments,CorrectiveActionTaken,CorrectiveActionDate,CorrectiveActionTime,CorrectiveActionComments,ReasonsforDisagreement,lastupdatedatetime,isdeleted,machinename,principletype,riskid,BatchID,PartyLocation,RiskCategory,EventCodes) values (@processtypeparam,@drdprocessparam,@approvalteamnameparam,@receiveddateparam,@receivedtimeparam,@completiondateparam,@completiontimeparam,@noofemailsparam,@associatenameparam,@requestorbusinessunitparam,@partynameparam,@principalnameparam,@categorynameparam,@noofrecordsparam,@qualityparametersparam,@typeofbreachesparam,@feedbackgivenparam,@typeoferrorparam,@noofcriticalerrorsparam,@noofminorerrorsparam,@commentsparam,@correctiveactiontakenparam,@correctiveactiondateparam,@correctiveactiontimeparam,@correctiveactioncommentsparam,@reasonsfordisagreementparam,@lastupdatedatetimeparam,@isdeletedparam,@machinenameparam,@principletypeparam,@riskidparam,@BatchIDparam,@PartyLocationparam,@RiskCategory,@EventCodes)";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_sanctions_qc_insert_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@Process",process.Text);
                    cmd.Parameters.AddWithValue("@Month",month.Value.Date);
                    cmd.Parameters.AddWithValue("@RequestID_BatchID",requestid_batchid.Text);
                    cmd.Parameters.AddWithValue("@GCID_TrackingID",gcid_trackingid.Text);
                    cmd.Parameters.AddWithValue("@WTW_Legal_Entity_Name",legal_entity_name.Text);
                    cmd.Parameters.AddWithValue("@Party_Name",party_name.Text);
                    cmd.Parameters.AddWithValue("@Principle_Name",principal_name.Text);
                    cmd.Parameters.AddWithValue("@Client_Country",client_country.Text);
                    cmd.Parameters.AddWithValue("@Client_Risk_Category",client_risk_category.Text);
                    cmd.Parameters.AddWithValue("@Global_Sanctions",global_sanctions.Text);
                    cmd.Parameters.AddWithValue("@Type_Of_Global_Sanctions",type_of_global_sanctions.Text);
                    cmd.Parameters.AddWithValue("@Regional_Sanctions",regional_sanctions.Text);
                    cmd.Parameters.AddWithValue("@Regional_Sanction_Type",regional_sanctions_type.Text);
                    cmd.Parameters.AddWithValue("@Segment_Name",segment.Text);
                    cmd.Parameters.AddWithValue("@Sanctions_Identified_Date",sanctions_identified_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Sanctions_Notified_Date",sanctions_notified_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Request_Completion_Date",completion_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Requestor_Email_Address",requestor_email_address.Text);
                    cmd.Parameters.AddWithValue("@LOB",lob.Text);
                    cmd.Parameters.AddWithValue("@Requestor_Location",requestor_location.Text);
                    cmd.Parameters.AddWithValue("@Region",region.Text);
                    cmd.Parameters.AddWithValue("@Sanctions_Status",sanctions_status.Text);
                    cmd.Parameters.AddWithValue("@Comments",comments.Text);
                    cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());

                    if (string.IsNullOrEmpty(process.Text))
                    {
                        MessageBox.Show("Please update Process");
                    }
                    else if (month.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Month");
                    }
                    else if (string.IsNullOrEmpty(requestid_batchid.Text))
                    {
                        MessageBox.Show("Please update RequestID_BatchID");
                    }
                    else if (string.IsNullOrEmpty(gcid_trackingid.Text))
                    {
                        MessageBox.Show("Please update GCID_TrackingID");
                    }
                    else if(string.IsNullOrEmpty(legal_entity_name.Text))
                    {
                        MessageBox.Show("Please update Legal Entity Name");
                    }
                    else if(string.IsNullOrEmpty(party_name.Text))
                    {
                        MessageBox.Show("Please update Party Name");
                    }
                    else if(string.IsNullOrEmpty(principal_name.Text))
                    {
                        MessageBox.Show("Please update Principal Name");
                    }
                    else if(string.IsNullOrEmpty(client_country.Text))
                    {
                        MessageBox.Show("Please update Client Country");
                    }
                    else if(string.IsNullOrEmpty(client_risk_category.Text))
                    {
                        MessageBox.Show("Please update Client Risk Category");
                    }
                    else if(string.IsNullOrEmpty(global_sanctions.Text))
                    {
                        MessageBox.Show("Please update Global Sanctions");
                    }
                    else if(string.IsNullOrEmpty(type_of_global_sanctions.Text))
                    {
                        MessageBox.Show("Please update Type of Global Sanctions");
                    }
                    else if(string.IsNullOrEmpty(regional_sanctions.Text))
                    {
                        MessageBox.Show("Please update Regional Sanctions");
                    }
                    else if(string.IsNullOrEmpty(regional_sanctions_type.Text))
                    {
                        MessageBox.Show("Please update Regional Sanctions Type");
                    }
                    else if(sanctions_identified_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Sanctions Identified Date");
                    }
                    else if(sanctions_notified_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Sanctions Notified Date");
                    }
                    else if(completion_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Completion Date");
                    }
                    else if(string.IsNullOrEmpty(requestor_email_address.Text))
                    {
                        MessageBox.Show("Please update Requestor Email Address");
                    }
                    else if(string.IsNullOrEmpty(segment.Text))
                    {
                        MessageBox.Show("Please update Segment Name");
                    }
                    else if(string.IsNullOrEmpty(lob.Text))
                    {
                        MessageBox.Show("Please update LOB name");
                    }
                    else if(string.IsNullOrEmpty(region.Text))
                    {
                        MessageBox.Show("Please update Region");
                    }
                    else if(string.IsNullOrEmpty(requestor_location.Text))
                    {
                        MessageBox.Show("Please update Requestor Location");
                    }
                    else if(string.IsNullOrEmpty(sanctions_status.Text))
                    {
                        MessageBox.Show("Please update Sanctions Status");
                    }
                    else
                    {
                        conn.Open();
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
                    MessageBox.Show("Error Generated Details" + ab.ToString());
                }
            }
            else
            {
                id.Focus();
            }
        }

        private void requestor_email_address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                requestor_details();
            }
        }

        private void requestid_batchid_TextChanged(object sender, EventArgs e)
        {
            if(process.Text == "KYC")
            {
                request_details_kyc();
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void searchby_requestid_batchid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }
    }
}
