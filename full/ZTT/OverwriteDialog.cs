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
    public partial class OverwriteDialog : Form
    {
        public int Result;

        public OverwriteDialog(string message)
        {
            InitializeComponent();
            txtMessage.Text = message;
        }

        private void btnOverwrite_Click(object sender, EventArgs e)
        {
            Result = OverwriteDialogResponse.Overwrite;
            Close();
        }

        private void btnOverwriteAll_Click(object sender, EventArgs e)
        {
            Result = OverwriteDialogResponse.OverwriteAll;
            Close();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            Result = OverwriteDialogResponse.Skip;
            Close();
        }

        private void btnSkipAll_Click(object sender, EventArgs e)
        {
            Result = OverwriteDialogResponse.SkipAll;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Result = OverwriteDialogResponse.Cancel;
            Close();
        }
    }

    static class OverwriteDialogResponse
    {
        public const int Cancel = 0;
        public const int Overwrite = 1;
        public const int OverwriteAll = 2;
        public const int Skip = 3;
        public const int SkipAll = 4;
    }
}
