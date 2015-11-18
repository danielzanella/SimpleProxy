using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleProxy.Example
{
    public partial class BarDialog : Form
    {
        public BarDialog()
        {
            InitializeComponent();
        }

        public static string ShowDialog(string bar) 
        {
            BarDialog barDlg = new BarDialog();

            barDlg.txtBar.Text = bar ?? string.Empty;

            DialogResult result = barDlg.ShowDialog();

            if (result == DialogResult.Cancel) return null;

            return barDlg.txtBar.Text;
        }
    }
}
