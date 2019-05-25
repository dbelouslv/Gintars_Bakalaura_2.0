using BS.EntityData.Context;
using System;
using System.Linq;

namespace BS.BusinessLogic.Services
{
    public class MatchService : BaseService<Match>, IMatchService
    {
        public MatchService(IDataContext dataContext) : base(dataContext)
        {
        }

        public Match CreateMatch()
        {
            var entity = new Match
            {
                Date = DateTime.Now
            };

            Add(entity);

            return entity;
        }

        public void UpdateMath(Match activeMatch)
        {
            Update(activeMatch);
        }

        public Match GetMath(int id)
        {
            return DataContext.Matches
                .Include("TeamOne")
                .Include("TeamTwo")
                .Include("Participants")
                .FirstOrDefault(w => w.Id == id);
        }
    }

    public interface IMatchService : IService<Match>
    {
        Match CreateMatch();
        void UpdateMath(Match activeMatch);
        Match GetMath(int id);
    }
}
