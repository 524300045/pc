using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WmsApp
{
    public partial class WeightForm : TabWindow
    {
        public WeightForm()
        {
            InitializeComponent();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void WeightForm_Load(object sender, EventArgs e)
        {
            tbWeight.Focus();
        }
    }
}
