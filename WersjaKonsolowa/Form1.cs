using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WersjaOkienkowa
{
    public partial class Form1 : Form
    {
        FormManager formManager;
        public Form1()
        {
            InitializeComponent();
            formManager = new FormManager(this);
            RandomizeMemoryCells();
        }
        public void RandomizeMemoryCells()
        {
            for (int i = 0; i < 8; i++)
            {
                Random random = new Random();
                formManager.SetTextBoxText(System.Convert.ToString(random.Next(255), 2), i);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void SimulationButtonClick(object sender, EventArgs e)
        {
            int[] radioChecks = formManager.RetrunCheckedRadioIndexes();
            if (radioChecks.Contains<int>(-1))
            {
                return;
            }
            switch (radioChecks[0])
            {
                case 0:
                    formManager.SetTextBoxText(formManager.ReturnTextBoxText(radioChecks[1]), radioChecks[2]);
                    break;
                case 1:
                    string temp = formManager.ReturnTextBoxText(radioChecks[1]);
                    formManager.SetTextBoxText(formManager.ReturnTextBoxText(radioChecks[2]), radioChecks[1]);
                    formManager.SetTextBoxText(temp, radioChecks[2]);
                    break;
                default:
                    break;
            }

        }

        //private int WitchRadioButtonIsChecked(int arrayNumber)
        //{
        //    if (arrayNumber == 0)
        //    {
        //        for (int i = 0; i < radioButtonArray1.Length; i++)
        //        {
        //            if (radioButtonArray1[i].Checked)
        //            {
        //                return i;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < radioButtonArray2.Length; i++)
        //        {
        //            if (radioButtonArray2[i].Checked)
        //            {
        //                return i;
        //            }
        //        }
        //    }
        //    return -1;
        //}
    }
}
