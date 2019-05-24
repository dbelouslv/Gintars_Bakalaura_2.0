using BS.EntityData.Context;
using BS.BusinessLogic.Services;
using Ninject.Modules;

namespace BS.BusinessLogic
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataContext>().To<DataContext>();
            Bind<ITeamService>().To<TeamService>();
            Bind<IParticapantService>().To<ParticapantService>();
            Bind<IMatchService>().To<MatchService>();
        }
    }
}
