using AutoMapper;
using WEBAPI.Entities;
using WEBAPI.Helpers;
using WEBAPI.Models.MatchStatus;

namespace WEBAPI.Services
{
    public interface IMatchStatusService
    {
        IEnumerable<MatchStatusConfig> GetAll();
        MatchStatusConfig GetById(int id);
        void Create(string status);
        void Update(int id,UpdateRequest model);
        void Delete(int id);        
    }
    public class MatchStatusService : IMatchStatusService
    {
        private DataContext _context;
            private readonly IMapper _mapper;

        public MatchStatusService(
            DataContext context,
                IMapper mapper)
        {
                _context = context;
                _mapper = mapper;
        }
        public void Create(string Status)
        {
            //CB-10042023 Validate if exist value
            if (_context.MatchStatusConfigs.Any(x => x.Status == Status))
                throw new AppException("Status is already exists. Please check your entry");
            
            _context.MatchStatusConfigs.Add(new MatchStatusConfig() { Status = Status });
            _context.SaveChanges();
        }

        public IEnumerable<MatchStatusConfig> GetAll()
        {
            return _context.MatchStatusConfigs;
        }
        public MatchStatusConfig GetById(int id)
        {
            return getMatchStatus(id);
        }

        public void Update(int id, UpdateRequest model)
        {
            var matchstatus = getMatchStatus(id);

            // copy model to user and save
            _mapper.Map(model, matchstatus);
            _context.MatchStatusConfigs.Update(matchstatus);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var matchStatus = getMatchStatus(id);
            _context.MatchStatusConfigs.Remove(matchStatus);
            _context.SaveChanges();
        }
        private MatchStatusConfig getMatchStatus(int id)
        {
            var matchresult = _context.MatchStatusConfigs.Find(id);
            if (matchresult == null) throw new KeyNotFoundException("User not found");
            return matchresult;
        }       
    }    
}
