namespace Finance
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlFinance = new System.Windows.Forms.TabControl();
            this.tabPageSymbols = new System.Windows.Forms.TabPage();
            this.lblSymbols = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridViewSymbols = new System.Windows.Forms.DataGridView();
            this.symbolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageWeb = new System.Windows.Forms.TabPage();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblCookies = new System.Windows.Forms.Label();
            this.btnAuthenticate = new System.Windows.Forms.Button();
            this.dtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtLTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlFinance.SuspendLayout();
            this.tabPageSymbols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSymbols)).BeginInit();
            this.tabPageWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlFinance
            // 
            this.tabControlFinance.Controls.Add(this.tabPageSymbols);
            this.tabControlFinance.Controls.Add(this.tabPageWeb);
            this.tabControlFinance.Location = new System.Drawing.Point(12, 12);
            this.tabControlFinance.Name = "tabControlFinance";
            this.tabControlFinance.SelectedIndex = 0;
            this.tabControlFinance.Size = new System.Drawing.Size(644, 341);
            this.tabControlFinance.TabIndex = 3;
            // 
            // tabPageSymbols
            // 
            this.tabPageSymbols.Controls.Add(this.lblSymbols);
            this.tabPageSymbols.Controls.Add(this.btnUpdate);
            this.tabPageSymbols.Controls.Add(this.dataGridViewSymbols);
            this.tabPageSymbols.Location = new System.Drawing.Point(4, 22);
            this.tabPageSymbols.Name = "tabPageSymbols";
            this.tabPageSymbols.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSymbols.Size = new System.Drawing.Size(636, 315);
            this.tabPageSymbols.TabIndex = 0;
            this.tabPageSymbols.Text = "Symbols";
            this.tabPageSymbols.UseVisualStyleBackColor = true;
            // 
            // lblSymbols
            // 
            this.lblSymbols.AutoSize = true;
            this.lblSymbols.Location = new System.Drawing.Point(200, 12);
            this.lblSymbols.Name = "lblSymbols";
            this.lblSymbols.Size = new System.Drawing.Size(131, 13);
            this.lblSymbols.TabIndex = 2;
            this.lblSymbols.Text = "Manage the list of symbols";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(202, 190);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dataGridViewSymbols
            // 
            this.dataGridViewSymbols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSymbols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.symbolName});
            this.dataGridViewSymbols.Location = new System.Drawing.Point(202, 34);
            this.dataGridViewSymbols.Name = "dataGridViewSymbols";
            this.dataGridViewSymbols.Size = new System.Drawing.Size(232, 150);
            this.dataGridViewSymbols.TabIndex = 0;
            // 
            // symbolName
            // 
            this.symbolName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.symbolName.DataPropertyName = "Name";
            this.symbolName.HeaderText = "Name";
            this.symbolName.Name = "symbolName";
            // 
            // tabPageWeb
            // 
            this.tabPageWeb.Controls.Add(this.txtPassword);
            this.tabPageWeb.Controls.Add(this.txtUsername);
            this.tabPageWeb.Controls.Add(this.lblPassword);
            this.tabPageWeb.Controls.Add(this.lblUsername);
            this.tabPageWeb.Controls.Add(this.btnRefresh);
            this.tabPageWeb.Controls.Add(this.dataGridViewData);
            this.tabPageWeb.Controls.Add(this.btnGetData);
            this.tabPageWeb.Controls.Add(this.lblCookies);
            this.tabPageWeb.Controls.Add(this.btnAuthenticate);
            this.tabPageWeb.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeb.Name = "tabPageWeb";
            this.tabPageWeb.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeb.Size = new System.Drawing.Size(636, 315);
            this.tabPageWeb.TabIndex = 1;
            this.tabPageWeb.Text = "Download";
            this.tabPageWeb.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(381, 53);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(168, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(381, 26);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(168, 20);
            this.txtUsername.TabIndex = 7;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(319, 56);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(312, 31);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 13);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "User Name:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(101, 51);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Stop";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.AllowUserToAddRows = false;
            this.dataGridViewData.AllowUserToDeleteRows = false;
            this.dataGridViewData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtName,
            this.dtDate,
            this.dtLTP,
            this.dtTime,
            this.dtVolume,
            this.dtAsk,
            this.dtBid,
            this.dtHigh,
            this.dtLow});
            this.dataGridViewData.Location = new System.Drawing.Point(6, 86);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.ReadOnly = true;
            this.dataGridViewData.RowHeadersVisible = false;
            this.dataGridViewData.Size = new System.Drawing.Size(624, 207);
            this.dataGridViewData.TabIndex = 3;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(20, 51);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 2;
            this.btnGetData.Text = "Start";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblCookies
            // 
            this.lblCookies.AutoSize = true;
            this.lblCookies.Location = new System.Drawing.Point(17, 296);
            this.lblCookies.Name = "lblCookies";
            this.lblCookies.Size = new System.Drawing.Size(93, 13);
            this.lblCookies.TabIndex = 1;
            this.lblCookies.Text = "Not Authenticated";
            // 
            // btnAuthenticate
            // 
            this.btnAuthenticate.Location = new System.Drawing.Point(555, 24);
            this.btnAuthenticate.Name = "btnAuthenticate";
            this.btnAuthenticate.Size = new System.Drawing.Size(75, 23);
            this.btnAuthenticate.TabIndex = 0;
            this.btnAuthenticate.Text = "Authenticate";
            this.btnAuthenticate.UseVisualStyleBackColor = true;
            this.btnAuthenticate.Click += new System.EventHandler(this.btnAuthenticate_Click);
            // 
            // dtName
            // 
            this.dtName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dtName.DataPropertyName = "Name";
            this.dtName.HeaderText = "Name";
            this.dtName.Name = "dtName";
            this.dtName.ReadOnly = true;
            // 
            // dtDate
            // 
            this.dtDate.DataPropertyName = "Date";
            this.dtDate.HeaderText = "Date";
            this.dtDate.MinimumWidth = 125;
            this.dtDate.Name = "dtDate";
            this.dtDate.ReadOnly = true;
            this.dtDate.Width = 125;
            // 
            // dtLTP
            // 
            this.dtLTP.DataPropertyName = "LTP";
            this.dtLTP.HeaderText = "LTP";
            this.dtLTP.Name = "dtLTP";
            this.dtLTP.ReadOnly = true;
            this.dtLTP.Width = 52;
            // 
            // dtTime
            // 
            this.dtTime.DataPropertyName = "Time";
            dataGridViewCellStyle1.Format = "HH:mm";
            this.dtTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtTime.HeaderText = "Time";
            this.dtTime.Name = "dtTime";
            this.dtTime.ReadOnly = true;
            this.dtTime.Visible = false;
            this.dtTime.Width = 55;
            // 
            // dtVolume
            // 
            this.dtVolume.DataPropertyName = "Volume";
            this.dtVolume.HeaderText = "Volume";
            this.dtVolume.Name = "dtVolume";
            this.dtVolume.ReadOnly = true;
            this.dtVolume.Width = 67;
            // 
            // dtAsk
            // 
            this.dtAsk.DataPropertyName = "Ask";
            this.dtAsk.HeaderText = "Ask";
            this.dtAsk.Name = "dtAsk";
            this.dtAsk.ReadOnly = true;
            this.dtAsk.Width = 50;
            // 
            // dtBid
            // 
            this.dtBid.DataPropertyName = "Bid";
            this.dtBid.HeaderText = "Bid";
            this.dtBid.Name = "dtBid";
            this.dtBid.ReadOnly = true;
            this.dtBid.Width = 47;
            // 
            // dtHigh
            // 
            this.dtHigh.DataPropertyName = "High";
            this.dtHigh.HeaderText = "High";
            this.dtHigh.Name = "dtHigh";
            this.dtHigh.ReadOnly = true;
            this.dtHigh.Width = 54;
            // 
            // dtLow
            // 
            this.dtLow.DataPropertyName = "Low";
            this.dtLow.HeaderText = "Low";
            this.dtLow.Name = "dtLow";
            this.dtLow.ReadOnly = true;
            this.dtLow.Width = 52;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 359);
            this.Controls.Add(this.tabControlFinance);
            this.Name = "MainForm";
            this.Text = "Yahoo! Finance";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlFinance.ResumeLayout(false);
            this.tabPageSymbols.ResumeLayout(false);
            this.tabPageSymbols.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSymbols)).EndInit();
            this.tabPageWeb.ResumeLayout(false);
            this.tabPageWeb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlFinance;
        private System.Windows.Forms.TabPage tabPageSymbols;
        private System.Windows.Forms.Label lblSymbols;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridViewSymbols;
        private System.Windows.Forms.TabPage tabPageWeb;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblCookies;
        private System.Windows.Forms.Button btnAuthenticate;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtLTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtAsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtLow;
    }
}

