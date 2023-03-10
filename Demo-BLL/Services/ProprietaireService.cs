using Demo_BLL.Entities;
using Demo_Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Services
{
    public class ProprietaireService 
    {
        private readonly IProprietaireRepository<Demo_DAL.Entities.Proprietaire, int> _repository;

        public ProprietaireService(IProprietaireRepository<Demo_DAL.Entities.Proprietaire, int> repository)
        {
            _repository = repository;
        }

        public int Insert(Proprietaire entity)
        {
            return _repository.Insert(entity.ToDAL());
        }
    }
}
