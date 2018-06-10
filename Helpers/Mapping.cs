using System.Collections.Generic;
using AutoMapper;
using System.Linq;

namespace MyApi.Helpers
{
    public class Mapping
    {
        public void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.SalesOrderDetail, Models.SalesOrderDetailDTO>();
                cfg.CreateMap<ICollection<Entities.SalesOrderDetail>, IEnumerable<Models.SalesOrderDetailDTO>>();
                cfg.CreateMap<Entities.SalesOrderHeader, Models.SalesOrderHeaderDTO>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                        Helpers.EnumerationExtensions.OrderStatusExtension(src.Status))
                    );
            });            
        }
    }
}