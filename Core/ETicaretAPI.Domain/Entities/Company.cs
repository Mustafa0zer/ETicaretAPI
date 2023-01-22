using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Company : BaseEntitiy
    {
        public string Name { get; set; }
        public bool State { get; set; }
        public TimeSpan OrderStart { get; set; }
        public TimeSpan OrderEnd { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Company()
        {
            Orders = new List<Order>();
            this.OrderStart = new TimeSpan(8,30,0);
            this.OrderEnd = new TimeSpan(11,0,0);
        }
    }
}
