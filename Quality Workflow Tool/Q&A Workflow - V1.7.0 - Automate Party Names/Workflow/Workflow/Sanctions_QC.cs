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
            reset_overall();
        }

        public void reset_overall()
        {
            party_name_lookup.Visible = false;
            party_name_lookup.SelectedIndex = -1;
            legal_entity_name_lookup.Visible = false;
            legal_entity_name_lookup.SelectedIndex = -1;
            gcid_partylookup.Visible = false;
            gcid_partylookup.SelectedIndex = -1;
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
            relationship_type.SelectedIndex = -1;
            qc_status.SelectedIndex = -1;
            sanctions_risk_status.SelectedIndex = -1;
            chaser1_sent.CustomFormat = " ";
            chaser2_sent.CustomFormat = " ";
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
                cmd.CommandText = "select Requestor_Email_Address,LOB,Country,Sub_Region_New,SegmentName from dbo.vw_Globaldirectory_Upload_New where Requestor_Email_address = @Requestor_Email_address union select Requestor_Email_Address,LOB,Requestor_Location,Sub_Region_Derived,SegmentName from dbo.tbl_globaldirectory_sanctions_qc with(nolock) where Requestor_Email_address = @Requestor_Email_address ";
                cmd.Parameters.AddWithValue("@Requestor_Email_address", requestor_email_address.Text);
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

                client_country.DataSource = dt;
                client_country.DisplayMember = "ClientCountry";

                legal_entity_name_lookup.DataSource = dt;
                legal_entity_name_lookup.DisplayMember = "LegalEntityName";
                legal_entity_name.Text = legal_entity_name_lookup.Text;

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void request_details_kyc_gcid()
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
                cmd.CommandText = "select * from kycRequest_Request.Item with(nolock) where RequestID = @RequestID";
                cmd.Parameters.AddWithValue("@RequestID", requestid_batchid.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                gcid_partylookup.DataSource = dt;
                gcid_partylookup.DisplayMember = "GCID";
                gcid_trackingid.Text = gcid_partylookup.Text;

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void request_details_oms()
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
                cmd.CommandText = "select a.RequestId,a.ResultName as PartyName, b.ShortName, GCID as CountryName from kycRequest_Request.Item a with(nolock) inner join [kycrequest_Ref].[Country] b with(nolock) on a.CountryCode = b.CountryAlpha2Code where a.RequestID = @RequestID";
                cmd.Parameters.AddWithValue("@RequestID", requestid_batchid.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                party_name_lookup.DataSource = dt;
                party_name_lookup.DisplayMember = "PartyName";
                party_name.Text = party_name_lookup.Text;

                client_country.DataSource = dt;
                client_country.DisplayMember = "ClientCountry";

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
                    cmd.CommandText = "select top 10 ID,Process,Month,RequestID_BatchID,GCID_TrackingID,WTW_Legal_Entity_Name,Party_Name,Principle_Name,Client_Country,Client_Risk_Category,Global_Sanctions,Type_Of_Global_Sanctions,Regional_Sanctions,Regional_Sanction_Type\r\n,Segment_Name\r\n,Sanctions_Identified_Date,Sanctions_Notified_Date,Request_Completion_Date,Requestor_Email_Address,LOB,Requestor_Location,Region,Sanctions_Status,Comments,Chaser1_Due_Date,Chaser2_Due_Date,Chaser1_Status,Chaser2_Status,LastUpdatedDateTime,LastUpdatedBy,Relationship_Type,QC_Status,Sanctions_Risk_Status,Chaser1_Sent,Chaser2_Sent from dbo.tbl_sanctions_qc_daily_dotnet with(nolock) where IsDeleted = 0";
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

                    cmd.Parameters.AddWithValue("@Process", process.Text);
                    cmd.Parameters.AddWithValue("@Month", month.Value.Date);
                    cmd.Parameters.AddWithValue("@RequestID_BatchID", requestid_batchid.Text);
                    cmd.Parameters.AddWithValue("@GCID_TrackingID", gcid_trackingid.Text);
                    cmd.Parameters.AddWithValue("@WTW_Legal_Entity_Name", legal_entity_name.Text);
                    cmd.Parameters.AddWithValue("@Party_Name", party_name.Text);
                    cmd.Parameters.AddWithValue("@Principle_Name", principal_name.Text);
                    cmd.Parameters.AddWithValue("@Client_Country", client_country.Text);
                    cmd.Parameters.AddWithValue("@Client_Risk_Category", client_risk_category.Text);
                    cmd.Parameters.AddWithValue("@Global_Sanctions", global_sanctions.Text);
                    cmd.Parameters.AddWithValue("@Type_Of_Global_Sanctions", type_of_global_sanctions.Text);
                    cmd.Parameters.AddWithValue("@Regional_Sanctions", regional_sanctions.Text);
                    cmd.Parameters.AddWithValue("@Regional_Sanction_Type", regional_sanctions_type.Text);
                    cmd.Parameters.AddWithValue("@Segment_Name", segment.Text);
                    cmd.Parameters.AddWithValue("@Sanctions_Identified_Date", sanctions_identified_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Sanctions_Notified_Date", sanctions_notified_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Request_Completion_Date", completion_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Requestor_Email_Address", requestor_email_address.Text);
                    cmd.Parameters.AddWithValue("@LOB", lob.Text);
                    cmd.Parameters.AddWithValue("@Requestor_Location", requestor_location.Text);
                    cmd.Parameters.AddWithValue("@Region", region.Text);
                    cmd.Parameters.AddWithValue("@Sanctions_Status", sanctions_status.Text);
                    cmd.Parameters.AddWithValue("@Comments", comments.Text);
                    cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                    if (string.IsNullOrEmpty(relationship_type.Text))
                    {
                        cmd.Parameters.AddWithValue("@Relationship_Type", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Relationship_Type", relationship_type.Text);
                    }
                    if (string.IsNullOrEmpty(qc_status.Text))
                    {
                        cmd.Parameters.AddWithValue("@QC_Status", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QC_Status", qc_status);
                    }
                    if (string.IsNullOrEmpty(sanctions_risk_status.Text))
                    {
                        cmd.Parameters.AddWithValue("@Sanctions_Risk_Status", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Sanctions_Risk_Status", sanctions_risk_status.Text);
                    }
                    if (chaser1_sent.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Chaser1_Sent", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Chaser1_Sent", chaser1_sent.Value.Date);
                    }
                    if (chaser2_sent.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Chaser2_Sent", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Chaser2_Sent", chaser2_sent.Value.Date);
                    }

                    //If conditions
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
                    else if (string.IsNullOrEmpty(legal_entity_name.Text))
                    {
                        MessageBox.Show("Please update Legal Entity Name");
                    }
                    else if (string.IsNullOrEmpty(party_name.Text))
                    {
                        MessageBox.Show("Please update Party Name");
                    }
                    else if (string.IsNullOrEmpty(principal_name.Text))
                    {
                        MessageBox.Show("Please update Principal Name");
                    }
                    else if (string.IsNullOrEmpty(client_country.Text))
                    {
                        MessageBox.Show("Please update Client Country");
                    }
                    else if (string.IsNullOrEmpty(client_risk_category.Text))
                    {
                        MessageBox.Show("Please update Client Risk Category");
                    }
                    else if (string.IsNullOrEmpty(global_sanctions.Text))
                    {
                        MessageBox.Show("Please update Global Sanctions");
                    }
                    else if (string.IsNullOrEmpty(type_of_global_sanctions.Text))
                    {
                        MessageBox.Show("Please update Type of Global Sanctions");
                    }
                    else if (string.IsNullOrEmpty(regional_sanctions.Text))
                    {
                        MessageBox.Show("Please update Regional Sanctions");
                    }
                    else if (string.IsNullOrEmpty(regional_sanctions_type.Text))
                    {
                        MessageBox.Show("Please update Regional Sanctions Type");
                    }
                    else if (sanctions_identified_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Sanctions Identified Date");
                    }
                    else if (sanctions_notified_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Sanctions Notified Date");
                    }
                    else if (completion_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Completion Date");
                    }
                    else if (string.IsNullOrEmpty(requestor_email_address.Text))
                    {
                        MessageBox.Show("Please update Requestor Email Address");
                    }
                    else if (string.IsNullOrEmpty(segment.Text))
                    {
                        MessageBox.Show("Please update Segment Name");
                    }
                    else if (string.IsNullOrEmpty(lob.Text))
                    {
                        MessageBox.Show("Please update LOB name");
                    }
                    else if (string.IsNullOrEmpty(region.Text))
                    {
                        MessageBox.Show("Please update Region");
                    }
                    else if (string.IsNullOrEmpty(requestor_location.Text))
                    {
                        MessageBox.Show("Please update Requestor Location");
                    }
                    else if (string.IsNullOrEmpty(sanctions_status.Text))
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
            //if (process.Text == "KYC")
            //{
            //    request_details_kyc();
            //    request_details_kyc_gcid();
            //}
            //if (process.Text == "OMS")
            //{
            //    request_details_oms();
            //}
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void searchby_requestid_batchid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void update_Click(object sender, EventArgs e)
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
                    cmd.CommandText = "dbo.usp_sanctions_qc_update_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@Process", process.Text);
                    cmd.Parameters.AddWithValue("@ID", id.Text);
                    cmd.Parameters.AddWithValue("@Month", month.Value.Date);
                    cmd.Parameters.AddWithValue("@RequestID_BatchID", requestid_batchid.Text);
                    cmd.Parameters.AddWithValue("@GCID_TrackingID", gcid_trackingid.Text);
                    cmd.Parameters.AddWithValue("@WTW_Legal_Entity_Name", legal_entity_name.Text);
                    cmd.Parameters.AddWithValue("@Party_Name", party_name.Text);
                    cmd.Parameters.AddWithValue("@Principle_Name", principal_name.Text);
                    cmd.Parameters.AddWithValue("@Client_Country", client_country.Text);
                    cmd.Parameters.AddWithValue("@Client_Risk_Category", client_risk_category.Text);
                    cmd.Parameters.AddWithValue("@Global_Sanctions", global_sanctions.Text);
                    cmd.Parameters.AddWithValue("@Type_Of_Global_Sanctions", type_of_global_sanctions.Text);
                    cmd.Parameters.AddWithValue("@Regional_Sanctions", regional_sanctions.Text);
                    cmd.Parameters.AddWithValue("@Regional_Sanction_Type", regional_sanctions_type.Text);
                    cmd.Parameters.AddWithValue("@Segment_Name", segment.Text);
                    cmd.Parameters.AddWithValue("@Sanctions_Identified_Date", sanctions_identified_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Sanctions_Notified_Date", sanctions_notified_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Request_Completion_Date", completion_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Requestor_Email_Address", requestor_email_address.Text);
                    cmd.Parameters.AddWithValue("@LOB", lob.Text);
                    cmd.Parameters.AddWithValue("@Requestor_Location", requestor_location.Text);
                    cmd.Parameters.AddWithValue("@Region", region.Text);
                    cmd.Parameters.AddWithValue("@Sanctions_Status", sanctions_status.Text);
                    cmd.Parameters.AddWithValue("@Comments", comments.Text);
                    cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                    if (string.IsNullOrEmpty(relationship_type.Text))
                    {
                        cmd.Parameters.AddWithValue("@Relationship_Type", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Relationship_Type", relationship_type.Text);
                    }
                    if (string.IsNullOrEmpty(qc_status.Text))
                    {
                        cmd.Parameters.AddWithValue("@QC_Status", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QC_Status", qc_status);
                    }
                    if (string.IsNullOrEmpty(sanctions_risk_status.Text))
                    {
                        cmd.Parameters.AddWithValue("@Sanctions_Risk_Status", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Sanctions_Risk_Status", sanctions_risk_status.Text);
                    }
                    if (chaser1_sent.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Chaser1_Sent", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Chaser1_Sent", chaser1_sent.Value.Date);
                    }
                    if (chaser2_sent.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Chaser2_Sent", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Chaser2_Sent", chaser2_sent.Value.Date);
                    }

                    //If conditions
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
                    else if (string.IsNullOrEmpty(legal_entity_name.Text))
                    {
                        MessageBox.Show("Please update Legal Entity Name");
                    }
                    else if (string.IsNullOrEmpty(party_name.Text))
                    {
                        MessageBox.Show("Please update Party Name");
                    }
                    else if (string.IsNullOrEmpty(principal_name.Text))
                    {
                        MessageBox.Show("Please update Principal Name");
                    }
                    else if (string.IsNullOrEmpty(client_country.Text))
                    {
                        MessageBox.Show("Please update Client Country");
                    }
                    else if (string.IsNullOrEmpty(client_risk_category.Text))
                    {
                        MessageBox.Show("Please update Client Risk Category");
                    }
                    else if (string.IsNullOrEmpty(global_sanctions.Text))
                    {
                        MessageBox.Show("Please update Global Sanctions");
                    }
                    else if (string.IsNullOrEmpty(type_of_global_sanctions.Text))
                    {
                        MessageBox.Show("Please update Type of Global Sanctions");
                    }
                    else if (string.IsNullOrEmpty(regional_sanctions.Text))
                    {
                        MessageBox.Show("Please update Regional Sanctions");
                    }
                    else if (string.IsNullOrEmpty(regional_sanctions_type.Text))
                    {
                        MessageBox.Show("Please update Regional Sanctions Type");
                    }
                    else if (sanctions_identified_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Sanctions Identified Date");
                    }
                    else if (sanctions_notified_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Sanctions Notified Date");
                    }
                    else if (completion_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Completion Date");
                    }
                    else if (string.IsNullOrEmpty(requestor_email_address.Text))
                    {
                        MessageBox.Show("Please update Requestor Email Address");
                    }
                    else if (string.IsNullOrEmpty(segment.Text))
                    {
                        MessageBox.Show("Please update Segment Name");
                    }
                    else if (string.IsNullOrEmpty(lob.Text))
                    {
                        MessageBox.Show("Please update LOB name");
                    }
                    else if (string.IsNullOrEmpty(region.Text))
                    {
                        MessageBox.Show("Please update Region");
                    }
                    else if (string.IsNullOrEmpty(requestor_location.Text))
                    {
                        MessageBox.Show("Please update Requestor Location");
                    }
                    else if (string.IsNullOrEmpty(sanctions_status.Text))
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
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    id.Text = row.Cells["txt_ID"].Value.ToString();
                    process.Text = row.Cells["txt_Process"].Value.ToString();
                    month.Text = row.Cells["txt_Month"].Value.ToString();
                    month.CustomFormat = "MMMM-yyyy";
                    requestid_batchid.Text = row.Cells["txt_RequestID_BatchID"].Value.ToString();
                    gcid_trackingid.Text = row.Cells["txt_GCID_TrackingID"].Value.ToString();
                    legal_entity_name.Text = row.Cells["txt_WTW_Legal_Entity_Name"].Value.ToString();
                    party_name.Text = row.Cells["txt_Party_Name"].Value.ToString();
                    principal_name.Text = row.Cells["txt_Principle_Name"].Value.ToString();
                    client_country.Text = row.Cells["txt_Client_Country"].Value.ToString();
                    client_risk_category.Text = row.Cells["txt_Client_Risk_Category"].Value.ToString();
                    global_sanctions.Text = row.Cells["txt_Global_Sanctions"].Value.ToString();
                    type_of_global_sanctions.Text = row.Cells["txt_Type_Of_Global_Sanctions"].Value.ToString();
                    regional_sanctions.Text = row.Cells["txt_Regional_Sanctions"].Value.ToString();
                    regional_sanctions_type.Text = row.Cells["txt_Regional_Sanction_Type"].Value.ToString();
                    sanctions_identified_date.Text = row.Cells["txt_Sanctions_Identified_Date"].Value.ToString();
                    sanctions_identified_date.CustomFormat = "dd-MMMM-yyyy";
                    sanctions_notified_date.Text = row.Cells["txt_Sanctions_Notified_Date"].Value.ToString();
                    sanctions_notified_date.CustomFormat = "dd-MMMM-yyyy";
                    completion_date.Text = row.Cells["txt_Request_Completion_Date"].Value.ToString();
                    completion_date.CustomFormat = "dd-MMMM-yyyy";
                    requestor_email_address.Text = row.Cells["txt_Requestor_Email_Address"].Value.ToString();
                    segment.Text = row.Cells["txt_Segment_Name"].Value.ToString();
                    lob.Text = row.Cells["txt_LOB"].Value.ToString();
                    region.Text = row.Cells["txt_Region"].Value.ToString();
                    requestor_location.Text = row.Cells["txt_Requestor_Location"].Value.ToString();
                    sanctions_status.Text = row.Cells["txt_Sanctions_Status"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txt_Relationship_Type"].Value.ToString()))
                    {
                        relationship_type.SelectedIndex = -1;
                    }
                    else
                    {
                        relationship_type.Text = row.Cells["txt_Relationship_Type"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_QC_Status"].Value.ToString()))
                    {
                        qc_status.SelectedIndex = -1;
                    }
                    else
                    {
                        qc_status.Text = row.Cells["txt_QC_Status"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Sanctions_Risk_Status"].Value.ToString()))
                    {
                        sanctions_risk_status.SelectedIndex = -1;
                    }
                    else
                    {
                        sanctions_risk_status.Text = row.Cells["txt_Sanctions_Risk_Status"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Comments"].Value.ToString()))
                    {
                        comments.Text = string.Empty;
                    }
                    else
                    {
                        comments.Text = row.Cells["txt_Comments"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Chaser1_Sent"].Value.ToString()))
                    {
                        chaser1_sent.CustomFormat = " ";
                    }
                    else
                    {
                        chaser1_sent.Text = row.Cells["txt_Chaser1_Sent"].Value.ToString();
                        chaser1_sent.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Chaser2_Sent"].Value.ToString()))
                    {
                        chaser2_sent.CustomFormat = " ";
                    }
                    else
                    {
                        chaser2_sent.Text = row.Cells["txt_Chaser2_Sent"].Value.ToString();
                        chaser2_sent.CustomFormat = "dd-MMMM-yyyy";
                    }
                
                }
            }
            else
            {
                id.Focus();
                insert.Enabled = true;
                update.Enabled = false;
            }

        }

        private void requestor_email_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void chaser1_sent_ValueChanged(object sender, EventArgs e)
        {
            chaser1_sent.CustomFormat = "dd-MMMM-yyyy";
        }

        private void chaser1_sent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                chaser1_sent.CustomFormat = " ";
            }
        }

        private void chaser2_sent_ValueChanged(object sender, EventArgs e)
        {
            chaser2_sent.CustomFormat = "dd-MMMM-yyyy";
        }

        private void chaser2_sent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                chaser2_sent.CustomFormat = " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }

        private void raw_data_Click(object sender, EventArgs e)
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

        private void requestid_batchid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (process.Text == "KYC")
                {
                    request_details_kyc();
                    request_details_kyc_gcid();
                }
                if (process.Text == "OMS")
                {
                    request_details_oms();
                }
            }
        }
    }
}
