using BS.EntityData.Context;
using BusinessLogic.Model;
using System;
using System.Collections.Generic;
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

        public Match GetMatch(int id)
        {
            return DataContext.Matches
                .Include("TeamOne")
                .Include("TeamTwo")
                .Include("Participants")
                .FirstOrDefault(w => w.Id == id);
        }

        public List<BasicModel> GetMatchesForSaving(DateTime? date = null)
        {
            var matches = Dbset.Where(w => w.Participants.Count > 0 && w.TeamTwo != null && w.TeamOne != null).ToList();

            if (date.HasValue)
                matches = matches.Where(w => w.Date.Value.Date == date.Value.Date).ToList();

            matches = matches.OrderByDescending(o => o.Date).Take(15).ToList();

            var result = new List<BasicModel>();
            foreach (var match in matches)
            {
                result.Add(new BasicModel
                {
                    Name = $"{match.Date.Value.ToShortDateString()}: {match.TeamOne.Name} " +
                    $"{match.Participants.Where(w => w.TeamId == match.TeamOneId).Sum(s => s.Points)} " +
                    $" : {match.Participants.Where(w => w.TeamId == match.TeamTwoId).Sum(s => s.Points)} " +
                    $" {match.TeamTwo.Name}",
                    Id = match.Id
                });
            }

            return result;
        }
    }

    public interface IMatchService : IService<Match>
    {
        Match CreateMatch();
        void UpdateMath(Match activeMatch);
        Match GetMatch(int id);
        List<BasicModel> GetMatchesForSaving(DateTime? date = null);
    }
}
