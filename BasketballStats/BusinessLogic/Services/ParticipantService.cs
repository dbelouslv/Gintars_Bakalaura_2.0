using BS.EntityData.Context;
using System.Linq;

namespace BS.BusinessLogic.Services
{
    public class ParticapantService : BaseService<Particapant>, IParticapantService
    {
        public ParticapantService(IDataContext dataContext) : base(dataContext)
        {
        }

        public Particapant CreateParticipant(string name, string surname, int number, int teamId, int matchId)
        {
            var entity = new Particapant
            {
                FirstName = name, 
                LastName = surname,
                TeamId = teamId,
                Number = number,
                MatchId = matchId
            };

            Add(entity);

            return entity;
        }

        public void RemoveParticipant(int id)
        {
            Delete(Dbset.Where(w => w.Id == id));
        }
    }

    public interface IParticapantService : IService<Particapant>
    {
        Particapant CreateParticipant(string name, string surname, int number, int teamId, int matchId);
        void RemoveParticipant(int id);
    }
}
