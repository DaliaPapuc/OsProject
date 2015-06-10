using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    //ljhjlhjkhhj
    //git add . - adauga
    //git commit -m "comentariu" pune un nume commituului
    //git pull - ia chestiile noi de pe repo
    //rezolva conflictele in caz ca exista
    //git push pune ce ai facut tu si face merge
    //in caz ca aici nu vrea git push si tipa mai bagi un git add . si git commit -m "acelasicomentariucamaidevreme" si git push

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
