using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mediatek86
{
    /// <summary>
    /// Application de gestion du personnel d'une médiathèque
    /// </summary>
    internal class NamespaceDoc
    {

    }

    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAuthentification());
        }
    }
}
