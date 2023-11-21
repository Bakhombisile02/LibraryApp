using DeweyDecLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class FindingCallNumber : UserControl
    {
        private FindingCallNum _callNum = new FindingCallNum();
        public FindingCallNumber()
        {
            InitializeComponent();
            _callNum.loadtree();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
