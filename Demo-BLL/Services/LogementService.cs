using DAL = Demo_DAL.Entities;
using Demo_BLL.Entities;
using Demo_Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Services
{
    public class LogementService : ILogementRepository<Logement, int>
    {
        private readonly ILogementRepository<DAL.Logement, int> _repository;

        public LogementService(ILogementRepository<DAL.Logement, int> repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Logement> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public IEnumerable<Logement> GetMyLogement(int id)
        {
            return _repository.GetMyLogement(id).Select(e => e.ToBLL());
        }

        public IEnumerable<Logement> GetLogementMonth(DateTime month)
        {
            return _repository.GetByDate(month).Select(e => e.ToBLL());
        }
        public IEnumerable<Logement> GetLogementTwoDate(DateTime date_deb, DateTime date_fin)
        {
            return _repository.GetLogementTwoDate(date_deb,date_fin).Select(e => e.ToBLL());
        }


        public Logement Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Logement> GetByDate(DateTime date)
        {
            return _repository.GetByDate(date).Select(e => e.ToBLL());
        }

        public IEnumerable<Logement> GetBySpectacle(int idSpec)
        {
            return _repository.GetBySpectacle(idSpec).Select(e => e.ToBLL());
        }

        public int Insert(Logement entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(int id, Logement entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }


    }
}
