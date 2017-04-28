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
        private List<_Assembly> _data;

        public Form1()
        {
            InitializeComponent();
            cb_swapFrom.DataSource = Enum.GetValues(typeof(TopInFormEnum));
            cb_selectFrom.DataSource = Enum.GetValues(typeof(TopInFormEnum));
            _data = new List<_Assembly>();
            controlsToggle(false);
        }

        private void controlsToggle(bool status)
        {
            btn_select.Enabled = status;
            btn_swap.Enabled = status;
            cb_selectFrom.Enabled = status;
            cb_swapFrom.Enabled = status;
            txt_swapTo.Enabled = status;
        }

        private void btn_getSelected_Click(object sender, EventArgs e)
        {
            txt_report.Text = "";

            try
            {
                getSelected();
            }
            catch
            {
                print("[ERROR - 1] Could not connect to Tekla");
            }

            if (_data.Count > 0)
            {
                controlsToggle(true);
            }
            else
            {
                controlsToggle(false);
            }
        }


        private void getSelected()
        {
            _data = TeklaHandler.getPartInfo();
            string report = DataSorting.main(_data);
            print(report);
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            try
            {
                select();
            }
            catch
            {
                print("[ERROR - 2] Could not connect to Tekla");
            }
        }

        private void select()
        {
            string statusString = cb_selectFrom.SelectedValue.ToString();
            TopInFormEnum status = (TopInFormEnum)Enum.Parse(typeof(TopInFormEnum), statusString);
            List<_Assembly> filteredAssemblys = DataSorting.filterAssemblysByTIF(_data, status);
            string report = "Selected " + filteredAssemblys.Count.ToString() + " assemblys \n";
            TeklaHandler.selectAssemblys(filteredAssemblys);
            print(report);
        }

        private void selectAll()
        {
            string statusString = TopInFormEnum.ALL.ToString();
            TopInFormEnum status = (TopInFormEnum)Enum.Parse(typeof(TopInFormEnum), statusString);
            List<_Assembly> filteredAssemblys = DataSorting.filterAssemblysByTIF(_data, status);
            TeklaHandler.selectAssemblys(filteredAssemblys);
        }

        private void btn_swap_Click(object sender, EventArgs e)
        {
            try
            {
                swap();
                selectAll();
                getSelected();
            }
            catch
            {
                print("[ERROR - 3] Could not connect to Tekla");
            }
        }

        private void swap()
        {
            string statusString = cb_swapFrom.SelectedValue.ToString();
            TopInFormEnum status = (TopInFormEnum)Enum.Parse(typeof(TopInFormEnum), statusString);
            List<_Assembly> filteredAssemblys = DataSorting.filterAssemblysByTIF(_data, status);
            SwapMainLoop.main(filteredAssemblys);
        }

        public void print(string text)
        {
            txt_report.AppendText(text + "\n");
        }

        private void cb_swapFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTxt();
        }

        private void changeTxt()
        {
            string opposite = "";

            if (cb_swapFrom.SelectedValue.ToString() == "FRONT")
            {
                opposite = TopInFormEnum.BACK.ToString();
            }
            else if (cb_swapFrom.SelectedValue.ToString() == "BACK")
            {
                opposite = TopInFormEnum.FRONT.ToString();
            }
            else if (cb_swapFrom.SelectedValue.ToString() == "START")
            {
                opposite = TopInFormEnum.END.ToString();
            }
            else if (cb_swapFrom.SelectedValue.ToString() == "END")
            {
                opposite = TopInFormEnum.START.ToString();
            }
            else if (cb_swapFrom.SelectedValue.ToString() == "TOP")
            {
                opposite = TopInFormEnum.BOTTOM.ToString();
            }
            else if (cb_swapFrom.SelectedValue.ToString() == "BOTTOM")
            {
                opposite = TopInFormEnum.TOP.ToString();
            }
            else if (cb_swapFrom.SelectedValue.ToString() == "NOT_SET")
            {
                opposite = TopInFormEnum.NOT_SET.ToString();
            }

            txt_swapTo.Text = opposite;
        }
    }
}
