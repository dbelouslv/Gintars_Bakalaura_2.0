using BS.BusinessLogic;
using BS.BusinessLogic.Services;
using Ninject;
using System;
using System.Windows.Forms;

namespace BasketballStats
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var kernel = new StandardKernel(new Bindings());
            var teamService = kernel.Get<ITeamService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BasketballStats(teamService));
        }
    }
}
