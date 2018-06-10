using System.Collections.Generic;
using AutoMapper;

namespace MyApi.Helpers
{
    public class Mapping
    {
        public void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.SalesOrderDetail, Models.SalesOrderDetailDTO>();

                cfg.CreateMap<Entities.SalesOrderHeader, Models.SalesOrderHeaderDTO>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    Helpers.EnumerationExtensions.OrderStatusExtension(src.Status)))
                    .ForMember(dest => dest.SalesOrderDetail, opt => opt.MapFrom(src =>
                    Mapper.Map<IEnumerable<Models.SalesOrderDetailDTO>>(src.SalesOrderDetail)));
            });            
        }
    }
}