using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            U04uzGEntities entities = new U04uzGEntities();
            entities.addresses?.ToList();
            address address = new address();
            address.address1 = "206 S Houston School Road";
            entities.addresses.Add(address);
            entities.SaveChanges();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
