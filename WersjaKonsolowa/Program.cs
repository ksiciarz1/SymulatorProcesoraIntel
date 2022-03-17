using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WersjaOkienkowa
{
    // TODO:
    // INC - IKREMENTUJ 
    // DEC - DEKREMENTUJ
    // NOT - NEGACJA zamienia 1 na 0 i 0 na 1
    // NEG - UZUPE£NIENIE DO 2 NEGACJIA I IKREMENTACJA
    // ZROBIÆ SPRAWOZDANIE PDF
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 mainForm = new Form1();
            Application.Run(mainForm);
            FormManager formManager = new FormManager(mainForm);
        }
    }
}
