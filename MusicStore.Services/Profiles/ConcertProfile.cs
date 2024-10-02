using AutoMapper;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Entities.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services.Profiles
{
    public class ConcertProfile : Profile
    {
        public ConcertProfile()
        {
            //configurar perfil de mapeo
            CreateMap<ConcertInfo, ConcertResponseDto>();//ORIGEN> DESTINO
            CreateMap<Concert, ConcertResponseDto>()

                .ForMember(d => d.DateEvent, o => o.MapFrom(x => x.DateEvent.ToShortDateString()))
                .ForMember(d => d.TimeEvent, o => o.MapFrom(x => x.DateEvent.ToShortTimeString()))
                .ForMember(d => d.Status, o => o.MapFrom(x => x.Status ? "Activo" : "Inactivo"));
            CreateMap<ConcertRequestDto, Concert>()
                .ForMember(d => d.DateEvent, o => o.MapFrom(x => Convert.ToDateTime($"{x.DateEvent} {x.TimeEvent}")));



            //test nilton
            //CreateMap<TestInfo, ConcertResponseDto>();//ORIGEN> DESTINO

        }
    }
}
