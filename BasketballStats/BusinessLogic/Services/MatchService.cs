using BS.EntityData.Context;
using System;

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
    }

    public interface IMatchService : IService<Match>
    {
        Match CreateMatch();
    }
}
