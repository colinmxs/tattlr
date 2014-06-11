using System.Collections.Generic;

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
