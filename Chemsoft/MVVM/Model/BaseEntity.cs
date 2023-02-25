using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemsoft.MVVM.Model
{
    internal abstract class BaseEntity
    {
        public Guid ID { get; set; }
    }
}
