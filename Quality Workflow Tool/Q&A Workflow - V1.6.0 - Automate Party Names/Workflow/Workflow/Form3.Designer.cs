namespace Workflow
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label3 = new System.Windows.Forms.Label();
            this.completionmonth = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtAcknowledge = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQualityCheckerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtErrorDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAssociateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrincipalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTypeofError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNoofCriticalErrors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNoofMinorErrors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBreaches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTypeofBreaches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAcknowledged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQualityParameters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.raise_for_dispute = new System.Windows.Forms.Button();
            this.searchbyassociatename = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(418, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Search by Associate Name";
            // 
            // completionmonth
            // 
            this.completionmonth.CalendarTitleBackColor = System.Drawing.Color.Purple;
            this.completionmonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.completionmonth.Location = new System.Drawing.Point(140, 31);
            this.completionmonth.Name = "completionmonth";
            this.completionmonth.Size = new System.Drawing.Size(200, 26);
            this.completionmonth.TabIndex = 10;
            this.completionmonth.ValueChanged += new System.EventHandler(this.completionmonth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Month";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(8, 29);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 58);
            this.button1.TabIndex = 8;
            this.button1.Text = "Export to Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.txtAcknowledge,
            this.txtRequestID,
            this.txtQualityCheckerName,
            this.txtErrorDate,
            this.txtAssociateName,
            this.txtPartyName,
            this.txtPrincipalName,
            this.txtTypeofError,
            this.txtNoofCriticalErrors,
            this.txtNoofMinorErrors,
            this.txtComments,
            this.txtBreaches,
            this.txtTypeofBreaches,
            this.txtAcknowledged,
            this.txtQualityParameters});
            this.dataGridView1.Location = new System.Drawing.Point(18, 198);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1829, 809);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // txtAcknowledge
            // 
            this.txtAcknowledge.HeaderText = "Acknowledge";
            this.txtAcknowledge.Name = "txtAcknowledge";
            this.txtAcknowledge.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtAcknowledge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtRequestID
            // 
            this.txtRequestID.DataPropertyName = "RequestID";
            this.txtRequestID.HeaderText = "RequestID";
            this.txtRequestID.Name = "txtRequestID";
            this.txtRequestID.ReadOnly = true;
            // 
            // txtQualityCheckerName
            // 
            this.txtQualityCheckerName.DataPropertyName = "QualityCheckerName\r\n";
            this.txtQualityCheckerName.HeaderText = "QualityCheckerName";
            this.txtQualityCheckerName.Name = "txtQualityCheckerName";
            this.txtQualityCheckerName.ReadOnly = true;
            // 
            // txtErrorDate
            // 
            this.txtErrorDate.DataPropertyName = "ErrorDate";
            this.txtErrorDate.HeaderText = "ErrorDate";
            this.txtErrorDate.Name = "txtErrorDate";
            this.txtErrorDate.ReadOnly = true;
            // 
            // txtAssociateName
            // 
            this.txtAssociateName.DataPropertyName = "AssociateName";
            this.txtAssociateName.HeaderText = "AssociateName";
            this.txtAssociateName.Name = "txtAssociateName";
            this.txtAssociateName.ReadOnly = true;
            // 
            // txtPartyName
            // 
            this.txtPartyName.DataPropertyName = "PartyName";
            this.txtPartyName.HeaderText = "PartyName";
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.ReadOnly = true;
            // 
            // txtPrincipalName
            // 
            this.txtPrincipalName.DataPropertyName = "PrincipalName";
            this.txtPrincipalName.HeaderText = "PrincipalName";
            this.txtPrincipalName.Name = "txtPrincipalName";
            this.txtPrincipalName.ReadOnly = true;
            // 
            // txtTypeofError
            // 
            this.txtTypeofError.DataPropertyName = "TypeofError";
            this.txtTypeofError.HeaderText = "TypeofError";
            this.txtTypeofError.Name = "txtTypeofError";
            this.txtTypeofError.ReadOnly = true;
            // 
            // txtNoofCriticalErrors
            // 
            this.txtNoofCriticalErrors.DataPropertyName = "NoofCriticalErrors";
            this.txtNoofCriticalErrors.HeaderText = "NoofCriticalErrors";
            this.txtNoofCriticalErrors.Name = "txtNoofCriticalErrors";
            this.txtNoofCriticalErrors.ReadOnly = true;
            // 
            // txtNoofMinorErrors
            // 
            this.txtNoofMinorErrors.DataPropertyName = "NoofMinorErrors";
            this.txtNoofMinorErrors.HeaderText = "NoofMinorErrors";
            this.txtNoofMinorErrors.Name = "txtNoofMinorErrors";
            this.txtNoofMinorErrors.ReadOnly = true;
            // 
            // txtComments
            // 
            this.txtComments.DataPropertyName = "Comments";
            this.txtComments.HeaderText = "Comments";
            this.txtComments.Name = "txtComments";
            this.txtComments.ReadOnly = true;
            // 
            // txtBreaches
            // 
            this.txtBreaches.DataPropertyName = "Breaches";
            this.txtBreaches.HeaderText = "Breaches";
            this.txtBreaches.Name = "txtBreaches";
            this.txtBreaches.ReadOnly = true;
            // 
            // txtTypeofBreaches
            // 
            this.txtTypeofBreaches.DataPropertyName = "TypeofBreaches";
            this.txtTypeofBreaches.HeaderText = "TypeofBreaches";
            this.txtTypeofBreaches.Name = "txtTypeofBreaches";
            this.txtTypeofBreaches.ReadOnly = true;
            // 
            // txtAcknowledged
            // 
            this.txtAcknowledged.DataPropertyName = "Acknowledged";
            this.txtAcknowledged.HeaderText = "Acknowledged";
            this.txtAcknowledged.Name = "txtAcknowledged";
            this.txtAcknowledged.Visible = false;
            // 
            // txtQualityParameters
            // 
            this.txtQualityParameters.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.txtQualityParameters.DataPropertyName = "QualityParameters";
            this.txtQualityParameters.HeaderText = "QualityParameters";
            this.txtQualityParameters.Name = "txtQualityParameters";
            this.txtQualityParameters.Width = 521;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1621, 17);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(278, 149);
            this.dataGridView2.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Purple;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(18, 17);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 35);
            this.button2.TabIndex = 66;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(706, 31);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 71);
            this.button3.TabIndex = 67;
            this.button3.Text = "Acknowledge";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.raise_for_dispute);
            this.groupBox1.Controls.Add(this.searchbyassociatename);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.completionmonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(120, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1034, 121);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            // 
            // raise_for_dispute
            // 
            this.raise_for_dispute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.raise_for_dispute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raise_for_dispute.Location = new System.Drawing.Point(866, 31);
            this.raise_for_dispute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.raise_for_dispute.Name = "raise_for_dispute";
            this.raise_for_dispute.Size = new System.Drawing.Size(152, 71);
            this.raise_for_dispute.TabIndex = 70;
            this.raise_for_dispute.Text = "Raise for Dispute";
            this.raise_for_dispute.UseVisualStyleBackColor = false;
            this.raise_for_dispute.Click += new System.EventHandler(this.raise_for_dispute_Click);
            // 
            // searchbyassociatename
            // 
            this.searchbyassociatename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchbyassociatename.FormattingEnabled = true;
            this.searchbyassociatename.Location = new System.Drawing.Point(374, 31);
            this.searchbyassociatename.Name = "searchbyassociatename";
            this.searchbyassociatename.Size = new System.Drawing.Size(298, 28);
            this.searchbyassociatename.TabIndex = 69;
            this.searchbyassociatename.SelectedIndexChanged += new System.EventHandler(this.searchbyassociatename_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form3";
            this.Text = "Self Service Error Report Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker completionmonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn txtAcknowledge;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQualityCheckerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtErrorDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAssociateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPrincipalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTypeofError;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNoofCriticalErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNoofMinorErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtComments;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBreaches;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTypeofBreaches;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAcknowledged;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQualityParameters;
        private System.Windows.Forms.ComboBox searchbyassociatename;
        private System.Windows.Forms.Button raise_for_dispute;
    }
}