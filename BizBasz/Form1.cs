using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BizBasz
{
    public partial class Form1 : Form
    {
        private bool nextGroup;
        static readonly string columns;
        private static bool mainWindowsClosed;
        private ListViewColumnSorter lvwColumnSorter;
        private static bool sortingDisabled;

        public static bool MainWindowsClosed { get => mainWindowsClosed; set => mainWindowsClosed = value; }

        delegate void UniversalVoidDelegate();

        public static void ControlInvoke(Control control, Action function)
        {
            if (control.IsDisposed || control.Disposing)
                return;

            if (control.InvokeRequired)
            {
                control.Invoke(new UniversalVoidDelegate(() => ControlInvoke(control, function)));
                return;
            }
            function();
        }

        private void TestFunction()
        {
            ControlInvoke(listView1, () => listView1.Items.Add("Test"));
        }

        static Form1()
        {
            columns = $"Számlaszám;Kézi azonosító;Ügyfélkód;Ügyfél név;Telephely;Dátum;Teljesítés;Fizetési mód;Esedékes;Könyvelés;Áfa Dátum;Elsz. f. szám;Termék név;Tétel f. szám;Költséghely;Témaszám kód;Témaszám név;Pozíciószám;Deviza;Eladási érték;Engedmény;Nettó;Áfa;Bruttó;Áfa kulcs;Egységár;Mennyiség;Mennyiségi egység";
        }

        public Form1()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            this.FormClosing += Form1_FormClosing;
            listView1.ColumnClick += ListView1_ColumnClick;

            Thread mainThread = Thread.CurrentThread;
            odt.Multiselect = false;
            odt.Filter = "Pontosvesszővel tagolt fájlok (*.csv)|*.csv|Text fájlok (*.txt)|*.txt|Minden fájl (*.*)|*.*";

            string[] aColumn = Form1.columns.Split(';');
            foreach (string column in aColumn)
            {
                ColumnHeader header = new ColumnHeader();
                header.Text = column;
                if (header.Text.Equals("Deviza") || header.Text.Equals("Mennyiség") || header.Text.Equals("Mennyiségi egység"))
                {
                    header.Width = 80;
                }
                else
                {
                    header.Width = 150;
                }

                listView1.Columns.Add(header);
                if (header.Text.Equals("Ügyfélkód") || header.Text.Equals("Telephely") ||
                    header.Text.Equals("Esedékes") || header.Text.Equals("Áfa Dátum") || 
                    header.Text.Equals("Elsz. f. szám") || header.Text.Equals("Tétel f. szám") ||
                    header.Text.Equals("Költséghely") || header.Text.Equals("Pozíciószám") ||
                    header.Text.Equals("Eladási érték") || header.Text.Equals("Engedmény") ||
                    header.Text.Equals("Dátum") || header.Text.Equals("Könyvelés") ||
                    header.Text.Equals("Fizetési mód") || header.Text.Equals("Témaszám kód") ||
                    header.Text.Equals("Témaszám név") || header.Text.Equals("Áfa") ||
                    header.Text.Equals("Bruttó") || header.Text.Equals("Áfa kulcs") ||
                    header.Text.Equals("Kézi azonosító"))
                {
                    header.Width = 0;
                }  
            }
            


        }

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindowsClosed = true;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {

            if (odt.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = odt.FileName;
                btnOpenFile.Enabled = false;

                new Thread(() =>
                {
                    string line;
                    char[] delimiterChars = { ';' };

                    try
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader(odt.FileName, Encoding.GetEncoding(1252));
                        StringBuilder newFileContent = new StringBuilder();

                        string prevInvoiceId = null;

                        int counter = 0;
                        while ((line = file.ReadLine()) != null)
                        {
                            counter++;
                            string[] words = line.Split(delimiterChars);
                            if (words[0].Equals("Számlaszám"))
                            {
                                continue;
                            }
                            if (counter == 2)
                            {
                                prevInvoiceId = words[0];
                            }

                            if (prevInvoiceId.Equals(words[0]))
                            {
                                ControlInvoke(listView1, () =>
                                {
                                ListViewItem lvi = new ListViewItem(words[0]);
                                for (int i = 1; i < words.Length; i++)
                                {
                                    lvi.SubItems.Add(words[i]);
                                }
                                listView1.Items.Add(lvi);
                                if (listView1.Items.Count > 0)
                                {
                                    listView1.Items[0].Selected = true;
                                }
                                listView1.Select();
                                });
                            }
                            else
                            {
                                while (!nextGroup)
                                {
                                    Thread.Sleep(300);
                                    if (MainWindowsClosed)
                                    {
                                        return;
                                    }
                                }

                                if (nextGroup)
                                {
                                    nextGroup = false;
                                    prevInvoiceId = words[0];
                                    ControlInvoke(listView1, () =>
                                    {
                                        ListViewItem lvi = new ListViewItem(words[0]);
                                        for (int i = 1; i < words.Length; i++)
                                        {
                                            lvi.SubItems.Add(words[i]);
                                        }
                                        listView1.Items.Add(lvi);
                                        if (listView1.Items.Count > 0)
                                        {
                                            listView1.Items[0].Selected = true;
                                        }
                                        listView1.Select();
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        ControlInvoke(btnOpenFile, () => btnOpenFile.Enabled = true);
                    }
                }).Start();
            }
        }

        private void btnNextGroup_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            nextGroup = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ColumnHeader columnheader;// Used for creating column headers.
            ListViewItem listviewitem;// Used for creating listview items.

            // Ensure that the view is set to show details.
            listView1.View = View.Details;
            ColumnClickEventArgs args = new ColumnClickEventArgs(21);
            listView1_ColumnClick_1(this, args);
            listView1_ColumnClick_1(this, args);
            sortingDisabled = true;

            //// Loop through and size each column header to fit the column header text.
            //foreach (ColumnHeader ch in this.listView1.Columns)
            //{
            //    ch.Width = -2;
            //}
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                tbCompliance.Text = listView1.SelectedItems[0].SubItems[6].Text;
                tbNet.Text = listView1.SelectedItems[0].SubItems[21].Text;
                tbProductName.Text = listView1.SelectedItems[0].SubItems[12].Text;
                tbCustomerName.Text = listView1.SelectedItems[0].SubItems[3].Text;
                tbInvoiceId.Text = listView1.SelectedItems[0].SubItems[0].Text;
            }
        }


        private void listView1_ColumnClick_1(object sender, ColumnClickEventArgs e)
        {
            if (!sortingDisabled)
            {
                // Determine if clicked column is already the column that is being sorted.
                if (e.Column == lvwColumnSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)
                    {
                        lvwColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    lvwColumnSorter.SortColumn = e.Column;
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }

                // Perform the sort with these new sort options.
                this.listView1.Sort();
            }
        }
    }
}
