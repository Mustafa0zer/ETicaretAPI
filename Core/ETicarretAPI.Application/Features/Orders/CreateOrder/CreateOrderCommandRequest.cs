using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommandRequest:IRequest<CreateOrderCommandResponse>
    {
        public string CompanyID { get; set; }
        public string OrderOwner { get; set; }
        public DateTime OrderDate { get; set; }
        public string Now { get; set; }
       
    }
}
