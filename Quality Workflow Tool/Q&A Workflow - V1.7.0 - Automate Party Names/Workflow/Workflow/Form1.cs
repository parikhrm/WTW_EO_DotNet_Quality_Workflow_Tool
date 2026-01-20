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
    public partial class Form1 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'dRDDataSet3.tbl_approvals_daily_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_approvals_daily_dotnetTableAdapter.Fill(this.dRDDataSet3.tbl_approvals_daily_dotnet);
            //// TODO: This line of code loads data into the 'dRDDataSet2.tbl_BUMappings_May2018onwards' table. You can move, or remove it, as needed.
            //this.tbl_BUMappings_May2018onwardsTableAdapter.Fill(this.dRDDataSet2.tbl_BUMappings_May2018onwards);
            //// TODO: This line of code loads data into the 'dRDDataSet1.tbl_emp_details' table. You can move, or remove it, as needed.
            //this.tbl_emp_detailsTableAdapter.Fill(this.dRDDataSet1.tbl_emp_details);
            //// TODO: This line of code loads data into the 'dRDDataSet.tbl_approvalteamname_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_approvalteamname_dotnetTableAdapter.Fill(this.dRDDataSet.tbl_approvalteamname_dotnet);

            //EmpDetails obj_empdetails = new EmpDetails();
            //ProcessType obj_processtype = new ProcessType();
            //EDSProcess obj_edsprocess = new EDSProcess();
            //CategoryName obj_categoryname = new CategoryName();
            //TypeOfBreaches obj_breaches = new TypeOfBreaches();
            //FeedBackGiven obj_feedback = new FeedBackGiven();
            //QueueName obj_queue = new QueueName();
            //TypeOfError obj_typeoferror = new TypeOfError();
            //QualityParameters obj_quality = new QualityParameters();
            //PrincipleType obj_principle = new PrincipleType();
            //RequestorBusinessUnit obj_bu = new RequestorBusinessUnit();
            //SourceCodes obj_sourcecode = new SourceCodes();
            //PartyLocation obj_partylocation = new PartyLocation();
            //EventCodes obj_evencode = new EventCodes();
            //RiskCategory obj_riskcategory = new RiskCategory();
            

            processtype_list();
            edsprocess_list();
            categoryname_list();
            typeofbreaches_list();
            //feedbackgiven_list();
            typeoferror_list();
            //correctiveactiontaken_list();
            principletype_list();
            empdetails_list();
            partylocation_list();
            riskcategory_list();
            eventcodes_list();
            //atchworkflowqueuestatus_list();
            datagridview1_display_overall();
            //datagridview_batch_approvalsqueue_overall();
            reset_overall();
        }

        public void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        public void reset_overall()
        {
            requestid.Enabled = false;
            receiveddate.Text = DateTime.Now.ToLongDateString();
            receivedtime.Text = DateTime.Now.ToLongTimeString();
            completiondate.CustomFormat = " ";
            completiontime.CustomFormat = " ";
            correctiveactiondate.CustomFormat = " ";
            correctiveactiontime.CustomFormat = " ";
            //completiondate.Enabled = false;
            //completiontime.Enabled = false;
            noofemails.Value = 0;
            partyname.Text = string.Empty;
            principlename.Text = string.Empty;
            categoryname.SelectedIndex = -1;
            noofrecords.Value = 1;
            //noofrecords.Visible = false;
            for (int i = 0; i < qualityparameters.Items.Count; i++)
            {
                qualityparameters.SetItemChecked(i, false);
            }
            //noofcriticalerrors.Value = 0;
            //noofminorerrors.Value = 0;
            comments.Text = string.Empty;
            //correctiveactiondate.Enabled = false;
            //correctiveactiontime.Enabled = false;
            correctiveactioncomments.Text = string.Empty;
            reasonsfordisagreement.Text = string.Empty;
            todaydate.Visible = false;
            todaydate.Text = DateTime.Now.ToLongDateString();
            isdeleted.Visible = false;
            isdeleted.Value = 0;
            qualityparameters.Enabled = true;
            insert.Enabled = true;
            update.Enabled = false;
            processtype.SelectedIndex = -1;
            //processtype_list();
            drdprocess.SelectedIndex = -1;
            //edsprocess_list();
            associatename.SelectedIndex = -1;
            //empdetails_list();
            categoryname.SelectedIndex = -1;
            //categoryname_list();
            ////qualityparameters_list();
            typeofbreach.SelectedIndex = -1;
            //typeofbreaches_list();
            feedbackgiven.SelectedIndex = -1;
            //feedbackgiven_list();
            typeoferror.SelectedIndex = -1;
            //typeoferror_list();
            correctiveactiontaken.SelectedIndex = -1;
            //correctiveactiontaken_list();
            principletype.SelectedIndex = -1;
            //principletype_list();
            //datagridview1_display_overall();
            insert.Enabled = true;
            update.Enabled = false;
            qualityparameters.Enabled = false;
            qualityparameters.Items.Clear();
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            riskid.Text = string.Empty;
            //partylocation_list();
            batchid.Text = string.Empty;
            //label19.Visible = true;
            //batchid.Visible = true;
            label27.Visible = true;
            principletype.Visible = true;
            label13.Visible = true;
            dataGridView4.Visible = false;
            requestid.Text = string.Empty;
            requestid_search.Text = string.Empty;
            riskcategory.SelectedIndex = -1;
            eventcodes.SelectedIndex = -1;
            partyname_lookup.Visible = false;
            principlename_lookup.Visible = false;
            partyname_lookup.SelectedIndex = -1;
            partyname_lookup.Text = string.Empty;
            principlename_lookup.SelectedIndex = -1;
            principlename_lookup.Text = string.Empty;
            partylocation.SelectedIndex = -1;
            datagridview1_cellclick.SelectedIndex = -1;
            datagridview1_cellclick.Text = string.Empty;
            datagridview1_cellclick.Visible = false;
            batchworkflowqueuestatus_search.SelectedIndex = -1;
            batchworkflowinquiryid_search.Text = string.Empty;
            batchworkflow_requestid.Text = string.Empty;
            batchworkflow_requestid.Visible = false;
            approvalreceivedfromdesginatedsmsoapprover.SelectedIndex = -1;
            //temporary adjustment
            dataGridView5.Visible = false;
            tabControl2.Visible = false;
            batchworkflowqueuestatus_search.Visible = false;
            batchworkflowinquiryid_search.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            entityid.Text = string.Empty;
            oms_clientname_autopopulate.Visible = false;
            oms_clientname_autopopulate.SelectedIndex = -1;
        }

        public void autopopulate_clientname_oms()
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
                cmd.CommandText = "dbo.usp_partyname_autopopulate_oms_dotnet_datamart";
                cmd.Parameters.AddWithValue("@RequestID", batchid.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                oms_clientname_autopopulate.DataSource = dt;
                oms_clientname_autopopulate.DisplayMember = "PartyName";
                conn.Close();
                partyname.Text = oms_clientname_autopopulate.Text;
                principlename.Text = oms_clientname_autopopulate.Text;
                //segmentname.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void partydetails_lookup()
        {

            if (string.IsNullOrEmpty(datagridview1_cellclick.Text))
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
                    cmd.CommandText = "select RequestID,PartyName,PrincipleName,PartyLocation,RequestorBusinessUnit from dbo.vw_qualityapprovals_partydetailslookup_dotnet where 1=1 and rownum = 1 and RequestID = @RequestID";
                    cmd.Parameters.AddWithValue("@RequestID", batchid.Text);
                    cmd.ExecuteNonQuery();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        partylocation.DataSource = dt;
                        partylocation.DisplayMember = "PartyLocation";
                        requestorbusinessunit.DataSource = dt;
                        requestorbusinessunit.DisplayMember = "RequestorBusinessUnit";
                        partyname_lookup.DataSource = dt;
                        partyname_lookup.DisplayMember = "PartyName";
                        principlename_lookup.DataSource = dt;
                        principlename_lookup.DisplayMember = "PrincipleName";
                        partyname.Text = partyname_lookup.Text;
                        principlename.Text = principlename_lookup.Text;
                    }
                    else
                    {
                        partyname.Text = string.Empty;
                        principlename.Text = string.Empty;
                        if (drdprocess.Text == "KYC")
                        {
                            requestorbusinessunit_list();
                        }
                        else if (drdprocess.Text == "OMS")
                        {
                            requestorbusinessunit_list();
                        }
                        else
                        {
                            sourcecodes_list();
                        }
                        partylocation_list();
                    }
                    conn.Close();
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details: " + ab.ToString());
                }
            }
            
        }

        public void partydetails_lookup_approvals()
        {

            if (string.IsNullOrEmpty(datagridview1_cellclick.Text))
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
                    cmd.CommandText = "select RequestID,PartyName,PrincipleName,PartyLocation,RequestorBusinessUnit from dbo.vw_qualityapprovals_partydetailslookup_dotnet where 1=1 and rownum = 1 and RequestID = @RequestID";
                    cmd.Parameters.AddWithValue("@RequestID", batchid.Text);
                    cmd.ExecuteNonQuery();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        partylocation.DataSource = dt;
                        partylocation.DisplayMember = "PartyLocation";
                        requestorbusinessunit.DataSource = dt;
                        requestorbusinessunit.DisplayMember = "RequestorBusinessUnit";
                        partyname_lookup.DataSource = dt;
                        partyname_lookup.DisplayMember = "PartyName";
                        principlename_lookup.DataSource = dt;
                        principlename_lookup.DisplayMember = "PrincipleName";
                        partyname.Text = partyname_lookup.Text;
                        //principlename.Text = principlename_lookup.Text;
                        principlename.Text = string.Empty;
                    }
                    else
                    {
                        partyname.Text = string.Empty;
                        principlename.Text = string.Empty;
                        if (drdprocess.Text == "KYC")
                        {
                            requestorbusinessunit_list();
                        }
                        else if (drdprocess.Text == "OMS")
                        {
                            requestorbusinessunit_list();
                        }
                        else
                        {
                            sourcecodes_list();
                        }
                        partylocation_list();
                    }
                    conn.Close();
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details: " + ab.ToString());
                }
            }

        }

        //public void reset_overall()
        //{
        //    requestid.Enabled = false;
        //    receiveddate.Text = DateTime.Now.ToLongDateString();
        //    receivedtime.Text = DateTime.Now.ToLongTimeString();
        //    completiondate.CustomFormat = " ";
        //    completiontime.CustomFormat = " ";
        //    correctiveactiondate.CustomFormat = " ";
        //    correctiveactiontime.CustomFormat = " ";
        //    //completiondate.Enabled = false;
        //    //completiontime.Enabled = false;
        //    noofemails.Value = 0;
        //    partyname.Text = string.Empty;
        //    principlename.Text = string.Empty;
        //    categoryname.SelectedIndex = -1;
        //    noofrecords.Value = 1;
        //    //noofrecords.Visible = false;
        //    for (int i = 0; i < qualityparameters.Items.Count; i++)
        //    {
        //        qualityparameters.SetItemChecked(i, false);
        //    }
        //    //noofcriticalerrors.Value = 0;
        //    //noofminorerrors.Value = 0;
        //    comments.Text = string.Empty;
        //    //correctiveactiondate.Enabled = false;
        //    //correctiveactiontime.Enabled = false;
        //    correctiveactioncomments.Text = string.Empty;
        //    reasonsfordisagreement.Text = string.Empty;
        //    todaydate.Visible = false;
        //    todaydate.Text = DateTime.Now.ToLongTimeString();
        //    isdeleted.Visible = false;
        //    isdeleted.Value = 0;
        //    qualityparameters.Enabled = true;
        //    insert.Enabled = true;
        //    update.Enabled = false;
        //    processtype_list();
        //    edsprocess_list();
        //    empdetails_list();
        //    categoryname_list();
        //    //qualityparameters_list();
        //    typeofbreaches_list();
        //    feedbackgiven_list();
        //    typeoferror_list();
        //    correctiveactiontaken_list();
        //    principletype_list();
        //    datagridview1_display_overall();
        //    insert.Enabled = true;
        //    update.Enabled = false;
        //    qualityparameters.Enabled = false;
        //    qualityparameters.Items.Clear();
        //    dataGridView2.Visible = false;
        //    dataGridView3.Visible = false;
        //    riskid.Text = string.Empty;
        //    partylocation_list();
        //    batchid.Text = string.Empty;
        //    label19.Visible = true;
        //    batchid.Visible = true;
        //    label27.Visible = true;
        //    principletype.Visible = true;
        //    label13.Visible = true;
        //    dataGridView4.Visible = false;
        //    requestid.Text = string.Empty;
        //    requestid_search.Text = string.Empty;
            
        //}

        public void processtype_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                ProcessType obj_processtype = new ProcessType();
                DataTable dtaa = new DataTable();
                obj_processtype.processtype_list(dtaa);
                processtype.DataSource = dtaa;
                processtype.DisplayMember = "ProcessType";
                conn.Close();
                processtype.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void batchworkflowqueuestatus_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                BatchWorkflowQueueStatus obj_batchworkflowqueuestatus = new BatchWorkflowQueueStatus();
                DataTable dtaa = new DataTable();
                obj_batchworkflowqueuestatus.batchworkflowqueuestatus_list(dtaa);
                batchworkflowqueuestatus_search.DataSource = dtaa;
                batchworkflowqueuestatus_search.DisplayMember = "BatchWorkflow_RequestID_Status";
                conn.Close();
                batchworkflowqueuestatus_search.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void eventcodes_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                EventCodes obj_evencode = new EventCodes();
                DataTable dtaa = new DataTable();
                obj_evencode.evencodes_list(dtaa);
                eventcodes.DataSource = dtaa;
                eventcodes.DisplayMember = "EventCodeDescription";
                conn.Close();
                eventcodes.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void riskcategory_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                RiskCategory obj_riskcategory = new RiskCategory();
                DataTable dtaa = new DataTable();
                obj_riskcategory.riskcategory_list(dtaa);
                riskcategory.DataSource = dtaa;
                riskcategory.DisplayMember = "RiskCategory";
                conn.Close();
                riskcategory.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void partylocation_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                PartyLocation obj_partylocation = new PartyLocation();
                DataTable dtaa = new DataTable();
                obj_partylocation.partylocation_list(dtaa);
                partylocation.DataSource = dtaa;
                partylocation.DisplayMember = "PartyLocation";
                conn.Close();
                partylocation.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }

        }

        public void edsprocess_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                EDSProcess obj_edsprocess = new EDSProcess();
                DataTable dtaa = new DataTable();
                obj_edsprocess.edsprocess_list(dtaa);
                drdprocess.DataSource = dtaa;
                drdprocess.DisplayMember = "ProcessName";
                conn.Close();
                drdprocess.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void empdetails_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                if (drdprocess.Text == "KYC")
                {
                    obj_empdetails.empdetails_list_kyc(dtaa);
                }
                else if (drdprocess.Text == "OMS")
                {
                    obj_empdetails.empdetails_list_kyc(dtaa);
                }
                else if (drdprocess.Text == "Audit")
                {
                    obj_empdetails.empdetails_list_audit(dtaa);
                }
                else
                {
                    obj_empdetails.empdetails_list_batch(dtaa);
                }
                associatename.DataSource = dtaa;
                associatename.DisplayMember = "EmpName";
                conn.Close();
                associatename.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void categoryname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                CategoryName obj_categoryname = new CategoryName();
                DataTable dtaa = new DataTable();
                obj_categoryname.categoryname_list(dtaa);
                categoryname.DataSource = dtaa;
                categoryname.DisplayMember = "CategoryName";
                conn.Close();
                categoryname.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void typeofbreaches_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                TypeOfBreaches obj_breaches = new TypeOfBreaches();
                DataTable dtaa = new DataTable();
                obj_breaches.typeofbreaches_list(dtaa);
                typeofbreach.DataSource = dtaa;
                typeofbreach.DisplayMember = "TypeOfBreach";
                conn.Close();
                typeofbreach.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void feedbackgiven_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                FeedBackGiven obj_feedback = new FeedBackGiven();
                DataTable dtaa = new DataTable();
                obj_feedback.feedbackgiven_list(dtaa);
                feedbackgiven.DataSource = dtaa;
                feedbackgiven.DisplayMember = "FeedBackGiven";
                conn.Close();
                feedbackgiven.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        

        public void typeoferror_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                TypeOfError obj_typeoferror = new TypeOfError();
                DataTable dtaa = new DataTable();
                obj_typeoferror.typeoferror_list(dtaa);
                typeoferror.DataSource = dtaa;
                typeoferror.DisplayMember = "TypeOfError";
                conn.Close();
                typeoferror.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void correctiveactiontaken_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                CorrectiveActionTaken obj_correctiveaction = new CorrectiveActionTaken();
                DataTable dtaa = new DataTable();
                obj_correctiveaction.correctionactiontaken_list(dtaa);
                correctiveactiontaken.DataSource = dtaa;
                correctiveactiontaken.DisplayMember = "CorrectiveActionTaken";
                conn.Close();
                correctiveactiontaken.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void qualityparameters_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                QualityParameters obj_quality = new QualityParameters();
                DataTable dtaa = new DataTable();
                DataSet ds = new DataSet();
                obj_quality.qualityparameters_list(dtaa,typeoferror.Text, drdprocess.Text);
                foreach (DataRow datarow in dtaa.Rows)
                {
                    qualityparameters.Items.Add(datarow["QualityParameters"]);
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void requestorbusinessunit_sourcecode_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                RequestorBusinessUnit obj_bu = new RequestorBusinessUnit();
                DataTable dtaa = new DataTable();
                obj_bu.requestorbusinessunit_audit_list(dtaa);
                requestorbusinessunit.DataSource = dtaa;
                requestorbusinessunit.DisplayMember = "RequestorBusinessunit";
                dataGridView2.DataSource = dtaa;
                conn.Close();
                requestorbusinessunit.SelectedIndex = -1;
                requestorbusinessunit.DropDownStyle = ComboBoxStyle.DropDown;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void requestorbusinessunit_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                RequestorBusinessUnit obj_bu = new RequestorBusinessUnit();
                DataTable dtaa = new DataTable();
                obj_bu.requestorbusinessunit_list(dtaa);
                requestorbusinessunit.DataSource = dtaa;
                requestorbusinessunit.DisplayMember = "RequestorBusinessunit";
                dataGridView2.DataSource = dtaa;
                conn.Close();
                requestorbusinessunit.SelectedIndex = -1;
                requestorbusinessunit.DropDownStyle = ComboBoxStyle.DropDown;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void sourcecodes_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SourceCodes obj_sourcecode = new SourceCodes();
                DataTable dtaa = new DataTable();
                obj_sourcecode.sourcecode_list(dtaa);
                requestorbusinessunit.DataSource = dtaa;
                requestorbusinessunit.DisplayMember = "Source_Code_Original";
                conn.Close();
                requestorbusinessunit.SelectedIndex = -1;
                requestorbusinessunit.DropDownStyle = ComboBoxStyle.DropDown;
                requestorbusinessunit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void sourcecodes_dotnet_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SourceCodes obj_sourcecode = new SourceCodes();
                DataTable dtaa = new DataTable();
                obj_sourcecode.sourcecode_dotnet_list(dtaa);
                requestorbusinessunit.DataSource = dtaa;
                requestorbusinessunit.DisplayMember = "Source_Code_Original";
                conn.Close();
                requestorbusinessunit.SelectedIndex = -1;
                requestorbusinessunit.DropDownStyle = ComboBoxStyle.DropDown;
                requestorbusinessunit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void principletype_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                PrincipleType obj_principle = new PrincipleType();
                DataTable dtaa = new DataTable();
                obj_principle.principletype_list(dtaa);
                principletype.DataSource = dtaa;
                principletype.DisplayMember = "PrincipleType";
                conn.Close();
                principletype.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
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
                cmd.CommandText = "select RequestID,ProcessType,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,TypeofBreaches,FeedbackGiven,TypeofError,DRDProcess,NoofCriticalErrors,NoofMinorErrors,Comments,CorrectiveActionTaken,CorrectiveActionDate,CorrectiveActionTime,CorrectiveActionComments,ReasonsforDisagreement,NoofEmails,LastUpdateDateTime,NoofRecords,QualityParameters,PrincipleType,RiskID,BatchID,PartyLocation,RiskCategory,EventCodes,ApprovalReceivedFromDesginatedSMSOApprover,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where 1=1 and isdeleted = 0 and convert(date,ReceivedDate) between convert(date,dateadd(dd,-4,getdate())) and convert(date,getdate()) and approvalteam = @intidparam order by RequestID desc";
                cmd.Parameters.AddWithValue("@intidparam",Environment.UserName.ToString());
                cmd.ExecuteNonQuery();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void datagridview_batch_approvalsqueue_overall()
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
                cmd.CommandText = "select * from dbo.vw_batchworkflow_approvalsqueue_dotnet order by ReceivedDate desc";
                cmd.ExecuteNonQuery();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView5.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void datagridview2_display_filter()
        {
            if (!string.IsNullOrEmpty(requestorbusinessunit.Text))
            {
                dataGridView2.Visible = true;
                //label19.Visible = false;
                //batchid.Visible = false;

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                if (drdprocess.Text == "KYC" || drdprocess.Text == "OMS")
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        conn.ConnectionString = connectionstringtxt;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select RequestorBusinessUnit from dbo.tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where 1=1 and RequestorBusinessUnit like @requestorbusinessunitparam and requestorbusinessunit <> 'International India' and status = 'NonGlobalDirectory' order by RequestorBusinessUnit asc";
                        cmd.Parameters.AddWithValue("@requestorbusinessunitparam", "%" + requestorbusinessunit.Text + "%");
                        cmd.ExecuteNonQuery();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                        conn.Close();

                    }
                    catch (Exception ab)
                    {
                        MessageBox.Show("Error Generated Details: " + ab.ToString());
                    }
                }
                else if (drdprocess.Text == "Audit")
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        conn.ConnectionString = connectionstringtxt;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = ";with cte1 as (select RequestorBusinessunit from dbo.tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where RequestorBusinessunit <> 'International India' and Status = 'NonGlobalDirectory' union select [Client list] from tbl_BUMappingsBatchCheck_May2018onwards) select * from cte1 where  RequestorBusinessunit like @requestorbusinessunitparam order by RequestorBusinessUnit asc";
                        cmd.Parameters.AddWithValue("@requestorbusinessunitparam", "%" + requestorbusinessunit.Text + "%");
                        cmd.ExecuteNonQuery();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                        conn.Close();

                    }
                    catch (Exception ab)
                    {
                        MessageBox.Show("Error Generated Details: " + ab.ToString());
                    }
                }
                else if(drdprocess.Text == "Batch" && string.IsNullOrEmpty(batchworkflow_requestid.Text))
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        conn.ConnectionString = connectionstringtxt;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.Text;
                        //cmd.CommandText = "select [Client list] as RequestorBusinessUnit from tbl_BUMappingsBatchCheck_May2018onwards with(nolock) where 1=1 and [Client list] like @sourcecodeparam order by [Client list] asc";
                        cmd.CommandText = "select Source_Code_Original as RequestorBusinessUnit from dbo.tbl_batchworkflow_sourcecodes_dotnet with(nolock) where IsDeleted = 0 and Source_Code_Original like @sourcecodeparam order by Source_Code_Original asc";
                        cmd.Parameters.AddWithValue("@sourcecodeparam", "%" + requestorbusinessunit.Text + "%");
                        cmd.ExecuteNonQuery();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                        conn.Close();

                    }
                    catch (Exception ab)
                    {
                        MessageBox.Show("Error Generated Details: " + ab.ToString());
                    }
                }
                else if (drdprocess.Text == "Batch" && !string.IsNullOrEmpty(batchworkflow_requestid.Text))
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        conn.ConnectionString = connectionstringtxt;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Source_Code_Original as RequestorBusinessUnit from vw_batchworkflow_sourcecodes_dotnet with(nolock) where 1=1 and Source_Code_Original like @sourcecodeparam order by Source_Code_Original asc";
                        cmd.Parameters.AddWithValue("@sourcecodeparam", "%" + requestorbusinessunit.Text + "%");
                        cmd.ExecuteNonQuery();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                        conn.Close();

                    }
                    catch (Exception ab)
                    {
                        MessageBox.Show("Error Generated Details: " + ab.ToString());
                    }
                }
            }
            else
            {
                dataGridView2.Visible = false;
                //label19.Visible = true;
                //batchid.Visible = true;
            }
        }

        public void datagridview3_display_filter()
        {
            if (!string.IsNullOrEmpty(partylocation.Text))
            {
                dataGridView3.Visible = true;
              

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
                    cmd.CommandText = "select PartyLocation from tbl_kycrdcworkflow_partylocation_dotnet with(nolock) where 1=1 and PartyLocation like @partylocationparam order by PartyLocation asc";
                    cmd.Parameters.AddWithValue("@partylocationparam", "%" + partylocation.Text + "%");
                    cmd.ExecuteNonQuery();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    dataGridView3.DataSource = dt;
                    conn.Close();

                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details: " + ab.ToString());
                }
            }
            else
            {
                dataGridView3.Visible = false;
                
            }

        }

        public void datagridview4_display_filter()
        {
            if (!string.IsNullOrEmpty(associatename.Text) && !string.IsNullOrEmpty(drdprocess.Text))
            {
                dataGridView4.Visible = true;
                label27.Visible = false;
                principletype.Visible = false;
                label13.Visible = false;


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
                    cmd.CommandText = "select EmpName from dbo.vw_emp_details_dotnet where empname like @empname order by EmpName asc";
                    cmd.Parameters.AddWithValue("@empname", "%" + associatename.Text + "%");
                    cmd.ExecuteNonQuery();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    dataGridView4.DataSource = dt;
                    conn.Close();

                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details: " + ab.ToString());
                }
            }
            else
            {
                dataGridView4.Visible = false;
                label27.Visible = true;
                principletype.Visible = true;
                label13.Visible = true;

            }

        }

        //public void datagridview1_display_approvalteamname()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }

        //    try
        //    {
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        conn.ConnectionString = connectionstringtxt;
        //        cmd.Connection = conn;
        //        conn.Open();
        //        cmd.Parameters.Clear();
        //        cmd.CommandText = "select RequestID,ProcessType,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,TypeofBreaches,FeedbackGiven,TypeofError,DRDProcess,NoofCriticalErrors,NoofMinorErrors,Comments,CorrectiveActionTaken,CorrectiveActionDate,CorrectiveActionTime,CorrectiveActionComments,ReasonsforDisagreement,NoofEmails,LastUpdateDateTime,NoofRecords,QualityParameters,PrincipleType,RiskID,BatchID,PartyLocation from tbl_approvals_daily_dotnet with(nolock) where 1=1 and isdeleted = 0 and approvalteam like @approvalteamparam order by LastUpdateDateTime asc";
        //        cmd.Parameters.AddWithValue("@approvalteamparam","%" + approvalteamname_search.Text + "%");
        //        cmd.ExecuteNonQuery();
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        dataGridView1.DataSource = dt;
        //        conn.Close();

        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details: " + ab.ToString());
        //    }
        //}

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
                cmd.CommandText = "select RequestID,ProcessType,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,TypeofBreaches,FeedbackGiven,TypeofError,DRDProcess,NoofCriticalErrors,NoofMinorErrors,Comments,CorrectiveActionTaken,CorrectiveActionDate,CorrectiveActionTime,CorrectiveActionComments,ReasonsforDisagreement,NoofEmails,LastUpdateDateTime,NoofRecords,QualityParameters,PrincipleType,RiskID,BatchID,PartyLocation,RiskCategory,EventCodes,ApprovalReceivedFromDesginatedSMSOApprover,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where 1=1 and isdeleted = 0 and riskid like @riskidparam order by RequestID desc";
                //cmd.Parameters.AddWithValue("@intidparam", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@riskidparam", "%" + riskid_search.Text + "%");
                cmd.ExecuteNonQuery();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
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
                cmd.CommandText = "select RequestID,ProcessType,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,TypeofBreaches,FeedbackGiven,TypeofError,DRDProcess,NoofCriticalErrors,NoofMinorErrors,Comments,CorrectiveActionTaken,CorrectiveActionDate,CorrectiveActionTime,CorrectiveActionComments,ReasonsforDisagreement,NoofEmails,LastUpdateDateTime,NoofRecords,QualityParameters,PrincipleType,RiskID,BatchID,PartyLocation,RiskCategory,EventCodes,ApprovalReceivedFromDesginatedSMSOApprover,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where 1=1 and isdeleted = 0 and partyname like @partynameparam and convert(date,ReceivedDate) >= convert(date,dateadd(dd,-60,getdate())) order by RequestID desc";
                cmd.Parameters.AddWithValue("@partynameparam", "%" + partyname_search.Text + "%");
                //cmd.Parameters.AddWithValue("@intidparam", Environment.UserName.ToString());
                cmd.ExecuteNonQuery();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void datagridview1_display_plcidbatchid()
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
                cmd.CommandText = "select RequestID,ProcessType,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,TypeofBreaches,FeedbackGiven,TypeofError,DRDProcess,NoofCriticalErrors,NoofMinorErrors,Comments,CorrectiveActionTaken,CorrectiveActionDate,CorrectiveActionTime,CorrectiveActionComments,ReasonsforDisagreement,NoofEmails,LastUpdateDateTime,NoofRecords,QualityParameters,PrincipleType,RiskID,BatchID,PartyLocation,RiskCategory,EventCodes,ApprovalReceivedFromDesginatedSMSOApprover,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where 1=1 and isdeleted = 0 and batchid like @plcidbatchidparam and convert(date,ReceivedDate) >= convert(date,dateadd(dd,-60,getdate())) order by RequestID desc";
                cmd.Parameters.AddWithValue("@plcidbatchidparam", "%" + plcidbatchid_search.Text + "%");
                //cmd.Parameters.AddWithValue("@intidparam", Environment.UserName.ToString());
                cmd.ExecuteNonQuery();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void datagridview1_display_associatename()
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
                cmd.CommandText = "select RequestID,ProcessType,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,TypeofBreaches,FeedbackGiven,TypeofError,DRDProcess,NoofCriticalErrors,NoofMinorErrors,Comments,CorrectiveActionTaken,CorrectiveActionDate,CorrectiveActionTime,CorrectiveActionComments,ReasonsforDisagreement,NoofEmails,LastUpdateDateTime,NoofRecords,QualityParameters,PrincipleType,RiskID,BatchID,PartyLocation,RiskCategory,EventCodes,ApprovalReceivedFromDesginatedSMSOApprover,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where 1=1 and isdeleted = 0 and associatename like @associatenameparam and convert(date,ReceivedDate) >= convert(date,dateadd(dd,-60,getdate())) order by RequestID desc";
                cmd.Parameters.AddWithValue("@associatenameparam", "%" + associatename_search.Text + "%");
                //cmd.Parameters.AddWithValue("@intidparam", Environment.UserName.ToString());
                cmd.ExecuteNonQuery();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
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
                cmd.CommandText = "select RequestID,ProcessType,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipalName,PartyName,Category,TypeofBreaches,FeedbackGiven,TypeofError,DRDProcess,NoofCriticalErrors,NoofMinorErrors,Comments,CorrectiveActionTaken,CorrectiveActionDate,CorrectiveActionTime,CorrectiveActionComments,ReasonsforDisagreement,NoofEmails,LastUpdateDateTime,NoofRecords,QualityParameters,PrincipleType,RiskID,BatchID,PartyLocation,RiskCategory,EventCodes,ApprovalReceivedFromDesginatedSMSOApprover,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where 1=1 and isdeleted = 0 and convert(bigint,requestid) like @requestidparam and convert(date,ReceivedDate) >= convert(date,dateadd(dd,-60,getdate()))  order by RequestID desc";
                cmd.Parameters.AddWithValue("@requestidparam", "%" + requestid_search.Text + "%");
                //cmd.Parameters.AddWithValue("@intidparam", Environment.UserName.ToString());
                cmd.ExecuteNonQuery();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void validate_requestorbusinessunit()
        {

            if (!string.IsNullOrEmpty(requestorbusinessunit.Text) && string.IsNullOrEmpty(requestid.Text))
            {
                
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                if (drdprocess.Text == "KYC")
                {
                    //cmd.CommandText = "select RequestorBusinessunit from tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where 1=1 and requestorbusinessunit = @requestorbusinessunitparam and requestorbusinessunit <> 'International India' and status = 'NonGlobalDirectory' order by RequestorBusinessunit asc";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select RequestorBusinessunit from tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where 1=1 and requestorbusinessunit = @requestorbusinessunitparam and requestorbusinessunit <> 'International India' and status = 'NonGlobalDirectory' and RequestorBusinessunit is not null union select [Product Service] from dbo.tbl_bumapping_GlobalDirectory where Segment <> 'corporate' and Business <> 'India Operations' and [Product Service] = @requestorbusinessunitparam and [Product Service] is not null";
                    cmd.Parameters.AddWithValue("@requestorbusinessunitparam", requestorbusinessunit.Text);
                }
                else if (drdprocess.Text == "OMS")
                {
                    //cmd.CommandText = "select RequestorBusinessunit from tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where 1=1 and requestorbusinessunit = @requestorbusinessunitparam and requestorbusinessunit <> 'International India' and status = 'NonGlobalDirectory' order by RequestorBusinessunit asc";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select RequestorBusinessunit from tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where 1=1 and requestorbusinessunit = @requestorbusinessunitparam and requestorbusinessunit <> 'International India' and status = 'NonGlobalDirectory' and RequestorBusinessunit is not null union select [Product Service] from dbo.tbl_bumapping_GlobalDirectory where Segment <> 'corporate' and Business <> 'India Operations' and [Product Service] = @requestorbusinessunitparam and [Product Service] is not null";
                    cmd.Parameters.AddWithValue("@requestorbusinessunitparam", requestorbusinessunit.Text);
                }
                else if (drdprocess.Text == "Batch" && string.IsNullOrEmpty(batchworkflow_requestid.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = "select [Client list] as RequestorBusinessUnit from dbo.tbl_BUMappingsBatchCheck_May2018onwards with(nolock) where 1=1 and [Client list] = @requestorbusinessunitparam order by [Client list] asc";
                    cmd.CommandText = "select Source_Code_Original as RequestorBusinessUnit from dbo.tbl_batchworkflow_sourcecodes_dotnet with(nolock) where IsDeleted = 0 and source_code_original = @requestorbusinessunitparam order by Source_Code_Original asc";
                    cmd.Parameters.AddWithValue("@requestorbusinessunitparam", requestorbusinessunit.Text);
                }
                else if (drdprocess.Text == "Audit")
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = ";with cte1 as ( select RequestorBusinessunit from dbo.tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where requestorbusinessunit <> 'International India' and Status = 'NonGlobalDirectory' union select [Client list] from tbl_BUMappingsBatchCheck_May2018onwards) select * from cte1 where RequestorBusinessUnit = @requestorbusinessunitparam order by RequestorBusinessUnit asc";
                    cmd.Parameters.AddWithValue("@requestorbusinessunitparam", requestorbusinessunit.Text);
                }
                //else if (drdprocess.Text == "Batch" && !string.IsNullOrEmpty(batchworkflow_requestid.Text))
                //{
                //    cmd.CommandType = CommandType.Text;
                //    cmd.CommandText = "select Source_Code as RequestorBusinessUnit from dbo.vw_batchworkflow_sourcecodes_dotnet where source_code = @requestorbusinessunitparam order by source_code asc";
                //}
                //cmd.Parameters.AddWithValue("@requestorbusinessunitparam", requestorbusinessunit.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please enter a valid RequestorBusinessUnit/SourceCode from the selection");
                    conn.Close();
                    insert.Enabled = false;
                }
                
                else
                {
                    insert.Enabled = true;
                }
            }

            else if (!string.IsNullOrEmpty(requestorbusinessunit.Text) && !string.IsNullOrEmpty(requestid.Text))
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                if (drdprocess.Text == "KYC")
                {
                    //cmd.CommandText = "select RequestorBusinessunit from tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where 1=1 and requestorbusinessunit = @requestorbusinessunitparam and requestorbusinessunit <> 'International India' and status = 'NonGlobalDirectory' order by RequestorBusinessunit asc";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select RequestorBusinessunit from dbo.tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where 1=1 and requestorbusinessunit = @requestorbusinessunitparam and requestorbusinessunit <> 'International India' and status = 'NonGlobalDirectory' and RequestorBusinessunit is not null union select [Product Service] from dbo.tbl_bumapping_GlobalDirectory where Segment <> 'corporate' and Business <> 'India Operations' and [Product Service] = @requestorbusinessunitparam and [Product Service] is not null";
                }
                else if (drdprocess.Text == "OMS")
                {
                    //cmd.CommandText = "select RequestorBusinessunit from tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where 1=1 and requestorbusinessunit = @requestorbusinessunitparam and requestorbusinessunit <> 'International India' and status = 'NonGlobalDirectory' order by RequestorBusinessunit asc";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select RequestorBusinessunit from dbo.tbl_kycrdcworkflow_requestorbusinessunit_dotnet with(nolock) where 1=1 and requestorbusinessunit = @requestorbusinessunitparam and requestorbusinessunit <> 'International India' and status = 'NonGlobalDirectory' and RequestorBusinessunit is not null union select [Product Service] from dbo.tbl_bumapping_GlobalDirectory where Segment <> 'corporate' and Business <> 'India Operations' and [Product Service] = @requestorbusinessunitparam and [Product Service] is not null";
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select [Client list] from dbo.tbl_BUMappingsBatchCheck_May2018onwards with(nolock) where 1=1 and [Client list] = @requestorbusinessunitparam order by [Client list] asc";
                }
                cmd.Parameters.AddWithValue("@requestorbusinessunitparam", requestorbusinessunit.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please enter a valid RequestorBusinessUnit/SourceCode from the selection");
                    conn.Close();
                    insert.Enabled = false;
                    update.Enabled = false;
                }
                else
                {
                    insert.Enabled = true;
                    update.Enabled = true;
                }
            }
            
        }

        public void validate_partylocation()
        {

            if (!string.IsNullOrEmpty(partylocation.Text) && string.IsNullOrEmpty(requestid.Text))
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select PartyLocation from dbo.tbl_kycrdcworkflow_partylocation_dotnet with(nolock) where 1=1 and PartyLocation = @partylocationparam union select PartyLocation from vw_qualityapprovals_partydetailslookup_dotnet where 1=1 and PartyLocation = @partylocationparam order by PartyLocation asc";
                cmd.Parameters.AddWithValue("@partylocationparam", partylocation.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please enter a valid PartyLocation from the selection");
                    conn.Close();
                    insert.Enabled = false;
                }

                else
                {
                    insert.Enabled = true;
                }
            }

            else if (!string.IsNullOrEmpty(partylocation.Text) && !string.IsNullOrEmpty(requestid.Text))
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select PartyLocation from dbo.tbl_kycrdcworkflow_partylocation_dotnet with(nolock) where 1=1 and PartyLocation = @partylocationparam order by PartyLocation asc";
                cmd.Parameters.AddWithValue("@partylocationparam", partylocation.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please enter a valid PartyLocation from the selection");
                    conn.Close();
                    insert.Enabled = false;
                    update.Enabled = false;
                }
                else
                {
                    insert.Enabled = true;
                    update.Enabled = true;
                }
            }

        }

        public void validate_associatename()
        {

            if (!string.IsNullOrEmpty(associatename.Text) && string.IsNullOrEmpty(requestid.Text))
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select EmpName from dbo.tbl_emp_details where empname = @empnameparam order by EmpName asc";
                cmd.Parameters.AddWithValue("@empnameparam", associatename.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please enter a valid Associate Name from the selection");
                    conn.Close();
                    insert.Enabled = false;
                }

                else
                {
                    insert.Enabled = true;
                }
            }

            else if (!string.IsNullOrEmpty(associatename.Text) && !string.IsNullOrEmpty(requestid.Text))
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select EmpName from dbo.tbl_emp_details with(nolock) where empname = @empnameparam order by EmpName asc";
                cmd.Parameters.AddWithValue("@empnameparam", associatename.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please enter a valid Associate Name from the selection");
                    conn.Close();
                    insert.Enabled = false;
                    update.Enabled = false;
                }
                else
                {
                    insert.Enabled = true;
                    update.Enabled = true;
                }
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
                        cmd.CommandText = "dbo.usp_approvals_insert_dotnet";
                        cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                        cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                        //if (!string.IsNullOrEmpty(batchworkflow_requestid.Text))
                        //{
                        //    cmd.Parameters.AddWithValue("@BatchWorkflow_RequestID", batchworkflow_requestid.Text);
                        //}
                        //else
                        //{
                        //    cmd.Parameters.AddWithValue("@BatchWorkflow_RequestID", DBNull.Value);
                        //}
                        cmd.Parameters.AddWithValue("@processtypeparam", processtype.Text);
                        cmd.Parameters.AddWithValue("@drdprocessparam", drdprocess.Text);
                        cmd.Parameters.AddWithValue("@approvalteamnameparam", Environment.UserName.ToString());
                        cmd.Parameters.AddWithValue("@receiveddateparam", receiveddate.Value.Date);
                        cmd.Parameters.AddWithValue("@receivedtimeparam", receivedtime.Value.ToLongTimeString());
                        if (completiondate.Text.Trim() != string.Empty)
                        {
                            cmd.Parameters.AddWithValue("@completiondateparam", completiondate.Value.Date);
                            cmd.Parameters.AddWithValue("@completiontimeparam", completiontime.Value.ToLongTimeString());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@completiondateparam", DBNull.Value);
                            cmd.Parameters.AddWithValue("@completiontimeparam", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@noofemailsparam", noofemails.Value);
                        cmd.Parameters.AddWithValue("@associatenameparam", associatename.Text);
                        cmd.Parameters.AddWithValue("@requestorbusinessunitparam", requestorbusinessunit.Text);
                        cmd.Parameters.AddWithValue("@partynameparam", partyname.Text);
                        cmd.Parameters.AddWithValue("@principalnameparam", principlename.Text);
                        if (string.IsNullOrEmpty(entityid.Text))
                        {
                            cmd.Parameters.AddWithValue("@entityid",DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@entityid",entityid.Text);
                        }
                        if (string.IsNullOrEmpty(categoryname.Text))
                        {
                            cmd.Parameters.AddWithValue("@categorynameparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@categorynameparam", categoryname.Text);
                        }
                        if (string.IsNullOrEmpty(pf_gcid.Text))
                        {
                            cmd.Parameters.AddWithValue("@pf_gcid",DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@pf_gcid",pf_gcid.Text);
                        }
                        cmd.Parameters.AddWithValue("@noofrecordsparam", noofrecords.Value);
                        //inserting checkedboxlistitems
                        if (qualityparameters.CheckedItems.Count != 0)
                        {
                            string qualityitems = string.Empty;
                            foreach (var checkeditem in this.qualityparameters.CheckedItems)
                            {
                                qualityitems += "," + checkeditem.ToString();
                            }
                            qualityitems = qualityitems.Substring(1);
                            cmd.Parameters.AddWithValue("@qualityparametersparam", qualityitems);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@qualityparametersparam", DBNull.Value);
                        }
                        if (string.IsNullOrEmpty(typeofbreach.Text))
                        {
                            cmd.Parameters.AddWithValue("@typeofbreachesparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@typeofbreachesparam", typeofbreach.Text);
                        }
                        if (string.IsNullOrEmpty(feedbackgiven.Text))
                        {
                            cmd.Parameters.AddWithValue("@feedbackgivenparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@feedbackgivenparam", feedbackgiven.Text);
                        }
                        if (string.IsNullOrEmpty(typeoferror.Text))
                        {
                            cmd.Parameters.AddWithValue("@typeoferrorparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@typeoferrorparam", typeoferror.Text);
                        }
                        cmd.Parameters.AddWithValue("@noofcriticalerrorsparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@noofminorerrorsparam", DBNull.Value);
                        if (string.IsNullOrEmpty(comments.Text))
                        {
                            cmd.Parameters.AddWithValue("@commentsparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@commentsparam", comments.Text);
                        }
                        if (string.IsNullOrEmpty(correctiveactiontaken.Text))
                        {
                            cmd.Parameters.AddWithValue("@correctiveactiontakenparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@correctiveactiontakenparam", correctiveactiontaken.Text);
                        }
                        if (correctiveactiondate.Text.Trim() != string.Empty)
                        {
                            cmd.Parameters.AddWithValue("@correctiveactiondateparam", correctiveactiondate.Value.Date);
                            cmd.Parameters.AddWithValue("@correctiveactiontimeparam", correctiveactiontime.Value.ToLongTimeString());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@correctiveactiondateparam", DBNull.Value);
                            cmd.Parameters.AddWithValue("@correctiveactiontimeparam", DBNull.Value);
                        }
                        if (string.IsNullOrEmpty(correctiveactioncomments.Text))
                        {
                            cmd.Parameters.AddWithValue("@correctiveactioncommentsparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@correctiveactioncommentsparam", correctiveactioncomments.Text);
                        }
                        if (string.IsNullOrEmpty(reasonsfordisagreement.Text))
                        {
                            cmd.Parameters.AddWithValue("@reasonsfordisagreementparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@reasonsfordisagreementparam", reasonsfordisagreement.Text);
                        }
                        cmd.Parameters.AddWithValue("@lastupdatedatetimeparam", DateTime.Now.ToLocalTime());
                        cmd.Parameters.AddWithValue("@isdeletedparam", isdeleted.Value);
                        cmd.Parameters.AddWithValue("@machinenameparam", Environment.MachineName.ToString());
                        if (string.IsNullOrEmpty(principletype.Text))
                        {
                            cmd.Parameters.AddWithValue("@principletypeparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@principletypeparam", principletype.Text);
                        }
                        if (string.IsNullOrEmpty(riskid.Text))
                        {
                            cmd.Parameters.AddWithValue("@riskidparam", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@riskidparam", riskid.Text);
                        }
                        if (!string.IsNullOrEmpty(batchid.Text))
                        {
                            cmd.Parameters.AddWithValue("@BatchIDparam", batchid.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@BatchIDparam", DBNull.Value);
                        }
                        if (!string.IsNullOrEmpty(partylocation.Text))
                        {
                            cmd.Parameters.AddWithValue("@PartyLocationparam", partylocation.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@PartyLocationparam", DBNull.Value);
                        }
                        if (!string.IsNullOrEmpty(riskcategory.Text))
                        {
                            cmd.Parameters.AddWithValue("@RiskCategory", riskcategory.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@RiskCategory", DBNull.Value);
                        }
                        if (!string.IsNullOrEmpty(eventcodes.Text))
                        {
                            cmd.Parameters.AddWithValue("@EventCodes", eventcodes.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EventCodes", DBNull.Value);
                        }
                       
                        if (string.IsNullOrEmpty(approvalreceivedfromdesginatedsmsoapprover.Text))
                        {
                            cmd.Parameters.AddWithValue("@approvalreceivedfromdesginatedsmsoapprover", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@approvalreceivedfromdesginatedsmsoapprover", approvalreceivedfromdesginatedsmsoapprover.Text);
                        }


                        //If Conditions
                        if (string.IsNullOrEmpty(processtype.Text))
                        {
                            MessageBox.Show("Please update Process Type");
                        }
                        else if (noofrecords.Value < 1)
                        {
                            MessageBox.Show("No Of Records cannot be less than 1. Please update No of records");
                        }
                        else if (string.IsNullOrEmpty(drdprocess.Text))
                        {
                            MessageBox.Show("Please update DRD Process");
                        }
                        else if (string.IsNullOrEmpty(partyname.Text))
                        {
                            MessageBox.Show("Please update Party Name");
                        }
                        else if (string.IsNullOrEmpty(principlename.Text))
                        {
                            MessageBox.Show("Please update Principle Name");
                        }
                        else if (string.IsNullOrEmpty(associatename.Text))
                        {
                            MessageBox.Show("Please update Associate Name");
                        }
                        else if (string.IsNullOrEmpty(requestorbusinessunit.Text))
                        {
                            MessageBox.Show("Please update RequestorBusinessUnit");
                        }
                        else if (!string.IsNullOrEmpty(typeoferror.Text) && qualityparameters.CheckedItems.Count == 0)
                        {
                            MessageBox.Show("Please select Quality Parameters");
                        }
                        else if (receiveddate.Value.Date > completiondate.Value.Date && completiondate.Text.Trim() != string.Empty)
                        {
                            MessageBox.Show("Received Date cannot be greater than completion date");
                        }
                        else if (receiveddate.Value.Date > todaydate.Value.Date)
                        {
                            MessageBox.Show("Received Date cannot be greater than todays date");
                        }
                        else if (completiondate.Text.Trim() != string.Empty && completiondate.Value.Date > todaydate.Value.Date)
                        {
                            MessageBox.Show("Completion Date cannot be greater than todays date");
                        }
                        else if (correctiveactiondate.Text.Trim() != string.Empty && correctiveactiondate.Value.Date > todaydate.Value.Date)
                        {
                            MessageBox.Show("Corrective Action Date cannot be greater than todays date");
                        }
                        //else if (receiveddate.Text.Trim() == string.Empty)
                        //{
                        //    MessageBox.Show("Please update Received Date");
                        //}
                        //else if (receivedtime.Text.Trim() == string.Empty)
                        //{
                        //    MessageBox.Show("Please update Received Time");
                        //}
                        else if (completiondate.Text.Trim() != string.Empty && completiontime.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Please update Completion Time");
                        }
                        else if (completiondate.Text.Trim() == string.Empty && completiontime.Text.Trim() != string.Empty)
                        {
                            MessageBox.Show("Please update Completion Date");
                        }
                        else if (noofrecords.Value < 0)
                        {
                            MessageBox.Show("No of Records cannot be less than 0");
                        }
                        else if (!string.IsNullOrEmpty(typeofbreach.Text) && string.IsNullOrEmpty(typeoferror.Text))
                        {
                            MessageBox.Show("Please update Type Of Error");
                        }
                        else if (!string.IsNullOrEmpty(typeofbreach.Text) && typeoferror.Text != "Critical")
                        {
                            MessageBox.Show("Please update correct type of error since it is a breach");
                        }
                        else if (processtype.Text == "SR KYC QC" && categoryname.Text == "Mis-match" && string.IsNullOrEmpty(typeoferror.Text))
                        {
                            MessageBox.Show("Please update Type of Error if 'SR KYC QC' is selected");
                        }
                        else if (string.IsNullOrEmpty(batchid.Text))
                        {
                            MessageBox.Show("Please update PLC ID/Batch ID");
                        }
                        else if (string.IsNullOrEmpty(principletype.Text))
                        {
                            MessageBox.Show("Please update Principle Type");
                        }
                        else if (string.IsNullOrEmpty(riskid.Text))
                        {
                            MessageBox.Show("Please update Risk ID");
                        }
                        else if (categoryname.Text == "Exact" && string.IsNullOrEmpty(riskcategory.Text))
                        {
                            MessageBox.Show("Please update Risk Category");
                        }
                        else if (categoryname.Text == "Exact" && string.IsNullOrEmpty(eventcodes.Text))
                        {
                            MessageBox.Show("Please update Event codes");
                        }
                        else if (categoryname.Text == "Potential" && string.IsNullOrEmpty(riskcategory.Text))
                        {
                            MessageBox.Show("Please update Risk Category");
                        }
                        else if (categoryname.Text == "Potential" && string.IsNullOrEmpty(eventcodes.Text))
                        {
                            MessageBox.Show("Please update Event codes");
                        }
                        else if (processtype.Text == "OMS QC" && drdprocess.Text != "OMS" && drdprocess.Text != "Audit")
                        {
                            MessageBox.Show("Please select DRD Process as OMS since it is a OMS QC");
                        }
                        else if (processtype.Text == "Batch QC" && drdprocess.Text != "Batch" && drdprocess.Text != "Audit")
                        {
                            MessageBox.Show("Please select DRD Process as Batch since it is a Batch QC");
                        }
                        else if (typeoferror.Text == "Critical" && string.IsNullOrEmpty(typeofbreach.Text))
                        {
                            MessageBox.Show("Please update Type of Breach");
                        }
                        else if((processtype.Text == "Batch QC" || processtype.Text == "OMS QC" || processtype.Text == "KYC QC" || processtype.Text == "STP QC") && riskcategory.Text == "SMSO" && string.IsNullOrEmpty(approvalreceivedfromdesginatedsmsoapprover.Text))
                        {
                            MessageBox.Show("Please update 'Approval Received From Desginated SMSO Approver'");
                        }
                        else if(!string.IsNullOrEmpty(categoryname.Text) && categoryname.Text == "Exact" && string.IsNullOrEmpty(entityid.Text))
                        {
                            MessageBox.Show("Please update Entity ID");
                        }
                        else if (!string.IsNullOrEmpty(categoryname.Text) && categoryname.Text == "Potential" && string.IsNullOrEmpty(entityid.Text))
                        {
                            MessageBox.Show("Please update Entity ID");
                        }
                        else if (string.IsNullOrEmpty(pf_gcid.Text) && string.IsNullOrEmpty(batchid.Text))
                        {
                            MessageBox.Show("Please update PF GCID or WFTID/BatchID");
                        }
                        else
                        {

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                            MessageBox.Show("" + uploadmessage.ToString());
                            //MessageBox.Show("Record Inserted Successfully");
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
                    requestid.Focus();
                }
            
        }

        

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
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
                    //cmd.CommandText = "update tbl_approvals_daily_dotnet set processtype=@processtypeparam,drdprocess=@drdprocessparam,approvalteam=@approvalteamnameparam,receiveddate=@receiveddateparam,receivedtime=@receivedtimeparam,completiondate=@completiondateparam,completiontime=@completiontimeparam,noofemails=@noofemailsparam,associatename=@associatenameparam,requestorbusinessunit=@requestorbusinessunitparam,partyname=@partynameparam,principalname=@principalnameparam,category=@categorynameparam,noofrecords=@noofrecordsparam,TypeofBreaches=@typeofbreachesparam,FeedbackGiven=@feedbackgivenparam,TypeofError=@typeoferrorparam,NoofCriticalErrors=@noofcriticalerrorsparam,NoofMinorErrors=@noofminorerrorsparam,Comments=@commentsparam,CorrectiveActionTaken=@correctiveactiontakenparam,CorrectiveActionDate=@correctiveactiondateparam,CorrectiveActionTime=@correctiveactiontimeparam,CorrectiveActionComments=@correctiveactioncommentsparam,ReasonsforDisagreement=@reasonsfordisagreementparam,lastupdatedatetime=@lastupdatedatetimeparam,isdeleted=@isdeletedparam,machinename=@machinenameparam,principletype=@principletypeparam,riskid=@riskidparam,qualityparameters=@qualityparametersparam,BatchID=@BatchIDparam,PartyLocation=@PartyLocationparam,RiskCategory=@RiskCategory,EventCodes=@EventCodes where 1=1 and requestid=@requestidparam";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_approvals_update_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@requestidparam", requestid.Text);
                    cmd.Parameters.AddWithValue("@processtypeparam", processtype.Text);
                    cmd.Parameters.AddWithValue("@drdprocessparam", drdprocess.Text);
                    cmd.Parameters.AddWithValue("@approvalteamnameparam", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@receiveddateparam", receiveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@receivedtimeparam", receivedtime.Value.ToLongTimeString());
                    if (completiondate.Text.Trim() != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@completiondateparam", completiondate.Value.Date);
                        cmd.Parameters.AddWithValue("@completiontimeparam", completiontime.Value.ToLongTimeString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@completiondateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@completiontimeparam", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@noofemailsparam", noofemails.Value);
                    cmd.Parameters.AddWithValue("@associatenameparam", associatename.Text);
                    cmd.Parameters.AddWithValue("@requestorbusinessunitparam", requestorbusinessunit.Text);
                    cmd.Parameters.AddWithValue("@partynameparam", partyname.Text);
                    cmd.Parameters.AddWithValue("@principalnameparam", principlename.Text);
                    if (string.IsNullOrEmpty(entityid.Text))
                    {
                        cmd.Parameters.AddWithValue("@entityid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@entityid", entityid.Text);
                    }
                    if (string.IsNullOrEmpty(categoryname.Text))
                    {
                        cmd.Parameters.AddWithValue("@categorynameparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@categorynameparam", categoryname.Text);
                    }
                    if (string.IsNullOrEmpty(pf_gcid.Text))
                    {
                        cmd.Parameters.AddWithValue("@pf_gcid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@pf_gcid", pf_gcid.Text);
                    }
                    cmd.Parameters.AddWithValue("@noofrecordsparam", noofrecords.Value);
                    //updating checkedboxlistitems
                    if (qualityparameters.CheckedItems.Count != 0)
                    {
                        string qualityitems = string.Empty;
                        foreach (var checkeditem in this.qualityparameters.CheckedItems)
                        {
                            qualityitems += "," + checkeditem.ToString();
                        }
                        qualityitems = qualityitems.Substring(1);
                        cmd.Parameters.AddWithValue("@qualityparametersparam", qualityitems);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qualityparametersparam", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(typeofbreach.Text))
                    {
                        cmd.Parameters.AddWithValue("@typeofbreachesparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@typeofbreachesparam", typeofbreach.Text);
                    }
                    if (string.IsNullOrEmpty(feedbackgiven.Text))
                    {
                        cmd.Parameters.AddWithValue("@feedbackgivenparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@feedbackgivenparam", feedbackgiven.Text);
                    }
                    if (string.IsNullOrEmpty(typeoferror.Text))
                    {
                        cmd.Parameters.AddWithValue("@typeoferrorparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@typeoferrorparam", typeoferror.Text);
                    }
                    cmd.Parameters.AddWithValue("@noofcriticalerrorsparam", DBNull.Value);
                    cmd.Parameters.AddWithValue("@noofminorerrorsparam", DBNull.Value);
                    if (string.IsNullOrEmpty(comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@commentsparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@commentsparam", comments.Text);
                    }
                    if (string.IsNullOrEmpty(correctiveactiontaken.Text))
                    {
                        cmd.Parameters.AddWithValue("@correctiveactiontakenparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@correctiveactiontakenparam", correctiveactiontaken.Text);
                    }
                    if (correctiveactiondate.Text.Trim() != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@correctiveactiondateparam", correctiveactiondate.Value.Date);
                        cmd.Parameters.AddWithValue("@correctiveactiontimeparam", correctiveactiontime.Value.ToLongTimeString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@correctiveactiondateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@correctiveactiontimeparam", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(correctiveactioncomments.Text))
                    {
                        cmd.Parameters.AddWithValue("@correctiveactioncommentsparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@correctiveactioncommentsparam", correctiveactioncomments.Text);
                    }
                    if (string.IsNullOrEmpty(reasonsfordisagreement.Text))
                    {
                        cmd.Parameters.AddWithValue("@reasonsfordisagreementparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@reasonsfordisagreementparam", reasonsfordisagreement.Text);
                    }
                    cmd.Parameters.AddWithValue("@lastupdatedatetimeparam", DateTime.Now.ToLocalTime());
                    //cmd.Parameters.AddWithValue("@isdeletedparam", isdeleted.Value);
                    cmd.Parameters.AddWithValue("@machinenameparam", Environment.MachineName.ToString());
                    if (string.IsNullOrEmpty(principletype.Text))
                    {
                        cmd.Parameters.AddWithValue("@principletypeparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@principletypeparam", principletype.Text);
                    }
                    if (string.IsNullOrEmpty(riskid.Text))
                    {
                        cmd.Parameters.AddWithValue("@riskidparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@riskidparam", riskid.Text);
                    }
                    if (!string.IsNullOrEmpty(batchid.Text))
                    {
                        cmd.Parameters.AddWithValue("@BatchIDparam", batchid.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@BatchIDparam", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(partylocation.Text))
                    {
                        cmd.Parameters.AddWithValue("@PartyLocationparam", partylocation.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PartyLocationparam", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(riskcategory.Text))
                    {
                        cmd.Parameters.AddWithValue("@RiskCategory", riskcategory.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RiskCategory", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(eventcodes.Text))
                    {
                        cmd.Parameters.AddWithValue("@EventCodes", eventcodes.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@EventCodes", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(approvalreceivedfromdesginatedsmsoapprover.Text))
                    {
                        cmd.Parameters.AddWithValue("@approvalreceivedfromdesginatedsmsoapprover", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@approvalreceivedfromdesginatedsmsoapprover", approvalreceivedfromdesginatedsmsoapprover.Text);
                    }



                    //If Conditions
                    if (string.IsNullOrEmpty(processtype.Text))
                    {
                        MessageBox.Show("Please update Process Type");
                    }
                    else if (noofrecords.Value < 1)
                    {
                        MessageBox.Show("No Of Records cannot be less than 1. Please update No of records");
                    }
                    else if (string.IsNullOrEmpty(drdprocess.Text))
                    {
                        MessageBox.Show("Please update DRD Process");
                    }
                    else if (string.IsNullOrEmpty(partyname.Text))
                    {
                        MessageBox.Show("Please update Party Name");
                    }
                    else if (string.IsNullOrEmpty(principlename.Text))
                    {
                        MessageBox.Show("Please update Principle Name");
                    }
                    else if (string.IsNullOrEmpty(associatename.Text))
                    {
                        MessageBox.Show("Please update Associate Name");
                    }
                    else if (string.IsNullOrEmpty(requestorbusinessunit.Text))
                    {
                        MessageBox.Show("Please update RequestorBusinessUnit");
                    }
                    else if (!string.IsNullOrEmpty(typeoferror.Text) && qualityparameters.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Please select Quality Parameters");
                    }
                    else if (receiveddate.Value.Date > completiondate.Value.Date && completiondate.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Received Date cannot be greater than completion date");
                    }
                    else if (receiveddate.Value.Date > todaydate.Value.Date)
                    {
                        MessageBox.Show("Received Date cannot be greater than todays date");
                    }
                    else if (completiondate.Text.Trim() != string.Empty && completiondate.Value.Date > todaydate.Value.Date)
                    {
                        MessageBox.Show("Completion Date cannot be greater than todays date");
                    }
                    else if (correctiveactiondate.Text.Trim() != string.Empty && correctiveactiondate.Value.Date > todaydate.Value.Date)
                    {
                        MessageBox.Show("Corrective Action Date cannot be greater than todays date");
                    }
                    //else if (receiveddate.Text.Trim() == string.Empty)
                    //{
                    //    MessageBox.Show("Please update Received Date");
                    //}
                    //else if (receivedtime.Text.Trim() == string.Empty)
                    //{
                    //    MessageBox.Show("Please update Received Time");
                    //}
                    else if (completiondate.Text.Trim() != string.Empty && completiontime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Completion Time");
                    }
                    else if (completiondate.Text.Trim() == string.Empty && completiontime.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Please update Completion Date");
                    }
                    else if (noofrecords.Value < 0)
                    {
                        MessageBox.Show("No of Records cannot be less than 0");
                    }
                    else if (!string.IsNullOrEmpty(typeofbreach.Text) && string.IsNullOrEmpty(typeoferror.Text))
                    {
                        MessageBox.Show("Please update Type Of Error");
                    }
                    else if (!string.IsNullOrEmpty(typeofbreach.Text) && typeoferror.Text != "Critical")
                    {
                        MessageBox.Show("Please update correct type of error since it is a breach");
                    }
                    else if (processtype.Text == "SR KYC QC" && categoryname.Text == "Mis-match" && string.IsNullOrEmpty(typeoferror.Text))
                    {
                        MessageBox.Show("Please update Type of Error if 'SR KYC QC' is selected");
                    }
                    else if (string.IsNullOrEmpty(batchid.Text))
                    {
                        MessageBox.Show("Please update PLC ID/Batch ID");
                    }
                    else if (string.IsNullOrEmpty(principletype.Text))
                    {
                        MessageBox.Show("Please update Principle Type");
                    }
                    else if (string.IsNullOrEmpty(riskid.Text))
                    {
                        MessageBox.Show("Please update Risk ID");
                    }
                    else if (categoryname.Text == "Exact" && string.IsNullOrEmpty(riskcategory.Text))
                    {
                        MessageBox.Show("Please update Risk Category");
                    }
                    else if (categoryname.Text == "Exact" && string.IsNullOrEmpty(eventcodes.Text))
                    {
                        MessageBox.Show("Please update Event codes");
                    }
                    else if (categoryname.Text == "Potential" && string.IsNullOrEmpty(riskcategory.Text))
                    {
                        MessageBox.Show("Please update Risk Category");
                    }
                    else if (categoryname.Text == "Potential" && string.IsNullOrEmpty(eventcodes.Text))
                    {
                        MessageBox.Show("Please update Event codes");
                    }
                    else if (processtype.Text == "OMS QC" && drdprocess.Text != "OMS" && drdprocess.Text != "Audit")
                    {
                        MessageBox.Show("Please select DRD Process as OMS since it is a OMS QC");
                    }
                    else if (processtype.Text == "Batch QC" && drdprocess.Text != "Batch" && drdprocess.Text != "Audit")
                    {
                        MessageBox.Show("Please select DRD Process as Batch since it is a Batch QC");
                    }
                    else if (typeoferror.Text == "Critical" && string.IsNullOrEmpty(typeofbreach.Text))
                    {
                        MessageBox.Show("Please update Type of Breach");
                    }
                    else if ((processtype.Text == "Batch QC" || processtype.Text == "OMS QC" || processtype.Text == "KYC QC" || processtype.Text == "STP QC") && riskcategory.Text == "SMSO" && string.IsNullOrEmpty(approvalreceivedfromdesginatedsmsoapprover.Text))
                    {
                        MessageBox.Show("Please update 'Approval Received From Desginated SMSO Approver'");
                    }
                    else if (!string.IsNullOrEmpty(categoryname.Text) && categoryname.Text == "Exact" && string.IsNullOrEmpty(entityid.Text))
                    {
                        MessageBox.Show("Please update Entity ID");
                    }
                    else if (!string.IsNullOrEmpty(categoryname.Text) && categoryname.Text == "Potential" && string.IsNullOrEmpty(entityid.Text))
                    {
                        MessageBox.Show("Please update Entity ID");
                    }
                    else if (string.IsNullOrEmpty(pf_gcid.Text) && string.IsNullOrEmpty(batchid.Text))
                    {
                        MessageBox.Show("Please update PF GCID or WFTID/BatchID");
                    }
                    else
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                        MessageBox.Show("" + uploadmessage.ToString());
                        //MessageBox.Show("Record Updated Successfully");
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

        private void receiveddate_ValueChanged(object sender, EventArgs e)
        {
            //receiveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void receiveddate_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            //{
            //    receiveddate.CustomFormat = " ";
            //}
        }

        private void receivedtime_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            //{
            //    receivedtime.CustomFormat = " ";
            //}
        }

        private void receivedtime_MouseDown(object sender, MouseEventArgs e)
        {
            //receivedtime.Text = DateTime.Now.ToLongTimeString();
            //receivedtime.CustomFormat = "HH:mm:ss";
        }

        private void completiondate_ValueChanged(object sender, EventArgs e)
        {
            completiondate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void completiondate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completiondate.CustomFormat = " ";
            }
        }

        private void completiontime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completiontime.CustomFormat = " ";
            }
        }

        private void completiontime_MouseDown(object sender, MouseEventArgs e)
        {
            completiontime.Text = DateTime.Now.ToLongTimeString();
            completiontime.CustomFormat = "HH:mm:ss";
        }

        private void correctiveactiondate_ValueChanged(object sender, EventArgs e)
        {
            correctiveactiondate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void correctiveactiondate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                correctiveactiondate.CustomFormat = " ";
            }
        }

        private void correctiveactiontime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                correctiveactiontime.CustomFormat = " ";
            }
        }

        private void correctiveactiontime_MouseDown(object sender, MouseEventArgs e)
        {
            correctiveactiontime.Text = DateTime.Now.ToLongTimeString();
            correctiveactiontime.CustomFormat = "HH:mm:ss";
        }

        private void requestid_TextChanged(object sender, EventArgs e)
        {

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
                    insert.Enabled = true;
                    update.Enabled = true;

                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    datagridview1_cellclick.Text = row.Cells["txtrequestID"].Value.ToString();
                    requestid.Text = row.Cells["txtrequestID"].Value.ToString();
                    //if (string.IsNullOrEmpty(pf_gcid.Text))
                    //{
                    //    pf_gcid.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    pf_gcid.Text = row.Cells["txtPF_GCID"].Value.ToString();
                    //}
                    processtype.Text = row.Cells["txtprocesstype"].Value.ToString();
                    drdprocess.Text = row.Cells["txtdrdprocess"].Value.ToString();
                    receiveddate.Text = row.Cells["txtreceiveddate"].Value.ToString();
                    receiveddate.CustomFormat = "dd-MMMM-yyyy";
                    receivedtime.Text = row.Cells["txtreceivedtime"].Value.ToString();
                    receivedtime.CustomFormat = "HH:mm:ss";
                    if (string.IsNullOrEmpty(row.Cells["txtcompletiondate"].Value.ToString()))
                    {
                        completiondate.CustomFormat = " ";
                        completiontime.CustomFormat = " ";
                    }
                    else
                    {
                        completiondate.Text = row.Cells["txtcompletiondate"].Value.ToString();
                        completiondate.CustomFormat = "dd-MMMM-yyyy";
                        completiontime.Text = row.Cells["txtcompletiontime"].Value.ToString();
                        completiontime.CustomFormat = "HH:mm:ss";
                    }
                    noofemails.Value = Convert.ToInt32(row.Cells["txtnoofemails"].Value);
                    associatename.Text = row.Cells["txtassociatename"].Value.ToString();
                    requestorbusinessunit.Text = row.Cells["txtrequestorbusinessunit"].Value.ToString();
                    principletype.Text = row.Cells["txtprincipletype"].Value.ToString();
                    partyname.Text = row.Cells["txtpartyname"].Value.ToString();
                    principlename.Text = row.Cells["txtprinciplename"].Value.ToString();
                    categoryname.Text = row.Cells["txtcategory"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txttypeofbreaches"].Value.ToString()))
                    {
                        typeofbreach.SelectedIndex = -1;
                    }
                    else
                    {
                        typeofbreach.Text = row.Cells["txttypeofbreaches"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtfeedbackgiven"].Value.ToString()))
                    {
                        feedbackgiven.SelectedIndex = -1;
                    }
                    else
                    {
                        feedbackgiven.Text = row.Cells["txtfeedbackgiven"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txttypeoferror"].Value.ToString()))
                    {
                        typeoferror.SelectedIndex = -1;
                    }
                    else
                    {
                        typeoferror.Text = row.Cells["txttypeoferror"].Value.ToString();
                    }
                    //noofcriticalerrors.Value = Convert.ToInt32(row.Cells["txtcriticalerrors"].Value);
                    //noofminorerrors.Value = Convert.ToInt32(row.Cells["txtminorerrors"].Value);
                    if (string.IsNullOrEmpty(row.Cells["txtcomments"].Value.ToString()))
                    {
                        comments.Text = string.Empty;
                    }
                    else
                    {
                        comments.Text = row.Cells["txtcomments"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtcorrectiveactiontaken"].Value.ToString()))
                    {
                        correctiveactiontaken.SelectedIndex = -1;
                    }
                    else
                    {
                        correctiveactiontaken.Text = row.Cells["txtcorrectiveactiontaken"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtcorrectiveactiondate"].Value.ToString()))
                    {
                        correctiveactiondate.CustomFormat = " ";
                        correctiveactiontime.CustomFormat = " ";
                    }
                    else
                    {
                        correctiveactiondate.Text = row.Cells["txtcorrectiveactiondate"].Value.ToString();
                        correctiveactiontime.Text = row.Cells["txtcorrectiveactiontime"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtcorrectiveactioncomments"].Value.ToString()))
                    {
                        correctiveactioncomments.Text = string.Empty;
                    }
                    else
                    {
                        correctiveactioncomments.Text = row.Cells["txtcorrectiveactioncomments"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtreasonfordisagreement"].Value.ToString()))
                    {
                        reasonsfordisagreement.Text = string.Empty;
                    }
                    else
                    {
                        reasonsfordisagreement.Text = row.Cells["txtreasonfordisagreement"].Value.ToString();
                    }
                    noofrecords.Value = Convert.ToInt32(row.Cells["txtnoofrecords"].Value);
                    if (string.IsNullOrEmpty(row.Cells["txtriskid"].Value.ToString()))
                    {
                        riskid.Text = string.Empty;
                    }
                    else
                    {
                        riskid.Text = row.Cells["txtriskid"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtbatchid"].Value.ToString()))
                    {
                        batchid.Text = string.Empty;
                    }
                    else
                    {
                        batchid.Text = row.Cells["txtbatchid"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtentityid"].Value.ToString()))
                    {
                        entityid.Text = string.Empty;
                    }
                    else
                    {
                        entityid.Text = row.Cells["txtentityid"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtpartylocation"].Value.ToString()))
                    {
                        partylocation.SelectedIndex = -1;
                    }
                    else
                    {
                        partylocation.Text = row.Cells["txtpartylocation"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtriskcategory"].Value.ToString()))
                    {
                        riskcategory.SelectedIndex = -1;
                    }
                    else
                    {
                        riskcategory.Text = row.Cells["txtriskcategory"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txteventcodes"].Value.ToString()))
                    {
                        eventcodes.SelectedIndex = -1;
                    }
                    else
                    {
                        eventcodes.Text = row.Cells["txteventcodes"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtPF_GCID"].Value.ToString()))
                    {
                        pf_gcid.Text = string.Empty;
                    }
                    else
                    {
                        pf_gcid.Text = row.Cells["txtPF_GCID"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtapprovalreceivedfromdesginatedsmsoapprover"].Value.ToString()))
                    {
                        approvalreceivedfromdesginatedsmsoapprover.SelectedIndex = -1;
                    }
                    else
                    {
                        approvalreceivedfromdesginatedsmsoapprover.Text = row.Cells["txtapprovalreceivedfromdesginatedsmsoapprover"].Value.ToString();
                    }
                    if (!string.IsNullOrEmpty(row.Cells["txtqualityparameters"].Value.ToString()))
                    {
                        for (int i = 0; i < qualityparameters.Items.Count; i++)
                        {
                            qualityparameters.SetItemChecked(i, false);
                        }
                        foreach (string value in row.Cells["txtqualityparameters"].Value.ToString().Split(','))
                        {
                            qualityparameters.SetItemChecked(qualityparameters.Items.IndexOf(value), true);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < qualityparameters.Items.Count; i++)
                        {
                            qualityparameters.SetItemChecked(i, false);
                        }
                    }
                    //insert.Enabled = true;
                    //update.Enabled = true;
                }
            }
            else
            {
                requestid.Focus();
                datagridview1_cellclick.SelectedIndex = -1;
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in dataGridView1.Rows)
            {
                if (!string.IsNullOrEmpty(myrow.Cells["txtcompletiondate"].Value.ToString()) && string.IsNullOrEmpty(myrow.Cells["txttypeoferror"].Value.ToString()))
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (string.IsNullOrEmpty(myrow.Cells["txtcompletiondate"].Value.ToString()))
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                }
                else if(!string.IsNullOrEmpty(myrow.Cells["txtcompletiondate"].Value.ToString()) && !string.IsNullOrEmpty(myrow.Cells["txttypeoferror"].Value.ToString()))
                {
                    myrow.DefaultCellStyle.BackColor = Color.Red;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void qualityparameters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void typeoferror_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(typeoferror.Text))
            {
                qualityparameters.Enabled = false;
                qualityparameters.Items.Clear();
                for (int i = 0; i < qualityparameters.Items.Count; i++)
                {
                    qualityparameters.SetItemChecked(i, false);
                }

            }
            else
            {
                qualityparameters.Enabled = true;
                qualityparameters.Items.Clear();
                for (int i = 0; i < qualityparameters.Items.Count; i++)
                {
                    qualityparameters.SetItemChecked(i, false);
                }
                qualityparameters_list();
            }
        }

        private void typeoferror_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                typeoferror.SelectedIndex = -1;
                qualityparameters.Items.Clear();
            }
        }

        private void noofcriticalerrors_ValueChanged(object sender, EventArgs e)
        {

        }

        private void typeofbreach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                typeofbreach.SelectedIndex = -1;
            }
        }

        private void requestorbusinessunit_TextUpdate(object sender, EventArgs e)
        {            
            datagridview2_display_filter();   
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                requestorbusinessunit.Text = row.Cells["txtRequestorBusinessUnit1"].Value.ToString();
            }
        }

        private void requestorbusinessunit_Leave(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            validate_requestorbusinessunit();
            //label19.Visible = true;
            //batchid.Visible = true;
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

        private void feedbackgiven_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                feedbackgiven.SelectedIndex = -1;
            }
        }

        private void correctiveactiontaken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                correctiveactiontaken.SelectedIndex = -1;
            }
        }

        private void dataGridView2_MouseHover(object sender, EventArgs e)
        {
            requestorbusinessunit.Text = string.Empty;
            
        }

        public void businessunits_sourcecodes_display()
        {
            if (drdprocess.Text == "KYC")
            {
                requestorbusinessunit_list();
            }
            else if (drdprocess.Text == "OMS")
            {
                requestorbusinessunit_list();
            }
            else if (drdprocess.Text == "Audit")
            {
                requestorbusinessunit_sourcecode_list();
            }
            else if (drdprocess.Text == "Batch")
            {
                sourcecodes_dotnet_list();
            }
        }

        private void drdprocess_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (drdprocess.Text == "KYC")
            //{
            //    requestorbusinessunit_list();
            //}
            //else if (drdprocess.Text == "OMS")
            //{
            //    requestorbusinessunit_list();
            //}
            //else if (drdprocess.Text == "Audit")
            //{
            //    requestorbusinessunit_sourcecode_list();
            //}
            ///*
            //else if (drdprocess.Text == "Batch" && string.IsNullOrEmpty(batchworkflow_requestid.Text))
            //{
            //    sourcecodes_list();
            //}
            //else if (drdprocess.Text == "Batch" && !string.IsNullOrEmpty(batchworkflow_requestid.Text))
            //{
            //    sourcecodes_dotnet_list();
            //}
            //*/
            //else if (drdprocess.Text == "Batch")
            //{
            //    sourcecodes_dotnet_list();
            //}
            businessunits_sourcecodes_display();
            if (string.IsNullOrEmpty(datagridview1_cellclick.Text))
            {
                batchid.Text = string.Empty;
            }
            empdetails_list();

            if (string.IsNullOrEmpty(drdprocess.Text))
            {
                qualityparameters.Enabled = false;
                qualityparameters.Items.Clear();
                for (int i = 0; i < qualityparameters.Items.Count; i++)
                {
                    qualityparameters.SetItemChecked(i, false);
                }

            }
            else
            {
                qualityparameters.Enabled = true;
                qualityparameters.Items.Clear();
                for (int i = 0; i < qualityparameters.Items.Count; i++)
                {
                    qualityparameters.SetItemChecked(i, false);
                }
                qualityparameters_list();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Approvals_RawData_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void partylocation_TextUpdate(object sender, EventArgs e)
        {
            datagridview3_display_filter();
        }

        private void partylocation_Leave(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            validate_partylocation();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                partylocation.Text = row.Cells["txtPartyLocation1"].Value.ToString();
            }
        }

        private void dataGridView3_MouseHover(object sender, EventArgs e)
        {
            partylocation.Text = string.Empty;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                associatename.Text = row.Cells["txtEmpName"].Value.ToString();
            }
        }

        private void dataGridView4_MouseHover(object sender, EventArgs e)
        {
            associatename.Text = string.Empty;
        }

        private void associatename_TextUpdate(object sender, EventArgs e)
        {
            datagridview4_display_filter();
        }

        private void associatename_Leave(object sender, EventArgs e)
        {
            validate_associatename();
            label27.Visible = true;
            principletype.Visible = true;
            label13.Visible = true;
            dataGridView4.Visible = false;
            
        }

        private void completiondate_MouseHover(object sender, EventArgs e)
        {
            completiondate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void completiontime_MouseHover(object sender, EventArgs e)
        {
            completiontime.Text = DateTime.Now.ToLongTimeString();
            completiontime.CustomFormat = "HH:mm:ss";
        }

        private void dataGridView2_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                requestorbusinessunit.Text = row.Cells["txtRequestorBusinessUnit1"].Value.ToString();
            }
        }

        private void dataGridView4_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                associatename.Text = row.Cells["txtEmpName"].Value.ToString();
            }
        }

        private void dataGridView3_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                partylocation.Text = row.Cells["txtPartyLocation1"].Value.ToString();
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

        private void associatename_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(associatename_search.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_associatename();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 obj_form8 = new Form8();
            obj_form8.Show();
            //this.Hide();
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

        private void processtype_DropDown(object sender, EventArgs e)
        {
            //processtype_list();
        }

        private void drdprocess_DropDown(object sender, EventArgs e)
        {
            //edsprocess_list();
        }

        private void categoryname_DropDown(object sender, EventArgs e)
        {
            //categoryname_list();
        }

        private void typeofbreach_DropDown(object sender, EventArgs e)
        {
            //typeofbreaches_list();
        }

        private void feedbackgiven_DropDown(object sender, EventArgs e)
        {
            //feedbackgiven_list();
        }

        private void typeoferror_DropDown(object sender, EventArgs e)
        {
            //typeoferror_list();
        }

        private void correctiveactiontaken_DropDown(object sender, EventArgs e)
        {
            //correctiveactiontaken_list();
        }

        private void principletype_DropDown(object sender, EventArgs e)
        {
            //principletype_list();
        }

        private void associatename_DropDown(object sender, EventArgs e)
        {
            //empdetails_list();
        }

        private void partylocation_DropDown(object sender, EventArgs e)
        {
            //partylocation_list();
        }

        private void riskcategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                riskcategory.SelectedIndex = -1;
            }
        }

        private void eventcodes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                eventcodes.SelectedIndex = -1;
            }
        }

        private void plcidbatchid_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(plcidbatchid_search.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_plcidbatchid();
            }
        }

        private void batchid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(datagridview1_cellclick.Text))
            {
                if ((drdprocess.Text == "KYC" || drdprocess.Text == "Audit") && processtype.Text == "KYC QC")
                {
                    partydetails_lookup();
                }
                else if ((drdprocess.Text == "KYC" || drdprocess.Text == "Audit") && processtype.Text == "STP QC")
                {
                    partydetails_lookup();
                }
                else if ((drdprocess.Text == "KYC" || drdprocess.Text == "Audit") && processtype.Text == "SR KYC QC")
                {
                    partydetails_lookup();
                }
                else if ((drdprocess.Text == "KYC" || drdprocess.Text == "Audit") && processtype.Text == "Senior Review")
                {
                    partydetails_lookup_approvals();
                }
                else if ((drdprocess.Text == "KYC" || drdprocess.Text == "Audit") && processtype.Text == "PEP")
                {
                    partydetails_lookup_approvals();
                }
                else if (drdprocess.Text == "PR")
                {
                    partydetails_lookup_approvals();
                }
                else if (drdprocess.Text == "UBO")
                {
                    partydetails_lookup_approvals();
                }
                else
                {
                    partylocation_list();
                    //if (drdprocess.Text == "OMS" || drdprocess.Text == "KYC")
                    //{
                    //    requestorbusinessunit_list();
                    //}
                    //else
                    //{
                    //    sourcecodes_list();
                    //}
                    businessunits_sourcecodes_display();

                }
            }

            if (drdprocess.Text == "OMS" && update.Enabled == false)
            {
                autopopulate_clientname_oms();
            }
        }

        private void batchid_TabIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(datagridview1_cellclick.Text))
            {
                if (drdprocess.Text != "KYC")
                {
                    partylocation_list();
                    //if (drdprocess.Text == "KYC")
                    //{
                    //    requestorbusinessunit_list();
                    //}
                    //else if (drdprocess.Text == "OMS")
                    //{
                    //    requestorbusinessunit_list();
                    //}
                    //else
                    //{
                    //    sourcecodes_list();
                    //}
                    businessunits_sourcecodes_display();
                }
            }
            
        }

        private void batchid_MouseLeave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(datagridview1_cellclick.Text))
            {
                if (drdprocess.Text != "KYC")
                {
                    partylocation_list();
                    //if (drdprocess.Text == "KYC")
                    //{
                    //    requestorbusinessunit_list();
                    //}
                    //else if (drdprocess.Text == "OMS")
                    //{
                    //    requestorbusinessunit_list();
                    //}
                    //else
                    //{
                    //    sourcecodes_list();
                    //}
                }
            }
             
             
        }

        private void batchid_Leave(object sender, EventArgs e)
        {
            if (drdprocess.Text != "KYC")
            {
                partylocation_list();
                //if (drdprocess.Text == "KYC")
                //{
                //    requestorbusinessunit_list();
                //}
                //else if (drdprocess.Text == "OMS")
                //{
                //    requestorbusinessunit_list();
                //}
                //else
                //{
                //    sourcecodes_list();
                //}
                businessunits_sourcecodes_display();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            datagridview1_display_overall();
        }

        private void processtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(datagridview1_cellclick.Text))
            {
                if (processtype.Text == "PEP" && insert.Enabled == true)
                {
                    riskcategory.Text = "PEP";
                    eventcodes.Text = "Political Person";
                }
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string messsage = "Do you want to update the record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
                {
                    reset_overall();
                    sourcecodes_dotnet_list();
                    DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
                    processtype.Text = row.Cells["txtProcessType_batch"].Value.ToString();
                    drdprocess.Text = row.Cells["txtDRDProcess_batch"].Value.ToString();
                    batchid.Text = row.Cells["txtBatchID_batch"].Value.ToString();
                    associatename.Text = row.Cells["txtAssociateName_batch"].Value.ToString();
                    partyname.Text = row.Cells["txtPartyName_batch"].Value.ToString();
                    principlename.Text = row.Cells["txtPrincipleName_batch"].Value.ToString();
                    riskcategory.Text = row.Cells["txtRiskCategory_batch"].Value.ToString();
                    principletype.Text = row.Cells["txtPrincipleType_batch"].Value.ToString();
                    eventcodes.Text = row.Cells["txtEventCodes_batch"].Value.ToString();
                    riskid.Text = row.Cells["txtRiskID_batch"].Value.ToString();
                    batchworkflow_requestid.Text = row.Cells["txtBatchWorkflow_RequestID"].Value.ToString();
                    update.Enabled = false;
                    insert.Enabled = true;
                    sourcecodes_dotnet_list();
                    requestorbusinessunit.Text = row.Cells["txtRequestorBusinessUnit_batch"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txtApprovalRejectionComment"].Value.ToString()))
                    {
                        comments.Text = string.Empty;
                    }
                    else
                    {
                        comments.Text = row.Cells["txtApprovalRejectionComment"].Value.ToString();
                    }
                }
            }
            else
            {
                requestid.Focus();
                update.Enabled = true;
            }
        }

        private void dataGridView5_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in dataGridView5.Rows)
            {
                if (!string.IsNullOrEmpty(myrow.Cells["txtBatchWorkflow_RequestID_Status"].Value.ToString()) && myrow.Cells["txtBatchWorkflow_RequestID_Status"].Value.ToString() == "Added")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;
                }
                else 
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                }
                
            }
        }

        private void batchworkflowqueuestatus_search_SelectedIndexChanged(object sender, EventArgs e)
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
                cmd.CommandText = "select * from dbo.vw_batchworkflow_approvalsqueue_dotnet where BatchWorkflow_RequestID_Status = @BatchWorkflow_RequestID_Status order by ReceivedDate desc";
                cmd.Parameters.AddWithValue("@BatchWorkflow_RequestID_Status",batchworkflowqueuestatus_search.Text);
                cmd.ExecuteNonQuery();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView5.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        private void batchworkflowinquiryid_search_TextChanged(object sender, EventArgs e)
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
                cmd.CommandText = "select * from dbo.vw_batchworkflow_approvalsqueue_dotnet where inquiry like @inquiry order by ReceivedDate desc";
                cmd.Parameters.AddWithValue("@inquiry","%" + batchworkflowinquiryid_search.Text + "%");
                cmd.ExecuteNonQuery();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView5.DataSource = dt;
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        private void typeofbreach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
