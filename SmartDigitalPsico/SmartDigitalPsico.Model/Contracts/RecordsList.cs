using SmartDigitalPsico.Model.Entity.Principals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Model.Contracts
{
    public class RecordsList<T>
    {
        public long UserIdLogged { get; set; }
        public User LoggedInUser { get; set; }
        public List<T> Records { get; set; }
    }

    public class Record<T>
    {
        public long UserIdLogged { get; set; }
        public User LoggedInUser { get; set; }
        public T RecordEntity { get; set; }
    }
}
