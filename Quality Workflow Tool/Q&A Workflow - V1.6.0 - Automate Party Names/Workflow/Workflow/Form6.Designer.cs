namespace Workflow
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtFinalStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtUpdatedBy_WorkQueueStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAgeingDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequestid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSourceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrincipleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMatchCriteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMatchCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDunsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequestSourceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReferenceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCompletionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtINTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUniqueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWorkQueueStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ageingdays = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.workqueuestatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.completionmonth_search = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.empname_search = new System.Windows.Forms.TextBox();
            this.partyname_search = new System.Windows.Forms.TextBox();
            this.requestid_search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageingdays)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.txtUpdatedBy_WorkQueueStatus,
            this.txtAgeingDays,
            this.txtRequestid,
            this.txtSourceType,
            this.txtEmpName,
            this.txtReceivedDate,
            this.txtPrincipleName,
            this.txtPartyName,
            this.txtMatchCriteria,
            this.txtMatchCategory,
            this.txtDunsNumber,
            this.txtRequestSourceName,
            this.txtReferenceId,
            this.txtCompletionDate,
            this.txtINTID,
            this.txtUniqueID,
            this.txtWorkQueueStatus,
            this.txtID});
            this.dataGridView1.Location = new System.Drawing.Point(18, 210);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1877, 826);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // txtFinalStatus
            // 
            this.txtFinalStatus.HeaderText = "FinalStatus";
            this.txtFinalStatus.Name = "txtFinalStatus";
            // 
            // txtUpdatedBy_WorkQueueStatus
            // 
            this.txtUpdatedBy_WorkQueueStatus.DataPropertyName = "UpdatedBy_WorkQueueStatus";
            this.txtUpdatedBy_WorkQueueStatus.HeaderText = "UpdatedBy_WorkQueueStatus";
            this.txtUpdatedBy_WorkQueueStatus.Name = "txtUpdatedBy_WorkQueueStatus";
            this.txtUpdatedBy_WorkQueueStatus.ReadOnly = true;
            // 
            // txtAgeingDays
            // 
            this.txtAgeingDays.DataPropertyName = "AgeingDays";
            this.txtAgeingDays.HeaderText = "AgeingDays";
            this.txtAgeingDays.Name = "txtAgeingDays";
            this.txtAgeingDays.ReadOnly = true;
            // 
            // txtRequestid
            // 
            this.txtRequestid.DataPropertyName = "Requestid";
            this.txtRequestid.HeaderText = "Requestid";
            this.txtRequestid.Name = "txtRequestid";
            this.txtRequestid.ReadOnly = true;
            // 
            // txtSourceType
            // 
            this.txtSourceType.DataPropertyName = "SourceType";
            this.txtSourceType.HeaderText = "SourceType";
            this.txtSourceType.Name = "txtSourceType";
            this.txtSourceType.ReadOnly = true;
            // 
            // txtEmpName
            // 
            this.txtEmpName.DataPropertyName = "EmpName";
            this.txtEmpName.HeaderText = "EmpName";
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            // 
            // txtReceivedDate
            // 
            this.txtReceivedDate.DataPropertyName = "ReceivedDate";
            this.txtReceivedDate.HeaderText = "ReceivedDate";
            this.txtReceivedDate.Name = "txtReceivedDate";
            this.txtReceivedDate.ReadOnly = true;
            // 
            // txtPrincipleName
            // 
            this.txtPrincipleName.DataPropertyName = "PrincipleName";
            this.txtPrincipleName.HeaderText = "PrincipleName";
            this.txtPrincipleName.Name = "txtPrincipleName";
            this.txtPrincipleName.ReadOnly = true;
            this.txtPrincipleName.Width = 150;
            // 
            // txtPartyName
            // 
            this.txtPartyName.DataPropertyName = "PartyName";
            this.txtPartyName.HeaderText = "PartyName";
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.ReadOnly = true;
            this.txtPartyName.Width = 150;
            // 
            // txtMatchCriteria
            // 
            this.txtMatchCriteria.DataPropertyName = "MatchCriteria";
            this.txtMatchCriteria.HeaderText = "MatchCriteria";
            this.txtMatchCriteria.Name = "txtMatchCriteria";
            this.txtMatchCriteria.ReadOnly = true;
            // 
            // txtMatchCategory
            // 
            this.txtMatchCategory.DataPropertyName = "MatchCategory";
            this.txtMatchCategory.HeaderText = "MatchCategory";
            this.txtMatchCategory.Name = "txtMatchCategory";
            this.txtMatchCategory.ReadOnly = true;
            // 
            // txtDunsNumber
            // 
            this.txtDunsNumber.DataPropertyName = "DunsNumber";
            this.txtDunsNumber.HeaderText = "DunsNumber";
            this.txtDunsNumber.Name = "txtDunsNumber";
            this.txtDunsNumber.ReadOnly = true;
            // 
            // txtRequestSourceName
            // 
            this.txtRequestSourceName.DataPropertyName = "RequestSourceName";
            this.txtRequestSourceName.HeaderText = "RequestSourceName";
            this.txtRequestSourceName.Name = "txtRequestSourceName";
            this.txtRequestSourceName.ReadOnly = true;
            // 
            // txtReferenceId
            // 
            this.txtReferenceId.DataPropertyName = "ReferenceId";
            this.txtReferenceId.HeaderText = "ReferenceId";
            this.txtReferenceId.Name = "txtReferenceId";
            this.txtReferenceId.ReadOnly = true;
            // 
            // txtCompletionDate
            // 
            this.txtCompletionDate.DataPropertyName = "CompletionDate";
            this.txtCompletionDate.HeaderText = "CompletionDate";
            this.txtCompletionDate.Name = "txtCompletionDate";
            this.txtCompletionDate.ReadOnly = true;
            // 
            // txtINTID
            // 
            this.txtINTID.DataPropertyName = "INTID";
            this.txtINTID.HeaderText = "INTID";
            this.txtINTID.Name = "txtINTID";
            this.txtINTID.ReadOnly = true;
            // 
            // txtUniqueID
            // 
            this.txtUniqueID.DataPropertyName = "UniqueID";
            this.txtUniqueID.HeaderText = "UniqueID";
            this.txtUniqueID.Name = "txtUniqueID";
            this.txtUniqueID.ReadOnly = true;
            // 
            // txtWorkQueueStatus
            // 
            this.txtWorkQueueStatus.DataPropertyName = "WorkQueueStatus";
            this.txtWorkQueueStatus.HeaderText = "WorkQueueStatus";
            this.txtWorkQueueStatus.Name = "txtWorkQueueStatus";
            this.txtWorkQueueStatus.ReadOnly = true;
            this.txtWorkQueueStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtWorkQueueStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtID
            // 
            this.txtID.DataPropertyName = "ID";
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Purple;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(18, 18);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 35);
            this.button2.TabIndex = 69;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.groupBox1.Controls.Add(this.empname_search);
            this.groupBox1.Controls.Add(this.partyname_search);
            this.groupBox1.Controls.Add(this.requestid_search);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.workqueuestatus);
            this.groupBox1.Controls.Add(this.ageingdays);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(186, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1628, 154);
            this.groupBox1.TabIndex = 77;
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
            this.completionmonth_search.ValueChanged += new System.EventHandler(this.completionmonth_ValueChanged);
            this.completionmonth_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.completionmonth_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(988, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 83;
            this.label6.Text = "Emp Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(772, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 82;
            this.label5.Text = "Party Name";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(559, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 81;
            this.label4.Text = "Request ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 80;
            // 
            // empname_search
            // 
            this.empname_search.Location = new System.Drawing.Point(945, 29);
            this.empname_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.empname_search.Name = "empname_search";
            this.empname_search.Size = new System.Drawing.Size(184, 26);
            this.empname_search.TabIndex = 79;
            this.empname_search.TextChanged += new System.EventHandler(this.empname_search_TextChanged);
            // 
            // partyname_search
            // 
            this.partyname_search.Location = new System.Drawing.Point(717, 29);
            this.partyname_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.partyname_search.Name = "partyname_search";
            this.partyname_search.Size = new System.Drawing.Size(205, 26);
            this.partyname_search.TabIndex = 78;
            this.partyname_search.TextChanged += new System.EventHandler(this.partyname_search_TextChanged);
            // 
            // requestid_search
            // 
            this.requestid_search.Location = new System.Drawing.Point(534, 29);
            this.requestid_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.requestid_search.Name = "requestid_search";
            this.requestid_search.Size = new System.Drawing.Size(145, 26);
            this.requestid_search.TabIndex = 77;
            this.requestid_search.TextChanged += new System.EventHandler(this.requestid_search_TextChanged);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form6";
            this.Text = "Work Queue - KYC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageingdays)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown ageingdays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox workqueuestatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn txtFinalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUpdatedBy_WorkQueueStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAgeingDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestid;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSourceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReceivedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPrincipleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMatchCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMatchCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDunsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestSourceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReferenceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCompletionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtINTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUniqueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWorkQueueStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox empname_search;
        private System.Windows.Forms.TextBox partyname_search;
        private System.Windows.Forms.TextBox requestid_search;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker completionmonth_search;
    }
}