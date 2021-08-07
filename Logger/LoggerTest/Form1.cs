using nLogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerTest
{
    public partial class Form1 : Form
    {
        DirLogger dlog;
        public Form1()
        {
            InitializeComponent();
            string pathDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logffsefesfefsefefef");
            dlog = new DirLogger(pathDir , "aaaasefef", TimeMark.pre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            textBox1.Text = r.Next(0, 100).ToString();
            dlog.write(textBox1.Text);

        }
    }
}
