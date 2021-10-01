using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.DataAccess
{
    public  class DataAccessRequest<TEntity>
    {
        public TEntity Data { get; set; }
    }
}
