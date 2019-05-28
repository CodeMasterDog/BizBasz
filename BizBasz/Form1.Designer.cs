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
            this.btnCollect = new System.Windows.Forms.Button();
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
            // btnCollect
            // 
            this.btnCollect.Location = new System.Drawing.Point(987, 105);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(75, 23);
            this.btnCollect.TabIndex = 2;
            this.btnCollect.Text = "button1";
            this.btnCollect.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 171);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1156, 224);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick_1);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnNextGroup
            // 
            this.btnNextGroup.Location = new System.Drawing.Point(987, 66);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 395);
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
            this.Controls.Add(this.btnCollect);
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
        private System.Windows.Forms.Button btnCollect;
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
    }
}

