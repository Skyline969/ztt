using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZTT
{
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void DebugWindow_Load(object sender, EventArgs e)
        {

        }

        public void addDebug(string message)
        {
            message.Replace("\n", Environment.NewLine);
            txtDebug.Text += message + Environment.NewLine;
            txtDebug.SelectionStart = txtDebug.Text.Length;
            txtDebug.ScrollToCaret();
        }
    }
}
