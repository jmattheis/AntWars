using System;
using System.Windows.Forms;

namespace AntWars {

    static class Program {

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigurationPanel f = new ConfigurationPanel();
            Application.Run(f);
        }
    }
}
