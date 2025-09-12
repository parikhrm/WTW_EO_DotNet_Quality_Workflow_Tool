namespace Workflow
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtrequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtprocesstype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtapprovalteamname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtreceiveddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtreceivedtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcompletiondate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcompletiontime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtassociatename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtrequestorbusinessunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtprinciplename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtpartyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtprincipletype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtriskid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRiskCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEntityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.riskid = new System.Windows.Forms.TextBox();
            this.principlename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pf_gcid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.txtrequestID,
            this.txtprocesstype,
            this.txtapprovalteamname,
            this.txtreceiveddate,
            this.txtreceivedtime,
            this.txtcompletiondate,
            this.txtcompletiontime,
            this.txtassociatename,
            this.txtrequestorbusinessunit,
            this.txtprinciplename,
            this.txtpartyname,
            this.txtcategory,
            this.txtprincipletype,
            this.txtriskid,
            this.txtRiskCategory,
            this.txtEntityID});
            this.dataGridView1.Location = new System.Drawing.Point(45, 202);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1699, 811);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtrequestID
            // 
            this.txtrequestID.DataPropertyName = "RequestID";
            this.txtrequestID.HeaderText = "RequestID";
            this.txtrequestID.MinimumWidth = 8;
            this.txtrequestID.Name = "txtrequestID";
            this.txtrequestID.ReadOnly = true;
            this.txtrequestID.Width = 150;
            // 
            // txtprocesstype
            // 
            this.txtprocesstype.DataPropertyName = "ProcessType";
            this.txtprocesstype.HeaderText = "ProcessType";
            this.txtprocesstype.MinimumWidth = 8;
            this.txtprocesstype.Name = "txtprocesstype";
            this.txtprocesstype.ReadOnly = true;
            this.txtprocesstype.Width = 150;
            // 
            // txtapprovalteamname
            // 
            this.txtapprovalteamname.DataPropertyName = "ApprovalTeam";
            this.txtapprovalteamname.HeaderText = "ApprovalTeamName";
            this.txtapprovalteamname.MinimumWidth = 8;
            this.txtapprovalteamname.Name = "txtapprovalteamname";
            this.txtapprovalteamname.ReadOnly = true;
            this.txtapprovalteamname.Width = 150;
            // 
            // txtreceiveddate
            // 
            this.txtreceiveddate.DataPropertyName = "ReceivedDate";
            this.txtreceiveddate.HeaderText = "ReceivedDate";
            this.txtreceiveddate.MinimumWidth = 8;
            this.txtreceiveddate.Name = "txtreceiveddate";
            this.txtreceiveddate.ReadOnly = true;
            this.txtreceiveddate.Width = 150;
            // 
            // txtreceivedtime
            // 
            this.txtreceivedtime.DataPropertyName = "ReceivedTime";
            this.txtreceivedtime.HeaderText = "ReceivedTime";
            this.txtreceivedtime.MinimumWidth = 8;
            this.txtreceivedtime.Name = "txtreceivedtime";
            this.txtreceivedtime.ReadOnly = true;
            this.txtreceivedtime.Width = 150;
            // 
            // txtcompletiondate
            // 
            this.txtcompletiondate.DataPropertyName = "CompletionDate";
            this.txtcompletiondate.HeaderText = "CompletionDate";
            this.txtcompletiondate.MinimumWidth = 8;
            this.txtcompletiondate.Name = "txtcompletiondate";
            this.txtcompletiondate.ReadOnly = true;
            this.txtcompletiondate.Width = 150;
            // 
            // txtcompletiontime
            // 
            this.txtcompletiontime.DataPropertyName = "CompletionTime";
            this.txtcompletiontime.HeaderText = "CompletionTime";
            this.txtcompletiontime.MinimumWidth = 8;
            this.txtcompletiontime.Name = "txtcompletiontime";
            this.txtcompletiontime.ReadOnly = true;
            this.txtcompletiontime.Width = 150;
            // 
            // txtassociatename
            // 
            this.txtassociatename.DataPropertyName = "AssociateName";
            this.txtassociatename.HeaderText = "AssociateName";
            this.txtassociatename.MinimumWidth = 8;
            this.txtassociatename.Name = "txtassociatename";
            this.txtassociatename.ReadOnly = true;
            this.txtassociatename.Width = 150;
            // 
            // txtrequestorbusinessunit
            // 
            this.txtrequestorbusinessunit.DataPropertyName = "RequestorBusinessUnit";
            this.txtrequestorbusinessunit.HeaderText = "RequestorBusinessUnit";
            this.txtrequestorbusinessunit.MinimumWidth = 8;
            this.txtrequestorbusinessunit.Name = "txtrequestorbusinessunit";
            this.txtrequestorbusinessunit.ReadOnly = true;
            this.txtrequestorbusinessunit.Width = 150;
            // 
            // txtprinciplename
            // 
            this.txtprinciplename.DataPropertyName = "PrincipalName";
            this.txtprinciplename.HeaderText = "PrincipleName";
            this.txtprinciplename.MinimumWidth = 8;
            this.txtprinciplename.Name = "txtprinciplename";
            this.txtprinciplename.ReadOnly = true;
            this.txtprinciplename.Width = 150;
            // 
            // txtpartyname
            // 
            this.txtpartyname.DataPropertyName = "PartyName";
            this.txtpartyname.HeaderText = "PartyName";
            this.txtpartyname.MinimumWidth = 8;
            this.txtpartyname.Name = "txtpartyname";
            this.txtpartyname.ReadOnly = true;
            this.txtpartyname.Width = 150;
            // 
            // txtcategory
            // 
            this.txtcategory.DataPropertyName = "Category";
            this.txtcategory.HeaderText = "Category";
            this.txtcategory.MinimumWidth = 8;
            this.txtcategory.Name = "txtcategory";
            this.txtcategory.ReadOnly = true;
            this.txtcategory.Width = 150;
            // 
            // txtprincipletype
            // 
            this.txtprincipletype.DataPropertyName = "PrincipleType";
            this.txtprincipletype.HeaderText = "PrincipleType";
            this.txtprincipletype.MinimumWidth = 8;
            this.txtprincipletype.Name = "txtprincipletype";
            this.txtprincipletype.ReadOnly = true;
            this.txtprincipletype.Width = 150;
            // 
            // txtriskid
            // 
            this.txtriskid.DataPropertyName = "RiskID";
            this.txtriskid.HeaderText = "RiskID";
            this.txtriskid.MinimumWidth = 8;
            this.txtriskid.Name = "txtriskid";
            this.txtriskid.ReadOnly = true;
            this.txtriskid.Width = 150;
            // 
            // txtRiskCategory
            // 
            this.txtRiskCategory.DataPropertyName = "RiskCategory";
            this.txtRiskCategory.HeaderText = "RiskCategory";
            this.txtRiskCategory.MinimumWidth = 8;
            this.txtRiskCategory.Name = "txtRiskCategory";
            this.txtRiskCategory.ReadOnly = true;
            this.txtRiskCategory.Width = 150;
            // 
            // txtEntityID
            // 
            this.txtEntityID.DataPropertyName = "EntityID";
            this.txtEntityID.HeaderText = "EntityID";
            this.txtEntityID.MinimumWidth = 8;
            this.txtEntityID.Name = "txtEntityID";
            this.txtEntityID.ReadOnly = true;
            this.txtEntityID.Width = 150;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(45, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 66;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 67;
            this.label1.Text = "Risk ID";
            // 
            // riskid
            // 
            this.riskid.Location = new System.Drawing.Point(30, 46);
            this.riskid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.riskid.Name = "riskid";
            this.riskid.Size = new System.Drawing.Size(235, 26);
            this.riskid.TabIndex = 68;
            this.riskid.TextChanged += new System.EventHandler(this.riskid_TextChanged);
            // 
            // principlename
            // 
            this.principlename.Location = new System.Drawing.Point(296, 46);
            this.principlename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.principlename.Name = "principlename";
            this.principlename.Size = new System.Drawing.Size(250, 26);
            this.principlename.TabIndex = 69;
            this.principlename.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 70;
            this.label2.Text = "Principle Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pf_gcid);
            this.groupBox1.Controls.Add(this.riskid);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.principlename);
            this.groupBox1.Location = new System.Drawing.Point(306, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(923, 154);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pf_gcid
            // 
            this.pf_gcid.Location = new System.Drawing.Point(566, 46);
            this.pf_gcid.Name = "pf_gcid";
            this.pf_gcid.Size = new System.Drawing.Size(228, 26);
            this.pf_gcid.TabIndex = 71;
            this.pf_gcid.TextChanged += new System.EventHandler(this.pf_gcid_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(621, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 72;
            this.label3.Text = "PF - GCID";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form7";
            this.Text = "Search Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox riskid;
        private System.Windows.Forms.TextBox principlename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtrequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtprocesstype;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtapprovalteamname;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtreceiveddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtreceivedtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcompletiondate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcompletiontime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtassociatename;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtrequestorbusinessunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtprinciplename;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtpartyname;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtprincipletype;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtriskid;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRiskCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEntityID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pf_gcid;
    }
}