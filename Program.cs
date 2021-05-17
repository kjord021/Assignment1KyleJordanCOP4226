using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1KyleJordan
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MyForm(args[0], args[1]));
            }
            catch
            {
                
                Application.Run(new MyForm("My Windows App!", "Kyle Jordan"));
            }


        }
    }
}
