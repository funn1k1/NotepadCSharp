using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace NotepadCSharp
{
    public partial class blank : Form
    {
        public blank()
        {
            InitializeComponent();
            sbAmount.Text = "Amount of Sybmols";
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            sbTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());
        }
        public string DocName;
        private string BufferText;
        public bool IsSaved = false;
        public void Cut()
        {
            this.BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }
        public void Copy()
        {
            this.BufferText = richTextBox1.SelectedText;
        }
        public void Paste()
        {
            richTextBox1.SelectedText = this.BufferText;
        }
        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }
        public void Delete()
        {
            richTextBox1.SelectedText = "";
            this.BufferText = "";
        }

        private void CmnuCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void CmnuCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void CmnuPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void CmnuDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void CmnuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        public void Open(string OpenFileName)
        {
            if (OpenFileName == null)
            {
                    return;
            }
            else
            {
                StreamReader sr = new StreamReader(OpenFileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                DocName = OpenFileName;
            }
        }
        public void FontDialog(FontDialog fontdialog)
        {
                richTextBox1.Font = fontdialog.Font;
        }
        public void ColorDialog(ColorDialog colordialog)
        {
            richTextBox1.ForeColor = colordialog.Color;
        }
        public void Save(string SaveFileName)
        {
            if (SaveFileName == null)
            {
                return;
            }
            else
            {
                StreamWriter sw = new StreamWriter(SaveFileName);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                DocName = SaveFileName;
            }
        }
        private void Blank_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsSaved == false)
            {
                if (MessageBox.Show("Do you want save changes in " + this.DocName+ "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Save(this.DocName);
                }
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            sbAmount.Text = "Amount of symbols: " + richTextBox1.Text.Length.ToString();
        }

    }
}
