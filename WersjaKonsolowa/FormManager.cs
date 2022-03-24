﻿using System.Windows.Forms;
using WersjaOkienkowa;

namespace WersjaOkienkowa
{
    class FormManager
    {
        Form1 mainForm;
        TextBox[] registryTextBoxes = new TextBox[8];
        RadioButton[] registryRadioButtonesFirst = new RadioButton[8];
        RadioButton[] registryRadioButtonesSecond = new RadioButton[8];
        RadioButton[] commandsRadioButtons = new RadioButton[6];

        public FormManager(Form1 mainForm)
        {
            this.mainForm = mainForm;

            #region form variables
            commandsRadioButtons[0] = mainForm.movRadioButton;
            commandsRadioButtons[1] = mainForm.xchglRadioButton;
            commandsRadioButtons[2] = mainForm.incRadioButton;
            commandsRadioButtons[3] = mainForm.decRadioButton;
            commandsRadioButtons[4] = mainForm.notRadioButton;
            commandsRadioButtons[5] = mainForm.negRadioButton;

            registryTextBoxes[0] = mainForm.textBox1;
            registryTextBoxes[1] = mainForm.textBox2;
            registryTextBoxes[2] = mainForm.textBox3;
            registryTextBoxes[3] = mainForm.textBox4;
            registryTextBoxes[4] = mainForm.textBox5;
            registryTextBoxes[5] = mainForm.textBox6;
            registryTextBoxes[6] = mainForm.textBox7;
            registryTextBoxes[7] = mainForm.textBox8;

            registryRadioButtonesFirst[0] = mainForm.MemoryRadioButton1;
            registryRadioButtonesFirst[1] = mainForm.MemoryRadioButton2;
            registryRadioButtonesFirst[2] = mainForm.MemoryRadioButton3;
            registryRadioButtonesFirst[3] = mainForm.MemoryRadioButton4;
            registryRadioButtonesFirst[4] = mainForm.MemoryRadioButton5;
            registryRadioButtonesFirst[5] = mainForm.MemoryRadioButton6;
            registryRadioButtonesFirst[6] = mainForm.MemoryRadioButton7;
            registryRadioButtonesFirst[7] = mainForm.MemoryRadioButton8;

            registryRadioButtonesSecond[0] = mainForm.MemoryRadioButton9;
            registryRadioButtonesSecond[1] = mainForm.MemoryRadioButton10;
            registryRadioButtonesSecond[2] = mainForm.MemoryRadioButton11;
            registryRadioButtonesSecond[3] = mainForm.MemoryRadioButton12;
            registryRadioButtonesSecond[4] = mainForm.MemoryRadioButton13;
            registryRadioButtonesSecond[5] = mainForm.MemoryRadioButton14;
            registryRadioButtonesSecond[6] = mainForm.MemoryRadioButton15;
            registryRadioButtonesSecond[7] = mainForm.MemoryRadioButton16;
            #endregion
        }

        public void SetTextBoxText(string text, int textBoxIndex)
        {
            registryTextBoxes[textBoxIndex].Text = text.PadLeft(8, '0');
        }

        public string ReturnTextBoxText(int id)
        {
            return registryTextBoxes[id].Text;
        }

        public int[] RetrunCheckedRadioIndexes()
        {
            int[] selectedIndexes = new int[] { -1, -1, -1 };

            for (int i = 0; i < commandsRadioButtons.Length; i++)
            {
                if (commandsRadioButtons[i].Checked)
                {
                    selectedIndexes[0] = i;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (registryRadioButtonesFirst[i].Checked)
                {
                    selectedIndexes[1] = i;
                }
                if (registryRadioButtonesSecond[i].Checked)
                {
                    selectedIndexes[2] = i;
                }
            }

            return selectedIndexes;
        }
    }
}
