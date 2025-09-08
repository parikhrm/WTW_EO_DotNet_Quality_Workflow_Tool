namespace Workflow
{
    partial class Form12
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.requestid = new System.Windows.Forms.TextBox();
            this.comments_reportingmanager = new System.Windows.Forms.TextBox();
            this.comments_final = new System.Windows.Forms.TextBox();
            this.status_reportingmanager = new System.Windows.Forms.ComboBox();
            this.status_final = new System.Windows.Forms.ComboBox();
            this.insert = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtComments_ReportingManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStatus_ReportingManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtComments_Final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStatus_Final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.searchby_requestid = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Request ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comments\r\nReporting Manager";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status\r\nReporting Manager";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Comments Final";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status Final";
            // 
            // requestid
            // 
            this.requestid.Location = new System.Drawing.Point(201, 32);
            this.requestid.Name = "requestid";
            this.requestid.Size = new System.Drawing.Size(100, 26);
            this.requestid.TabIndex = 1;
            // 
            // comments_reportingmanager
            // 
            this.comments_reportingmanager.Location = new System.Drawing.Point(201, 102);
            this.comments_reportingmanager.Multiline = true;
            this.comments_reportingmanager.Name = "comments_reportingmanager";
            this.comments_reportingmanager.Size = new System.Drawing.Size(496, 58);
            this.comments_reportingmanager.TabIndex = 3;
            // 
            // comments_final
            // 
            this.comments_final.Location = new System.Drawing.Point(201, 293);
            this.comments_final.Multiline = true;
            this.comments_final.Name = "comments_final";
            this.comments_final.Size = new System.Drawing.Size(496, 58);
            this.comments_final.TabIndex = 7;
            // 
            // status_reportingmanager
            // 
            this.status_reportingmanager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status_reportingmanager.FormattingEnabled = true;
            this.status_reportingmanager.Location = new System.Drawing.Point(201, 200);
            this.status_reportingmanager.Name = "status_reportingmanager";
            this.status_reportingmanager.Size = new System.Drawing.Size(236, 28);
            this.status_reportingmanager.TabIndex = 5;
            // 
            // status_final
            // 
            this.status_final.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status_final.FormattingEnabled = true;
            this.status_final.Location = new System.Drawing.Point(201, 407);
            this.status_final.Name = "status_final";
            this.status_final.Size = new System.Drawing.Size(236, 28);
            this.status_final.TabIndex = 9;
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(72, 511);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(128, 47);
            this.insert.TabIndex = 10;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(232, 511);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(128, 47);
            this.update.TabIndex = 11;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(392, 511);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(128, 47);
            this.reset.TabIndex = 12;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.reset);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.insert);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.status_final);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.status_reportingmanager);
            this.groupBox1.Controls.Add(this.requestid);
            this.groupBox1.Controls.Add(this.comments_final);
            this.groupBox1.Controls.Add(this.comments_reportingmanager);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 658);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtRequestID,
            this.txtComments_ReportingManager,
            this.txtStatus_ReportingManager,
            this.txtComments_Final,
            this.txtStatus_Final});
            this.dataGridView1.Location = new System.Drawing.Point(794, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(924, 554);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtRequestID
            // 
            this.txtRequestID.HeaderText = "RequestID";
            this.txtRequestID.Name = "txtRequestID";
            this.txtRequestID.ReadOnly = true;
            // 
            // txtComments_ReportingManager
            // 
            this.txtComments_ReportingManager.HeaderText = "Comments_ReportingManager";
            this.txtComments_ReportingManager.Name = "txtComments_ReportingManager";
            this.txtComments_ReportingManager.ReadOnly = true;
            // 
            // txtStatus_ReportingManager
            // 
            this.txtStatus_ReportingManager.HeaderText = "Status_ReportingManager";
            this.txtStatus_ReportingManager.Name = "txtStatus_ReportingManager";
            this.txtStatus_ReportingManager.ReadOnly = true;
            // 
            // txtComments_Final
            // 
            this.txtComments_Final.HeaderText = "Comments_Final";
            this.txtComments_Final.Name = "txtComments_Final";
            this.txtComments_Final.ReadOnly = true;
            // 
            // txtStatus_Final
            // 
            this.txtStatus_Final.HeaderText = "Status_Final";
            this.txtStatus_Final.Name = "txtStatus_Final";
            this.txtStatus_Final.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(13, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 66;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(952, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 20);
            this.label6.TabIndex = 67;
            this.label6.Text = "Search by Request ID";
            // 
            // searchby_requestid
            // 
            this.searchby_requestid.Location = new System.Drawing.Point(917, 53);
            this.searchby_requestid.Name = "searchby_requestid";
            this.searchby_requestid.Size = new System.Drawing.Size(240, 26);
            this.searchby_requestid.TabIndex = 68;
            this.searchby_requestid.TextChanged += new System.EventHandler(this.searchby_requestid_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(794, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 56);
            this.button2.TabIndex = 69;
            this.button2.Text = "Export to Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1756, 737);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.searchby_requestid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form12";
            this.Text = "Raise Dispute";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form12_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox requestid;
        private System.Windows.Forms.TextBox comments_reportingmanager;
        private System.Windows.Forms.TextBox comments_final;
        private System.Windows.Forms.ComboBox status_reportingmanager;
        private System.Windows.Forms.ComboBox status_final;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtComments_ReportingManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStatus_ReportingManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtComments_Final;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStatus_Final;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox searchby_requestid;
        private System.Windows.Forms.Button button2;
    }
}