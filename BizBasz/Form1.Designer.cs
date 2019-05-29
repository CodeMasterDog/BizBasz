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
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 166);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1268, 176);
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
            this.lblCompliance.Size = new System.Drawing.Size(53, 13);
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
            this.lnlNet.Size = new System.Drawing.Size(33, 13);
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
            this.lblProductName.Size = new System.Drawing.Size(64, 13);
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
            this.lblCustomerName.Size = new System.Drawing.Size(58, 13);
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
            this.lblInvoiceId.Size = new System.Drawing.Size(65, 13);
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
            this.lblAction.Size = new System.Drawing.Size(45, 13);
            this.lblAction.TabIndex = 15;
            this.lblAction.Text = "Művelet";
            // 
            // lblserial
            // 
            this.lblserial.AutoSize = true;
            this.lblserial.Location = new System.Drawing.Point(12, 92);
            this.lblserial.Name = "lblserial";
            this.lblserial.Size = new System.Drawing.Size(43, 13);
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
            this.lblGroupCode.Size = new System.Drawing.Size(58, 13);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 342);
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
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnBizBasz);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

