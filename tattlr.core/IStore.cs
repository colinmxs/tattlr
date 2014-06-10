using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tattlr.core
{
    public interface IStore<TDomainObject>
    {
        void Save(TDomainObject entity);
        TDomainObject Get(int id);
        void Delete(int id);
    }
}
