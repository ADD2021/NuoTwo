using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceDasboard.API.Helpers;
using DeviceDasboard.API.Models;


namespace DeviceDasboard.API.Profiles
{
    /// <summary>
    /// Profile that contains methods to map entities (Device) to DTOs and reverse.
    /// </summary>
    public class DevicesProfile : Profile
    {
        public DevicesProfile()
        {
            CreateMap<DeviceDashboard.API.Entities.Device, DeviceDTO>();
            CreateMap<DeviceForCreationDTO, DeviceDashboard.API.Entities.Device>();
            CreateMap<DeviceForUpdateDTO, DeviceDashboard.API.Entities.Device>();
            CreateMap<DeviceDashboard.API.Entities.Device, DeviceForUpdateDTO>();
        }
    }
}
