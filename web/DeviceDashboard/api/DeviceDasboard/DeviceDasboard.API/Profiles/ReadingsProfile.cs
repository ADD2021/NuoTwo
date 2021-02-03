using AutoMapper;
using DeviceDasboard.API.Helpers;
using DeviceDasboard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.Profiles
{
    /// <summary>
    /// Profile that contains methods to map entities (Reading) to DTOs and reverse.
    /// </summary>
    public class ReadingsProfile : Profile

    {
        public ReadingsProfile()
        {
            CreateMap<DeviceDashboard.API.Entities.Reading, ReadingDTO>();
            CreateMap<ReadingForCreationDTO, DeviceDashboard.API.Entities.Reading>();
            CreateMap<ReadingForUpdateDTO, DeviceDashboard.API.Entities.Reading>();
            CreateMap<DeviceDashboard.API.Entities.Reading, ReadingForUpdateDTO> ();
        }
    }
}
