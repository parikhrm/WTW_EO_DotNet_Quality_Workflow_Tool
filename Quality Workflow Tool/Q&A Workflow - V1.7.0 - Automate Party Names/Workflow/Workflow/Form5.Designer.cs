namespace Workflow
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.txtUniqueID});
            this.dataGridView1.Location = new System.Drawing.Point(38, 101);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1842, 920);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.MouseHover += new System.EventHandler(this.dataGridView1_MouseHover);
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
            // 
            // txtPartyName
            // 
            this.txtPartyName.DataPropertyName = "PartyName";
            this.txtPartyName.HeaderText = "PartyName";
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.ReadOnly = true;
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Purple;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(38, 18);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 35);
            this.button2.TabIndex = 68;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 75);
            this.button1.TabIndex = 69;
            this.button1.Text = "Run Randomizer\r\n(Associate Wise)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(545, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 75);
            this.button3.TabIndex = 70;
            this.button3.Text = "Export to Work Queue";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(374, 14);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 75);
            this.button4.TabIndex = 71;
            this.button4.Text = "Run Randomizer\r\n(Region Wise)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form5";
            this.Text = "Randomizer KYC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form5_Load);
            this.MouseHover += new System.EventHandler(this.Form5_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
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
        private System.Windows.Forms.Button button4;
    }
}