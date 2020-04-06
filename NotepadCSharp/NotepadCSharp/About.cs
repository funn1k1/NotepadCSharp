﻿using System;
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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void LinkLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                VisitLink();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex + "Unable to open link that was clicked");
            }
        }
        private void VisitLink()
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.notepadcsharp.com");

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
