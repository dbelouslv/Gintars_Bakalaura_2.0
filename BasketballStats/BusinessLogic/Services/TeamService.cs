using BS.BusinessLogic.Services;
using BS.EntityData.Context;
using System;
using System.Linq;

namespace EP.BusinessLogic.Services
{
    public class TeamService : BaseService<Team>, ITeamService
    {
        public TeamService(IDataContext dataContext) : base(dataContext)
        {
        }

        public bool CreateTeam(string teamName)
        {
            if (!Dbset.Any(a => a.Name.ToLower() == teamName.ToLower()))
            {
                Dbset.Add(new Team
                {
                    CreateDate = DateTime.Now,
                    Name = teamName
                });

                return true;
            }

            return false;
        }
    }

    public interface ITeamService : IService<Team>
    {
        bool CreateTeam(string teamName);
    }
}
