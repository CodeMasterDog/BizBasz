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
            this.FormClosing += Form1_FormClosing;

            Thread mainThread = Thread.CurrentThread;
            odt.Multiselect = false;
            odt.Filter = "Text fájlok (*.txt)|*.txt|Pontosvesszővel tagolt fájlok (*.csv)|*.csv|Minden fájl (*.*)|*.*";

            string[] aColumn = Form1.columns.Split(';');
            foreach (string column in aColumn)
            {
                ColumnHeader header = new ColumnHeader();
                header.Text = column;
                listView1.Columns.Add(header);
                if (header.Text.Equals("Ügyfélkód") || header.Text.Equals("Telephely") || header.Text.Equals("Esedékes") || header.Text.Equals("Áfa Dátum"))
                {
                    header.Width = 0;
                }
            }

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
                                });
                            }
                        }
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

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}
