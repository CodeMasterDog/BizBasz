namespace BizBasz
{
    partial class Form1
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
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.odt = new System.Windows.Forms.OpenFileDialog();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnBizBasz = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnNextGroup = new System.Windows.Forms.Button();
            this.lblCompliance = new System.Windows.Forms.Label();
            this.tbCompliance = new System.Windows.Forms.TextBox();
            this.tbNet = new System.Windows.Forms.TextBox();
            this.lnlNet = new System.Windows.Forms.Label();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.tbInvoiceId = new System.Windows.Forms.TextBox();
            this.lblInvoiceId = new System.Windows.Forms.Label();
            this.tbAction = new System.Windows.Forms.TextBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblserial = new System.Windows.Forms.Label();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.cbGroupCode = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSave = new System.Windows.Forms.Button();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.cbAct = new System.Windows.Forms.ComboBox();
            this.lblAct = new System.Windows.Forms.Label();
            this.lblCsvLine = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // odt
            // 
            this.odt.FileName = "openFileDialog1";
            // 
            // tbPath
            // 
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(93, 15);
            this.tbPath.Multiline = true;
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(969, 20);
            this.tbPath.TabIndex = 1;
            // 
            // btnBizBasz
            // 
            this.btnBizBasz.Location = new System.Drawing.Point(1111, 69);
            this.btnBizBasz.Name = "btnBizBasz";
            this.btnBizBasz.Size = new System.Drawing.Size(75, 23);
            this.btnBizBasz.TabIndex = 2;
            this.btnBizBasz.Text = "BizBasz!!!";
            this.btnBizBasz.UseVisualStyleBackColor = true;
            this.btnBizBasz.Click += new System.EventHandler(this.btnBizBasz_Click);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1278, 136);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnNextGroup
            // 
            this.btnNextGroup.Location = new System.Drawing.Point(1030, 69);
            this.btnNextGroup.Name = "btnNextGroup";
            this.btnNextGroup.Size = new System.Drawing.Size(75, 23);
            this.btnNextGroup.TabIndex = 4;
            this.btnNextGroup.Text = "Next";
            this.btnNextGroup.UseVisualStyleBackColor = true;
            this.btnNextGroup.Click += new System.EventHandler(this.btnNextGroup_Click);
            // 
            // lblCompliance
            // 
            this.lblCompliance.AutoSize = true;
            this.lblCompliance.Location = new System.Drawing.Point(143, 51);
            this.lblCompliance.Name = "lblCompliance";
            this.lblCompliance.Size = new System.Drawing.Size(59, 15);
            this.lblCompliance.TabIndex = 5;
            this.lblCompliance.Text = "Teljesítés";
            // 
            // tbCompliance
            // 
            this.tbCompliance.Location = new System.Drawing.Point(143, 69);
            this.tbCompliance.Name = "tbCompliance";
            this.tbCompliance.Size = new System.Drawing.Size(100, 20);
            this.tbCompliance.TabIndex = 6;
            // 
            // tbNet
            // 
            this.tbNet.Location = new System.Drawing.Point(249, 69);
            this.tbNet.Name = "tbNet";
            this.tbNet.Size = new System.Drawing.Size(100, 20);
            this.tbNet.TabIndex = 8;
            // 
            // lnlNet
            // 
            this.lnlNet.AutoSize = true;
            this.lnlNet.Location = new System.Drawing.Point(246, 51);
            this.lnlNet.Name = "lnlNet";
            this.lnlNet.Size = new System.Drawing.Size(36, 15);
            this.lnlNet.TabIndex = 7;
            this.lnlNet.Text = "Nettó";
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(635, 69);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(274, 20);
            this.tbProductName.TabIndex = 10;
            this.tbProductName.TextChanged += new System.EventHandler(this.tbProductName_TextChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(632, 51);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(71, 15);
            this.lblProductName.TabIndex = 9;
            this.lblProductName.Text = "Termék név";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Location = new System.Drawing.Point(355, 69);
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(274, 20);
            this.tbCustomerName.TabIndex = 12;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(352, 51);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(63, 15);
            this.lblCustomerName.TabIndex = 11;
            this.lblCustomerName.Text = "Ügyfél név";
            // 
            // tbInvoiceId
            // 
            this.tbInvoiceId.Location = new System.Drawing.Point(15, 69);
            this.tbInvoiceId.Name = "tbInvoiceId";
            this.tbInvoiceId.Size = new System.Drawing.Size(122, 20);
            this.tbInvoiceId.TabIndex = 14;
            // 
            // lblInvoiceId
            // 
            this.lblInvoiceId.AutoSize = true;
            this.lblInvoiceId.Location = new System.Drawing.Point(12, 51);
            this.lblInvoiceId.Name = "lblInvoiceId";
            this.lblInvoiceId.Size = new System.Drawing.Size(79, 15);
            this.lblInvoiceId.TabIndex = 13;
            this.lblInvoiceId.Text = "Számlaszám";
            // 
            // tbAction
            // 
            this.tbAction.Location = new System.Drawing.Point(915, 69);
            this.tbAction.Name = "tbAction";
            this.tbAction.Size = new System.Drawing.Size(100, 20);
            this.tbAction.TabIndex = 16;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(912, 51);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(50, 15);
            this.lblAction.TabIndex = 15;
            this.lblAction.Text = "Művelet";
            // 
            // lblserial
            // 
            this.lblserial.AutoSize = true;
            this.lblserial.Location = new System.Drawing.Point(12, 92);
            this.lblserial.Name = "lblserial";
            this.lblserial.Size = new System.Drawing.Size(49, 15);
            this.lblserial.TabIndex = 17;
            this.lblserial.Text = "Sorozat";
            // 
            // cbSerial
            // 
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Items.AddRange(new object[] {
            "IM",
            "TE",
            "KE"});
            this.cbSerial.Location = new System.Drawing.Point(15, 110);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(121, 21);
            this.cbSerial.TabIndex = 18;
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Location = new System.Drawing.Point(143, 92);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(65, 15);
            this.lblGroupCode.TabIndex = 19;
            this.lblGroupCode.Text = "Csopotkód";
            // 
            // cbGroupCode
            // 
            this.cbGroupCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbGroupCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGroupCode.DropDownWidth = 280;
            this.cbGroupCode.FormattingEnabled = true;
            this.cbGroupCode.Items.AddRange(new object[] {
            "111 - Alapítás-átszervezés aktivált értéke",
            "112 - Kisérleti fejlesztés aktivált értéke",
            "113 - Vagyoni értékű jogok",
            "114 - Szellemi termékek",
            "115 - Üzleti vagy cégérték",
            "121 - Földterület",
            "122 - Telek telkesítés",
            "123 - Épületek, épületrészek, tulajdoni hányadok",
            "124 - Egyéb építmények",
            "125 - Üzemkörön kívüli ingatlanok, épületek",
            "126 - Ingatlanokhoz kapcsolódó vagyoni értékű jogok",
            "131 - Termelő gépek, berendezés, szerszámok, gyártóeszk",
            "132 - Termelésben közvetlenül résztvevő járművek",
            "141 - Üzemi (üzleti) gépek, berendezések, felszerelések",
            "142 - Egyéb járművek",
            "143 - Irodai igazgatási berendezések, felszerelések",
            "144 - Üzemkörön kívüli berendezések, felsz., járművek"});
            this.cbGroupCode.Location = new System.Drawing.Point(146, 110);
            this.cbGroupCode.Name = "cbGroupCode";
            this.cbGroupCode.Size = new System.Drawing.Size(309, 21);
            this.cbGroupCode.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Location = new System.Drawing.Point(12, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 136);
            this.panel1.TabIndex = 21;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(1068, 20);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 29);
            this.lblMsg.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1030, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSave
            // 
            this.lblSave.Location = new System.Drawing.Point(1192, 69);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(75, 23);
            this.lblSave.TabIndex = 24;
            this.lblSave.Text = "Rögzítés";
            this.lblSave.UseVisualStyleBackColor = true;
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // lblItemCount
            // 
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Location = new System.Drawing.Point(912, 119);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(41, 15);
            this.lblItemCount.TabIndex = 25;
            this.lblItemCount.Text = "label1";
            // 
            // cbAct
            // 
            this.cbAct.FormattingEnabled = true;
            this.cbAct.Items.AddRange(new object[] {
            "Aktiválás",
            "Bővítés"});
            this.cbAct.Location = new System.Drawing.Point(461, 110);
            this.cbAct.Name = "cbAct";
            this.cbAct.Size = new System.Drawing.Size(168, 21);
            this.cbAct.TabIndex = 26;
            // 
            // lblAct
            // 
            this.lblAct.AutoSize = true;
            this.lblAct.Location = new System.Drawing.Point(461, 92);
            this.lblAct.Name = "lblAct";
            this.lblAct.Size = new System.Drawing.Size(126, 15);
            this.lblAct.TabIndex = 27;
            this.lblAct.Text = "Aktiválás / Ráaktiválás";
            // 
            // lblCsvLine
            // 
            this.lblCsvLine.AutoSize = true;
            this.lblCsvLine.Location = new System.Drawing.Point(635, 110);
            this.lblCsvLine.Name = "lblCsvLine";
            this.lblCsvLine.Size = new System.Drawing.Size(53, 15);
            this.lblCsvLine.TabIndex = 28;
            this.lblCsvLine.Text = "csv line: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 285);
            this.Controls.Add(this.lblCsvLine);
            this.Controls.Add(this.lblAct);
            this.Controls.Add(this.cbAct);
            this.Controls.Add(this.lblItemCount);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblGroupCode);
            this.Controls.Add(this.cbGroupCode);
            this.Controls.Add(this.lblserial);
            this.Controls.Add(this.cbSerial);
            this.Controls.Add(this.tbAction);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.tbInvoiceId);
            this.Controls.Add(this.lblInvoiceId);
            this.Controls.Add(this.tbCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.tbProductName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.tbNet);
            this.Controls.Add(this.lnlNet);
            this.Controls.Add(this.tbCompliance);
            this.Controls.Add(this.lblCompliance);
            this.Controls.Add(this.btnNextGroup);
            this.Controls.Add(this.btnBizBasz);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog odt;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnBizBasz;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnNextGroup;
        private System.Windows.Forms.Label lblCompliance;
        private System.Windows.Forms.TextBox tbCompliance;
        private System.Windows.Forms.TextBox tbNet;
        private System.Windows.Forms.Label lnlNet;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox tbInvoiceId;
        private System.Windows.Forms.Label lblInvoiceId;
        private System.Windows.Forms.TextBox tbAction;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblserial;
        private System.Windows.Forms.ComboBox cbSerial;
        private System.Windows.Forms.Label lblGroupCode;
        private System.Windows.Forms.ComboBox cbGroupCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button lblSave;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.ComboBox cbAct;
        private System.Windows.Forms.Label lblAct;
        private System.Windows.Forms.Label lblCsvLine;
    }
}

