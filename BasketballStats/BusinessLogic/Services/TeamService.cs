using BS.EntityData.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BS.BusinessLogic.Services
{
    public class TeamService : BaseService<Team>, ITeamService
    {
        public TeamService(IDataContext dataContext) : base(dataContext)
        {
        }

        public List<Team> GetTeams()
        {
            return Dbset.ToList();
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
    }

    public interface ITeamService : IService<Team>
    {
       List<Team> GetTeams();
       bool CreateTeam(string teamName);        
    }
}
