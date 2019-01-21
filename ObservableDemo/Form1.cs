using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObservableDemo
{
    public partial class Form1 : Form
    {
        ObservableText text;
        public Form1()
        {
            InitializeComponent();

            text = new ObservableText();
            text.Click += new EventHandler(txtEmployeeId_TextChanged);

            ObserverTextBox tbxFirstName = new ObserverTextBox(txtFirstName);
            tbxFirstName.Subscribe(text);
            ObserverTextBox tbxLastName = new ObserverTextBox(txtLastName);
            tbxLastName.Subscribe(text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            text.Notify(String.Format("{0} this is the message", DateTime.Now));
        }

        private void txtEmployeeId_TextChanged(object sender, EventArgs e)
        {
            text.Notify(txtEmployeeId.Text);
        }
    }
}
