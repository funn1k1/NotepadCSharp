using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadCSharp
{
    public partial class Frmmain : Form
    {
        public Frmmain()
        {
            InitializeComponent();
        }
        private int openDoc;
        private void MnuNew_Click(object sender, EventArgs e)
        {
            blank frm = new blank();
            frm.DocName = "Документ "+ ++openDoc;
            frm.Text = frm.DocName;
            frm.MdiParent = this;
            frm.WindowState =  FormWindowState.Maximized;
            frm.Show();
        }

        private void MnuArrangeIcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void MnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void MnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void MnuCut_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Cut();

        }

        private void MnuCopy_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Copy();
        }

        private void MnuSelectAll_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.SelectAll();
        }

        private void MnuPaste_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Paste();
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Delete();
        }

        private void MnuOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = new blank();
                frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this;
                frm.DocName = openFileDialog1.FileName;
                frm.Text = frm.DocName;
                frm.Show();
            }
            mnuSave.Enabled = true;
        }

        private void MnuSave_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Save(frm.DocName);
            frm.IsSaved = true;
        }

        private void MnuSaveAs_Click(object sender, EventArgs e)
        {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    blank frm = (blank)(this.ActiveMdiChild);
                    frm.Save(saveFileDialog1.FileName);
                    frm.MdiParent = this;
                    frm.DocName = saveFileDialog1.FileName;
                    frm.Text = frm.DocName;
                }
            mnuSave.Enabled = true;
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MnuFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)(ActiveMdiChild);
                frm.FontDialog(fontDialog1);
            }
        }

        private void MnuColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)(ActiveMdiChild);
                frm.ColorDialog(colorDialog1);
            }
        }

        private void MnuFind_Click(object sender, EventArgs e)
        {
            FindForm frm = new FindForm();
            if (frm.ShowDialog(this) == DialogResult.Cancel) return;
            blank form = (blank)this.ActiveMdiChild;
            form.MdiParent = this;
            int start = form.richTextBox1.SelectionStart;
            form.richTextBox1.Find(frm.FindText, start, frm.FindCondition);
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.Show();
        }
    }
}
