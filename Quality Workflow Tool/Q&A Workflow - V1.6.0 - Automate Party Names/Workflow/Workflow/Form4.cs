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
    public partial class Form4 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            EmpDetails obj_empdetails = new EmpDetails();
            Boolean obj_boolean = new Boolean();
            LineManager obj_linemanager = new LineManager();
            //RequestorBusinessUnit obj_bu = new RequestorBusinessUnit();
            BU_RCAIncident obj_bu = new BU_RCAIncident();
            EventStream obj_eventstream = new EventStream(); 
            ProcessingHub obj_processhub = new ProcessingHub();
            EventCategory obj_eventcategory = new EventCategory();
            CounterMeasures obj_counter = new CounterMeasures();
            reset_overall();
            
        }

        public void reset_overall()
        {
            empdetails_list();
            boolean_list();
            linemanager_list();
            requestorbusinessunit_list();
            eventstream_list1();
            processinghub_list1();
            eventcategory_list1();
            countermeasures_list1();
            datagridview1_display_overall();
            isdeleted.Visible = false;
            isdeleted.Value = 0;
            workflowrequestid.Text = string.Empty;
            workflowrequestid.Enabled = false;
            bu.SelectedIndex = -1;
            officelocation.Text = string.Empty;
            occurence.Text = DateTime.Now.ToLongDateString();
            vertical.Text = string.Empty;
            rootcausejustification.Text = string.Empty;
            searchby_dateidentified.CustomFormat = " ";
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
                obj_empdetails.empdetails_list_rcaincident(dtaa);
                txtassociatereporting.DataSource = dtaa;
                txtassociatereporting.DisplayMember = "EmpName";
                txtcolleaguereporting.DataSource = dtaa;
                txtcolleaguereporting.DisplayMember = "EmpName";
                txtassociatecorrective.DataSource = dtaa;
                txtassociatecorrective.DisplayMember = "EmpName";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void linemanager_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                LineManager obj_linemanager = new LineManager();
                DataTable dtaa = new DataTable();
                obj_linemanager.linemanager_list(dtaa);
                txtlinemanager.DataSource = dtaa;
                txtlinemanager.DisplayMember = "EmpName";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void boolean_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Boolean obj_boolean = new Boolean();
                DataTable dtaa = new DataTable();
                obj_boolean.boolean_list(dtaa);
                txtapplytowillislimited.DataSource = dtaa;
                txtapplytowillislimited.DisplayMember = "Boolean";
                txtfinancialloss.DataSource = dtaa;
                txtfinancialloss.DisplayMember = "Boolean";
                txtclientmoney.DataSource = dtaa;
                txtclientmoney.DisplayMember = "Boolean";
                txtconflictsOfinterestpolicy.DataSource = dtaa;
                txtconflictsOfinterestpolicy.DisplayMember = "Boolean";
                txttegulatoryreportable.DataSource = dtaa;
                txttegulatoryreportable.DisplayMember = "Boolean";
                txtregulatornotified.DataSource = dtaa;
                txtregulatornotified.DisplayMember = "Boolean";
                txtresolved.DataSource = dtaa;
                txtresolved.DisplayMember = "Boolean";
                conn.Close();
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
                BU_RCAIncident obj_bu = new BU_RCAIncident();
                DataTable dtaa = new DataTable();
                obj_bu.bu_list(dtaa);
                txtbu.DataSource = dtaa;
                txtbu.DisplayMember = "BU";
                bu.DataSource = dtaa;
                bu.DisplayMember = "BU";
                conn.Close();

                RequestorBusinessUnit obj_requestorbu = new RequestorBusinessUnit();
                DataTable dtaa1 = new DataTable();
                obj_requestorbu.requestorbusinessunit_list(dtaa1);
                txtsubbu.DataSource = dtaa1;
                txtsubbu.DisplayMember = "RequestorBusinessunit";
                conn.Close();
                
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void eventstream_list1()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                EventStream obj_eventstream = new EventStream(); 
                DataTable dtaa = new DataTable();
                obj_eventstream.eventstream_list(dtaa);
                txteventstream.DataSource = dtaa;
                txteventstream.DisplayMember = "EventStream";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void processinghub_list1()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                ProcessingHub obj_processhub = new ProcessingHub();
                DataTable dtaa = new DataTable();
                obj_processhub.processinghub_list(dtaa);
                txtprocessinghub.DataSource = dtaa;
                txtprocessinghub.DisplayMember = "ProcessingHub";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void eventcategory_list1()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                EventCategory obj_eventcategory = new EventCategory();
                DataTable dtaa = new DataTable();
                obj_eventcategory.eventcategory_list(dtaa);
                txteventcategory.DataSource = dtaa;
                txteventcategory.DisplayMember = "EventCategory";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void countermeasures_list1()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                CounterMeasures obj_counter = new CounterMeasures();
                DataTable dtaa = new DataTable();
                obj_counter.countermeasures_list(dtaa);
                txtappropriatecountermeasures1.DataSource = dtaa;
                txtappropriatecountermeasures1.DisplayMember = "CounterMeasures";
                conn.Close();

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
                cmd.CommandText = "select * from dbo.vw_rcaincident_daily_dotnet order by ID asc";
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
                cmd.CommandText = "select * from dbo.vw_rcaincident_daily_dotnet where colleague_team_reporting like @associatename order by ID asc";
                cmd.Parameters.AddWithValue("@associatename","%" + searchby_associatename.Text + "%");
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

        public void datagridview1_display_workflowrequestid()
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
                cmd.CommandText = "select * from dbo.vw_rcaincident_daily_dotnet where workflowrequestid like @workflowrequestid order by ID asc";
                cmd.Parameters.AddWithValue("@workflowrequestid", "%" + searchby_workflowrequestid.Text + "%");
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

        public void datagridview1_display_breachmonth()
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
                cmd.CommandText = "select * from dbo.vw_rcaincident_daily_dotnet where convert(date,dateadd(dd,1,eomonth(date_identified,-1))) = convert(date,dateadd(dd,1,eomonth(@breachmonth,-1))) order by ID asc";
                cmd.Parameters.AddWithValue("@breachmonth",searchby_breachmonth.Text);
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

        public void datagridview1_display_dateidentified()
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
                cmd.CommandText = "select * from dbo.vw_rcaincident_daily_dotnet where convert(date,date_identified) = convert(date,@dateidentified) order by ID asc";
                cmd.Parameters.AddWithValue("@dateidentified", searchby_dateidentified.Text);
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    
                    DataGridViewRow dgvrow = dataGridView1.CurrentRow;
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "usp_rcaincident_addoredit_dotnet @ID,@Colleague_Team_Reporting,@Person_responsible_for_incidents,@View,@Associate_Reporting,@Date_Identified,@Line_Manager,@BU,@OfficeLocation,@Event_Stream,@Processing_Hub,@ApplyToWillisLimited,@Occurrence,@IncidentType,@RCAThreshold,@FinancialLoss,@NetLoss,@EventCategory,@FinancialCategories,@StrategicCategories,@LegalCategories,@RegulatoryCategories,@OperationalCategories,@PeopleCategories,@Complaint_ID,@ClientMoney,@ConflictsOfInterestPolicy,@RegulatoryReportable,@RegulatorNotified,@Details,@AssociateCorrective,@CorrectiveTaken,@DateCorrective,@RootCause,@ControlFailureDetails,@Responsible_for_this_Failure,@ExternalFactors,@RootCauseJustification,@RecurrencePrevention,@AppropriateCounterMeasures_1,@Comments,@Resolved,@Date_Resolved,@IdentificationMethod,@Requestor_BU_Vertical,@IsDeleted,@LastUpdatedBy,@LastUpdatedDateTime,@MachineName";
                    cmd.CommandText = "dbo.usp_rcaincident_addoredit_dotnet";
                    cmd.Parameters.AddWithValue("@ID", dgvrow.Cells["txtid"].Value);
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtcolleaguereporting"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Colleague_Team_Reporting", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Colleague_Team_Reporting", dgvrow.Cells["txtcolleaguereporting"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtpersonresponsibleforincidents"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Person_responsible_for_incidents", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Person_responsible_for_incidents", dgvrow.Cells["txtpersonresponsibleforincidents"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtview"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@View", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@View", dgvrow.Cells["txtview"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtassociatereporting"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Associate_Reporting", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Associate_Reporting", dgvrow.Cells["txtassociatereporting"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtdateidentified"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Date_Identified", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Date_Identified", dgvrow.Cells["txtdateidentified"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtlinemanager"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Line_Manager", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Line_Manager", dgvrow.Cells["txtlinemanager"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtbu"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@BU", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@BU", dgvrow.Cells["txtbu"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtofficelocation"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@OfficeLocation", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OfficeLocation", dgvrow.Cells["txtofficelocation"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txteventstream"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Event_Stream", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Event_Stream", dgvrow.Cells["txteventstream"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtprocessinghub"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Processing_Hub", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Processing_Hub", dgvrow.Cells["txtprocessinghub"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtapplytowillislimited"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@ApplyToWillisLimited", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ApplyToWillisLimited", dgvrow.Cells["txtapplytowillislimited"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtoccurrence"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Occurrence", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Occurrence", dgvrow.Cells["txtoccurrence"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtincidenttype"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@IncidentType", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IncidentType", dgvrow.Cells["txtincidenttype"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtrcathreshold"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@RCAThreshold", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RCAThreshold", dgvrow.Cells["txtrcathreshold"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtfinancialloss"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@FinancialLoss", DBNull.Value );
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FinancialLoss", dgvrow.Cells["txtfinancialloss"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtnetloss"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@NetLoss", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@NetLoss", dgvrow.Cells["txtnetloss"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txteventcategory"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@EventCategory", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@EventCategory", dgvrow.Cells["txteventcategory"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtfinancialcategories"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@FinancialCategories", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FinancialCategories", dgvrow.Cells["txtfinancialcategories"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtstrategiccategories"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@StrategicCategories", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@StrategicCategories", dgvrow.Cells["txtstrategiccategories"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtlegalcategories"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@LegalCategories", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@LegalCategories", dgvrow.Cells["txtlegalcategories"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtregulatorycategories"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@RegulatoryCategories", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RegulatoryCategories", dgvrow.Cells["txtregulatorycategories"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtoperationalcategories"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@OperationalCategories", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OperationalCategories", dgvrow.Cells["txtoperationalcategories"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtpeoplecategories"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@PeopleCategories", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PeopleCategories", dgvrow.Cells["txtpeoplecategories"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtcomplaintid"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Complaint_ID", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Complaint_ID", dgvrow.Cells["txtcomplaintid"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtclientmoney"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@ClientMoney", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ClientMoney", dgvrow.Cells["txtclientmoney"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtconflictsOfinterestpolicy"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@ConflictsOfInterestPolicy", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ConflictsOfInterestPolicy", dgvrow.Cells["txtconflictsOfinterestpolicy"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txttegulatoryreportable"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@RegulatoryReportable", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RegulatoryReportable", dgvrow.Cells["txttegulatoryreportable"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtregulatornotified"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@RegulatorNotified", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RegulatorNotified", dgvrow.Cells["txtregulatornotified"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtdetails"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Details", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Details", dgvrow.Cells["txtdetails"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtassociatecorrective"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@AssociateCorrective", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@AssociateCorrective", dgvrow.Cells["txtassociatecorrective"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtcorrectivetaken"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@CorrectiveTaken", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CorrectiveTaken", dgvrow.Cells["txtcorrectivetaken"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtdatecorrective"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@DateCorrective", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DateCorrective", dgvrow.Cells["txtdatecorrective"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtrootcause"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@RootCause", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RootCause", dgvrow.Cells["txtrootcause"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtcontrolfailuredetails"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@ControlFailureDetails", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ControlFailureDetails", dgvrow.Cells["txtcontrolfailuredetails"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtresponsibleforthisfailure"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Responsible_for_this_Failure", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Responsible_for_this_Failure", dgvrow.Cells["txtresponsibleforthisfailure"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtexternalfactors"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@ExternalFactors", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ExternalFactors", dgvrow.Cells["txtexternalfactors"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtrootcausejustification"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@RootCauseJustification", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RootCauseJustification", dgvrow.Cells["txtrootcausejustification"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtrecurrenceprevention"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@RecurrencePrevention", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RecurrencePrevention", dgvrow.Cells["txtrecurrenceprevention"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtappropriatecountermeasures1"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@AppropriateCounterMeasures_1", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@AppropriateCounterMeasures_1", dgvrow.Cells["txtappropriatecountermeasures1"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtcomments"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Comments", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Comments", dgvrow.Cells["txtcomments"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtresolved"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Resolved", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Resolved", dgvrow.Cells["txtresolved"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtdateresolved"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Date_Resolved", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Date_Resolved", dgvrow.Cells["txtdateresolved"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtidentificationmethod"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@IdentificationMethod", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IdentificationMethod", dgvrow.Cells["txtidentificationmethod"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["textrequestorbuvertical"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Requestor_BU_Vertical", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Requestor_BU_Vertical", dgvrow.Cells["textrequestorbuvertical"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtsubbu"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@SubBU", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SubBU", dgvrow.Cells["txtsubbu"].Value.ToString());
                    }
                    if (string.IsNullOrEmpty(dgvrow.Cells["txtlegalentityname"].Value.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@LegalEntityName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@LegalEntityName", dgvrow.Cells["txtlegalentityname"].Value.ToString());
                    }
                    cmd.Parameters.AddWithValue("@IsDeleted", isdeleted.Value);
                    cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                    cmd.Parameters.AddWithValue("@WorkflowRequestID", dgvrow.Cells["txtworkflowrequestid"].Value);
                    
                    cmd.ExecuteNonQuery();
                    datagridview1_display_overall();
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            
            try
            {
                if (dataGridView1.CurrentRow.Cells["txtid"].Value != DBNull.Value)
                {
                    if (MessageBox.Show("Are you sure to delete this record ?", "DataGridView", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DataGridViewRow dgvrow = dataGridView1.CurrentRow;
                        conn.ConnectionString = connectionstringtxt;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.CommandText = "usp_rcaincident_addoredit_dotnet @ID,@Colleague_Team_Reporting,@Person_responsible_for_incidents,@View,@Associate_Reporting,@Date_Identified,@Line_Manager,@BU,@OfficeLocation,@Event_Stream,@Processing_Hub,@ApplyToWillisLimited,@Occurrence,@IncidentType,@RCAThreshold,@FinancialLoss,@NetLoss,@EventCategory,@FinancialCategories,@StrategicCategories,@LegalCategories,@RegulatoryCategories,@OperationalCategories,@PeopleCategories,@Complaint_ID,@ClientMoney,@ConflictsOfInterestPolicy,@RegulatoryReportable,@RegulatorNotified,@Details,@AssociateCorrective,@CorrectiveTaken,@DateCorrective,@RootCause,@ControlFailureDetails,@Responsible_for_this_Failure,@ExternalFactors,@RootCauseJustification,@RecurrencePrevention,@AppropriateCounterMeasures_1,@Comments,@Resolved,@Date_Resolved,@IdentificationMethod,@Requestor_BU_Vertical,@IsDeleted,@LastUpdatedBy,@LastUpdatedDateTime,@MachineName";
                        cmd.CommandText = "dbo.[usp_rcaincident_delete_dotnet]";
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(dgvrow.Cells["txtid"].Value));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Row(s) deleted successfully ");
                        datagridview1_display_overall();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
                datagridview1_display_overall();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Approvals_IncidentRCA_dotnet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datagridview1_display_overall();
        }

        private void searchby_associatename_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchby_associatename.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_associatename();
            }
        }

        private void searchby_workflowrequestid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchby_workflowrequestid.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_workflowrequestid();
            }
        }

        private void searchby_breachmonth_ValueChanged(object sender, EventArgs e)
        {
            searchby_breachmonth.CustomFormat = "dd-MMMM-yyyy";
            if (searchby_breachmonth.Text.Trim() == string.Empty)
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_breachmonth();
            }
        }

        private void searchby_dateidentified_ValueChanged(object sender, EventArgs e)
        {
            searchby_dateidentified.CustomFormat = "dd-MMMM-yyyy";
            if (searchby_dateidentified.Text.Trim() == string.Empty)
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_dateidentified();
            }
        }

        private void searchby_breachmonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_breachmonth.CustomFormat = " ";
            }
        }

        private void searchby_dateidentified_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_dateidentified.CustomFormat = " ";
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
                    workflowrequestid.Text = row.Cells["txtworkflowrequestid"].Value.ToString();
                    bu.Text = row.Cells["txtbu"].Value.ToString();
                    officelocation.Text = row.Cells["txtofficelocation"].Value.ToString();
                    occurence.Text = row.Cells["txtoccurrence"].Value.ToString();
                    vertical.Text = row.Cells["textrequestorbuvertical"].Value.ToString();
                    rootcausejustification.Text = row.Cells["txtrootcausejustification"].Value.ToString();
                }
            }
            else
            {
                workflowrequestid.Focus();
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            workflowrequestid.Text = string.Empty;
            workflowrequestid.Enabled = false;
            bu.SelectedIndex = -1;
            officelocation.Text = string.Empty;
            occurence.Text = DateTime.Now.ToLongDateString();
            vertical.Text = string.Empty;
            rootcausejustification.Text = string.Empty;
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
                cmd.CommandText = "update dbo.tbl_rcaincident_daily_dotnet set BU=@BU,OfficeLocation=@OfficeLocation,Occurrence=@Occurrence,RootCauseJustification=@RootCauseJustification,Requestor_BU_Vertical=@Requestor_BU_Vertical where workflowrequestid=@workflowrequestid";
                cmd.Parameters.AddWithValue("@BU",bu.Text);
                cmd.Parameters.AddWithValue("@OfficeLocation",officelocation.Text);
                cmd.Parameters.AddWithValue("@Occurrence",occurence.Value.Date);
                cmd.Parameters.AddWithValue("@RootCauseJustification",rootcausejustification.Text);
                cmd.Parameters.AddWithValue("@Requestor_BU_Vertical",vertical.Text);
                cmd.Parameters.AddWithValue("@workflowrequestid",workflowrequestid.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                cmd.Parameters.Clear();
                workflowrequestid.Text = string.Empty;
                workflowrequestid.Enabled = false;
                bu.SelectedIndex = -1;
                officelocation.Text = string.Empty;
                occurence.Text = DateTime.Now.ToLongDateString();
                vertical.Text = string.Empty;
                rootcausejustification.Text = string.Empty;
                conn.Close();        
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details" + ab.ToString());
            }
        }
    }
}
