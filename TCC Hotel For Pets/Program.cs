using System;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.Telas;
using TCC_Hotel_For_Pets.Telas.Cadastrar_Funcionário;
using TCC_Hotel_For_Pets.Telas.Controle_Fornecedor;
using TCC_Hotel_For_Pets.Telas.Controle_Funcionário;
using TCC_Hotel_For_Pets.Telas.Splash;

namespace TCC_Hotel_For_Pets
{
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
            Application.Run(new frmSplash());
        }
    }
}
