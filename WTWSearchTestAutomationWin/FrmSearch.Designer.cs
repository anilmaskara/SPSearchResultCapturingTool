namespace WTWSearchTestAutomationWin
{
    partial class FrmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearch));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtoutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInputBrowse = new System.Windows.Forms.Button();
            this.btnOutputBrowse = new System.Windows.Forms.Button();
            this.txtinputfile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQueryTemplate = new System.Windows.Forms.TextBox();
            this.textQueryPath = new System.Windows.Forms.TextBox();
            this.lblRefinedBy = new System.Windows.Forms.Label();
            this.txtRefinedBy = new System.Windows.Forms.TextBox();
            this.lblRankingModel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkuseQueryRules = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSortBy = new System.Windows.Forms.TextBox();
            this.cmbsortdir = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtgroupBy = new System.Windows.Forms.TextBox();
            this.cmbResultSource = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRank = new System.Windows.Forms.ComboBox();
            this.cmbScope = new System.Windows.Forms.ComboBox();
            this.lblScope = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.openFileDialogInput = new System.Windows.Forms.OpenFileDialog();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.21244F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.78756F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.Controls.Add(this.txtoutput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnInputBrowse, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOutputBrowse, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtinputfile, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(48, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 97);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtoutput
            // 
            this.txtoutput.ForeColor = System.Drawing.Color.Purple;
            this.txtoutput.Location = new System.Drawing.Point(255, 48);
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.Size = new System.Drawing.Size(328, 26);
            this.txtoutput.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select  Output Folder*";
            // 
            // btnInputBrowse
            // 
            this.btnInputBrowse.ForeColor = System.Drawing.Color.Purple;
            this.btnInputBrowse.Location = new System.Drawing.Point(625, 6);
            this.btnInputBrowse.Name = "btnInputBrowse";
            this.btnInputBrowse.Size = new System.Drawing.Size(102, 33);
            this.btnInputBrowse.TabIndex = 2;
            this.btnInputBrowse.Text = "Browse";
            this.btnInputBrowse.UseVisualStyleBackColor = true;
            this.btnInputBrowse.Click += new System.EventHandler(this.btnInputBrowse_Click);
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.ForeColor = System.Drawing.Color.Purple;
            this.btnOutputBrowse.Location = new System.Drawing.Point(625, 48);
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Size = new System.Drawing.Size(102, 36);
            this.btnOutputBrowse.TabIndex = 3;
            this.btnOutputBrowse.Text = "Browse";
            this.btnOutputBrowse.UseVisualStyleBackColor = true;
            this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            // 
            // txtinputfile
            // 
            this.txtinputfile.ForeColor = System.Drawing.Color.Purple;
            this.txtinputfile.Location = new System.Drawing.Point(255, 6);
            this.txtinputfile.Name = "txtinputfile";
            this.txtinputfile.Size = new System.Drawing.Size(331, 26);
            this.txtinputfile.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Keyword File*";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5974F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.4026F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtQueryTemplate, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.textQueryPath, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblRefinedBy, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtRefinedBy, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblRankingModel, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.chkuseQueryRules, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSortBy, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbsortdir, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtgroupBy, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cmbResultSource, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.cmbRank, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.cmbScope, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblScope, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(49, 157);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.93893F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.06107F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(773, 495);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(6, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Query Text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Purple;
            this.label4.Location = new System.Drawing.Point(6, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Search Query Path";
            // 
            // txtQueryTemplate
            // 
            this.txtQueryTemplate.ForeColor = System.Drawing.Color.Purple;
            this.txtQueryTemplate.Location = new System.Drawing.Point(258, 205);
            this.txtQueryTemplate.Multiline = true;
            this.txtQueryTemplate.Name = "txtQueryTemplate";
            this.txtQueryTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQueryTemplate.Size = new System.Drawing.Size(411, 83);
            this.txtQueryTemplate.TabIndex = 5;
            // 
            // textQueryPath
            // 
            this.textQueryPath.ForeColor = System.Drawing.Color.Purple;
            this.textQueryPath.Location = new System.Drawing.Point(258, 297);
            this.textQueryPath.Name = "textQueryPath";
            this.textQueryPath.Size = new System.Drawing.Size(411, 26);
            this.textQueryPath.TabIndex = 6;
            // 
            // lblRefinedBy
            // 
            this.lblRefinedBy.AutoSize = true;
            this.lblRefinedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefinedBy.ForeColor = System.Drawing.Color.Purple;
            this.lblRefinedBy.Location = new System.Drawing.Point(6, 43);
            this.lblRefinedBy.Name = "lblRefinedBy";
            this.lblRefinedBy.Size = new System.Drawing.Size(106, 25);
            this.lblRefinedBy.TabIndex = 9;
            this.lblRefinedBy.Text = "Refined By";
            // 
            // txtRefinedBy
            // 
            this.txtRefinedBy.ForeColor = System.Drawing.Color.Purple;
            this.txtRefinedBy.Location = new System.Drawing.Point(258, 46);
            this.txtRefinedBy.Name = "txtRefinedBy";
            this.txtRefinedBy.Size = new System.Drawing.Size(411, 26);
            this.txtRefinedBy.TabIndex = 10;
            // 
            // lblRankingModel
            // 
            this.lblRankingModel.AutoSize = true;
            this.lblRankingModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRankingModel.ForeColor = System.Drawing.Color.Purple;
            this.lblRankingModel.Location = new System.Drawing.Point(6, 402);
            this.lblRankingModel.Name = "lblRankingModel";
            this.lblRankingModel.Size = new System.Drawing.Size(148, 50);
            this.lblRankingModel.TabIndex = 7;
            this.lblRankingModel.Text = "Select Ranking Model/Enter ID";
            // 
            // label7
            // 
            this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Purple;
            this.label7.Location = new System.Drawing.Point(6, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Use Query Rules?";
            // 
            // chkuseQueryRules
            // 
            this.chkuseQueryRules.AutoSize = true;
            this.chkuseQueryRules.Checked = true;
            this.chkuseQueryRules.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkuseQueryRules.ForeColor = System.Drawing.Color.Purple;
            this.chkuseQueryRules.Location = new System.Drawing.Point(258, 465);
            this.chkuseQueryRules.Name = "chkuseQueryRules";
            this.chkuseQueryRules.Size = new System.Drawing.Size(22, 21);
            this.chkuseQueryRules.TabIndex = 14;
            this.chkuseQueryRules.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Purple;
            this.label6.Location = new System.Drawing.Point(6, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Sort By";
            // 
            // txtSortBy
            // 
            this.txtSortBy.ForeColor = System.Drawing.Color.Purple;
            this.txtSortBy.Location = new System.Drawing.Point(258, 84);
            this.txtSortBy.Name = "txtSortBy";
            this.txtSortBy.Size = new System.Drawing.Size(411, 26);
            this.txtSortBy.TabIndex = 12;
            // 
            // cmbsortdir
            // 
            this.cmbsortdir.BackColor = System.Drawing.SystemColors.Window;
            this.cmbsortdir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsortdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbsortdir.ForeColor = System.Drawing.Color.Purple;
            this.cmbsortdir.FormattingEnabled = true;
            this.cmbsortdir.Items.AddRange(new object[] {
            "Select Order",
            "Descending",
            "Ascending"});
            this.cmbsortdir.Location = new System.Drawing.Point(258, 126);
            this.cmbsortdir.Name = "cmbsortdir";
            this.cmbsortdir.Size = new System.Drawing.Size(140, 28);
            this.cmbsortdir.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Purple;
            this.label8.Location = new System.Drawing.Point(6, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "Group By";
            // 
            // txtgroupBy
            // 
            this.txtgroupBy.ForeColor = System.Drawing.Color.Purple;
            this.txtgroupBy.Location = new System.Drawing.Point(258, 166);
            this.txtgroupBy.Name = "txtgroupBy";
            this.txtgroupBy.Size = new System.Drawing.Size(411, 26);
            this.txtgroupBy.TabIndex = 17;
            // 
            // cmbResultSource
            // 
            this.cmbResultSource.ForeColor = System.Drawing.Color.Purple;
            this.cmbResultSource.FormattingEnabled = true;
            this.cmbResultSource.Location = new System.Drawing.Point(258, 342);
            this.cmbResultSource.Name = "cmbResultSource";
            this.cmbResultSource.Size = new System.Drawing.Size(411, 28);
            this.cmbResultSource.TabIndex = 18;
            this.cmbResultSource.SelectedIndexChanged += new System.EventHandler(this.cmbResultSource_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Purple;
            this.label5.Location = new System.Drawing.Point(6, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 50);
            this.label5.TabIndex = 3;
            this.label5.Text = "Select Result Source/Enter Source ID";
            // 
            // cmbRank
            // 
            this.cmbRank.ForeColor = System.Drawing.Color.Purple;
            this.cmbRank.FormattingEnabled = true;
            this.cmbRank.Location = new System.Drawing.Point(258, 405);
            this.cmbRank.Name = "cmbRank";
            this.cmbRank.Size = new System.Drawing.Size(411, 28);
            this.cmbRank.TabIndex = 19;
            // 
            // cmbScope
            // 
            this.cmbScope.BackColor = System.Drawing.SystemColors.Window;
            this.cmbScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScope.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbScope.ForeColor = System.Drawing.Color.Purple;
            this.cmbScope.FormattingEnabled = true;
            this.cmbScope.Items.AddRange(new object[] {
            "Select Scope",
            "This Site",
            "Everything",
            "People"});
            this.cmbScope.Location = new System.Drawing.Point(258, 6);
            this.cmbScope.Name = "cmbScope";
            this.cmbScope.Size = new System.Drawing.Size(121, 28);
            this.cmbScope.TabIndex = 20;
            this.cmbScope.SelectedIndexChanged += new System.EventHandler(this.cmbScope_SelectedIndexChanged);
            // 
            // lblScope
            // 
            this.lblScope.AutoSize = true;
            this.lblScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScope.ForeColor = System.Drawing.Color.Purple;
            this.lblScope.Location = new System.Drawing.Point(6, 3);
            this.lblScope.Name = "lblScope";
            this.lblScope.Size = new System.Drawing.Size(129, 25);
            this.lblScope.TabIndex = 21;
            this.lblScope.Text = "Select Scope";
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.Purple;
            this.btnsearch.Location = new System.Drawing.Point(306, 655);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(207, 37);
            this.btnsearch.TabIndex = 2;
            this.btnsearch.Text = "Search and Export";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // openFileDialogInput
            // 
            this.openFileDialogInput.FileName = "openFileDialog1";
            this.openFileDialogInput.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogInput_FileOk);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Purple;
            this.btnLogout.Location = new System.Drawing.Point(665, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(156, 44);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.Purple;
            this.btnSettings.Location = new System.Drawing.Point(48, 5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(128, 43);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(199, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(460, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(834, 814);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSearch";
            this.Text = "Search";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSearch_FormClosed);
            this.Load += new System.EventHandler(this.FrmSearch_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQueryTemplate;
        private System.Windows.Forms.TextBox textQueryPath;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox txtoutput;
        private System.Windows.Forms.Button btnInputBrowse;
        private System.Windows.Forms.Button btnOutputBrowse;
        private System.Windows.Forms.TextBox txtinputfile;
        private System.Windows.Forms.OpenFileDialog openFileDialogInput;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblRankingModel;
        private System.Windows.Forms.Label lblRefinedBy;
        private System.Windows.Forms.TextBox txtRefinedBy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSortBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkuseQueryRules;
        private System.Windows.Forms.ComboBox cmbsortdir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtgroupBy;
        private System.Windows.Forms.ComboBox cmbResultSource;
        private System.Windows.Forms.ComboBox cmbRank;
        private System.Windows.Forms.ComboBox cmbScope;
        private System.Windows.Forms.Label lblScope;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}