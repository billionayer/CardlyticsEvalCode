namespace LinkedListTester
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonProcessData = new System.Windows.Forms.Button();
            this.buttonLocateData = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtRawData = new System.Windows.Forms.RichTextBox();
            this.gbDataAttributes = new System.Windows.Forms.GroupBox();
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.lblEntryDataType = new System.Windows.Forms.Label();
            this.lblNumEntries = new System.Windows.Forms.Label();
            this.txtNumEntries = new System.Windows.Forms.TextBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFoundData = new System.Windows.Forms.RichTextBox();
            this.lblItemNumber = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbDataAttributes.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text files|*.txt";
            // 
            // buttonProcessData
            // 
            this.buttonProcessData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcessData.Location = new System.Drawing.Point(12, 49);
            this.buttonProcessData.Name = "buttonProcessData";
            this.buttonProcessData.Size = new System.Drawing.Size(963, 23);
            this.buttonProcessData.TabIndex = 9;
            this.buttonProcessData.Text = "Load Data File";
            this.buttonProcessData.UseVisualStyleBackColor = true;
            this.buttonProcessData.Click += new System.EventHandler(this.buttonProcessData_Click);
            // 
            // buttonLocateData
            // 
            this.buttonLocateData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLocateData.Location = new System.Drawing.Point(851, 21);
            this.buttonLocateData.Name = "buttonLocateData";
            this.buttonLocateData.Size = new System.Drawing.Size(124, 23);
            this.buttonLocateData.TabIndex = 8;
            this.buttonLocateData.Text = "Locate Data File";
            this.buttonLocateData.UseVisualStyleBackColor = true;
            this.buttonLocateData.Click += new System.EventHandler(this.buttonLocateData_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.Location = new System.Drawing.Point(12, 24);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(829, 20);
            this.textBoxFileName.TabIndex = 7;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(9, 8);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(52, 13);
            this.lblFileName.TabIndex = 6;
            this.lblFileName.Text = "Data File:";
            // 
            // txtRawData
            // 
            this.txtRawData.Location = new System.Drawing.Point(12, 199);
            this.txtRawData.Name = "txtRawData";
            this.txtRawData.Size = new System.Drawing.Size(983, 352);
            this.txtRawData.TabIndex = 10;
            this.txtRawData.Text = "";
            // 
            // gbDataAttributes
            // 
            this.gbDataAttributes.Controls.Add(this.cmbTypes);
            this.gbDataAttributes.Controls.Add(this.lblEntryDataType);
            this.gbDataAttributes.Controls.Add(this.lblNumEntries);
            this.gbDataAttributes.Controls.Add(this.txtNumEntries);
            this.gbDataAttributes.Location = new System.Drawing.Point(12, 79);
            this.gbDataAttributes.Name = "gbDataAttributes";
            this.gbDataAttributes.Size = new System.Drawing.Size(281, 114);
            this.gbDataAttributes.TabIndex = 13;
            this.gbDataAttributes.TabStop = false;
            this.gbDataAttributes.Text = "Data Attributes";
            // 
            // cmbTypes
            // 
            this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.Items.AddRange(new object[] {
            "string",
            "integer"});
            this.cmbTypes.Location = new System.Drawing.Point(104, 46);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(155, 21);
            this.cmbTypes.TabIndex = 4;
            this.cmbTypes.SelectedIndexChanged += new System.EventHandler(this.cmbTypes_SelectedIndexChanged);
            // 
            // lblEntryDataType
            // 
            this.lblEntryDataType.AutoSize = true;
            this.lblEntryDataType.Location = new System.Drawing.Point(7, 46);
            this.lblEntryDataType.Name = "lblEntryDataType";
            this.lblEntryDataType.Size = new System.Drawing.Size(84, 13);
            this.lblEntryDataType.TabIndex = 3;
            this.lblEntryDataType.Text = "Entry Data Type";
            // 
            // lblNumEntries
            // 
            this.lblNumEntries.AutoSize = true;
            this.lblNumEntries.Location = new System.Drawing.Point(7, 20);
            this.lblNumEntries.Name = "lblNumEntries";
            this.lblNumEntries.Size = new System.Drawing.Size(91, 13);
            this.lblNumEntries.TabIndex = 1;
            this.lblNumEntries.Text = "Number of Entries";
            // 
            // txtNumEntries
            // 
            this.txtNumEntries.Location = new System.Drawing.Point(104, 14);
            this.txtNumEntries.Name = "txtNumEntries";
            this.txtNumEntries.ReadOnly = true;
            this.txtNumEntries.Size = new System.Drawing.Size(155, 20);
            this.txtNumEntries.TabIndex = 0;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.txtItemNumber);
            this.gbSearch.Controls.Add(this.cmbSearchType);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.txtFoundData);
            this.gbSearch.Controls.Add(this.lblItemNumber);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Location = new System.Drawing.Point(300, 79);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(675, 114);
            this.gbSearch.TabIndex = 14;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // txtItemNumber
            // 
            this.txtItemNumber.Location = new System.Drawing.Point(106, 17);
            this.txtItemNumber.Name = "txtItemNumber";
            this.txtItemNumber.Size = new System.Drawing.Size(77, 20);
            this.txtItemNumber.TabIndex = 19;
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "DESC",
            "ASC"});
            this.cmbSearchType.Location = new System.Drawing.Point(106, 43);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(77, 21);
            this.cmbSearchType.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Entry Data Type";
            // 
            // txtFoundData
            // 
            this.txtFoundData.Location = new System.Drawing.Point(201, 12);
            this.txtFoundData.Name = "txtFoundData";
            this.txtFoundData.Size = new System.Drawing.Size(468, 96);
            this.txtFoundData.TabIndex = 16;
            this.txtFoundData.Text = "";
            // 
            // lblItemNumber
            // 
            this.lblItemNumber.AutoSize = true;
            this.lblItemNumber.Location = new System.Drawing.Point(7, 21);
            this.lblItemNumber.Name = "lblItemNumber";
            this.lblItemNumber.Size = new System.Drawing.Size(70, 13);
            this.lblItemNumber.TabIndex = 15;
            this.lblItemNumber.Text = "Item Number:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(10, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 568);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbDataAttributes);
            this.Controls.Add(this.txtRawData);
            this.Controls.Add(this.buttonProcessData);
            this.Controls.Add(this.buttonLocateData);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.lblFileName);
            this.Name = "MainForm";
            this.Text = "Link List Tester App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbDataAttributes.ResumeLayout(false);
            this.gbDataAttributes.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonProcessData;
        private System.Windows.Forms.Button buttonLocateData;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.RichTextBox txtRawData;
        private System.Windows.Forms.GroupBox gbDataAttributes;
        private System.Windows.Forms.Label lblEntryDataType;
        private System.Windows.Forms.Label lblNumEntries;
        private System.Windows.Forms.TextBox txtNumEntries;
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblItemNumber;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtFoundData;
        private System.Windows.Forms.TextBox txtItemNumber;
    }
}

