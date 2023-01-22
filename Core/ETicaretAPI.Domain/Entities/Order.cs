using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Order:BaseEntitiy
    { 
        public Company MyCompany { get; set; }
        public Guid CompanyID { get; set; }
        public string OrderOwner { get; set; }
        public DateTime OrderDate { get; set; }
            
        public ICollection<Product> Products { get; set; }
        public Order()
        {
            Products= new List<Product>();
        }  
    }
}
