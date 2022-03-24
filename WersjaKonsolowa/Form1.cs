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

        private void SimulationButtonClick(object sender, EventArgs e)
        {
            int[] radioChecks = formManager.RetrunCheckedRadioIndexes();
            if (radioChecks.Contains<int>(-1))
            {
                return;
            }
            // TODO:
            // AND
            // OR
            // XOR
            // ADD
            // SUB
            // NEG - UZUPEŁNIENIE DO 2 NEGACJIA I IKREMENTACJA ?
            // KONWERSJA NA/Z 16-WEGO
            // ZROBIĆ SPRAWOZDANIE PDF

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
                case 2:
                    int value = Convert.ToInt32(formManager.ReturnTextBoxText(radioChecks[1]), 2);
                    value++;
                    if (value > 255)
                    {
                        value = 0;
                    }
                    formManager.SetTextBoxText(Convert.ToString(value, 2), radioChecks[1]);
                    break;
                case 3:
                    value = Convert.ToInt32(formManager.ReturnTextBoxText(radioChecks[1]), 2);
                    value--;
                    if (value < 0)
                    {
                        value = 255;
                    }
                    formManager.SetTextBoxText(Convert.ToString(value, 2), radioChecks[1]);
                    break;
                case 4:
                    value = Convert.ToInt32(formManager.ReturnTextBoxText(radioChecks[1]), 2);
                    value = Math.Abs(value - 255);
                    formManager.SetTextBoxText(Convert.ToString(value, 2), radioChecks[1]);
                    break;
                case 5:
                    value = Convert.ToInt32(formManager.ReturnTextBoxText(radioChecks[1]), 2);
                    value = Math.Abs(value - 255);
                    if (value % 2 != 0)
                    {
                        value++;
                    }
                    if (value > 255)
                    {
                        value = 0;
                    }
                    formManager.SetTextBoxText(Convert.ToString(value, 2), radioChecks[1]);
                    break;
                case 6:
                    //AND
                    byte byteValue1 = Convert.ToByte(formManager.ReturnTextBoxText(radioChecks[1]), 2);
                    byte byteValue2 = Convert.ToByte(formManager.ReturnTextBoxText(radioChecks[2]), 2);
                    formManager.SetTextBoxText(Convert.ToString(byteValue1 & byteValue2, 2), radioChecks[1]);
                    break;
                case 7:
                    //OR
                    byteValue1 = Convert.ToByte(formManager.ReturnTextBoxText(radioChecks[1]), 2);
                    byteValue2 = Convert.ToByte(formManager.ReturnTextBoxText(radioChecks[2]), 2);
                    formManager.SetTextBoxText(Convert.ToString(byteValue1 | byteValue2, 2), radioChecks[1]);
                    break;
                case 8:
                    //XOR
                    byteValue1 = Convert.ToByte(formManager.ReturnTextBoxText(radioChecks[1]), 2);
                    byteValue2 = Convert.ToByte(formManager.ReturnTextBoxText(radioChecks[2]), 2);
                    formManager.SetTextBoxText(Convert.ToString(byteValue1 ^ byteValue2, 2), radioChecks[1]);
                    break;
                case 9:
                    //ADD
                    int value1 = Convert.ToInt32(formManager.ReturnTextBoxText(radioChecks[1]), 2);
                    int value2 = Convert.ToInt32(formManager.ReturnTextBoxText(radioChecks[2]), 2);
                    int valueToSet = value1 + value2;
                    if (valueToSet > 255)
                    {
                        valueToSet -= 255;
                    }
                    formManager.SetTextBoxText(Convert.ToString(valueToSet, 2), radioChecks[1]);
                    break;
                case 10:
                    //SUB
                    value1 = Convert.ToInt32(formManager.ReturnTextBoxText(radioChecks[1]), 2);
                    value2 = Convert.ToInt32(formManager.ReturnTextBoxText(radioChecks[2]), 2);
                    valueToSet = value1 - value2;
                    if (valueToSet < 0)
                    {
                        valueToSet += 255;
                    }
                    formManager.SetTextBoxText(Convert.ToString(valueToSet, 2), radioChecks[1]);
                    break;

                default:
                    break;
            }

        }
    }
}
