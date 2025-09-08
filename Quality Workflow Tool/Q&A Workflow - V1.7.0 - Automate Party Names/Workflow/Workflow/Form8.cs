using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms.Integration;
using System.Windows.Forms.Design;


namespace Workflow
{
    public partial class Form8 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            Email_FromList obj_fromlist = new Email_FromList();
            Email_ToList obj_tolist = new Email_ToList();
            fromlist();
            tolist();
            //reset_overall();
        }

        public void reset_overall()
        {
            cc_names.Text = string.Empty;
            subject.Text = string.Empty;
            message.Text = string.Empty;
            requestid.Text = string.Empty;
            attachment_path.Text = string.Empty;
            fromlist();
            tolist();
        }

        public void fromlist()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Email_FromList obj_fromlist = new Email_FromList();
                DataTable dtaa = new DataTable();
                obj_fromlist.fromlist(dtaa);
                from_names.DataSource = dtaa;
                from_names.DisplayMember = "Names";
                conn.Close();
                from_names.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void tolist()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Email_ToList obj_tolist = new Email_ToList();
                DataTable dtaa = new DataTable();
                obj_tolist.tolist(dtaa);
                to_names.DataSource = dtaa;
                to_names.DisplayMember = "EmailAddress";
                conn.Close();
                to_names.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void sendmail_outlook()
        {
            try
            {
                Outlook.Application _app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                mail.SentOnBehalfOfName = from_names.Text;
                mail.To = to_names.Text;
                mail.CC = cc_names.Text;
                mail.Subject = subject.Text;
                mail.Body = message.Text;
                if (attachment_path.Text != string.Empty)
                {
                    mail.Attachments.Add(attachment_path.Text);
                }
                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                ((Outlook._MailItem)mail).Send();
                MessageBox.Show("Your message has been sent successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            sendmail_outlook();
            reset_overall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj_form1 = new Form1();
            obj_form1.Show();
        }

        public void oninfomessagegenerated(object sender, SqlInfoMessageEventArgs e)
        {
            message.Text = e.Message.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                //SqlDataAdapter sda = new SqlDataAdapter();
                subject.Text = string.Empty;
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_approvals_emailformat_subjectline_dotnet";
                cmd.Parameters.AddWithValue("@requestid", requestid.Text);
                cmd.Parameters.Add("@Subjectline", SqlDbType.NVarChar,3000);
                cmd.Parameters["@Subjectline"].Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteNonQuery();
                string subjectline = Convert.ToString(cmd.Parameters["@Subjectline"].Value.ToString());
                if (string.IsNullOrEmpty(subjectline))
                {
                    subject.Text = string.Empty;
                }
                else
                {
                    subject.Text = subjectline;
                }
                /////////////////////////////////////////////////
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                message.Text = string.Empty;
                SqlDataAdapter sda = new SqlDataAdapter();
                ////SqlDataReader sdr = new SqlDataReader();
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                conn.InfoMessage += oninfomessagegenerated;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "exec dbo.usp_approvals_emailformat_dotnet @requestid,@subjectline";
                cmd.Parameters.AddWithValue("@requestid",requestid.Text);
                cmd.Parameters.AddWithValue("@subjectline",subject.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.InfoMessage += oninfomessagegenerated;
                conn.Close();
                //sdr = cmd.ExecuteReader();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.attachment_path.Text = openFileDialog1.FileName;
            }
        }
    }
}
