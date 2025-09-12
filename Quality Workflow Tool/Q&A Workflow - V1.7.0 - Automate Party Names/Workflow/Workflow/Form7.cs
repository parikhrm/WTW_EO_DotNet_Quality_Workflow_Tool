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
    public partial class Form7 : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";

        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            reset_overall();
        }

        public void reset_overall()
        {
            datagridview1_display_overall();
        }

        public void datagridview1_display_overall()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            conn.Open();
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            cmd.CommandText = "select top 100 RequestID,ProcessType,DRDProcess,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipleType,PrincipalName,PartyName,Category,RiskID,BatchID,PartyLocation,RiskCategory,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where ProcessType not like '%qc%' and isdeleted = 0 ";
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public void datagridview1_display_riskid()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            conn.Open();
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            cmd.CommandText = "select RequestID,ProcessType,DRDProcess,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipleType,PrincipalName,PartyName,Category,RiskID,BatchID,PartyLocation,RiskCategory,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where riskid like @riskidparam and ProcessType not like '%qc%' and isdeleted = 0";
            cmd.Parameters.AddWithValue("@riskidparam","%" + riskid.Text + "%");
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public void datagridview1_display_pf_gcid()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            conn.Open();
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            cmd.CommandText = "select RequestID,ProcessType,DRDProcess,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipleType,PrincipalName,PartyName,Category,RiskID,BatchID,PartyLocation,RiskCategory,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where pf_gcid like @pf_gcid and ProcessType not like '%qc%' and isdeleted = 0";
            cmd.Parameters.AddWithValue("pf_gcid", "%" + pf_gcid.Text + "%");
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public void datagridview1_display_principlename()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            conn.Open();
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            cmd.CommandText = "select RequestID,ProcessType,DRDProcess,ApprovalTeam,ReceivedDate,ReceivedTime,CompletionDate,CompletionTime,AssociateName,RequestorBusinessUnit,PrincipleType,PrincipalName,PartyName,Category,RiskID,BatchID,PartyLocation,RiskCategory,EntityID,PF_GCID from dbo.tbl_approvals_daily_dotnet with(nolock) where PrincipalName like @principlenameparam and ProcessType not like '%qc%' and isdeleted = 0";
            cmd.Parameters.AddWithValue("@principlenameparam", "%" + principlename.Text + "%");
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void riskid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(riskid.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_riskid();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(principlename.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_principlename();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pf_gcid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(riskid.Text))
            {
                datagridview1_display_overall();
            }
            else
            {
                datagridview1_display_pf_gcid();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
