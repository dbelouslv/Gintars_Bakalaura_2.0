using BS.EntityData.Context;
using System;
using System.Linq;

namespace BS.BusinessLogic.Services
{
    public class TeamService : BaseService<Team>, ITeamService
    {
        public TeamService(IDataContext dataContext) : base(dataContext)
        {
        }

        public string[] GetTeams()
        {
            return Dbset.Select(s => s.Name).ToArray();
        }

        public bool CreateTeam(string teamName)
        {
            if (!Dbset.Any(a => a.Name.ToLower() == teamName.ToLower()))
            {
                Add(new Team
                {
                    CreateDate = DateTime.Now,
                    Name = teamName
                });

                return true;
            }

            return false;
        }

        public Team GetTeamByName(string name)
        {
            return Dbset.FirstOrDefault(w => w.Name == name);
        }
    }

    public interface ITeamService : IService<Team>
    {
        string[] GetTeams();
        bool CreateTeam(string teamName);
        Team GetTeamByName(string name);
    }
}
