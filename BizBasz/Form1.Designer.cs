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
            this.button1 = new System.Windows.Forms.Button();
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
            this.btnCollect.Location = new System.Drawing.Point(12, 420);
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
            this.listView1.Location = new System.Drawing.Point(0, 206);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1074, 189);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            this.lblCompliance.Location = new System.Drawing.Point(9, 48);
            this.lblCompliance.Name = "lblCompliance";
            this.lblCompliance.Size = new System.Drawing.Size(59, 15);
            this.lblCompliance.TabIndex = 5;
            this.lblCompliance.Text = "Teljesítés";
            // 
            // tbCompliance
            // 
            this.tbCompliance.Location = new System.Drawing.Point(12, 66);
            this.tbCompliance.Name = "tbCompliance";
            this.tbCompliance.Size = new System.Drawing.Size(100, 20);
            this.tbCompliance.TabIndex = 6;
            // 
            // tbNet
            // 
            this.tbNet.Location = new System.Drawing.Point(118, 66);
            this.tbNet.Name = "tbNet";
            this.tbNet.Size = new System.Drawing.Size(100, 20);
            this.tbNet.TabIndex = 8;
            // 
            // lnlNet
            // 
            this.lnlNet.AutoSize = true;
            this.lnlNet.Location = new System.Drawing.Point(115, 48);
            this.lnlNet.Name = "lnlNet";
            this.lnlNet.Size = new System.Drawing.Size(36, 15);
            this.lnlNet.TabIndex = 7;
            this.lnlNet.Text = "Nettó";
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(224, 66);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(100, 20);
            this.tbProductName.TabIndex = 10;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(221, 48);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(71, 15);
            this.lblProductName.TabIndex = 9;
            this.lblProductName.Text = "Termék név";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 395);
            this.Controls.Add(this.button1);
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
            this.Shown += new System.EventHandler(this.Form1_Shown);
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
        private System.Windows.Forms.Button button1;
    }
}

