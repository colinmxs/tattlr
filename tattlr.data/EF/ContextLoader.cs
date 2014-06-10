using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
