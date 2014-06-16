using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tattlr.data.Models
{
    public interface ITrackableEntity<T>
    {
        T Id { get; set; }
    }
}
