using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Product.Queries.GetALLProducts
{
    public class GetALLProductQueryResponse
    {
        public List<ETicaretAPI.Domain.Entities.Product> Products { get; set; }


    }
}
