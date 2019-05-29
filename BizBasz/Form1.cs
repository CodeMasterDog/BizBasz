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
using System.Runtime.InteropServices;

namespace BizBasz
{
    public partial class Form1 : Form
    {
        static readonly string columns;
        public static bool MainWindowsClosed { get; set; }
        private static bool sortingDisabled;
        private static readonly float Dpi;

        private bool nextGroup;
        private ListViewColumnSorter lvwColumnSorter;

        static Form1()
        {
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                IntPtr hwnd = GetForegroundWindow();
                Form1.Dpi = GetDisplayScaleFactor(hwnd);
            }
            columns = $"Számlaszám;Kézi azonosító;Ügyfélkód;Ügyfél név;Telephely;Dátum;Teljesítés;Fizetési mód;Esedékes;Könyvelés;Áfa Dátum;Elsz. f. szám;Termék név;Tétel f. szám;Költséghely;Témaszám kód;Témaszám név;Pozíciószám;Deviza;Eladási érték;Engedmény;Nettó;Áfa;Bruttó;Áfa kulcs;Egységár;Mennyiség;Egység;Művelet";
        }

        public Form1()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            this.FormClosing += Form1_FormClosing;

            odt.Multiselect = false;
            odt.Filter = "Pontosvesszővel tagolt fájlok (*.csv)|*.csv|Text fájlok (*.txt)|*.txt|Minden fájl (*.*)|*.*";

            string[] columns = Form1.columns.Split(';');
            foreach (string aColumn in columns)
            {
                ColumnHeader header = new ColumnHeader();
                header.Text = aColumn;
                if (header.Text.Equals("Deviza") || header.Text.Equals("Mennyiség") || header.Text.Equals("Egység"))
                {
                    header.Width = 55;
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

        //DPI
        [DllImport("user32.dll")]
        static extern int GetDpiForWindow(IntPtr hWnd);

        public static float GetDisplayScaleFactor(IntPtr windowHandle)
        {
            try
            {
                return GetDpiForWindow(windowHandle) / 96f;
            }
            catch
            {
                // Or fallback to GDI solutions above
                return 1;
            }
        }
        //DPI

        //Get foreground window, title
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        static private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return string.Empty;
        }
        //Get foreground window, title

        //Get window coordinates
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rectangle rect);
        //Get window coordinates

        //Mouse position, click
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        static public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        //Mouse position, click

        public static void ChangeTextColorIfTooLong(TextBox tb, int maxlenght)
        {
            if (tb.TextLength > maxlenght)
            {
                tb.ForeColor = Color.Red;
            }
            else
            {
                tb.ForeColor = Color.Black;
            }
        }


        //Universal delegate
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

        private void readGropuInfoFromFile(string[] words)
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
        //Universal delegate

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindowsClosed = true;
        }

        private void readingFile()
        {
            new Thread(() =>
            {
                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(odt.FileName, Encoding.GetEncoding(1252));
                    //StringBuilder newFileContent = new StringBuilder();
                    string line;
                    char[] delimiterChars = { ';' };
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
                            readGropuInfoFromFile(words);
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
                                readGropuInfoFromFile(words);
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

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (odt.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = odt.FileName;
                btnOpenFile.Enabled = false;
                readingFile();
            }
        }

        private void btnNextGroup_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            nextGroup = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            ColumnClickEventArgs args = new ColumnClickEventArgs(21);
            listView1_ColumnClick(this, args);
            listView1_ColumnClick(this, args);
            sortingDisabled = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                tbCompliance.Text = listView1.SelectedItems[0].SubItems[6].Text;
                tbNet.Text = listView1.SelectedItems[0].SubItems[21].Text;
                tbProductName.Text = listView1.SelectedItems[0].SubItems[12].Text + " (" + listView1.SelectedItems[0].SubItems[26].Text + " " + listView1.SelectedItems[0].SubItems[27].Text + ")";
                ChangeTextColorIfTooLong(tbProductName, 50);

                tbCustomerName.Text = listView1.SelectedItems[0].SubItems[3].Text;
                tbInvoiceId.Text = listView1.SelectedItems[0].SubItems[0].Text;
                tbAction.Text = listView1.SelectedItems[0].SubItems[28].Text;
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
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

        private void btnBizBasz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbSerial.Text) || string.IsNullOrWhiteSpace(cbGroupCode.Text))
            {
                MessageBox.Show("Nincs Kiválasztva sorozat és/vagy csoportkód!");
            }
            else
            {
                SendKeys.SendWait("%{TAB}");
                Thread.Sleep(300);

                Rectangle rect;
                IntPtr hwnd = GetForegroundWindow();
                GetWindowRect(hwnd, out rect);
                //Sorozat lenyitás
                Cursor.Position = new Point((int)(rect.X + 418 * Dpi), (int)(rect.Y + 191 * Dpi));
                DoMouseClick();
                Thread.Sleep(300);

                //Sorozat kiválasztás
                int y = 0;
                switch (cbSerial.SelectedIndex)
                {
                    case 0:
                        y = 22;
                        break;
                    case 1:
                        y = 38;
                        break;
                    case 2:
                        y = 52;
                        break;
                }
                Cursor.Position = new Point((int)(Cursor.Position.X * Dpi), (int)(Cursor.Position.Y + y * Dpi));
                DoMouseClick();
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{TAB}");
                //SendKeys.SendWait(listView1.SelectedItems[0].SubItems[1].Text);
                SendKeys.SendWait("{TAB}");
                //Product name
                SendKeys.SendWait(tbProductName.Text);
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{TAB}");
                //Quantity unit
                SendKeys.SendWait("db");
                SendKeys.SendWait("{TAB}");
                //Groupcode
                SendKeys.SendWait(cbGroupCode.Text.Substring(0, 3));
                //Event tab
                Cursor.Position = new Point((int)(rect.X + 293 * Dpi), (int)(rect.Y + 168 * Dpi));
                DoMouseClick();
                Thread.Sleep(300);
                //More event info
                Cursor.Position = new Point((int)(rect.X + 293 + 88 * Dpi), (int)(rect.Y + 168 * Dpi));
                DoMouseClick();
                Thread.Sleep(300);
                //Point to date, select
                Cursor.Position = new Point((int)(rect.X + 526 * Dpi), (int)(rect.Y + 296 * Dpi));
                DoMouseClick();
                DoMouseClick();
                //Enter compliance date
                SendKeys.SendWait(tbCompliance.Text);
            }
        }

        private void tbProductName_TextChanged(object sender, EventArgs e)
        {
            ChangeTextColorIfTooLong(sender as TextBox, 50);
        }
    }
}
