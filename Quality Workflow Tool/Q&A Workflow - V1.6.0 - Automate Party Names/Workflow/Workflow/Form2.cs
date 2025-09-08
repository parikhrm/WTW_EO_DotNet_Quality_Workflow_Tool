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
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            hide_buttons();
            EmpName_level();
            empname.Visible = false;
            adminlevel.Visible = false;
            processname.Visible = false;
            accesslevel.Visible = false;
        }

        public void hide_buttons()
        {
            workqueue_kyc.Visible = false;
            workqueue_qualityandapprovals.Visible = false;
            workflow.Visible = false;
            incidentrca.Visible = false;
            processmanuals.Visible = false;
            errortracker.Visible = false;
            qualityselfservice.Visible = false;
            randomizer_kyc.Visible = false;
            randomizer_qualityandapprovals.Visible = false;
            qsptracker.Visible = false;
            searchtool.Visible = false;
            searchtool_datamart.Visible = false;
            compediumoferrors.Visible = false;
            audittrail.Visible = false;
            qualityreport_ssrs.Visible = false;
            qualityreport_powerbi.Visible = false;
            qualityreport_qualityandapprovals.Visible = false;
            productivityreport.Visible = false;
            qaworkqueue.Visible = false;
            qualitysupervisor.Visible = false;
            quicklinks.Visible = false;
            reports.Visible = false;
            smsosearchtool.Visible = false;
            raisedispute.Visible = false;
            qualityreport_audit.Visible = false;
            batch_oms_bulk_upload.Visible = false;
            kpiscorecard.Visible = false;
        }

        private void qaworkqueue_MouseHover(object sender, EventArgs e)
        {
            randomizer_kyc.Visible = false;
            randomizer_qualityandapprovals.Visible = false;
            qsptracker.Visible = false;
            processmanuals.Visible = false;
            errortracker.Visible = false;
            searchtool.Visible = false;
            searchtool_datamart.Visible = false;
            qualityselfservice.Visible = false;
            compediumoferrors.Visible = false;
            audittrail.Visible = false;
            qualityreport_ssrs.Visible = false;
            qualityreport_powerbi.Visible = false;
            qualityreport_qualityandapprovals.Visible = false;
            productivityreport.Visible = false;
            smsosearchtool.Visible = false;
            raisedispute.Visible = false;
            qualityreport_audit.Visible = false;
            batch_oms_bulk_upload.Visible = false;
            kpiscorecard.Visible = false;

            //if (adminlevel.Text == "Associate" && processname.Text != "Approvals")//Read
            if(accesslevel.Text == "Read")
            {
                workqueue_kyc.Visible = true;
                workqueue_kyc.Enabled = false;
                workqueue_qualityandapprovals.Visible = true;
                workqueue_qualityandapprovals.Enabled = false;
                workflow.Visible = true;
                workflow.Enabled = false;
                incidentrca.Visible = true;
                incidentrca.Enabled = false;
            }
            //else if (adminlevel.Text == "Admin" || processname.Text == "Approvals")//<>Read
            else if(accesslevel.Text != "Read")
            {
                workqueue_kyc.Visible = true;
                workqueue_kyc.Enabled = true;
                workqueue_qualityandapprovals.Visible = true;
                workqueue_qualityandapprovals.Enabled = true;
                workflow.Visible = true;
                workflow.Enabled = true;
                incidentrca.Enabled = true;
                incidentrca.Visible = true;
            }
            else
            {
                workqueue_kyc.Visible = true;
                workqueue_kyc.Enabled = false;
                workqueue_qualityandapprovals.Visible = true;
                workqueue_qualityandapprovals.Enabled = false;
                workflow.Visible = true;
                workflow.Enabled = false;
                incidentrca.Visible = true;
                incidentrca.Enabled = false;
            }
        }

        private void qaworkqueue_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void workqueue_MouseHover(object sender, EventArgs e)
        {
            //workqueue.Visible = true;
        }

        private void qaworkqueue_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void qualitysupervisor_MouseHover(object sender, EventArgs e)
        {
            workqueue_kyc.Visible = false;
            workqueue_qualityandapprovals.Visible = false;
            workflow.Visible = false;
            incidentrca.Visible = false;
            processmanuals.Visible = false;
            errortracker.Visible = false;
            searchtool.Visible = false;
            searchtool_datamart.Visible = false;
            qualityselfservice.Visible = false;
            compediumoferrors.Visible = false;
            audittrail.Visible = false;
            qualityreport_ssrs.Visible = false;
            qualityreport_powerbi.Visible = false;
            qualityreport_qualityandapprovals.Visible = false;
            productivityreport.Visible = false;
            smsosearchtool.Visible = false;
            raisedispute.Visible = false;
            qualityreport_audit.Visible = false;
            batch_oms_bulk_upload.Visible = false;
            kpiscorecard.Visible = false;

            //if (adminlevel.Text == "Admin")
            if(accesslevel.Text == "Admin")
            {
                randomizer_kyc.Enabled = true;
                randomizer_kyc.Visible = true;
                randomizer_qualityandapprovals.Enabled = true;
                randomizer_qualityandapprovals.Visible = true;
                qsptracker.Enabled = true;
                qsptracker.Visible = true;
                raisedispute.Enabled = true;
                raisedispute.Visible = true;
            }
            else
            {
                randomizer_kyc.Enabled = false;
                randomizer_kyc.Visible = true;
                randomizer_qualityandapprovals.Enabled = false;
                randomizer_qualityandapprovals.Visible = true;
                qsptracker.Enabled = false;
                qsptracker.Visible = true;
                raisedispute.Enabled = false;
                raisedispute.Visible = true;
            }
        }

        private void workflow_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj_form1 = new Form1();
            obj_form1.Show();
        }

        private void workqueue_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 obj_form6 = new Form6();
            obj_form6.Show();
        }

        private void quicklinks_MouseHover(object sender, EventArgs e)
        {
            workqueue_kyc.Visible = false;
            workqueue_qualityandapprovals.Visible = false;
            workflow.Visible = false;
            incidentrca.Visible = false;
            randomizer_kyc.Visible = false;
            randomizer_qualityandapprovals.Visible = false;
            qsptracker.Visible = false;
            qualityselfservice.Visible = false;
            compediumoferrors.Visible = false;
            audittrail.Visible = false;
            qualityreport_ssrs.Visible = false;
            qualityreport_powerbi.Visible = false;
            qualityreport_qualityandapprovals.Visible = false;
            productivityreport.Visible = false;
            raisedispute.Visible = false;
            processmanuals.Visible = true;
            errortracker.Visible = true;
            searchtool.Visible = true;
            searchtool_datamart.Visible = true;
            smsosearchtool.Visible = true;
            qualityreport_audit.Visible = false;
            batch_oms_bulk_upload.Visible = true;
            kpiscorecard.Visible = false;
        }

        private void processmanuals_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://connect-eu.willis.com/ukdataref/MI%20%20Data%20Ref%20Admin/Forms/AllItems.aspx");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            hide_buttons();
        }

        private void errortracker_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 obj_form3 = new Form3();
            obj_form3.Show();
        }

        private void incidentrca_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 obj_form4 = new Form4();
            obj_form4.Show();
        }

        public void EmpName_level()
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
                conn.Open();
                cmd.Connection = conn;
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from dbo.tbl_emp_details with(nolock) where 1=1 and isdeleted = 0 and SUBSTRING(INTID,5,len(intid)) = @intidparam ";
                cmd.Parameters.AddWithValue("@INTIDparam", Environment.UserName.ToString());
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                empname.DataSource = dt;
                empname.DisplayMember = "EmpName";
                adminlevel.DataSource = dt;
                adminlevel.DisplayMember = "Admin Level";
                processname.DataSource = dt;
                processname.DisplayMember = "Process";
                accesslevel.DataSource = dt;
                accesslevel.DisplayMember = "AccessLevel";
                conn.Close();
            }
            catch(Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void randomizer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 obj_form5 = new Form5();
            obj_form5.Show();
        }

        private void qsptracker_Click(object sender, EventArgs e)
        {
            try
            {
                //System.Diagnostics.Process.Start("inmum-i-fs5\\group$:\\Global Corporate & Data Strategy\\Data Reference\\Workflow\\2018\\MFC - 2018 Workflow");
                System.Diagnostics.Process.Start("\\\\inmum-i-fs5\\group$\\Global Corporate & Data Strategy\\QMF Central\\GCDS QMS\\QSP");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void qualityselfservice_Click(object sender, EventArgs e)
        {
            try
            {
                //System.Diagnostics.Process.Start("inmum-i-fs5\\group$:\\Global Corporate & Data Strategy\\Data Reference\\Workflow\\2018\\MFC - 2018 Workflow");
                System.Diagnostics.Process.Start("\\\\inmum-i-fs5\\group$\\Global Corporate & Data Strategy\\Data Reference\\PROCESS - MI\\DRD Reports\\Self Service Portal");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void searchtool_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 obj_form7 = new Form7();
            obj_form7.Show();
        }

        private void reports_MouseHover(object sender, EventArgs e)
        {
            workqueue_kyc.Visible = false;
            workqueue_qualityandapprovals.Visible = false;
            workflow.Visible = false;
            incidentrca.Visible = false;
            randomizer_kyc.Visible = false;
            randomizer_qualityandapprovals.Visible = false;
            qsptracker.Visible = false;
            processmanuals.Visible = false;
            errortracker.Visible = false;
            searchtool.Visible = false;
            searchtool_datamart.Visible = false;
            smsosearchtool.Visible = false;
            raisedispute.Visible = false;
            batch_oms_bulk_upload.Visible = false;
            
            qualityselfservice.Visible = true;
            //if (adminlevel.Text == "Admin" || processname.Text == "Approvals")
            if(accesslevel.Text != "Read")
            {
                compediumoferrors.Enabled = true;
                compediumoferrors.Visible = true;
                audittrail.Visible = true;
                audittrail.Enabled = true;
                qualityreport_ssrs.Visible = true;
                qualityreport_ssrs.Enabled = true;
                qualityreport_powerbi.Visible = true;
                qualityreport_powerbi.Enabled = true;
                //qualityreport_qualityandapprovals.Visible = true;
                //qualityreport_qualityandapprovals.Enabled = true;
                productivityreport.Visible = true;
                productivityreport.Enabled = true;
                kpiscorecard.Visible = true;
                kpiscorecard.Enabled = true;
            }
            //else if (adminlevel.Text == "Associate" && processname.Text != "Approvals")
            else if(accesslevel.Text == "Read")
            {
                compediumoferrors.Enabled = false;
                compediumoferrors.Visible = true;
                audittrail.Visible = true;
                audittrail.Enabled = false;
                qualityreport_ssrs.Visible = true;
                qualityreport_ssrs.Enabled = false;
                qualityreport_powerbi.Visible = true;
                qualityreport_powerbi.Enabled = false;
                //qualityreport_qualityandapprovals.Visible = true;
                //qualityreport_qualityandapprovals.Enabled = false;
                productivityreport.Visible = true;
                productivityreport.Enabled = false;
                qualityreport_audit.Visible = true;
                qualityreport_audit.Enabled = false;
                kpiscorecard.Visible = true;
                kpiscorecard.Enabled = false;
            }
            else
            {
                compediumoferrors.Enabled = false;
                compediumoferrors.Visible = true;
                audittrail.Visible = true;
                audittrail.Enabled = false;
                qualityreport_ssrs.Visible = true;
                qualityreport_ssrs.Enabled = false;
                qualityreport_powerbi.Visible = true;
                qualityreport_powerbi.Enabled = false;
                //qualityreport_qualityandapprovals.Visible = true;
                //qualityreport_qualityandapprovals.Enabled = false;
                productivityreport.Visible = true;
                productivityreport.Enabled = false;
                qualityreport_audit.Visible = true;
                qualityreport_audit.Enabled = false;
                kpiscorecard.Visible = true;
                kpiscorecard.Enabled = false;
            }
            //condition only for quality report Q&A
            if (empname.Text == "Gautami Kamath" || empname.Text == "Hari Alwar" || empname.Text == "Rinkesh Parikh")
            {
                qualityreport_qualityandapprovals.Visible = true;
                qualityreport_qualityandapprovals.Enabled = true;
                qualityreport_audit.Visible = true;
                qualityreport_audit.Enabled = true;
                kpiscorecard.Visible = true;
                kpiscorecard.Enabled = true;
            }
            else
            {
                qualityreport_qualityandapprovals.Visible = true;
                qualityreport_qualityandapprovals.Enabled = false;
                qualityreport_audit.Visible = true;
                qualityreport_audit.Enabled = false;
                kpiscorecard.Visible = true;
                kpiscorecard.Enabled = true;
            }
        }

        private void compediumoferrors_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Approvals_QualityParamters_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void audittrail_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Approvals_QualityParameters_AuditTrial_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void qualityreport_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Approvals_QualityDashboard_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void productivityreport_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_ApprovalsProductivity_Daily_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void menubutton_MouseHover(object sender, EventArgs e)
        {
            qaworkqueue.Visible = true;
            qualitysupervisor.Visible = true;
            quicklinks.Visible = true;
            reports.Visible = true;
        }

        private void qaworkqueue_DragLeave(object sender, EventArgs e)
        {
            
        }

        private void qualitysupervisor_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void smsosearchtool_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 obj_form9 = new Form9();
            obj_form9.Show();
        }

        private void workqueue_qualityandapprovals_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 obj_form11 = new Form11();
            obj_form11.Show();
        }

        private void randomizer_qualityandapprovals_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 obj_form10 = new Form10();
            obj_form10.Show();
        }

        private void qaworkqueue_Click(object sender, EventArgs e)
        {

        }

        private void qualityreport_qualityandapprovals_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_QualitySamples_QualityandApprovals_dotnet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void reports_Click(object sender, EventArgs e)
        {

        }

        private void raisedispute_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 obj_form12 = new Form12();
            obj_form12.Show();   
        }

        private void qualityreport_audit_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Approvals_QualityDashboard_Audit_AssociateWise_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void quicklinks_Click(object sender, EventArgs e)
        {

        }

        private void batch_oms_bulk_upload_Click(object sender, EventArgs e)
        {
            this.Hide();
            Batch_OMS_Bulk_Upload obj_batch_oms = new Batch_OMS_Bulk_Upload();
            obj_batch_oms.Show();
        }

        private void kpiscorecard_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://app.powerbi.com/groups/81c3ab7d-0a2a-46f2-b54f-38eb239011a1/reports/c07ea03c-a52d-43e5-9a7b-a711c3cd15f1/ReportSection31a41de679b2bcefa277?experience=power-bi");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void qualityreport_powerbi_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://app.powerbi.com/groups/81c3ab7d-0a2a-46f2-b54f-38eb239011a1/reports/20155e5a-a6d3-46d7-8a52-cfe9bd664249/001340537de0d8b1d73c?experience=power-bi");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void searchtool_datamart_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchTool_New_DataMart obj_searchtool = new SearchTool_New_DataMart();
            obj_searchtool.Show();
        }
    }
}
