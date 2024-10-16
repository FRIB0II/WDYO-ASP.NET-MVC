using System.Collections.Generic;
using System.Threading.Tasks;
using WhatDoYouOwn_ASPNET.Models;

namespace WhatDoYouOwn_ASPNET.Repository.Interfaces
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<DeviceModel>> GetAllDevicesAsync();
        Task<IEnumerable<DeviceModel>> GetDevicesByUserIdAsync(int idfUsuario);
        Task<DeviceModel> GetDeviceByIdAsync(int id);
        Task<DeviceModel> AddDeviceAsync(DeviceModel device);
        Task UpdateDeviceAsync(DeviceModel device);
        Task<bool> DeleteDeviceAsync(int id);
    }
}