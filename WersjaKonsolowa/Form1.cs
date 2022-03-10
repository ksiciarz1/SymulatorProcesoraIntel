using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WersjaKonsolowa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxArray = new System.Windows.Forms.TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
            radioButtonArray1 = new System.Windows.Forms.RadioButton[] { MemoryRadioButton1, MemoryRadioButton2, MemoryRadioButton3, MemoryRadioButton4, MemoryRadioButton5, MemoryRadioButton6, MemoryRadioButton7, MemoryRadioButton8 };
            radioButtonArray2 = new System.Windows.Forms.RadioButton[] { MemoryRadioButton9, MemoryRadioButton10, MemoryRadioButton11, MemoryRadioButton12, MemoryRadioButton13, MemoryRadioButton14, MemoryRadioButton15, MemoryRadioButton16 };
            RandomizeMemoryCells();
        }
        public void RandomizeMemoryCells()
        {
            for (int i = 0; i < textBoxArray.Length; i++)
            {
                System.Random random = new System.Random();
                textBoxArray[i].Text = System.Convert.ToString(random.Next(255), 2).PadLeft(8, '0');
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
            int memoryCell1, memoryCell2;
            memoryCell1 = WitchRadioButtonIsChecked(0);
            memoryCell2 = WitchRadioButtonIsChecked(1);
            if (memoryCell1 != -1 && memoryCell2 != -1)
            {
                if (movRadioButton.Checked)
                {
                    textBoxArray[memoryCell2].Text = textBoxArray[memoryCell1].Text;
                }
                else if (xchglRadioButton.Checked)
                {
                    string temp = textBoxArray[memoryCell2].Text;
                    textBoxArray[memoryCell2].Text = textBoxArray[memoryCell1].Text;
                    textBoxArray[memoryCell1].Text = temp;
                }
            }
        }

        private int WitchRadioButtonIsChecked(int arrayNumber)
        {
            if (arrayNumber == 0)
            {
                for (int i = 0; i < radioButtonArray1.Length; i++)
                {
                    if (radioButtonArray1[i].Checked)
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < radioButtonArray2.Length; i++)
                {
                    if (radioButtonArray2[i].Checked)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
