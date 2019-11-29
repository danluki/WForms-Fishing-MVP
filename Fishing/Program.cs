using Fishing.Presenter;
using System;
using System.Windows.Forms;

namespace Fishing {

    internal static class Program {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var MenuView = new Menu();

            var presenter = new MenuPresenter(MenuView);
            Application.Run(MenuView);
        }
    }
}