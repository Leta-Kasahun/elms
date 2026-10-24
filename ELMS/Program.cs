using System;
using System.Windows.Forms;
using ELMS.Forms;
using ELMS.Services;

namespace ELMS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }

                if (AuthService.Instance.CurrentUser != null)
                {
                    Application.Run(new MainForm());

                    if (AuthService.Instance.CurrentUser != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
