using AutoMapper;
using WEBAPI.Authorization;
using WEBAPI.Entities;
using WEBAPI.Helpers;
using WEBAPI.Models.FightMatch;
using WEBAPI.Models.Users;

namespace WEBAPI.Services
{
    public interface IFightMatchService
    {
        public IEnumerable<FightMatch> GetAll();
        public FightMatch GetFightMatchById(int id);
        public void Register(FightMatchRequest model);
        public void UpdateFightStatus(FightMatchRequest model);
        public void UpdateFightResult(FightMatchRequest model);
        void Update(int id, FightMatchRequest model);
        void Delete(int id);



    }
    public class FightMatchService : IFightMatchService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public FightMatchService(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public IEnumerable<FightMatch> GetAll()
        {
            return _context.FightMatches;
        }

        public FightMatch GetFightMatchById(int id)
        {
            return getFightMatchById(id);
        }

        public void Register(FightMatchRequest model)
        {
            // validate
            if (_context.FightMatches.Any(x => x.MatchDate == model.FightDate && x.MatchNumber == model.MatchNumber))
                throw new AppException("Fight Number: '" + model.MatchNumber + "' is already exists");

            // validate match number in fightmatchconfig CB-10132023 Check Date if fightmatchconfig is already created
            var fightmatchconfig = _context.FightMatchConfigs.Where(x=>x.MatchDate.Year == model.FightDate.Year
                            && x.MatchDate.Month == model.FightDate.Month
                            && x.MatchDate.Day == model.FightDate.Day).FirstOrDefault();

            if(fightmatchconfig == null)
                throw new AppException("No FightMatch Number found for today. Please start the Fight Match first");

            // map model to new user object
            //var useradmin = _mapper.Map<UserAdmin>(model);

            // hash password
            //useradmin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            FightMatch match = new FightMatch
            {
                MatchDate = model.FightDate,
                MatchNumber = model.MatchNumber,
                MatchStatusId = 0,
                MatchResultId = 0,
            };


            // save user
            _context.FightMatches.Add(match);

            _context.SaveChanges();
        }

        public void UpdateFightStatus(FightMatchRequest model)
        {
            //CB-09302023 Get User via id
            var fight = getFightMatch(model);
            fight.MatchStatusId = (int)model.MatchStatusId;

            _context.FightMatches.Update(fight);
            _context.SaveChanges();
        }
        public void UpdateFightResult(FightMatchRequest model)
        {
            //CB-09302023 Get User via id
            var fight = getFightMatch(model);
            fight.MatchResultId = (int)model.MatchResultId;

            _context.FightMatches.Update(fight);
            _context.SaveChanges();
        }

        public void Update(int id, FightMatchRequest model)
        {
            var fightmatch = getFightMatch(model);
            if (fightmatch == null) throw new KeyNotFoundException("Fight not found");
            _context.FightMatches.Update((FightMatch)fightmatch);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var fight = _context.FightMatches.Find(id);
            if (fight == null) throw new KeyNotFoundException("Fight not found");

            _context.FightMatches.Remove(fight);
            _context.SaveChanges();
        }
        private FightMatch getFightMatch(FightMatchRequest model)
        {
            var fight = _context.FightMatches.Where(x=>x.MatchDate == model.FightDate
             && x.MatchNumber == model.MatchNumber);

            if (fight == null) throw new KeyNotFoundException("Fight not found");

            return (FightMatch)fight;
        }
        private FightMatch getFightMatchById(int id)
        {
            var fight = _context.FightMatches.Find(id);

            if (fight == null) throw new KeyNotFoundException("Fight not found");

            return fight;
        }
    }
}
