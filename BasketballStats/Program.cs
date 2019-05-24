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
            var participantService = kernel.Get<IParticapantService>();
            var matchService = kernel.Get<IMatchService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BasketballStats(teamService, participantService, matchService));
        }
    }
}
