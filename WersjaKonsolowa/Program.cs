using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WersjaOkienkowa
{
    // TODO:
    // AND
    // OR
    // XOR
    // ADD
    // SUB
    // NEG - UZUPE£NIENIE DO 2 NEGACJIA I IKREMENTACJA ?
    // ZROBIÆ SPRAWOZDANIE PDF
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 mainForm = new Form1();
            Application.Run(mainForm);
        }
    }
}
