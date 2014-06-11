using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tattlr.core
{
    public interface IStore<TDomainObject>
    {
        TDomainObject Save(TDomainObject entity);
        TDomainObject Get(int id);
        IEnumerable<TDomainObject> GetAll();
        void Delete(int id);
    }
}
