using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tattlr.core;
using tattlr.data.Models;

namespace tattlr.data.Repositories
{
    public class MockRepo<TDomain, TId> : IStore<TDomain, TId> where TDomain : ITrackableEntity<TId>
    {
        private Dictionary<TId, TDomain> Entities { get; set; }
        #region IStore<TDomain, TId> Members

        public MockRepo(Dictionary<TId, TDomain> entities)
        {
            Entities = entities;
        }
        public MockRepo()
        {

        }
        public TDomain Save(TDomain entity)
        {
            Entities.Add(entity.Id,entity);
            return entity;
        }

        public TDomain Get(TId id)
        {
            return Entities.Where(tdomain => tdomain.Key.Equals(id))
                .SingleOrDefault().Value;
        }

        public IEnumerable<TDomain> GetAll()
        {
            var entities = new List<TDomain>();
            foreach (var entity in Entities)
            {
                entity.Value.Id = entity.Key;
                entities.Add(entity.Value);
            }
            return entities;
        }

        public void Delete(TId id)
        {
            Entities.Remove(id);
        }

        #endregion
    }
}
