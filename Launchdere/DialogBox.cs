using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launchdere
{
    public partial class DialogBox : Form
    {
        public DialogBox()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            label1.Text = text;
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }

        public void AddCancelEvent(EventHandler handler)
        {
            button1.Click += handler;
        }

        private void DialogBox_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
