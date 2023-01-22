using ETicaretAPI.Domain.Entities;
using ETicarretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly ICompanyReadRepository companyReadRepository;
        readonly IOrderWriteRepository orderWriteRepository;

        public CreateOrderCommandHandler(ICompanyReadRepository companyReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            this.companyReadRepository = companyReadRepository;
            this.orderWriteRepository = orderWriteRepository;
        }

        async Task<CreateOrderCommandResponse> IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>.Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await companyReadRepository.GetAsync(x => x.ID == new Guid(request.CompanyID));
            var Now = TimeSpan.Parse(request.Now);
            if (company.OrderStart< Now && company.OrderEnd>Now )
            {
                if (company.State)
                {
                    await orderWriteRepository.AddAsync(new()
                    {
                        CompanyID = company.ID,
                        OrderDate = DateTime.Now,
                        ID = new Guid(),
                        OrderOwner = request.OrderOwner,
                    });
                    return new()
                    {
                        Message = "Sipariş başarıyla oluşturuldu"
                    };
                }
                else
                {
                    return new()
                    {
                        Message="Firma Onaylı Değildir."
                    };
                }
                
            }
            else
            {
                return new()
                {
                    Message = $"Firma Şuan Sipariş Almıyor.{company.OrderStart},{company.OrderEnd} Saatleri Arasında Tekrar Deneyin"
                };
            }

        }
    }
}
