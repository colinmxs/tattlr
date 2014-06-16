using System.Collections.Generic;

namespace tattlr.core
{
    public interface IStore<TDomainObject, TId>
    {
        TDomainObject Save(TDomainObject entity);
        TDomainObject Get(TId id);
        IEnumerable<TDomainObject> GetAll();
        void Delete(TId id);
    }
}
