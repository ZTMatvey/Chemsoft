using Chemsoft.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemsoft.MVVM.Model
{
    internal abstract class BaseEntity : ObservableObject
    {
        public ulong ID { get; set; }

        public bool IsDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
