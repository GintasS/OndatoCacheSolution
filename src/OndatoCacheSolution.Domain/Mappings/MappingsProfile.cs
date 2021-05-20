using AutoMapper;
using OndatoCacheSolution.Domain.Dtos;
using OndatoCacheSolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CreateCacheItemDto, ListCacheItem>()
                .ForMember(c => c.ExpiresAfter, opt => opt.MapFrom(s => TimeSpan.Parse(s.Offset)));
        }
    }
}
