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
                //formManager.SetTextBoxText(System.Convert.ToString(random.Next(255), 2), i);
                SetBothTextBoxes(FormatNumberToRegistry(random.Next(255)), i);
            }
        }

        /// <summary>
        /// Converts number to string in binary or hexagonal format
        /// </summary>
        /// <param name="numberToFormat">number to be formatet</param>
        /// <param name="binary">if format should be binary or hexagonal</param>
        /// <returns>formatet string</returns>
        public string FormatNumberToRegistry(int numberToFormat, bool binary = true)
        {
            string stringToFormat = binary ? Convert.ToString(numberToFormat, 2) : Convert.ToString(numberToFormat, 16);
            return FormatNumberToRegistry(stringToFormat, binary);
        }

        public string FormatNumberToRegistry(string stringToFormat, bool binary = true)
        {
            string result = stringToFormat;

            if (binary)
            {
                int diffrance = result.Length - 8;
                if (diffrance < 0)
                    diffrance = 0;
                result = result.Substring(diffrance, result.Length - diffrance);
            }
            else
            {
                int diffrance = result.Length - 2;
                if (diffrance < 0)
                    diffrance = 0;
                result = result.Substring(diffrance, result.Length - diffrance);
            }

            //result = binary ? result.Substring(result.Length - 8) : result.Substring(result.Length - 2);

            return result;
        }

        public string ReturnTextBoxTextAndFormat(int id, bool binary = true)
        {
            string temp = formManager.ReturnTextBoxText(id, binary);
            string result = FormatNumberToRegistry(temp, binary);
            return result;
        }

        public void SetBothTextBoxes(string value, int idOfTextBox)
        {
            int intValue = Convert.ToInt32(value, 2);
            SetBothTextBoxes(intValue, idOfTextBox);
        }
        public void SetBothTextBoxes(int value, int idOfTextBox)
        {
            formManager.SetTextBoxText(FormatNumberToRegistry(Convert.ToString(value, 2)), idOfTextBox);
            formManager.SetTextBoxText(FormatNumberToRegistry(Convert.ToString(value, 16), false), idOfTextBox, false);
        }

        private void SimulationButtonClick(object sender, EventArgs e)
        {
            int[] radioChecks = formManager.RetrunCheckedRadioIndexes();
            if (radioChecks.Contains<int>(-1))
            {
                return;
            }
            // TODO: 
            // KONWERSJA NA/Z 16-WEGO
            // ZROBIĆ SPRAWOZDANIE PDF

            switch (radioChecks[0])
            {
                case 0: // MOV
                    SetBothTextBoxes(ReturnTextBoxTextAndFormat(radioChecks[1]), radioChecks[2]);
                    break;
                case 1: // XCHGL
                    string temp = FormatNumberToRegistry(ReturnTextBoxTextAndFormat(radioChecks[1]));
                    formManager.SetTextBoxText(ReturnTextBoxTextAndFormat(radioChecks[2]), radioChecks[1]);
                    formManager.SetTextBoxText(temp, radioChecks[2]);
                    break;
                case 2: // INC
                    int value = Convert.ToInt32(ReturnTextBoxTextAndFormat(radioChecks[1]), 2);
                    value++;
                    SetBothTextBoxes(value, radioChecks[1]);
                    break;
                case 3: // DEC
                    value = Convert.ToInt32(ReturnTextBoxTextAndFormat(radioChecks[1]), 2);
                    value--;
                    SetBothTextBoxes(value, radioChecks[1]);
                    break;
                case 4: // NOT
                    value = Convert.ToInt32(ReturnTextBoxTextAndFormat(radioChecks[1]), 2);
                    value = Math.Abs(value - 255);
                    SetBothTextBoxes(value, radioChecks[1]);
                    break;
                case 5: // NEG
                    value = Convert.ToInt32(ReturnTextBoxTextAndFormat(radioChecks[1]), 2);
                    value = Math.Abs(value - 255);
                    if (value % 2 != 0)
                        value++;
                    SetBothTextBoxes(value, radioChecks[1]);
                    break;
                case 6:  // AND
                    byte byteValue1 = Convert.ToByte(ReturnTextBoxTextAndFormat(radioChecks[1]), 2);
                    byte byteValue2 = Convert.ToByte(ReturnTextBoxTextAndFormat(radioChecks[2]), 2);
                    SetBothTextBoxes(Convert.ToString(byteValue1 & byteValue2, 2), radioChecks[1]);
                    break;
                case 7:  // OR
                    byteValue1 = Convert.ToByte(ReturnTextBoxTextAndFormat(radioChecks[1]), 2);
                    byteValue2 = Convert.ToByte(ReturnTextBoxTextAndFormat(radioChecks[2]), 2);
                    SetBothTextBoxes(Convert.ToString(byteValue1 | byteValue2, 2), radioChecks[1]);
                    break;
                case 8:  // XOR
                    byteValue1 = Convert.ToByte(ReturnTextBoxTextAndFormat(radioChecks[1]), 2);
                    byteValue2 = Convert.ToByte(ReturnTextBoxTextAndFormat(radioChecks[2]), 2);
                    SetBothTextBoxes(Convert.ToString(byteValue1 ^ byteValue2, 2), radioChecks[1]);
                    break;
                case 9:  // ADD
                    int value1 = Convert.ToInt32(ReturnTextBoxTextAndFormat(radioChecks[1]), 2);
                    int value2 = Convert.ToInt32(ReturnTextBoxTextAndFormat(radioChecks[2]), 2);
                    int valueToSet = value1 + value2;
                    SetBothTextBoxes(Convert.ToString(valueToSet, 2), radioChecks[1]);
                    break;
                case 10: // SUB
                    value1 = Convert.ToInt32(ReturnTextBoxTextAndFormat(radioChecks[1]), 2);
                    value2 = Convert.ToInt32(ReturnTextBoxTextAndFormat(radioChecks[2]), 2);
                    valueToSet = value1 - value2;
                    SetBothTextBoxes(Convert.ToString(valueToSet, 2), radioChecks[1]);
                    break;

                default:
                    break;
            }

        }
        private void UnsellectEvent(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                SetBothTextBoxes(ReturnTextBoxTextAndFormat(i), i);
            }
        }
    }
}
