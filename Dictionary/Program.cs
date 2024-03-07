using System;
using System.Windows.Forms;

namespace Dictionary
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, ex) => MessageBox.Show(ex.Exception.Message);
            Application.Run(new DictionaryApp());
        }
    }
}