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
using System.Timers;
using System.IO;
using System.Collections;

namespace BizBasz
{
    public partial class Form1 : Form
    {
        static readonly string columns;
        public static bool MainWindowsClosed { get; set; }
        private static bool sortingDisabled;
        private static readonly float Dpi;
        private int lineCounter = 0;
        private bool eof;
        private bool nextGroup;
        private ListViewColumnSorter lvwColumnSorter;
        private Dictionary<string, string> themes;

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

            themes = new Dictionary<string, string>();
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
                    /*header.Text.Equals("Témaszám név") ||*/ header.Text.Equals("Áfa") ||
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
                listView1.Select();
                ListViewItem lvi = new ListViewItem(words[0]);
                for (int i = 1; i < words.Length; i++)
                {
                    lvi.SubItems.Add(words[i]);
                }
                listView1.Items.Add(lvi);
                if (listView1.Items.Count > 0)
                {
                    //listView1.Items[0].Selected = true;
                }
                changeCounterLabels();
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
                    eof = true;
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
            if (eof)
            {
                lblCsvLine.Text = "End of file";
                lblItemCount. Text = "End of file";
            }
            lineCounter += listView1.Items.Count;

            listView1.Items.Clear();
            tbThemeId.Text = string.Empty;
            lblRepeatingTheme.Text = string.Empty;
            tbThemeEquipment.Text = string.Empty;
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
                tbThemeId.Text = $"{listView1.SelectedItems[0].SubItems[15].Text} - {listView1.SelectedItems[0].SubItems[16].Text}";

                if (listView1.SelectedItems[0].Index == 0 && tbAction.Text.Equals("Új"))
                {
                    cbAct.SelectedIndex = 0;
                }
                else
                {
                    cbAct.SelectedIndex = 1;
                }
                changeCounterLabels();

                string themeKey = listView1.SelectedItems[0].SubItems[15].Text;
                if (!string.IsNullOrWhiteSpace(themeKey))
                {
                    if (themes.Keys.Contains(themeKey))
                    {
                        string tmp = "";
                        lblRepeatingTheme.Text = "Már szerepelt ez a téma";
                        themes.TryGetValue(themeKey, out tmp);
                        tbThemeEquipment.Text = tmp;
                    }
                    else
                    {
                        lblRepeatingTheme.Text = string.Empty;
                        tbThemeEquipment.Text = string.Empty;
                    }
                }
            }
            else
            {
                lblRepeatingTheme.Text = string.Empty;
                tbThemeEquipment.Text = string.Empty;
                tbThemeId.Text = string.Empty;
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
            if ((string.IsNullOrWhiteSpace(cbSerial.Text) || string.IsNullOrWhiteSpace(cbGroupCode.Text)) && cbAct.SelectedIndex == 0)
            {
                MessageBox.Show("Nincs Kiválasztva sorozat és/vagy csoportkód!");
            }
            else
            {
                if (cbAct.SelectedIndex == 0 && ((Double.Parse(tbNet.Text) > 100000 && cbSerial.SelectedIndex == 2) ||
                   ((Double.Parse(tbNet.Text) < 100000 && cbSerial.SelectedIndex == 0) || (Double.Parse(tbNet.Text) < 100000 && cbSerial.SelectedIndex == 1))))
                {
                    DialogResult dialogResult = MessageBox.Show($"Biztos, hogy a sorozat {cbSerial.Text}?", "Kérdés", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                SendKeys.SendWait("%{TAB}");
                Thread.Sleep(300);

                Rectangle rect;
                IntPtr hwnd = GetForegroundWindow();
                GetWindowRect(hwnd, out rect);

                if (cbAct.SelectedIndex == 0) //új tétel Aktiválás
                {
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
                    Thread.Sleep(300);
                    DoMouseClick();
                    Thread.Sleep(200);
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
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    //Szöveg
                    SendKeys.SendWait(tbProductName.Text);
                    SendKeys.SendWait("{TAB}");
                    //fellelési hely
                    SendKeys.SendWait("100");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    //általános fül bruttó érték
                    SendKeys.SendWait(tbNet.Text);
                    //Kapcsolódó bizonylatok fül
                    Cursor.Position = new Point((int)(rect.X + 460 * Dpi), (int)(rect.Y + 252 * Dpi));
                    DoMouseClick();
                    Thread.Sleep(300);
                    //Thread.Sleep(300);
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}"); // megnyílik az új bizonylat felviteli sor, de még nem a szlaszám az aktív
                    SendKeys.SendWait("{TAB}"); //ekkor lehet beírni a bizonylatszámot
                    SendKeys.SendWait(tbInvoiceId.Text);
                    Thread.Sleep(300);
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait(tbNet.Text);
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("0");
                    //ha kisértékű
                    if (cbSerial.SelectedIndex == 2)
                    {
                        Cursor.Position = new Point((int)(rect.X + 420 * Dpi), (int)(rect.Y + 170 * Dpi));
                        DoMouseClick();
                        Thread.Sleep(300);
                        //sztv leírás 100%
                        Cursor.Position = new Point((int)(rect.X + 492), (int)(rect.Y + 273));
                        DoMouseClick();
                        DoMouseClick();
                        SendKeys.SendWait("100");

                        //atv leírás 100%
                        Cursor.Position = new Point((int)(rect.X + 492), (int)(rect.Y + 411));
                        DoMouseClick();
                        DoMouseClick();
                        SendKeys.SendWait("100");
                    }
                }
                else
                {
                    //új bővítési biz Ctrl + B //csak módosítás
                    Cursor.Position = new Point((int)(rect.X + 378 * Dpi), (int)(rect.Y + 168 * Dpi)); //esemény fül
                    DoMouseClick();
                    Thread.Sleep(300);
                    SendKeys.SendWait("^b");
                    Thread.Sleep(300);
                    SendKeys.SendWait(tbCompliance.Text); //teljesítés
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait(tbProductName.Text); //szöveg
                    //fellelési hely
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("100");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    //bt értékváltozás
                    SendKeys.SendWait(tbNet.Text);
                    SendKeys.SendWait("{TAB}");
                    //kapcsolódó bizonylatok
                    Cursor.Position = new Point((int)(rect.X + 466 * Dpi), (int)(rect.Y + 254 * Dpi));
                    DoMouseClick();
                    Thread.Sleep(300);
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}"); // új bizonylat sor
                    string subInvoice = $"{tbInvoiceId.Text}/{(listView1.SelectedItems[0].Index + 1).ToString()}";
                    SendKeys.SendWait(subInvoice);
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait(tbNet.Text);
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("0");

                }



            }
        }

        private void tbProductName_TextChanged(object sender, EventArgs e)
        {
            ChangeTextColorIfTooLong(sender as TextBox, 50);
        }

        private void warningMsg(string msg, Label lbl, bool exit)
        {
            System.Timers.Timer timer = new System.Timers.Timer(300);
            lbl.Text = msg;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            if (exit)
            {
                timer.Start();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (lblMsg.ForeColor == Color.Red)
            {
                lblMsg.ForeColor = Color.Black;
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            warningMsg("Hiba", lblMsg, true);
            new Thread(() =>
            {

                for (int i = 0; i < 900000000; i++)
                {

                }
                ControlInvoke(lblMsg, () =>
                {
                    warningMsg(string.Empty, lblMsg, true);
                });
            }
                ).Start();

        }

        private void logItems()
        {
            try
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "Log_" + odt.SafeFileName)))
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(Path.Combine(Application.StartupPath, "Log_" + odt.SafeFileName), FileMode.Create), Encoding.UTF8));
                }
                using (StreamWriter sw = File.AppendText(Path.Combine(Application.StartupPath, "Log_" + odt.SafeFileName)))
                {
                    StringBuilder sb = new StringBuilder();
                    int sItemcount = listView1.SelectedItems[0].SubItems.Count;
                    for (int i = 0; i < sItemcount; i++)
                    {
                        sb.Append(listView1.SelectedItems[0].SubItems[i].Text + ";");
                    }
                    sw.WriteLine(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lblSave_Click(object sender, EventArgs e)
        {
            logItems();
            SendKeys.SendWait("%{TAB}");
            Thread.Sleep(300);
            //CTRL + R //Serpa rögzítés
            SendKeys.SendWait("^r");

        }

        private void changeCounterLabels()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                lblItemCount.Text = $"Items: {listView1.Items.Count}, selected item's index: { listView1.SelectedItems[0].Index}";
                lblCsvLine.Text = $"csv line: {lineCounter + listView1.SelectedItems[0].Index+1}";
            }
            else
            {
                lblItemCount.Text = "0";
            }
        }

        private void btnSaveAquipment_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string themeKey = listView1.SelectedItems[0].SubItems[15].Text;
                themes.Add(themeKey, tbThemeEquipment.Text);
            }
        }
    }
}
