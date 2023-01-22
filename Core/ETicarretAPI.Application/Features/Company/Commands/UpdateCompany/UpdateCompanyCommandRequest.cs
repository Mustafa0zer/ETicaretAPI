using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommandRequest:IRequest<UpdateCompanyCommandResponse>
    {
        public string Name { get; set; }
        public bool State { get; set; }
        public string OrderStart { get; set; }
        public string OrderEnd { get; set; }
    }
}
