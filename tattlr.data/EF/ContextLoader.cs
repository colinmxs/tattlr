using System.Data.Entity;

namespace tattlr.data.EF
{
    public class ContextLoader
    {
        public static DbContext LoadContext()
        {
            var connectionStringName = "DefaultConnection";
            return new Tattlr(connectionStringName);
        }
    }
}
