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
    public partial class Form5 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            reset_overall();
        }

        public void reset_overall()
        {
            button3.Enabled = false;
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
                cmd.CommandText = "select Requestid,SourceType,EmpName,ReceivedDate,PrincipleName,PartyName,MatchCriteria,MatchCategory,DunsNumber,RequestSourceName,ReferenceId,CompletionDate,INTID,UniqueID from dbo.tbl_randomizer_kyc_daily_dotnet with(nolock)";
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
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Randomizer_KYC_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
            datagridview1_display_overall();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                //SqlDataAdapter sda = new SqlDataAdapter();
                //DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "exec dbo.usp_randomizer_kyc_archive_dotnet @UploadDate,@UploadedBy";
                cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@UploadedBy",Environment.UserName.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data exported successfully to work queue");
                //sda.SelectCommand = cmd;
                //sda.Fill(dt);
                //dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Data export failed");
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells["txtUniqueID"].Value != DBNull.Value)
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
                        cmd.CommandText = "dbo.usp_randomizer_kyc_daily_delete_dotnet";
                        cmd.Parameters.AddWithValue("@UniqueID", dgvrow.Cells["txtUniqueID"].Value.ToString());
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
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            datagridview1_display_overall();
        }

        private void Form5_MouseHover(object sender, EventArgs e)
        {
            datagridview1_display_overall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Randomizer_KYC_DotNet_RegionWise");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
            datagridview1_display_overall();
        }
    }
}
