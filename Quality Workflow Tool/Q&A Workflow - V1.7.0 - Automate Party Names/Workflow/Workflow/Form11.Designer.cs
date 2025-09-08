namespace Workflow
{
    partial class Form11
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtFinalStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProcessType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtApprovalTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCompletionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAssociateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequestorBusinessUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrincipalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBreaches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTypeofBreaches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTypeofError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDRDProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQualityParameters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrincipleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRiskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUploadDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUploadedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWorkQueueStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.completionmonth_search = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.approvalteam_search = new System.Windows.Forms.TextBox();
            this.batchid_search = new System.Windows.Forms.TextBox();
            this.riskid_search = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.workqueuestatus = new System.Windows.Forms.ComboBox();
            this.ageingdays = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageingdays)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Purple;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(9, 19);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 35);
            this.button2.TabIndex = 70;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtFinalStatus,
            this.txtRequestID,
            this.txtProcessType,
            this.txtApprovalTeam,
            this.txtReceivedDate,
            this.txtCompletionDate,
            this.txtAssociateName,
            this.txtRequestorBusinessUnit,
            this.txtPrincipalName,
            this.txtPartyName,
            this.txtCategory,
            this.txtBreaches,
            this.txtTypeofBreaches,
            this.txtTypeofError,
            this.txtDRDProcess,
            this.txtQualityParameters,
            this.txtPrincipleType,
            this.txtRiskID,
            this.txtBatchID,
            this.txtUploadDate,
            this.txtUploadedBy,
            this.txtWorkQueueStatus,
            this.txtID});
            this.dataGridView1.Location = new System.Drawing.Point(12, 171);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1883, 841);
            this.dataGridView1.TabIndex = 71;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // txtFinalStatus
            // 
            this.txtFinalStatus.HeaderText = "FinalStatus";
            this.txtFinalStatus.Name = "txtFinalStatus";
            this.txtFinalStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtFinalStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtRequestID
            // 
            this.txtRequestID.DataPropertyName = "RequestID";
            this.txtRequestID.HeaderText = "RequestID";
            this.txtRequestID.Name = "txtRequestID";
            // 
            // txtProcessType
            // 
            this.txtProcessType.DataPropertyName = "ProcessType";
            this.txtProcessType.HeaderText = "ProcessType";
            this.txtProcessType.Name = "txtProcessType";
            // 
            // txtApprovalTeam
            // 
            this.txtApprovalTeam.DataPropertyName = "ApprovalTeam";
            this.txtApprovalTeam.HeaderText = "ApprovalTeam";
            this.txtApprovalTeam.Name = "txtApprovalTeam";
            // 
            // txtReceivedDate
            // 
            this.txtReceivedDate.DataPropertyName = "ReceivedDate";
            this.txtReceivedDate.HeaderText = "ReceivedDate";
            this.txtReceivedDate.Name = "txtReceivedDate";
            // 
            // txtCompletionDate
            // 
            this.txtCompletionDate.DataPropertyName = "CompletionDate";
            this.txtCompletionDate.HeaderText = "CompletionDate";
            this.txtCompletionDate.Name = "txtCompletionDate";
            // 
            // txtAssociateName
            // 
            this.txtAssociateName.DataPropertyName = "AssociateName";
            this.txtAssociateName.HeaderText = "AssociateName";
            this.txtAssociateName.Name = "txtAssociateName";
            // 
            // txtRequestorBusinessUnit
            // 
            this.txtRequestorBusinessUnit.DataPropertyName = "RequestorBusinessUnit";
            this.txtRequestorBusinessUnit.HeaderText = "RequestorBusinessUnit";
            this.txtRequestorBusinessUnit.Name = "txtRequestorBusinessUnit";
            // 
            // txtPrincipalName
            // 
            this.txtPrincipalName.DataPropertyName = "PrincipalName";
            this.txtPrincipalName.HeaderText = "PrincipalName";
            this.txtPrincipalName.Name = "txtPrincipalName";
            // 
            // txtPartyName
            // 
            this.txtPartyName.DataPropertyName = "PartyName";
            this.txtPartyName.HeaderText = "PartyName";
            this.txtPartyName.Name = "txtPartyName";
            // 
            // txtCategory
            // 
            this.txtCategory.DataPropertyName = "Category";
            this.txtCategory.HeaderText = "Category";
            this.txtCategory.Name = "txtCategory";
            // 
            // txtBreaches
            // 
            this.txtBreaches.DataPropertyName = "Breaches";
            this.txtBreaches.HeaderText = "Breaches";
            this.txtBreaches.Name = "txtBreaches";
            // 
            // txtTypeofBreaches
            // 
            this.txtTypeofBreaches.DataPropertyName = "TypeofBreaches";
            this.txtTypeofBreaches.HeaderText = "TypeofBreaches";
            this.txtTypeofBreaches.Name = "txtTypeofBreaches";
            // 
            // txtTypeofError
            // 
            this.txtTypeofError.DataPropertyName = "TypeofError";
            this.txtTypeofError.HeaderText = "TypeofError";
            this.txtTypeofError.Name = "txtTypeofError";
            // 
            // txtDRDProcess
            // 
            this.txtDRDProcess.DataPropertyName = "DRDProcess";
            this.txtDRDProcess.HeaderText = "DRDProcess";
            this.txtDRDProcess.Name = "txtDRDProcess";
            // 
            // txtQualityParameters
            // 
            this.txtQualityParameters.DataPropertyName = "QualityParameters";
            this.txtQualityParameters.HeaderText = "QualityParameters";
            this.txtQualityParameters.Name = "txtQualityParameters";
            // 
            // txtPrincipleType
            // 
            this.txtPrincipleType.DataPropertyName = "PrincipleType";
            this.txtPrincipleType.HeaderText = "PrincipleType";
            this.txtPrincipleType.Name = "txtPrincipleType";
            // 
            // txtRiskID
            // 
            this.txtRiskID.DataPropertyName = "RiskID";
            this.txtRiskID.HeaderText = "RiskID";
            this.txtRiskID.Name = "txtRiskID";
            // 
            // txtBatchID
            // 
            this.txtBatchID.DataPropertyName = "BatchID";
            this.txtBatchID.HeaderText = "BatchID";
            this.txtBatchID.Name = "txtBatchID";
            // 
            // txtUploadDate
            // 
            this.txtUploadDate.DataPropertyName = "UploadDate";
            this.txtUploadDate.HeaderText = "UploadDate";
            this.txtUploadDate.Name = "txtUploadDate";
            // 
            // txtUploadedBy
            // 
            this.txtUploadedBy.DataPropertyName = "UploadedBy";
            this.txtUploadedBy.HeaderText = "UploadedBy";
            this.txtUploadedBy.Name = "txtUploadedBy";
            // 
            // txtWorkQueueStatus
            // 
            this.txtWorkQueueStatus.DataPropertyName = "WorkQueueStatus";
            this.txtWorkQueueStatus.HeaderText = "WorkQueueStatus";
            this.txtWorkQueueStatus.Name = "txtWorkQueueStatus";
            // 
            // txtID
            // 
            this.txtID.DataPropertyName = "ID";
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.completionmonth_search);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.approvalteam_search);
            this.groupBox1.Controls.Add(this.batchid_search);
            this.groupBox1.Controls.Add(this.riskid_search);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.workqueuestatus);
            this.groupBox1.Controls.Add(this.ageingdays);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(111, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1628, 154);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1181, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 85;
            this.label7.Text = "Completion Month";
            // 
            // completionmonth_search
            // 
            this.completionmonth_search.CustomFormat = " ";
            this.completionmonth_search.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.completionmonth_search.Location = new System.Drawing.Point(1154, 29);
            this.completionmonth_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.completionmonth_search.Name = "completionmonth_search";
            this.completionmonth_search.Size = new System.Drawing.Size(200, 26);
            this.completionmonth_search.TabIndex = 84;
            this.completionmonth_search.ValueChanged += new System.EventHandler(this.completionmonth_search_ValueChanged);
            this.completionmonth_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.completionmonth_search_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(988, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 83;
            this.label6.Text = "Approval Team";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(783, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 82;
            this.label5.Text = "Batch ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(577, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 81;
            this.label4.Text = "Risk ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 80;
            // 
            // approvalteam_search
            // 
            this.approvalteam_search.Location = new System.Drawing.Point(945, 29);
            this.approvalteam_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.approvalteam_search.Name = "approvalteam_search";
            this.approvalteam_search.Size = new System.Drawing.Size(184, 26);
            this.approvalteam_search.TabIndex = 79;
            this.approvalteam_search.TextChanged += new System.EventHandler(this.approvalteam_search_TextChanged);
            // 
            // batchid_search
            // 
            this.batchid_search.Location = new System.Drawing.Point(717, 29);
            this.batchid_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.batchid_search.Name = "batchid_search";
            this.batchid_search.Size = new System.Drawing.Size(205, 26);
            this.batchid_search.TabIndex = 78;
            this.batchid_search.TextChanged += new System.EventHandler(this.batchid_search_TextChanged);
            // 
            // riskid_search
            // 
            this.riskid_search.Location = new System.Drawing.Point(534, 29);
            this.riskid_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.riskid_search.Name = "riskid_search";
            this.riskid_search.Size = new System.Drawing.Size(145, 26);
            this.riskid_search.TabIndex = 77;
            this.riskid_search.TextChanged += new System.EventHandler(this.riskid_search_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(42, 29);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 54);
            this.button4.TabIndex = 76;
            this.button4.Text = "Refresh";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(1364, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 58);
            this.button1.TabIndex = 70;
            this.button1.Text = "Update Status - Complete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 75;
            this.label2.Text = "Work Queue Status";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkOrange;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1365, 88);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(255, 58);
            this.button3.TabIndex = 71;
            this.button3.Text = "Update Status - Pending";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // workqueuestatus
            // 
            this.workqueuestatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workqueuestatus.FormattingEnabled = true;
            this.workqueuestatus.Items.AddRange(new object[] {
            "Completed",
            "Pending"});
            this.workqueuestatus.Location = new System.Drawing.Point(330, 29);
            this.workqueuestatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workqueuestatus.Name = "workqueuestatus";
            this.workqueuestatus.Size = new System.Drawing.Size(180, 28);
            this.workqueuestatus.TabIndex = 74;
            this.workqueuestatus.SelectedIndexChanged += new System.EventHandler(this.workqueuestatus_SelectedIndexChanged);
            this.workqueuestatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.workqueuestatus_KeyDown);
            // 
            // ageingdays
            // 
            this.ageingdays.Location = new System.Drawing.Point(190, 29);
            this.ageingdays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ageingdays.Name = "ageingdays";
            this.ageingdays.Size = new System.Drawing.Size(100, 26);
            this.ageingdays.TabIndex = 72;
            this.ageingdays.ValueChanged += new System.EventHandler(this.ageingdays_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 73;
            this.label1.Text = "Ageing Days";
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form11";
            this.Text = "Work Queue - Quality and Approvals";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageingdays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker completionmonth_search;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox approvalteam_search;
        private System.Windows.Forms.TextBox batchid_search;
        private System.Windows.Forms.TextBox riskid_search;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox workqueuestatus;
        private System.Windows.Forms.NumericUpDown ageingdays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn txtFinalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProcessType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtApprovalTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReceivedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCompletionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAssociateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestorBusinessUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPrincipalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBreaches;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTypeofBreaches;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTypeofError;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDRDProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQualityParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPrincipleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRiskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUploadDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUploadedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWorkQueueStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
    }
}