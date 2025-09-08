namespace Workflow
{
    partial class Error_Dispute_Tracker
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lm_comments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.dispute_closure_date = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.insert = new System.Windows.Forms.Button();
            this.additional_comments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.final_dispute_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dispute_description = new System.Windows.Forms.TextBox();
            this.dispute_raised_date = new System.Windows.Forms.DateTimePicker();
            this.ia_qa_requestID = new System.Windows.Forms.TextBox();
            this.associate_access = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchby_ia_qa_requestid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.searchby_empname = new System.Windows.Forms.ComboBox();
            this.searchby_reportingmanagername = new System.Windows.Forms.ComboBox();
            this.txtIA_QA_RequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDispute_Raised_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDispute_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDispute_Closure_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFinal_Dispute_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLM_Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAdditional_Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLastUpdatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQC_Checker_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAssociateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtErrorMarkedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtKYC_WFT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQualityParameters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrincipalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTypeofError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "IA_QA \r\nRequestID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dispute Raised Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(786, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dispute Description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lm_comments);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.reset);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.dispute_closure_date);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.insert);
            this.groupBox1.Controls.Add(this.additional_comments);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.final_dispute_status);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dispute_description);
            this.groupBox1.Controls.Add(this.dispute_raised_date);
            this.groupBox1.Controls.Add(this.ia_qa_requestID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1460, 313);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lm_comments
            // 
            this.lm_comments.Location = new System.Drawing.Point(975, 131);
            this.lm_comments.Multiline = true;
            this.lm_comments.Name = "lm_comments";
            this.lm_comments.Size = new System.Drawing.Size(462, 76);
            this.lm_comments.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(786, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "LM Comments";
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(349, 240);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(125, 44);
            this.reset.TabIndex = 16;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(193, 240);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(125, 44);
            this.update.TabIndex = 15;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // dispute_closure_date
            // 
            this.dispute_closure_date.CustomFormat = " ";
            this.dispute_closure_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dispute_closure_date.Location = new System.Drawing.Point(154, 131);
            this.dispute_closure_date.Name = "dispute_closure_date";
            this.dispute_closure_date.Size = new System.Drawing.Size(238, 26);
            this.dispute_closure_date.TabIndex = 7;
            this.dispute_closure_date.ValueChanged += new System.EventHandler(this.dispute_closure_date_ValueChanged);
            this.dispute_closure_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dispute_closure_date_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 40);
            this.label6.TabIndex = 6;
            this.label6.Text = "Dispute Closure \r\nDate";
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(48, 240);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(125, 44);
            this.insert.TabIndex = 14;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // additional_comments
            // 
            this.additional_comments.Location = new System.Drawing.Point(975, 213);
            this.additional_comments.Multiline = true;
            this.additional_comments.Name = "additional_comments";
            this.additional_comments.Size = new System.Drawing.Size(462, 79);
            this.additional_comments.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(786, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 40);
            this.label5.TabIndex = 12;
            this.label5.Text = "Additional\r\nComments";
            // 
            // final_dispute_status
            // 
            this.final_dispute_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.final_dispute_status.FormattingEnabled = true;
            this.final_dispute_status.Items.AddRange(new object[] {
            "Overturned",
            "Upheld"});
            this.final_dispute_status.Location = new System.Drawing.Point(559, 129);
            this.final_dispute_status.Name = "final_dispute_status";
            this.final_dispute_status.Size = new System.Drawing.Size(209, 28);
            this.final_dispute_status.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 40);
            this.label4.TabIndex = 8;
            this.label4.Text = "Final Dispute\r\nStatus";
            // 
            // dispute_description
            // 
            this.dispute_description.Location = new System.Drawing.Point(975, 39);
            this.dispute_description.Multiline = true;
            this.dispute_description.Name = "dispute_description";
            this.dispute_description.Size = new System.Drawing.Size(462, 86);
            this.dispute_description.TabIndex = 5;
            // 
            // dispute_raised_date
            // 
            this.dispute_raised_date.CustomFormat = " ";
            this.dispute_raised_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dispute_raised_date.Location = new System.Drawing.Point(480, 39);
            this.dispute_raised_date.Name = "dispute_raised_date";
            this.dispute_raised_date.Size = new System.Drawing.Size(276, 26);
            this.dispute_raised_date.TabIndex = 3;
            this.dispute_raised_date.ValueChanged += new System.EventHandler(this.dispute_raised_date_ValueChanged);
            this.dispute_raised_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dispute_raised_date_KeyDown);
            // 
            // ia_qa_requestID
            // 
            this.ia_qa_requestID.Location = new System.Drawing.Point(130, 39);
            this.ia_qa_requestID.Name = "ia_qa_requestID";
            this.ia_qa_requestID.Size = new System.Drawing.Size(142, 26);
            this.ia_qa_requestID.TabIndex = 1;
            // 
            // associate_access
            // 
            this.associate_access.FormattingEnabled = true;
            this.associate_access.Location = new System.Drawing.Point(1351, 16);
            this.associate_access.Name = "associate_access";
            this.associate_access.Size = new System.Drawing.Size(121, 28);
            this.associate_access.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtIA_QA_RequestID,
            this.txtDispute_Raised_Date,
            this.txtDispute_Description,
            this.txtDispute_Closure_Date,
            this.txtFinal_Dispute_Status,
            this.txtLM_Comments,
            this.txtAdditional_Comments,
            this.txtLastUpdatedBy,
            this.txtLastUpdatedDateTime,
            this.txtQC_Checker_Name,
            this.txtAssociateName,
            this.txtErrorMarkedDate,
            this.txtKYC_WFT_ID,
            this.txtQualityParameters,
            this.txtPartyName,
            this.txtPrincipalName,
            this.txtTypeofError});
            this.dataGridView1.Location = new System.Drawing.Point(12, 440);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1699, 441);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // searchby_ia_qa_requestid
            // 
            this.searchby_ia_qa_requestid.Location = new System.Drawing.Point(187, 374);
            this.searchby_ia_qa_requestid.Name = "searchby_ia_qa_requestid";
            this.searchby_ia_qa_requestid.Size = new System.Drawing.Size(212, 26);
            this.searchby_ia_qa_requestid.TabIndex = 0;
            this.searchby_ia_qa_requestid.TextChanged += new System.EventHandler(this.searchby_ia_qa_requestid_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Search by IA QA Request ID";
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Purple;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Location = new System.Drawing.Point(13, 7);
            this.back.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(94, 35);
            this.back.TabIndex = 67;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 37);
            this.button1.TabIndex = 68;
            this.button1.Text = "Raw Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(746, 407);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 20);
            this.label9.TabIndex = 69;
            this.label9.Text = "Search by EmpName";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(430, 405);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(267, 20);
            this.label10.TabIndex = 70;
            this.label10.Text = "Search by Reporting Manager Name";
            // 
            // searchby_empname
            // 
            this.searchby_empname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchby_empname.FormattingEnabled = true;
            this.searchby_empname.Location = new System.Drawing.Point(718, 374);
            this.searchby_empname.Name = "searchby_empname";
            this.searchby_empname.Size = new System.Drawing.Size(237, 28);
            this.searchby_empname.TabIndex = 71;
            this.searchby_empname.SelectedIndexChanged += new System.EventHandler(this.searchby_empname_SelectedIndexChanged);
            // 
            // searchby_reportingmanagername
            // 
            this.searchby_reportingmanagername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchby_reportingmanagername.FormattingEnabled = true;
            this.searchby_reportingmanagername.Location = new System.Drawing.Point(424, 374);
            this.searchby_reportingmanagername.Name = "searchby_reportingmanagername";
            this.searchby_reportingmanagername.Size = new System.Drawing.Size(263, 28);
            this.searchby_reportingmanagername.TabIndex = 72;
            this.searchby_reportingmanagername.SelectedIndexChanged += new System.EventHandler(this.searchby_reportingmanagername_SelectedIndexChanged);
            // 
            // txtIA_QA_RequestID
            // 
            this.txtIA_QA_RequestID.DataPropertyName = "IA_QA_RequestID";
            this.txtIA_QA_RequestID.HeaderText = "IA_QA_RequestID";
            this.txtIA_QA_RequestID.Name = "txtIA_QA_RequestID";
            this.txtIA_QA_RequestID.ReadOnly = true;
            // 
            // txtDispute_Raised_Date
            // 
            this.txtDispute_Raised_Date.DataPropertyName = "Dispute_Raised_Date";
            this.txtDispute_Raised_Date.HeaderText = "Dispute_Raised_Date";
            this.txtDispute_Raised_Date.Name = "txtDispute_Raised_Date";
            this.txtDispute_Raised_Date.ReadOnly = true;
            // 
            // txtDispute_Description
            // 
            this.txtDispute_Description.DataPropertyName = "Dispute_Description";
            this.txtDispute_Description.HeaderText = "Dispute_Description";
            this.txtDispute_Description.Name = "txtDispute_Description";
            this.txtDispute_Description.ReadOnly = true;
            // 
            // txtDispute_Closure_Date
            // 
            this.txtDispute_Closure_Date.DataPropertyName = "Dispute_Closure_Date";
            this.txtDispute_Closure_Date.HeaderText = "Dispute_Closure_Date";
            this.txtDispute_Closure_Date.Name = "txtDispute_Closure_Date";
            this.txtDispute_Closure_Date.ReadOnly = true;
            // 
            // txtFinal_Dispute_Status
            // 
            this.txtFinal_Dispute_Status.DataPropertyName = "Final_Dispute_Status";
            this.txtFinal_Dispute_Status.HeaderText = "Final_Dispute_Status";
            this.txtFinal_Dispute_Status.Name = "txtFinal_Dispute_Status";
            this.txtFinal_Dispute_Status.ReadOnly = true;
            // 
            // txtLM_Comments
            // 
            this.txtLM_Comments.DataPropertyName = "LM_Comments";
            this.txtLM_Comments.HeaderText = "LM_Comments";
            this.txtLM_Comments.Name = "txtLM_Comments";
            this.txtLM_Comments.ReadOnly = true;
            this.txtLM_Comments.Width = 200;
            // 
            // txtAdditional_Comments
            // 
            this.txtAdditional_Comments.DataPropertyName = "Additional_Comments";
            this.txtAdditional_Comments.HeaderText = "Additional_Comments";
            this.txtAdditional_Comments.Name = "txtAdditional_Comments";
            this.txtAdditional_Comments.ReadOnly = true;
            this.txtAdditional_Comments.Width = 200;
            // 
            // txtLastUpdatedBy
            // 
            this.txtLastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.txtLastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.txtLastUpdatedBy.Name = "txtLastUpdatedBy";
            this.txtLastUpdatedBy.ReadOnly = true;
            // 
            // txtLastUpdatedDateTime
            // 
            this.txtLastUpdatedDateTime.DataPropertyName = "LastUpdatedDateTime";
            this.txtLastUpdatedDateTime.HeaderText = "LastUpdatedDateTime";
            this.txtLastUpdatedDateTime.Name = "txtLastUpdatedDateTime";
            this.txtLastUpdatedDateTime.ReadOnly = true;
            // 
            // txtQC_Checker_Name
            // 
            this.txtQC_Checker_Name.DataPropertyName = "QC_Checker_Name";
            this.txtQC_Checker_Name.HeaderText = "QC_Checker_Name";
            this.txtQC_Checker_Name.Name = "txtQC_Checker_Name";
            this.txtQC_Checker_Name.ReadOnly = true;
            // 
            // txtAssociateName
            // 
            this.txtAssociateName.DataPropertyName = "AssociateName";
            this.txtAssociateName.HeaderText = "AssociateName";
            this.txtAssociateName.Name = "txtAssociateName";
            this.txtAssociateName.ReadOnly = true;
            // 
            // txtErrorMarkedDate
            // 
            this.txtErrorMarkedDate.DataPropertyName = "ErrorMarkedDate";
            this.txtErrorMarkedDate.HeaderText = "ErrorMarkedDate";
            this.txtErrorMarkedDate.Name = "txtErrorMarkedDate";
            this.txtErrorMarkedDate.ReadOnly = true;
            // 
            // txtKYC_WFT_ID
            // 
            this.txtKYC_WFT_ID.DataPropertyName = "KYC_WFT_ID";
            this.txtKYC_WFT_ID.HeaderText = "KYC_WFT_ID";
            this.txtKYC_WFT_ID.Name = "txtKYC_WFT_ID";
            this.txtKYC_WFT_ID.ReadOnly = true;
            // 
            // txtQualityParameters
            // 
            this.txtQualityParameters.DataPropertyName = "QualityParameters";
            this.txtQualityParameters.HeaderText = "QualityParameters";
            this.txtQualityParameters.Name = "txtQualityParameters";
            this.txtQualityParameters.ReadOnly = true;
            this.txtQualityParameters.Width = 200;
            // 
            // txtPartyName
            // 
            this.txtPartyName.DataPropertyName = "PartyName";
            this.txtPartyName.HeaderText = "PartyName";
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.ReadOnly = true;
            this.txtPartyName.Width = 200;
            // 
            // txtPrincipalName
            // 
            this.txtPrincipalName.DataPropertyName = "PrincipalName";
            this.txtPrincipalName.HeaderText = "PrincipalName";
            this.txtPrincipalName.Name = "txtPrincipalName";
            this.txtPrincipalName.ReadOnly = true;
            this.txtPrincipalName.Width = 200;
            // 
            // txtTypeofError
            // 
            this.txtTypeofError.DataPropertyName = "TypeofError";
            this.txtTypeofError.HeaderText = "TypeofError";
            this.txtTypeofError.Name = "txtTypeofError";
            this.txtTypeofError.ReadOnly = true;
            // 
            // Error_Dispute_Tracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1723, 917);
            this.Controls.Add(this.searchby_reportingmanagername);
            this.Controls.Add(this.searchby_empname);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.searchby_ia_qa_requestid);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.associate_access);
            this.Controls.Add(this.groupBox1);
            this.Name = "Error_Dispute_Tracker";
            this.Text = "Error_Dispute_Tracker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Error_Dispute_Tracker_Load);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ia_qa_requestID;
        private System.Windows.Forms.DateTimePicker dispute_raised_date;
        private System.Windows.Forms.TextBox dispute_description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox final_dispute_status;
        private System.Windows.Forms.TextBox additional_comments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox associate_access;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.DateTimePicker dispute_closure_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox searchby_ia_qa_requestid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox lm_comments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox searchby_empname;
        private System.Windows.Forms.ComboBox searchby_reportingmanagername;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIA_QA_RequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDispute_Raised_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDispute_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDispute_Closure_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFinal_Dispute_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLM_Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAdditional_Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLastUpdatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQC_Checker_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAssociateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtErrorMarkedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtKYC_WFT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQualityParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPrincipalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTypeofError;
    }
}