using Demo_BLL.Entities;
using Demo_Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Services
{
    public class ReservationService : IReservationRepository<Reservation, int>
    {
        private readonly IReservationRepository<Demo_DAL.Entities.Reservation, int> _repository;
        private readonly ILogementRepository<Demo_DAL.Entities.Logement, int> _repr_repository;

        public ReservationService(IReservationRepository<Demo_DAL.Entities.Reservation, int> repository, ILogementRepository<Demo_DAL.Entities.Logement, int> repr_repository)
        {
            _repository = repository;
            _repr_repository = repr_repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Reservation> GetMyReservation(int id)
        {
            return _repository.GetMyReservation(id).Select(e => e.ToBLL());
        }

        public IEnumerable<Reservation> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public IEnumerable<Reservation> GetReservationLogement(int id)
        {
            return _repository.GetReservationLogement(id).Select(e => e.ToBLL());
        }

        public Reservation Get(int id)
        {
            Reservation entity = _repository.Get(id).ToBLL();
           // entity.representations = _repr_repository.GetByReservation(id).Select(e => e.ToBLL());
            return entity;
        }

        public int Insert(Reservation entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(int id, Reservation entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }
    }
}
