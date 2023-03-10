using DAL = Demo_DAL.Entities;
using Demo_BLL.Entities;
using Demo_Common.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Services
{
    public class TypeLogementService : ITypeLogementRepository<TypeLogement, int>
    {
        private readonly ITypeLogementRepository<DAL.TypeLogement, int> _repository;

        public TypeLogementService(ITypeLogementRepository<DAL.TypeLogement, int> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TypeLogement> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public TypeLogement Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }
    }
}
