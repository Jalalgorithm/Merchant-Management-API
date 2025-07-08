using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MerchantAPI.Application.Features.Merchant;
using MerchantAPI.Application.Features.Merchant.Create;
using MerchantAPI.Application.Features.Merchant.Get;
using MerchantAPI.Application.Features.Merchant.GetAll;
using MerchantAPI.Application.Features.Merchant.Update;
using MerchantAPI.Domain.Entities;

namespace MerchantAPI.Application.Commons.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateMerchant, Merchant>();
            CreateMap<Merchant, GetMerchantData>()
                .ForMember(m=>m.Status , o=>o.MapFrom(m => m.Status.ToString()))
                .ForMember(m => m.CreatedAt, o => o.MapFrom(m => m.CreatedAt.ToString("yyyy-MM-dd HH:mm")));
            CreateMap<Merchant, GetMerchant>()
                .ForMember(m => m.Status, o => o.MapFrom(m => m.Status.ToString()))
                .ForMember(m => m.CreatedAt, o => o.MapFrom(m => m.CreatedAt.ToString("yyyy-MM-dd HH:mm")));
            CreateMap<Merchant, GetAllMerchant>()
                .ForMember(m => m.Status, o => o.MapFrom(m => m.Status.ToString()))
                .ForMember(m => m.CreatedAt, o => o.MapFrom(m => m.CreatedAt.ToString("yyyy-MM-dd HH:mm")));
            CreateMap<UpdateMerchant, Merchant>()
                .ForMember(m => m.Id, o => o.Ignore());
                
        }
    }
}
