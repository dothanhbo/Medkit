using AutoMapper;
using Domain.Entities;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<OriginalMedicine, OriginalMedicineDto>().ReverseMap();
            CreateMap<Disease, DiseaseDto>()
                .ForMember(dest => dest.MedicineDisease, opt => opt.MapFrom(src => src.MedicineDisease))
                .ReverseMap();
            CreateMap<MedicineDisease, MedicineDiseaseDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Medicine, MedicineDto>().ReverseMap();
            CreateMap<UsingHistory, UsingHistoryDto>().ForMember(dest => dest.MedicineName, opt => opt.Ignore()).ReverseMap();
        }
    }
}
