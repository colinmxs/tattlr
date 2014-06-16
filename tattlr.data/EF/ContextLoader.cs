using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace tattlr.data.EF
{
    public class ContextLoader : IDbContextFactory<Tattlr>
    {
        public static DbContext LoadContext()
        {
            var connectionStringName = "DefaultConnection";
            return new Tattlr(connectionStringName);
        }

        #region IDbContextFactory<Tattlr> Members

        public Tattlr Create()
        {
            return new Tattlr("DefaultConnection");
        }

        #endregion
    }
}
