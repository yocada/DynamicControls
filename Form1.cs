using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicControls
{
    public partial class Form1 : Form
    {
        PersonContract test;

        public Form1()
        {
            InitializeComponent();

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(test.getValue("Nombre").ToString());
            MessageBox.Show(test.getValue("Edad").ToString());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            test = new PersonContract(this);
        }
    }
}
