using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exCloning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_getData_Click(object sender, EventArgs e)
        {
            List<_Assembly> data = TeklaHandler.getPartInfo();
            string report = DataSorting.main(data);
            print(report);
        }

        public void print(string text)
        {
            txt_report.Clear();
            txt_report.AppendText(text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<_Assembly> data = TeklaHandler.getPartInfo();
            Stuff2.main(data);
        }
    }
}
